namespace Logger_2
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogarTexto = new System.Windows.Forms.Button();
            this.btnTotRegistros = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(21, 68);
            this.txtBox.Multiline = true;
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(753, 250);
            this.txtBox.TabIndex = 0;
            this.txtBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Texto";
            // 
            // btnLogarTexto
            // 
            this.btnLogarTexto.Location = new System.Drawing.Point(21, 338);
            this.btnLogarTexto.Name = "btnLogarTexto";
            this.btnLogarTexto.Size = new System.Drawing.Size(213, 63);
            this.btnLogarTexto.TabIndex = 2;
            this.btnLogarTexto.Text = "Logar texto";
            this.btnLogarTexto.UseVisualStyleBackColor = true;
            this.btnLogarTexto.Click += new System.EventHandler(this.btnLogarTexto_Click_1);
            // 
            // btnTotRegistros
            // 
            this.btnTotRegistros.Location = new System.Drawing.Point(291, 338);
            this.btnTotRegistros.Name = "btnTotRegistros";
            this.btnTotRegistros.Size = new System.Drawing.Size(213, 63);
            this.btnTotRegistros.TabIndex = 3;
            this.btnTotRegistros.Text = "Total registros";
            this.btnTotRegistros.UseVisualStyleBackColor = true;
            this.btnTotRegistros.Click += new System.EventHandler(this.btnTotRegistros_Click_1);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(561, 338);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(213, 63);
            this.btnSair.TabIndex = 4;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 425);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnTotRegistros);
            this.Controls.Add(this.btnLogarTexto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBox);
            this.Name = "Form1";
            this.Text = "Logger v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogarTexto;
        private System.Windows.Forms.Button btnTotRegistros;
        private System.Windows.Forms.Button btnSair;
    }
}

