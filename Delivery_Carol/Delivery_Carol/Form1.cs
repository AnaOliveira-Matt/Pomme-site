namespace Delivery_Carol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTestarConexao_Click(object sender, EventArgs e)
        {
            try
            {
                Conexao conexao = new Conexao();

                using (var conn = conexao.Conectar())
                {
                    conn.Open();

                    MessageBox.Show(
                        "Conexão com o MySQL realizada com sucesso!"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao conectar: " + ex.Message
                );
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias telaCategorias = new FrmCategorias();
            telaCategorias.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes telaClientes = new FrmClientes();
            telaClientes.ShowDialog();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            FrmProdutos tela = new FrmProdutos();
            tela.ShowDialog();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos tela = new FrmPedidos();
            tela.ShowDialog();
        }
    }
}
