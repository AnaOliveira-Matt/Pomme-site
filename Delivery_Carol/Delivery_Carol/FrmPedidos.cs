using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Delivery_Carol
{
    public partial class FrmPedidos : Form
    {
        public FrmPedidos()
        {
            InitializeComponent();

            CarregarPedidos();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {

        }
        private void CarregarPedidos()
        {
            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"
                SELECT
                    id_pedido AS ID,
                    nome_cliente AS Cliente,
                    data_pedido AS Data,
                    valor_total AS Total,
                    status AS Status
                FROM pedidos
                ORDER BY id_pedido DESC";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        DataTable tabela = new DataTable();

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabela);
                        }

                        dgvPedidos.DataSource = tabela;
                        dgvPedidos.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar pedidos: " + ex.Message);
            }
        }

        private void CarregarItensPedido(int idPedido)
        {
            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"
                SELECT
                    nome_produto AS Produto,
                    quantidade AS Quantidade,
                    preco_unitario AS PrecoUnitario,
                    subtotal AS Subtotal
                FROM itens_pedido
                WHERE id_pedido = @idPedido
                ORDER BY id_item";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@idPedido", idPedido);

                        DataTable tabela = new DataTable();

                        using (var adapter =
                            new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabela);
                        }

                        dgvItensPedido.AutoGenerateColumns = true;
                        dgvItensPedido.DataSource = null;
                        dgvItensPedido.Columns.Clear();
                        dgvItensPedido.DataSource = tabela;

                        dgvItensPedido.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar produtos: " + ex.Message);
            }
        }
        private int idPedidoSelecionado = 0;

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow linha = dgvPedidos.Rows[e.RowIndex];

            DataRowView dados = linha.DataBoundItem as DataRowView;

            if (dados == null)
            {
                return;
            }

            // Guarda o ID do pedido selecionado
            idPedidoSelecionado =
                Convert.ToInt32(dados["ID"]);

            // Preenche os campos
            txtId.Text = dados["ID"].ToString();

            txtCliente.Text = dados["Cliente"].ToString();

            txtData.Text = Convert.ToDateTime(
                dados["Data"]
            ).ToString("dd/MM/yyyy HH:mm");

            txtTotal.Text = Convert.ToDecimal(
                dados["Total"]
            ).ToString("N2");

            cmbStatus.Text = dados["Status"].ToString();
            CarregarItensPedido(idPedidoSelecionado);
        }
        public class PedidoJSON
        {
            public int id_pedido { get; set; }
            public string cliente { get; set; }
            public string data_pedido { get; set; }
            public decimal valor_total { get; set; }
            public string status { get; set; }
            public List<ItemPedidoJSON> itens { get; set; }
        }

        public class ItemPedidoJSON
        {
            public string produto { get; set; }
            public int quantidade { get; set; }
            public decimal preco_unitario { get; set; }
            public decimal subtotal { get; set; }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog abrir = new OpenFileDialog())
            {
                abrir.Filter = "Arquivos JSON (*.json)|*.json";
                abrir.Title = "Selecionar arquivo de pedidos";

                if (abrir.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    string conteudo = File.ReadAllText(abrir.FileName);

                    List<PedidoJSON> pedidos =
                        JsonConvert.DeserializeObject<List<PedidoJSON>>(conteudo);

                    if (pedidos == null || pedidos.Count == 0)
                    {
                        MessageBox.Show("Nenhum pedido encontrado!");
                        return;
                    }

                    int importados = 0;

                    Conexao conexao = new Conexao();

                    using (var conn = conexao.Conectar())
                    {
                        conn.Open();

                        foreach (var pedido in pedidos)
                        {
                            using (var transacao = conn.BeginTransaction())
                            {
                                try
                                {
                                    if (pedido == null ||
                                        string.IsNullOrWhiteSpace(pedido.cliente))
                                    {
                                        throw new Exception(
                                            "Pedido sem nome do cliente.");
                                    }

                                    if (pedido.itens == null ||
                                        pedido.itens.Count == 0)
                                    {
                                        throw new Exception(
                                            "Pedido sem produtos.");
                                    }

                                    decimal totalCalculado = 0;

                                    foreach (var item in pedido.itens)
                                    {
                                        if (item == null ||
                                            string.IsNullOrWhiteSpace(item.produto) ||
                                            item.quantidade <= 0 ||
                                            item.preco_unitario < 0 ||
                                            item.subtotal !=
                                            item.quantidade * item.preco_unitario)
                                        {
                                            throw new Exception(
                                                "Produto ou valores inválidos.");
                                        }

                                        totalCalculado += item.subtotal;
                                    }

                                    if (totalCalculado != pedido.valor_total)
                                    {
                                        throw new Exception(
                                            "O total do pedido não confere.");
                                    }

                                    // SALVAR PEDIDO

                                    string sqlPedido = @"
                                INSERT INTO pedidos
                                (nome_cliente, data_pedido,
                                 valor_total, status)
                                VALUES
                                (@cliente, @data, @total, @status)";

                                    long idPedido;

                                    using (var cmd = new MySqlCommand(
                                        sqlPedido, conn, transacao))
                                    {
                                        cmd.Parameters.AddWithValue(
                                            "@cliente", pedido.cliente.Trim());

                                        cmd.Parameters.AddWithValue(
                                            "@data",
                                            DateTime.Parse(pedido.data_pedido));

                                        cmd.Parameters.AddWithValue(
                                            "@total", totalCalculado);

                                        cmd.Parameters.AddWithValue(
                                            "@status",
                                            string.IsNullOrWhiteSpace(pedido.status)
                                            ? "Pendente" : pedido.status);

                                        cmd.ExecuteNonQuery();

                                        idPedido = cmd.LastInsertedId;
                                    }

                                    // SALVAR ITENS SEM CONSULTAR PRODUTOS

                                    foreach (var item in pedido.itens)
                                    {
                                        string sqlItem = @"
                                    INSERT INTO itens_pedido
                                    (id_pedido, nome_produto,
                                     quantidade, preco_unitario,
                                     subtotal)
                                    VALUES
                                    (@pedido, @produto,
                                     @quantidade, @preco,
                                     @subtotal)";

                                        using (var cmd = new MySqlCommand(
                                            sqlItem, conn, transacao))
                                        {
                                            cmd.Parameters.AddWithValue(
                                                "@pedido", idPedido);

                                            cmd.Parameters.AddWithValue(
                                                "@produto", item.produto.Trim());

                                            cmd.Parameters.AddWithValue(
                                                "@quantidade", item.quantidade);

                                            cmd.Parameters.AddWithValue(
                                                "@preco", item.preco_unitario);

                                            cmd.Parameters.AddWithValue(
                                                "@subtotal", item.subtotal);

                                            cmd.ExecuteNonQuery();
                                        }
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
                        }
                    }

                    CarregarPedidos();

                    MessageBox.Show(
                        "Importação concluída!\n" +
                        "Pedidos importados: " + importados);
                }
                catch (Exception ex)
                {
                    CarregarPedidos();

                    MessageBox.Show(
                        "Erro na importação: " + ex.Message);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idPedidoSelecionado == 0)
            {
                MessageBox.Show("Selecione um pedido primeiro!");
                return;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um status!");
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"
                UPDATE pedidos
                SET status = @status
                WHERE id_pedido = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@status", cmbStatus.Text);

                        cmd.Parameters.AddWithValue(
                            "@id", idPedidoSelecionado);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Status atualizado com sucesso!");

                CarregarPedidos();

                txtId.Clear();
                txtCliente.Clear();
                txtData.Clear();
                txtTotal.Clear();

                cmbStatus.SelectedIndex = -1;
                dgvItensPedido.DataSource = null;

                idPedidoSelecionado = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao atualizar status: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idPedidoSelecionado == 0)
            {
                MessageBox.Show("Selecione um pedido primeiro!");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este pedido?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    using (var transacao = conn.BeginTransaction())
                    {
                        try
                        {
                            // Excluir os itens do pedido
                            string sqlItens = @"
                        DELETE FROM itens_pedido
                        WHERE id_pedido = @id";

                            using (var cmd = new MySqlCommand(
                                sqlItens, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id", idPedidoSelecionado);

                                cmd.ExecuteNonQuery();
                            }

                            // Excluir o pedido
                            string sqlPedido = @"
                        DELETE FROM pedidos
                        WHERE id_pedido = @id";

                            using (var cmd = new MySqlCommand(
                                sqlPedido, conn, transacao))
                            {
                                cmd.Parameters.AddWithValue(
                                    "@id", idPedidoSelecionado);

                                cmd.ExecuteNonQuery();
                            }

                            transacao.Commit();
                        }
                        catch
                        {
                            transacao.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Pedido excluído com sucesso!");

                CarregarPedidos();

                txtId.Clear();
                txtCliente.Clear();
                txtData.Clear();
                txtTotal.Clear();

                cmbStatus.SelectedIndex = -1;
                dgvItensPedido.DataSource = null;

                idPedidoSelecionado = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir pedido: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            // Limpar os campos
            txtId.Clear();
            txtCliente.Clear();
            txtData.Clear();
            txtTotal.Clear();
            txtPesquisar.Clear();

            // Limpar o status
            cmbStatus.SelectedIndex = -1;

            // Remover o pedido selecionado
            idPedidoSelecionado = 0;

            // Limpar a tabela de produtos
            dgvItensPedido.DataSource = null;

            // Atualizar os pedidos
            CarregarPedidos();

            // Remover a seleção da tabela
            dgvPedidos.ClearSelection();
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
                    id_pedido AS ID,
                    nome_cliente AS Cliente,
                    data_pedido AS Data,
                    valor_total AS Total,
                    status AS Status
                FROM pedidos
                WHERE
                    CAST(id_pedido AS CHAR) LIKE @pesquisa
                    OR nome_cliente LIKE @pesquisa
                    OR status LIKE @pesquisa
                ORDER BY id_pedido DESC";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@pesquisa",
                            "%" + txtPesquisar.Text.Trim() + "%");

                        DataTable tabela = new DataTable();

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabela);
                        }

                        dgvPedidos.DataSource = tabela;
                        dgvPedidos.ClearSelection();

                        // Limpar o pedido selecionado
                        idPedidoSelecionado = 0;

                        txtId.Clear();
                        txtCliente.Clear();
                        txtData.Clear();
                        txtTotal.Clear();

                        cmbStatus.SelectedIndex = -1;

                        dgvItensPedido.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao pesquisar pedidos: " + ex.Message);
            }
        }
    }
}
