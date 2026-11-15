using System.Security.Cryptography;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace Delivery_Carol
{
    // Servidor HTTPS embutido no WinForms (Kestrel).
    // Recebe os JSONs do site e grava no MySQL usando a mesma classe Conexao.
    public static class ApiServer
    {
        public const string Url = "https://localhost:3006";

        private static WebApplication? _app;

        public static void Iniciar()
        {
            try
            {
                var builder = WebApplication.CreateBuilder();

                builder.WebHost.UseUrls(Url);
                builder.Logging.ClearProviders();

                // Projeto escolar: libera qualquer origem (site aberto por file://, Live Server etc.)
                builder.Services.AddCors(opcoes =>
                    opcoes.AddDefaultPolicy(p =>
                        p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

                _app = builder.Build();
                _app.UseCors();

                _app.MapGet("/api/ping", () =>
                    Results.Ok(new { sucesso = true, mensagem = "API no ar" }));

                _app.MapPost("/api/login", Login);
                _app.MapPost("/api/clientes", CadastrarClientes);
                _app.MapPost("/api/pedidos", ReceberPedidos);

                _app.Start(); // não trava a tela: roda em segundo plano
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Não foi possível iniciar a API HTTPS: " + ex.Message +
                    "\n\nSe a mensagem falar de certificado, rode no terminal:\n" +
                    "dotnet dev-certs https --trust");
            }
        }

        public static void Parar()
        {
            try { _app?.StopAsync().GetAwaiter().GetResult(); } catch { }
        }

        // ---------- formato dos JSONs enviados pelo site ----------

        public class LoginDto
        {
            public string Email { get; set; } = "";
            public string Senha { get; set; } = "";
        }

        public class ClienteDto
        {
            public string Nome { get; set; } = "";
            public string Telefone { get; set; } = "";
            public string Email { get; set; } = "";
            public string Endereco { get; set; } = "";
            public string Senha { get; set; } = "";
        }

        public class ItemDto
        {
            [JsonPropertyName("produto")] public string Produto { get; set; } = "";
            [JsonPropertyName("quantidade")] public int Quantidade { get; set; }
            [JsonPropertyName("preco_unitario")] public decimal PrecoUnitario { get; set; }
            [JsonPropertyName("subtotal")] public decimal Subtotal { get; set; }
        }

        public class PedidoDto
        {
            [JsonPropertyName("id_pedido")] public int IdPedido { get; set; }
            [JsonPropertyName("cliente")] public string Cliente { get; set; } = "";
            [JsonPropertyName("data_pedido")] public string DataPedido { get; set; } = "";
            [JsonPropertyName("valor_total")] public decimal ValorTotal { get; set; }
            [JsonPropertyName("status")] public string Status { get; set; } = "";
            [JsonPropertyName("itens")] public List<ItemDto> Itens { get; set; } = new();
        }

        // ---------- Rotas ----------

        private static IResult Erro(int status, string mensagem) =>
            Results.Json(new { sucesso = false, mensagem }, statusCode: status);

        private static string Txt(MySqlDataReader rd, int i) =>
            rd.IsDBNull(i) ? "" : rd.GetString(i);

        // POST /api/login  { "Email": "...", "Senha": "..." }
        private static IResult Login(LoginDto dto)
        {
            if (dto == null ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.Senha))
            {
                return Erro(400, "Informe usuário e senha.");
            }

            try
            {
                using var conn = new Conexao().Conectar();
                conn.Open();

                // O campo do login.html se chama "nome", então aceita nome OU e-mail
                string sql = @"SELECT id_cliente, nome, telefone, email, endereco, senha
                               FROM clientes
                               WHERE email = @u OR nome = @u
                               LIMIT 1";

                using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", dto.Email.Trim());

                using var rd = cmd.ExecuteReader();

                if (!rd.Read() || rd.IsDBNull(5) ||
                    !VerificarSenha(dto.Senha.Trim(), rd.GetString(5)))
                {
                    return Erro(401, "Usuário ou senha incorretos.");
                }

                return Results.Ok(new
                {
                    sucesso = true,
                    mensagem = "Login realizado com sucesso!",
                    cliente = new
                    {
                        id = rd.GetInt32(0),
                        nome = Txt(rd, 1),
                        telefone = Txt(rd, 2),
                        email = Txt(rd, 3),
                        endereco = Txt(rd, 4)
                    }
                });
            }
            catch (Exception ex)
            {
                return Erro(500, "Erro no servidor: " + ex.Message);
            }
        }

        // POST /api/clientes  [ { Nome, Telefone, Email, Endereco, Senha } ]
        private static IResult CadastrarClientes(List<ClienteDto> clientes)
        {
            if (clientes == null || clientes.Count == 0)
                return Erro(400, "Nenhum cliente encontrado!");

            int importados = 0;
            int ignorados = 0;

            try
            {
                using var conn = new Conexao().Conectar();
                conn.Open();

                foreach (var c in clientes)
                {
                    if (c == null || string.IsNullOrWhiteSpace(c.Nome))
                    {
                        ignorados++;
                        continue;
                    }

                    // Mesma regra do botão Importar: não duplica e-mail
                    if (!string.IsNullOrWhiteSpace(c.Email))
                    {
                        using var verificar = new MySqlCommand(
                            "SELECT COUNT(*) FROM clientes WHERE email = @email", conn);
                        verificar.Parameters.AddWithValue("@email", c.Email.Trim());

                        if (Convert.ToInt32(verificar.ExecuteScalar()) > 0)
                        {
                            ignorados++;
                            continue;
                        }
                    }

                    string sql = @"INSERT INTO clientes
                                   (nome, telefone, email, endereco, senha)
                                   VALUES
                                   (@nome, @telefone, @email, @endereco, @senha)";

                    using var cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nome", c.Nome.Trim());
                    cmd.Parameters.AddWithValue("@telefone", c.Telefone ?? "");
                    cmd.Parameters.AddWithValue("@email", c.Email ?? "");
                    cmd.Parameters.AddWithValue("@endereco", c.Endereco ?? "");
                    cmd.Parameters.AddWithValue("@senha",
                        string.IsNullOrWhiteSpace(c.Senha)
                            ? DBNull.Value
                            : GerarHashSenha(c.Senha.Trim()));

                    cmd.ExecuteNonQuery();
                    importados++;
                }
            }
            catch (Exception ex)
            {
                return Erro(500, "Erro ao cadastrar: " + ex.Message);
            }

            if (importados == 0)
                return Erro(409, "Não foi possível cadastrar: e-mail já cadastrado ou nome vazio.");

            return Results.Ok(new
            {
                sucesso = true,
                importados,
                ignorados,
                mensagem = "Cadastro realizado com sucesso!"
            });
        }

        // POST /api/pedidos  [ { id_pedido, cliente, data_pedido, valor_total, status, itens:[...] } ]
        private static IResult ReceberPedidos(List<PedidoDto> pedidos)
        {
            if (pedidos == null || pedidos.Count == 0)
                return Erro(400, "Nenhum pedido encontrado!");

            int importados = 0;

            try
            {
                using var conn = new Conexao().Conectar();
                conn.Open();

                foreach (var pedido in pedidos)
                {
                    using var transacao = conn.BeginTransaction();

                    try
                    {
                        if (pedido == null || string.IsNullOrWhiteSpace(pedido.Cliente))
                            throw new ArgumentException("Pedido sem nome do cliente.");

                        if (pedido.Itens == null || pedido.Itens.Count == 0)
                            throw new ArgumentException("Pedido sem produtos.");

                        if (!DateTime.TryParse(pedido.DataPedido, out DateTime data))
                            data = DateTime.Now;

                        decimal totalCalculado = 0;

                        foreach (var item in pedido.Itens)
                        {
                            if (item == null ||
                                string.IsNullOrWhiteSpace(item.Produto) ||
                                item.Quantidade <= 0 ||
                                item.PrecoUnitario < 0 ||
                                item.Subtotal != item.Quantidade * item.PrecoUnitario)
                            {
                                throw new ArgumentException("Produto ou valores inválidos.");
                            }

                            totalCalculado += item.Subtotal;
                        }

                        if (totalCalculado != pedido.ValorTotal)
                            throw new ArgumentException("O total do pedido não confere.");

                        long idPedido;

                        string sqlPedido = @"INSERT INTO pedidos
                                             (nome_cliente, data_pedido, valor_total, status)
                                             VALUES
                                             (@cliente, @data, @total, @status)";

                        using (var cmd = new MySqlCommand(sqlPedido, conn, transacao))
                        {
                            cmd.Parameters.AddWithValue("@cliente", pedido.Cliente.Trim());
                            cmd.Parameters.AddWithValue("@data", data);
                            cmd.Parameters.AddWithValue("@total", totalCalculado);
                            cmd.Parameters.AddWithValue("@status",
                                string.IsNullOrWhiteSpace(pedido.Status) ? "Pendente" : pedido.Status);

                            cmd.ExecuteNonQuery();
                            idPedido = cmd.LastInsertedId;
                        }

                        foreach (var item in pedido.Itens)
                        {
                            string sqlItem = @"INSERT INTO itens_pedido
                                               (id_pedido, nome_produto, quantidade, preco_unitario, subtotal)
                                               VALUES
                                               (@pedido, @produto, @quantidade, @preco, @subtotal)";

                            using var cmd = new MySqlCommand(sqlItem, conn, transacao);
                            cmd.Parameters.AddWithValue("@pedido", idPedido);
                            cmd.Parameters.AddWithValue("@produto", item.Produto.Trim());
                            cmd.Parameters.AddWithValue("@quantidade", item.Quantidade);
                            cmd.Parameters.AddWithValue("@preco", item.PrecoUnitario);
                            cmd.Parameters.AddWithValue("@subtotal", item.Subtotal);
                            cmd.ExecuteNonQuery();
                        }

                        transacao.Commit();
                        importados++;
                    }
                    catch
                    {
                        transacao.Rollback();
                        throw;
                    }
                }

                return Results.Ok(new
                {
                    sucesso = true,
                    importados,
                    mensagem = "Pedido enviado com sucesso!"
                });
            }
            catch (ArgumentException ex)
            {
                return Erro(400, ex.Message);
            }
            catch (Exception ex)
            {
                return Erro(500, "Erro ao salvar pedido: " + ex.Message);
            }
        }

        // ---------- Senha (mesmo formato do GerarHashSenha do FrmClientes) ----------

        private static string GerarHashSenha(string senha)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                senha, salt, 100000, HashAlgorithmName.SHA256, 32);

            return "PBKDF2$100000$" +
                   Convert.ToBase64String(salt) + "$" +
                   Convert.ToBase64String(hash);
        }

        private static bool VerificarSenha(string senha, string armazenado)
        {
            try
            {
                var p = armazenado.Split('$');
                if (p.Length != 4 || p[0] != "PBKDF2") return false;

                int iteracoes = int.Parse(p[1]);
                byte[] salt = Convert.FromBase64String(p[2]);
                byte[] esperado = Convert.FromBase64String(p[3]);

                byte[] calculado = Rfc2898DeriveBytes.Pbkdf2(
                    senha, salt, iteracoes, HashAlgorithmName.SHA256, esperado.Length);

                return CryptographicOperations.FixedTimeEquals(calculado, esperado);
            }
            catch
            {
                return false;
            }
        }
    }
}
