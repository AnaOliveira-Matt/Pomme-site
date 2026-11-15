using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Delivery_Carol
{
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();

            CarregarProdutos();
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {

        }
        private int BuscarIdCategoria(string nomeCategoria)
        {
            Conexao conexao = new Conexao();

            using (var conn = conexao.Conectar())
            {
                conn.Open();

                string sql = @"SELECT id_categoria
                       FROM categorias
                       WHERE nome = @nome
                       LIMIT 1";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@nome", nomeCategoria.Trim());

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado);
                    }
                }
            }

            return 0;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome do produto!");
                txtNome.Focus();
                return;
            }

            decimal preco;

            if (!decimal.TryParse(txtPreco.Text, out preco) || preco < 0)
            {
                MessageBox.Show("Digite um preço válido!");
                txtPreco.Focus();
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"INSERT INTO produtos
                       (nome, descricao, preco, categoria)
                       VALUES
                       (@nome, @descricao, @preco, @categoria)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nome", txtNome.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@descricao", txtDescricao.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@preco", preco);

                        cmd.Parameters.AddWithValue(
                            "@categoria", txtCategoria.Text.Trim());

                        cmd.ExecuteNonQuery();

                        txtId.Text = cmd.LastInsertedId.ToString();
                    }
                }

                MessageBox.Show("Produto cadastrado com sucesso!");
                CarregarProdutos();

                txtNome.Clear();
                txtDescricao.Clear();
                txtPreco.Clear();
                txtCategoria.Clear();

                txtNome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao cadastrar produto: " + ex.Message
                );
            }
        }
        private void CarregarProdutos()
        {
            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"
                SELECT
                    id_produto AS ID,
                    nome AS Nome,
                    descricao AS Descricao,
                    preco AS Preco,
                    categoria AS Categoria
                FROM produtos
                ORDER BY id_produto";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        DataTable tabela = new DataTable();

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabela);
                        }

                        dgvProdutos.DataSource = tabela;

                        dgvProdutos.ClearSelection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao carregar produtos: " + ex.Message
                );
            }
        }
        private int idProdutoSelecionado = 0;

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridViewRow linha = dgvProdutos.Rows[e.RowIndex];

            if (linha.Cells["ID"].Value == null ||
                linha.Cells["ID"].Value == DBNull.Value)
            {
                return;
            }

            // Guarda o ID do produto selecionado
            idProdutoSelecionado =
                Convert.ToInt32(linha.Cells["ID"].Value);

            // Preenche os campos do formulário
            txtId.Text = idProdutoSelecionado.ToString();

            txtNome.Text =
                linha.Cells["Nome"].Value?.ToString() ?? "";

            txtDescricao.Text =
                linha.Cells["Descricao"].Value?.ToString() ?? "";

            txtPreco.Text =
                linha.Cells["Preco"].Value?.ToString() ?? "";

            txtCategoria.Text =
                linha.Cells["Categoria"].Value?.ToString() ?? "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (idProdutoSelecionado == 0)
            {
                MessageBox.Show("Selecione um produto para editar!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome do produto!");
                txtNome.Focus();
                return;
            }

            decimal preco;

            if (!decimal.TryParse(txtPreco.Text, out preco) || preco < 0)
            {
                MessageBox.Show("Digite um preço válido!");
                txtPreco.Focus();
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"UPDATE produtos
                       SET nome = @nome,
                           descricao = @descricao,
                           preco = @preco,
                           categoria = @categoria
                       WHERE id_produto = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nome", txtNome.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@descricao", txtDescricao.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@preco", preco);

                        cmd.Parameters.AddWithValue(
                            "@categoria", txtCategoria.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@id", idProdutoSelecionado);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Produto atualizado com sucesso!");

                // Limpa os campos
                txtId.Clear();
                txtNome.Clear();
                txtDescricao.Clear();
                txtPreco.Clear();
                txtCategoria.Clear();

                // Cancela a seleção
                idProdutoSelecionado = 0;

                // Atualiza a tabela
                CarregarProdutos();
                dgvProdutos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao editar produto: " + ex.Message
                );
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (idProdutoSelecionado == 0)
            {
                MessageBox.Show("Selecione um produto para excluir!");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir este produto?",
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

                    string sql = @"DELETE FROM produtos
                       WHERE id_produto = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id", idProdutoSelecionado);

                        int linhasExcluidas = cmd.ExecuteNonQuery();

                        if (linhasExcluidas == 0)
                        {
                            MessageBox.Show("Produto não encontrado!");
                            return;
                        }
                    }
                }

                MessageBox.Show("Produto excluído com sucesso!");

                txtId.Clear();
                txtNome.Clear();
                txtDescricao.Clear();
                txtPreco.Clear();
                txtCategoria.Clear();

                idProdutoSelecionado = 0;

                CarregarProdutos();
                dgvProdutos.ClearSelection();
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show(
                    "Não é possível excluir este produto porque existem pedidos vinculados a ele."
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao excluir produto: " + ex.Message
                );
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtCategoria.Clear();
            txtPesquisar.Clear();

            idProdutoSelecionado = 0;

            CarregarProdutos();
            dgvProdutos.ClearSelection();

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
                id_produto AS ID,
                nome AS Nome,
                descricao AS Descricao,
                preco AS Preco,
                categoria AS Categoria
            FROM produtos
            WHERE CAST(id_produto AS CHAR) LIKE @pesquisa
               OR nome LIKE @pesquisa
               OR descricao LIKE @pesquisa
               OR categoria LIKE @pesquisa
            ORDER BY id_produto";

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

                        dgvProdutos.DataSource = tabela;
                        dgvProdutos.ClearSelection();

                        idProdutoSelecionado = 0;

                        txtId.Clear();
                        txtNome.Clear();
                        txtDescricao.Clear();
                        txtPreco.Clear();
                        txtCategoria.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao pesquisar produtos: " + ex.Message
                );
            }
        }
    }
}
