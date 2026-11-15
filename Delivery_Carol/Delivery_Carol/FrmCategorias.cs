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
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
            CarregarCategorias();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome da categoria!");
                txtNome.Focus();
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = "INSERT INTO categorias (nome) VALUES (@nome)";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nome", txtNome.Text.Trim()
                        );

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Categoria cadastrada com sucesso!");

                txtNome.Clear();
                CarregarCategorias();
                txtNome.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }
        private void CarregarCategorias()
        {
            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = "SELECT id_categoria AS ID, nome AS Categoria FROM categorias ORDER BY id_categoria";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        DataTable tabela = new DataTable();

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabela);
                        }

                        dgvCategorias.DataSource = tabela;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
            }
        }
        private int idCategoriaSelecionada = 0;

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow linha = dgvCategorias.Rows[e.RowIndex];

            if (linha.Cells["ID"].Value == null ||
                linha.Cells["Categoria"].Value == null)
                return;

            idCategoriaSelecionada =
                Convert.ToInt32(linha.Cells["ID"].Value);

            txtNome.Text =
                linha.Cells["Categoria"].Value.ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idCategoriaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma categoria para editar!");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Digite o nome da categoria!");
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"UPDATE categorias
                       SET nome = @nome
                       WHERE id_categoria = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nome", txtNome.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@id", idCategoriaSelecionada);

                        int linhasAlteradas = cmd.ExecuteNonQuery();

                        if (linhasAlteradas == 0)
                        {
                            MessageBox.Show("Categoria não encontrada!");
                            CarregarCategorias();
                            return;
                        }
                    }
                }

                MessageBox.Show("Categoria atualizada com sucesso!");

                txtNome.Clear();
                idCategoriaSelecionada = 0;

                CarregarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (idCategoriaSelecionada == 0)
            {
                MessageBox.Show("Selecione uma categoria para excluir!");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja realmente excluir esta categoria?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta == DialogResult.No)
            {
                return;
            }

            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    string sql = @"DELETE FROM categorias
                       WHERE id_categoria = @id";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@id", idCategoriaSelecionada);

                        int linhasExcluidas = cmd.ExecuteNonQuery();

                        if (linhasExcluidas == 0)
                        {
                            MessageBox.Show("Categoria não encontrada!");
                            CarregarCategorias();
                            return;
                        }
                    }
                }

                MessageBox.Show("Categoria excluída com sucesso!");

                txtNome.Clear();
                idCategoriaSelecionada = 0;

                CarregarCategorias();
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show(
                    "Não é possível excluir esta categoria porque existem produtos vinculados a ela."
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            txtNome.Clear();
            txtPesquisar.Clear();

            idCategoriaSelecionada = 0;

            CarregarCategorias();

            dgvCategorias.ClearSelection();

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

                    string sql = @"SELECT
                           id_categoria AS ID,
                           nome AS Categoria
                       FROM categorias
                       WHERE nome LIKE @pesquisa
                       ORDER BY id_categoria";

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

                        dgvCategorias.DataSource = tabela;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao pesquisar: " + ex.Message
                );
            }
        }
    }
}
