namespace Clinica_Frba.Compra_de_Bono
{
    partial class ComprarBono
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboConsulta = new System.Windows.Forms.ComboBox();
            this.comboFarmacia = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumAfiliado = new System.Windows.Forms.Label();
            this.txtNumAfiliado = new System.Windows.Forms.TextBox();
            this.btnValidar = new System.Windows.Forms.Button();
            this.panelAfiliado = new System.Windows.Forms.Panel();
            this.btnComprar = new System.Windows.Forms.Button();
            this.panelAfiliado.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad de Bonos Consulta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cantidad de Bonos Farmacia";
            // 
            // comboConsulta
            // 
            this.comboConsulta.FormattingEnabled = true;
            this.comboConsulta.Location = new System.Drawing.Point(177, 14);
            this.comboConsulta.Name = "comboConsulta";
            this.comboConsulta.Size = new System.Drawing.Size(74, 21);
            this.comboConsulta.TabIndex = 1;
            this.comboConsulta.SelectedIndexChanged += new System.EventHandler(this.comboConsulta_SelectedIndexChanged);
            // 
            // comboFarmacia
            // 
            this.comboFarmacia.FormattingEnabled = true;
            this.comboFarmacia.Location = new System.Drawing.Point(177, 49);
            this.comboFarmacia.Name = "comboFarmacia";
            this.comboFarmacia.Size = new System.Drawing.Size(74, 21);
            this.comboFarmacia.TabIndex = 1;
            this.comboFarmacia.SelectedIndexChanged += new System.EventHandler(this.comboFarmacia_SelectedIndexChanged);
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(177, 81);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(73, 20);
            this.txtMonto.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Monto Total";
            // 
            // lblNumAfiliado
            // 
            this.lblNumAfiliado.AutoSize = true;
            this.lblNumAfiliado.Location = new System.Drawing.Point(12, 19);
            this.lblNumAfiliado.Name = "lblNumAfiliado";
            this.lblNumAfiliado.Size = new System.Drawing.Size(96, 13);
            this.lblNumAfiliado.TabIndex = 0;
            this.lblNumAfiliado.Text = "Numero de Afiliado";
            // 
            // txtNumAfiliado
            // 
            this.txtNumAfiliado.Location = new System.Drawing.Point(114, 16);
            this.txtNumAfiliado.Name = "txtNumAfiliado";
            this.txtNumAfiliado.Size = new System.Drawing.Size(100, 20);
            this.txtNumAfiliado.TabIndex = 2;
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(220, 12);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(73, 26);
            this.btnValidar.TabIndex = 4;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // panelAfiliado
            // 
            this.panelAfiliado.Controls.Add(this.btnComprar);
            this.panelAfiliado.Controls.Add(this.label3);
            this.panelAfiliado.Controls.Add(this.txtMonto);
            this.panelAfiliado.Controls.Add(this.comboFarmacia);
            this.panelAfiliado.Controls.Add(this.comboConsulta);
            this.panelAfiliado.Controls.Add(this.label2);
            this.panelAfiliado.Controls.Add(this.label1);
            this.panelAfiliado.Enabled = false;
            this.panelAfiliado.Location = new System.Drawing.Point(15, 63);
            this.panelAfiliado.Name = "panelAfiliado";
            this.panelAfiliado.Size = new System.Drawing.Size(277, 162);
            this.panelAfiliado.TabIndex = 5;
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(177, 123);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(87, 25);
            this.btnComprar.TabIndex = 6;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // ComprarBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 254);
            this.Controls.Add(this.panelAfiliado);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.txtNumAfiliado);
            this.Controls.Add(this.lblNumAfiliado);
            this.Name = "ComprarBono";
            this.Text = "ComprarBono";
            this.panelAfiliado.ResumeLayout(false);
            this.panelAfiliado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboConsulta;
        private System.Windows.Forms.ComboBox comboFarmacia;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumAfiliado;
        private System.Windows.Forms.TextBox txtNumAfiliado;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Panel panelAfiliado;
        private System.Windows.Forms.Button btnComprar;
    }
}