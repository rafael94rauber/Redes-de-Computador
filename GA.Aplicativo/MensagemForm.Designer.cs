namespace GA.Aplicativo
{
    partial class MensagemForm
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
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.TxtEnviadas = new System.Windows.Forms.TextBox();
            this.LblUsuarioEnvio = new System.Windows.Forms.Label();
            this.TxtRecebidas = new System.Windows.Forms.TextBox();
            this.LblUsuarioReceber = new System.Windows.Forms.Label();
            this.TxtEnviar = new System.Windows.Forms.TextBox();
            this.Lbl3 = new System.Windows.Forms.Label();
            this.BtnReceber = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Location = new System.Drawing.Point(15, 577);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(277, 52);
            this.BtnEnviar.TabIndex = 0;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // TxtEnviadas
            // 
            this.TxtEnviadas.Enabled = false;
            this.TxtEnviadas.Location = new System.Drawing.Point(15, 39);
            this.TxtEnviadas.Multiline = true;
            this.TxtEnviadas.Name = "TxtEnviadas";
            this.TxtEnviadas.Size = new System.Drawing.Size(277, 391);
            this.TxtEnviadas.TabIndex = 1;
            // 
            // LblUsuarioEnvio
            // 
            this.LblUsuarioEnvio.AutoSize = true;
            this.LblUsuarioEnvio.Location = new System.Drawing.Point(12, 23);
            this.LblUsuarioEnvio.Name = "LblUsuarioEnvio";
            this.LblUsuarioEnvio.Size = new System.Drawing.Size(109, 13);
            this.LblUsuarioEnvio.TabIndex = 2;
            this.LblUsuarioEnvio.Text = "Mensagens Enviadas";
            // 
            // TxtRecebidas
            // 
            this.TxtRecebidas.Enabled = false;
            this.TxtRecebidas.Location = new System.Drawing.Point(347, 39);
            this.TxtRecebidas.Multiline = true;
            this.TxtRecebidas.Name = "TxtRecebidas";
            this.TxtRecebidas.Size = new System.Drawing.Size(296, 391);
            this.TxtRecebidas.TabIndex = 3;
            // 
            // LblUsuarioReceber
            // 
            this.LblUsuarioReceber.AutoSize = true;
            this.LblUsuarioReceber.Location = new System.Drawing.Point(344, 23);
            this.LblUsuarioReceber.Name = "LblUsuarioReceber";
            this.LblUsuarioReceber.Size = new System.Drawing.Size(116, 13);
            this.LblUsuarioReceber.TabIndex = 4;
            this.LblUsuarioReceber.Text = "Mensagens Recebidas";
            // 
            // TxtEnviar
            // 
            this.TxtEnviar.Location = new System.Drawing.Point(15, 473);
            this.TxtEnviar.Multiline = true;
            this.TxtEnviar.Name = "TxtEnviar";
            this.TxtEnviar.Size = new System.Drawing.Size(628, 98);
            this.TxtEnviar.TabIndex = 5;
            // 
            // Lbl3
            // 
            this.Lbl3.AutoSize = true;
            this.Lbl3.Location = new System.Drawing.Point(12, 457);
            this.Lbl3.Name = "Lbl3";
            this.Lbl3.Size = new System.Drawing.Size(88, 13);
            this.Lbl3.TabIndex = 6;
            this.Lbl3.Text = "Nova Mensagem";
            // 
            // BtnReceber
            // 
            this.BtnReceber.Location = new System.Drawing.Point(347, 577);
            this.BtnReceber.Name = "BtnReceber";
            this.BtnReceber.Size = new System.Drawing.Size(296, 52);
            this.BtnReceber.TabIndex = 7;
            this.BtnReceber.Text = "Receber";
            this.BtnReceber.UseVisualStyleBackColor = true;
            this.BtnReceber.Click += new System.EventHandler(this.BtnReceber_Click);
            // 
            // MensagemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 641);
            this.Controls.Add(this.BtnReceber);
            this.Controls.Add(this.Lbl3);
            this.Controls.Add(this.TxtEnviar);
            this.Controls.Add(this.LblUsuarioReceber);
            this.Controls.Add(this.TxtRecebidas);
            this.Controls.Add(this.LblUsuarioEnvio);
            this.Controls.Add(this.TxtEnviadas);
            this.Controls.Add(this.BtnEnviar);
            this.Name = "MensagemForm";
            this.Text = "Usuario: ";
            this.Load += new System.EventHandler(this.MensagemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.TextBox TxtEnviadas;
        private System.Windows.Forms.Label LblUsuarioEnvio;
        private System.Windows.Forms.TextBox TxtRecebidas;
        private System.Windows.Forms.Label LblUsuarioReceber;
        private System.Windows.Forms.TextBox TxtEnviar;
        private System.Windows.Forms.Label Lbl3;
        private System.Windows.Forms.Button BtnReceber;
    }
}

