namespace Delivery_Carol
{
    partial class FrmCategorias
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
            btnPesquisar = new Button();
            txtPesquisar = new TextBox();
            lblPesquisar = new Label();
            dgvCategorias = new DataGridView();
            btnLimpar = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnGravar = new Button();
            txtNome = new TextBox();
            lblNome = new Label();
            txtId = new TextBox();
            lblId = new Label();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(155, 463);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(95, 23);
            btnPesquisar.TabIndex = 25;
            btnPesquisar.Text = "PESQUISAR";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(187, 418);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(236, 23);
            txtPesquisar.TabIndex = 24;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic);
            lblPesquisar.Location = new Point(25, 420);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(156, 21);
            lblPesquisar.TabIndex = 23;
            lblPesquisar.Text = "Pesquisar categoria:";
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(25, 234);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(398, 150);
            dgvCategorias.TabIndex = 22;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(348, 183);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 23);
            btnLimpar.TabIndex = 21;
            btnLimpar.Text = "LIMPAR";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(236, 183);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 20;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(125, 183);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 19;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(25, 183);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 23);
            btnGravar.TabIndex = 18;
            btnGravar.Text = "GRAVAR";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(182, 123);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(241, 23);
            txtNome.TabIndex = 17;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblNome.Location = new Point(25, 125);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(151, 21);
            lblNome.TabIndex = 16;
            lblNome.Text = "Nome da categoria:";
            // 
            // txtId
            // 
            txtId.Location = new Point(61, 78);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(113, 23);
            txtId.TabIndex = 15;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblId.Location = new Point(25, 76);
            lblId.Name = "lblId";
            lblId.Size = new Size(30, 21);
            lblId.TabIndex = 14;
            lblId.Text = "ID:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(100, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(292, 30);
            lblTitulo.TabIndex = 13;
            lblTitulo.Text = "CADASTRO DE CATEGORIAS";
            // 
            // FrmCategorias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 500);
            Controls.Add(btnPesquisar);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(dgvCategorias);
            Controls.Add(btnLimpar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnGravar);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(lblTitulo);
            Name = "FrmCategorias";
            Text = "FrmCategorias";
            Load += FrmCategorias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPesquisar;
        private TextBox txtPesquisar;
        private Label lblPesquisar;
        private DataGridView dgvCategorias;
        private Button btnLimpar;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnGravar;
        private TextBox txtNome;
        private Label lblNome;
        private TextBox txtId;
        private Label lblId;
        private Label lblTitulo;
    }
}