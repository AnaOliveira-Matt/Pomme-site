namespace Delivery_Carol
{
    partial class FrmPedidos
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
            label2 = new Label();
            label1 = new Label();
            dgvItensPedido = new DataGridView();
            dgvPedidos = new DataGridView();
            cmbStatus = new ComboBox();
            btnPesquisar = new Button();
            txtPesquisar = new TextBox();
            lblPesquisar = new Label();
            btnLimpar = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            btnImportar = new Button();
            txtData = new TextBox();
            lblData = new Label();
            txtTotal = new TextBox();
            lblTotal = new Label();
            txtCliente = new TextBox();
            lblCliente = new Label();
            lblStatus = new Label();
            txtId = new TextBox();
            lblId = new Label();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvItensPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 540);
            label2.Name = "label2";
            label2.Size = new Size(145, 20);
            label2.TabIndex = 82;
            label2.Text = "Produtos do Pedido:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 346);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 81;
            label1.Text = "Lista de Pedidos:";
            // 
            // dgvItensPedido
            // 
            dgvItensPedido.AllowUserToAddRows = false;
            dgvItensPedido.AllowUserToDeleteRows = false;
            dgvItensPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItensPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItensPedido.Location = new Point(27, 563);
            dgvItensPedido.MultiSelect = false;
            dgvItensPedido.Name = "dgvItensPedido";
            dgvItensPedido.ReadOnly = true;
            dgvItensPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItensPedido.Size = new Size(591, 150);
            dgvItensPedido.TabIndex = 80;
            // 
            // dgvPedidos
            // 
            dgvPedidos.AllowUserToAddRows = false;
            dgvPedidos.AllowUserToDeleteRows = false;
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(27, 369);
            dgvPedidos.MultiSelect = false;
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.ReadOnly = true;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.Size = new Size(590, 150);
            dgvPedidos.TabIndex = 79;
            dgvPedidos.CellClick += dgvPedidos_CellClick;
            // 
            // cmbStatus
            // 
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Recebido", "", "Em preparação", "", "Saiu para entrega", "", "Entregue", "", "Cancelado" });
            cmbStatus.Location = new Point(105, 135);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(514, 23);
            cmbStatus.TabIndex = 78;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(544, 298);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 27);
            btnPesquisar.TabIndex = 77;
            btnPesquisar.Text = "PESQUISAR";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // txtPesquisar
            // 
            txtPesquisar.Location = new Point(171, 298);
            txtPesquisar.Name = "txtPesquisar";
            txtPesquisar.Size = new Size(352, 23);
            txtPesquisar.TabIndex = 76;
            // 
            // lblPesquisar
            // 
            lblPesquisar.AutoSize = true;
            lblPesquisar.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPesquisar.Location = new Point(28, 301);
            lblPesquisar.Name = "lblPesquisar";
            lblPesquisar.Size = new Size(130, 20);
            lblPesquisar.TabIndex = 75;
            lblPesquisar.Text = "Pesquisar Pedido:";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(543, 243);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(75, 25);
            btnLimpar.TabIndex = 74;
            btnLimpar.Text = "LIMPAR";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(386, 243);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 25);
            btnExcluir.TabIndex = 73;
            btnExcluir.Text = "EXCLUIR";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(229, 243);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 25);
            btnEditar.TabIndex = 72;
            btnEditar.Text = "EDITAR";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(28, 243);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(119, 25);
            btnImportar.TabIndex = 71;
            btnImportar.Text = "IMPORTAR JSON";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // txtData
            // 
            txtData.Location = new Point(153, 194);
            txtData.Name = "txtData";
            txtData.Size = new Size(122, 23);
            txtData.TabIndex = 70;
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblData.Location = new Point(28, 197);
            lblData.Name = "lblData";
            lblData.Size = new Size(119, 20);
            lblData.TabIndex = 69;
            lblData.Text = "Data do Pedido:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(430, 194);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(189, 23);
            txtTotal.TabIndex = 68;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(308, 197);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(116, 20);
            lblTotal.TabIndex = 67;
            lblTotal.Text = "Valor total (R$):";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(362, 68);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(257, 23);
            txtCliente.TabIndex = 66;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(295, 67);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(61, 20);
            lblCliente.TabIndex = 65;
            lblCliente.Text = "Cliente:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(28, 134);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(55, 20);
            lblStatus.TabIndex = 64;
            lblStatus.Text = "Status:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(62, 66);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(187, 23);
            txtId.TabIndex = 63;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblId.Location = new Point(28, 66);
            lblId.Name = "lblId";
            lblId.Size = new Size(28, 20);
            lblId.TabIndex = 62;
            lblId.Text = "ID:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(184, 13);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(247, 25);
            lblTitulo.TabIndex = 61;
            lblTitulo.Text = "CADASTRO DE PRODUTOS";
            // 
            // FrmPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 728);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvItensPedido);
            Controls.Add(dgvPedidos);
            Controls.Add(cmbStatus);
            Controls.Add(btnPesquisar);
            Controls.Add(txtPesquisar);
            Controls.Add(lblPesquisar);
            Controls.Add(btnLimpar);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(btnImportar);
            Controls.Add(txtData);
            Controls.Add(lblData);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(txtCliente);
            Controls.Add(lblCliente);
            Controls.Add(lblStatus);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(lblTitulo);
            Name = "FrmPedidos";
            Text = "FrmPedidos";
            Load += FrmPedidos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvItensPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private DataGridView dgvItensPedido;
        private DataGridView dgvPedidos;
        private ComboBox cmbStatus;
        private Button btnPesquisar;
        private TextBox txtPesquisar;
        private Label lblPesquisar;
        private Button btnLimpar;
        private Button btnExcluir;
        private Button btnEditar;
        private Button btnImportar;
        private TextBox txtData;
        private Label lblData;
        private TextBox txtTotal;
        private Label lblTotal;
        private TextBox txtCliente;
        private Label lblCliente;
        private Label lblStatus;
        private TextBox txtId;
        private Label lblId;
        private Label lblTitulo;
    }
}