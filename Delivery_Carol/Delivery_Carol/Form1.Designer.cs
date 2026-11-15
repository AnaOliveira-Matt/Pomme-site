namespace Delivery_Carol
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCategorias = new Button();
            btnProdutos = new Button();
            btnClientes = new Button();
            btnPedidos = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCategorias
            // 
            btnCategorias.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCategorias.Location = new Point(39, 116);
            btnCategorias.Name = "btnCategorias";
            btnCategorias.Size = new Size(181, 97);
            btnCategorias.TabIndex = 0;
            btnCategorias.Text = "Categorias";
            btnCategorias.UseVisualStyleBackColor = true;
            btnCategorias.Click += btnCategorias_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnProdutos.Location = new Point(344, 116);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(181, 97);
            btnProdutos.TabIndex = 1;
            btnProdutos.Text = "Produtos";
            btnProdutos.UseVisualStyleBackColor = true;
            btnProdutos.Click += btnProdutos_Click;
            // 
            // btnClientes
            // 
            btnClientes.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnClientes.Location = new Point(39, 244);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(181, 97);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnPedidos
            // 
            btnPedidos.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnPedidos.Location = new Point(344, 244);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(181, 97);
            btnPedidos.TabIndex = 3;
            btnPedidos.Text = "Pedidos";
            btnPedidos.UseVisualStyleBackColor = true;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(178, 34);
            label1.Name = "label1";
            label1.Size = new Size(220, 40);
            label1.TabIndex = 4;
            label1.Text = "Menu Principal";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 450);
            Controls.Add(label1);
            Controls.Add(btnPedidos);
            Controls.Add(btnClientes);
            Controls.Add(btnProdutos);
            Controls.Add(btnCategorias);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCategorias;
        private Button btnProdutos;
        private Button btnClientes;
        private Button btnPedidos;
        private Label label1;
    }
}
