namespace Delivery_Carol
{
    partial class FrmLogin
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
            btnEntrar = new Button();
            txtSenha = new TextBox();
            lblSenha = new Label();
            lblEmail = new Label();
            lblTitulo = new Label();
            txtEmail = new TextBox();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            btnEntrar.Location = new Point(101, 241);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(88, 33);
            btnEntrar.TabIndex = 11;
            btnEntrar.Text = "ENTRAR";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(33, 172);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(222, 23);
            txtSenha.TabIndex = 10;
            txtSenha.UseSystemPasswordChar = true;
            // 
            // lblSenha
            // 
            lblSenha.AutoSize = true;
            lblSenha.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSenha.Location = new Point(33, 154);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(50, 19);
            lblSenha.TabIndex = 9;
            lblSenha.Text = "Senha:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblEmail.Location = new Point(33, 71);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(52, 19);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "E-mail:";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(33, 17);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(233, 32);
            lblTitulo.TabIndex = 6;
            lblTitulo.Text = "SISTEMA DELIVERY";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(33, 93);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(222, 23);
            txtEmail.TabIndex = 8;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 328);
            Controls.Add(btnEntrar);
            Controls.Add(txtSenha);
            Controls.Add(lblSenha);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblTitulo);
            Name = "FrmLogin";
            Text = "FrmLogin";
            Load += FrmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEntrar;
        private TextBox txtSenha;
        private Label lblSenha;
        private Label lblEmail;
        private Label lblTitulo;
        private TextBox txtEmail;
    }
}