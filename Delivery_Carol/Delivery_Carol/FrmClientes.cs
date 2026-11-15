using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Delivery_Carol
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
            CarregarClientes();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {

        }
        private string GerarHashSenha(string senha)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                senha,
                salt,
                100000,
                HashAlgorithmName.SHA256,
                32
            );

            return "PBKDF2$100000$" +
                   Convert.ToBase64String(salt) + "$" +
                   Convert.ToBase64String(hash);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            // Verifica se o nome foi preenchido
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome do cliente!");
                txtNome.Focus();
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    // Insere o cliente no MySQL
                    // O ID é gerado automaticamente
                    string sql = @"
                        INSERT INTO clientes
                        (nome, telefone, email, endereco)
                        VALUES
                        (@nome, @telefone, @email, @endereco)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nome", txtNome.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@telefone", txtTelefone.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@email", txtEmail.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@endereco", txtEndereco.Text.Trim());

                        // Executa o cadastro
                        cmd.ExecuteNonQuery();

                        // Mostra o ID gerado pelo MySQL
                        txtId.Text = cmd.LastInsertedId.ToString();
                    }
                }

                MessageBox.Show(
                    "Cliente cadastrado com sucesso!"
                );

                // Limpa os campos após cadastrar
                // Mantém o ID para visualização
                txtNome.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtEndereco.Clear();
                CarregarClientes();

                txtNome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar cliente: " + ex.Message
                );
            }
        }

        private void CarregarClientes()
        {
            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"
                SELECT
                    id_cliente AS ID,
                    nome AS Nome,
                    telefone AS Telefone,
                    email AS Email,
                    endereco AS Endereco
                FROM clientes
                ORDER BY id_cliente";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        DataTable tabela = new DataTable();

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabela);
                        }

                        dgvClientes.DataSource = tabela;
                        dgvClientes.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar clientes: " + ex.Message
                );
            }
        }
        private int idClienteSelecionado = 0;

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow linha = dgvClientes.Rows[e.RowIndex];

            if (linha.Cells["ID"].Value == null)
            {
                return;
            }

            // Guarda o ID do cliente selecionado
            idClienteSelecionado =
                Convert.ToInt32(linha.Cells["ID"].Value);

            // Preenche os campos do formulário
            txtId.Text = idClienteSelecionado.ToString();

            txtNome.Text =
                linha.Cells["Nome"].Value?.ToString() ?? "";

            txtTelefone.Text =
                linha.Cells["Telefone"].Value?.ToString() ?? "";

            txtEmail.Text =
                linha.Cells["Email"].Value?.ToString() ?? "";

            txtEndereco.Text =
                linha.Cells["Endereco"].Value?.ToString() ?? "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado == 0)
            {
                MessageBox.Show("Selecione um cliente para editar!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome do cliente!");
                txtNome.Focus();
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"UPDATE clientes
                       SET nome = @nome,
                           telefone = @telefone,
                           email = @email,
                           endereco = @endereco
                       WHERE id_cliente = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nome", txtNome.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@telefone", txtTelefone.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@email", txtEmail.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@endereco", txtEndereco.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@id", idClienteSelecionado);

                        int linhasAlteradas = cmd.ExecuteNonQuery();

                        if (linhasAlteradas == 0)
                        {
                            MessageBox.Show(
                                "Nenhum registro foi alterado. Verifique se o cliente existe ou se os dados já são iguais."
                            );
                        }
                        else
                        {
                            MessageBox.Show(
                                "Cliente atualizado com sucesso!"
                            );
                        }
                    }
                }

                // Limpa os campos
                txtId.Clear();
                txtNome.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtEndereco.Clear();

                // Cancela a seleção anterior
                idClienteSelecionado = 0;

                // Atualiza a tabela
                CarregarClientes();

                dgvClientes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao editar cliente: " + ex.Message
                );
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado == 0)
            {
                MessageBox.Show("Selecione um cliente para excluir!");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este cliente?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"DELETE FROM clientes
                       WHERE id_cliente = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id", idClienteSelecionado);

                        int linhasExcluidas = cmd.ExecuteNonQuery();

                        if (linhasExcluidas == 0)
                        {
                            MessageBox.Show("Cliente não encontrado!");
                            CarregarClientes();
                            return;
                        }
                    }
                }

                MessageBox.Show("Cliente excluído com sucesso!");

                txtId.Clear();
                txtNome.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtEndereco.Clear();

                idClienteSelecionado = 0;

                CarregarClientes();
                dgvClientes.ClearSelection();
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show(
                    "Não é possível excluir este cliente porque existem pedidos vinculados a ele."
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir cliente: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtPesquisar.Clear();

            idClienteSelecionado = 0;

            CarregarClientes();
            dgvClientes.ClearSelection();

            txtNome.Focus();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"
            SELECT
                id_cliente AS ID,
                nome AS Nome,
                telefone AS Telefone,
                email AS Email,
                endereco AS Endereco
            FROM clientes
            WHERE nome LIKE @pesquisa
               OR telefone LIKE @pesquisa
               OR email LIKE @pesquisa
               OR CAST(id_cliente AS CHAR) LIKE @pesquisa
            ORDER BY id_cliente";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@pesquisa",
                            "%" + txtPesquisar.Text.Trim() + "%"
                        );

                        DataTable tabela = new DataTable();

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabela);
                        }

                        dgvClientes.DataSource = tabela;
                        dgvClientes.ClearSelection();

                        idClienteSelecionado = 0;

                        txtId.Clear();
                        txtNome.Clear();
                        txtTelefone.Clear();
                        txtEmail.Clear();
                        txtEndereco.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao pesquisar clientes: " + ex.Message
                );
            }
        }
        public class ClienteJSON
        {
            public string Nome { get; set; } = "";
            public string Telefone { get; set; } = "";
            public string Email { get; set; } = "";
            public string Endereco { get; set; } = "";
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrir = new OpenFileDialog())
            {
                abrir.Filter = "Arquivos JSON (*.json)|*.json";
                abrir.Title = "Selecionar arquivo de clientes";

                if (abrir.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    string conteudo = File.ReadAllText(abrir.FileName);

                    List<ClienteJSON> clientes =
                        JsonConvert.DeserializeObject<List<ClienteJSON>>(
                            conteudo
                        );

                    if (clientes == null || clientes.Count == 0)
                    {
                        MessageBox.Show("Nenhum cliente encontrado!");
                        return;
                    }

                    int importados = 0;
                    int ignorados = 0;

                    Conexao conexao = new Conexao();

                    using (var conn = conexao.Conectar())
                    {
                        conn.Open();

                        foreach (var cliente in clientes)
                        {
                            if (cliente == null ||
                                string.IsNullOrWhiteSpace(cliente.Nome))
                            {
                                ignorados++;
                                continue;
                            }

                            // Verifica duplicidade pelo e-mail
                            if (!string.IsNullOrWhiteSpace(cliente.Email))
                            {
                                string verificar = @"
                        SELECT COUNT(*)
                        FROM clientes
                        WHERE email = @email";

                                using (var cmd = new MySqlCommand(
                                    verificar, conn))
                                {
                                    cmd.Parameters.AddWithValue(
                                        "@email", cliente.Email.Trim());

                                    if (Convert.ToInt32(
                                        cmd.ExecuteScalar()) > 0)
                                    {
                                        ignorados++;
                                        continue;
                                    }
                                }
                            }

                            string sql = @"
                    INSERT INTO clientes
                    (nome, telefone, email, endereco)
                    VALUES
                    (@nome, @telefone, @email, @endereco)";

                            using (var cmd = new MySqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@nome", cliente.Nome.Trim());

                                cmd.Parameters.AddWithValue(
                                    "@telefone", cliente.Telefone ?? "");

                                cmd.Parameters.AddWithValue(
                                    "@email", cliente.Email ?? "");

                                cmd.Parameters.AddWithValue(
                                    "@endereco", cliente.Endereco ?? "");

                                cmd.ExecuteNonQuery();
                                importados++;
                            }
                        }
                    }

                    CarregarClientes();

                    MessageBox.Show(
                        "Importação concluída!\n\n" +
                        "Clientes importados: " + importados +
                        "\nClientes ignorados: " + ignorados
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao importar JSON: " + ex.Message
                    );
                }
            }
        }
    }

}
