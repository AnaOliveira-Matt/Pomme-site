namespace Delivery_Carol
{
    partial class FrmClientes
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
            btnImportar = new Button();
            dgvClientes = new DataGridView();
            btnPesquisar = new Button();
            txtPesquisar = new TextBox();
            lblPesquisar = new Label();
            btnLimpar = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnGravar = new Button();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtEndereco = new TextBox();
            lblEndereco = new Label();
            txtNome = new TextBox();
            lblNome = new Label();
            txtTelefone = new TextBox();
            lblTelefone = new Label();
            txtId = new TextBox();
            lblId = new Label();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(446, 259);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(134, 23);
            btnImportar.TabIndex = 39;
            btnImportar.Text = "IMPORTAR CLIENTES";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(38, 386);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(545, 150);
            dgvClientes.TabIndex = 38;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(506, 330);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 37;
            btnPesquisar.Text = "PESQUISAR";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(172, 330);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(312, 23);
            txtPesquisar.TabIndex = 36;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPesquisar.Location = new Point(38, 329);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(128, 20);
            lblPesquisar.TabIndex = 35;
            lblPesquisar.Text = "Pesquisar cliente:";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(344, 259);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 34;
            btnLimpar.Text = "LIMPAR";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(242, 259);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 33;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(140, 259);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 32;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(38, 259);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 31;
            btnGravar.Text = "GRAVAR";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(101, 185);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(158, 23);
            txtEmail.TabIndex = 30;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(38, 188);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(57, 20);
            lblEmail.TabIndex = 29;
            lblEmail.Text = "E-mail:";
            // 
            // txtEndereco
            // 
            txtEndereco.Location = new Point(364, 185);
            txtEndereco.Name = "txtEndereco";
            txtEndereco.Size = new Size(219, 23);
            txtEndereco.TabIndex = 28;
            // 
            // lblEndereco
            // 
            lblEndereco.AutoSize = true;
            lblEndereco.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEndereco.Location = new Point(282, 188);
            lblEndereco.Name = "lblEndereco";
            lblEndereco.Size = new Size(76, 20);
            lblEndereco.TabIndex = 27;
            lblEndereco.Text = "Endereço:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(164, 117);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(419, 23);
            txtNome.TabIndex = 26;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNome.Location = new Point(38, 117);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(120, 20);
            lblNome.TabIndex = 25;
            lblNome.Text = "Nome completo:";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(364, 58);
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(219, 23);
            txtTelefone.TabIndex = 24;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTelefone.Location = new Point(287, 60);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(71, 20);
            lblTelefone.TabIndex = 23;
            lblTelefone.Text = "Telefone:";
            // 
            // txtId
            // 
            txtId.Location = new Point(72, 57);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(187, 23);
            txtId.TabIndex = 22;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblId.Location = new Point(38, 57);
            lblId.Name = "lblId";
            lblId.Size = new Size(28, 20);
            lblId.TabIndex = 21;
            lblId.Text = "ID:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(188, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(231, 25);
            lblTitulo.TabIndex = 20;
            lblTitulo.Text = "CADASTRO DE CLIENTES";
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 563);
            Controls.Add(btnImportar);
            Controls.Add(dgvClientes);
            Controls.Add(btnPesquisar);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(btnLimpar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnGravar);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtEndereco);
            Controls.Add(lblEndereco);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(txtTelefone);
            Controls.Add(lblTelefone);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(lblTitulo);
            Name = "FrmClientes";
            Text = "FrmClientes";
            Load += FrmClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImportar;
        private DataGridView dgvClientes;
        private Button btnPesquisar;
        private TextBox txtPesquisar;
        private Label lblPesquisar;
        private Button btnLimpar;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnGravar;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtEndereco;
        private Label lblEndereco;
        private TextBox txtNome;
        private Label lblNome;
        private TextBox txtTelefone;
        private Label lblTelefone;
        private TextBox txtId;
        private Label lblId;
        private Label lblTitulo;
    }
}