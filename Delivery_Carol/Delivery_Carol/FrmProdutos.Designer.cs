namespace Delivery_Carol
{
    partial class FrmProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProdutos = new DataGridView();
            btnPesquisar = new Button();
            txtPesquisar = new TextBox();
            lblPesquisar = new Label();
            btnLimpar = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnGravar = new Button();
            txtPreco = new TextBox();
            lblPreco = new Label();
            txtCategoria = new TextBox();
            lblCategoria = new Label();
            txtNome = new TextBox();
            lblNome = new Label();
            txtDescricao = new TextBox();
            lblDescricao = new Label();
            txtId = new TextBox();
            lblId = new Label();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            SuspendLayout();
            // 
            // dgvProdutos
            // 
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Location = new Point(27, 403);
            dgvProdutos.MultiSelect = false;
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.ReadOnly = true;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.Size = new Size(591, 150);
            dgvProdutos.TabIndex = 56;
            dgvProdutos.CellClick += dgvProdutos_CellClick;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(543, 342);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 27);
            btnPesquisar.TabIndex = 55;
            btnPesquisar.Text = "PESQUISAR";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(170, 342);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(352, 23);
            txtPesquisar.TabIndex = 54;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPesquisar.Location = new Point(27, 345);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(137, 20);
            lblPesquisar.TabIndex = 53;
            lblPesquisar.Text = "Pesquisar Produto:";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(543, 275);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 25);
            btnLimpar.TabIndex = 52;
            btnLimpar.Text = "LIMPAR";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(371, 275);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 25);
            btnExcluir.TabIndex = 51;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(199, 275);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 25);
            btnEditar.TabIndex = 50;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(27, 275);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 25);
            btnGravar.TabIndex = 49;
            btnGravar.Text = "GRAVAR";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(90, 201);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(158, 23);
            txtPreco.TabIndex = 48;
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPreco.Location = new Point(27, 204);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(51, 20);
            lblPreco.TabIndex = 47;
            lblPreco.Text = "Preço:";
            // 
            // txtCategoria
            // 
            txtCategoria.Location = new Point(358, 201);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.Size = new Size(260, 23);
            txtCategoria.TabIndex = 46;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCategoria.Location = new Point(271, 204);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(81, 20);
            lblCategoria.TabIndex = 45;
            lblCategoria.Text = "Categoria:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(433, 74);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(185, 23);
            txtNome.TabIndex = 44;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNome.Location = new Point(294, 74);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(133, 20);
            lblNome.TabIndex = 43;
            lblNome.Text = "Nome do Produto:";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(112, 138);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(506, 23);
            txtDescricao.TabIndex = 42;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblDescricao.Location = new Point(27, 141);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(79, 20);
            lblDescricao.TabIndex = 41;
            lblDescricao.Text = "Descrição:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(61, 73);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(187, 23);
            txtId.TabIndex = 40;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblId.Location = new Point(27, 73);
            lblId.Name = "lblId";
            lblId.Size = new Size(28, 20);
            lblId.TabIndex = 39;
            lblId.Text = "ID:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(183, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(247, 25);
            lblTitulo.TabIndex = 38;
            lblTitulo.Text = "CADASTRO DE PRODUTOS";
            // 
            // FrmProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 572);
            Controls.Add(dgvProdutos);
            Controls.Add(btnPesquisar);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(btnLimpar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnGravar);
            Controls.Add(txtPreco);
            Controls.Add(lblPreco);
            Controls.Add(txtCategoria);
            Controls.Add(lblCategoria);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(txtDescricao);
            Controls.Add(lblDescricao);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(lblTitulo);
            Name = "FrmProdutos";
            Text = "FrmProdutos";
            Load += FrmProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProdutos;
        private Button btnPesquisar;
        private TextBox txtPesquisar;
        private Label lblPesquisar;
        private Button btnLimpar;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnGravar;
        private TextBox txtPreco;
        private Label lblPreco;
        private TextBox txtCategoria;
        private Label lblCategoria;
        private TextBox txtNome;
        private Label lblNome;
        private TextBox txtDescricao;
        private Label lblDescricao;
        private TextBox txtId;
        private Label lblId;
        private Label lblTitulo;
    }
}