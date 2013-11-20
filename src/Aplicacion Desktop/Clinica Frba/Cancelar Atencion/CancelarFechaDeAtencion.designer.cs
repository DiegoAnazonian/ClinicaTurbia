namespace Clinica_Frba.Cancelar_Atencion
{
    partial class CancelarFechaDeAtencion
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
            this.comboFechas = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboFechas
            // 
            this.comboFechas.FormattingEnabled = true;
            this.comboFechas.Location = new System.Drawing.Point(30, 28);
            this.comboFechas.Name = "comboFechas";
            this.comboFechas.Size = new System.Drawing.Size(222, 21);
            this.comboFechas.TabIndex = 0;
            this.comboFechas.SelectedIndexChanged += new System.EventHandler(this.comboFechas_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(243, 68);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(113, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Aceptar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // CancelarFechaDeAtencion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 110);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.comboFechas);
            this.Name = "CancelarFechaDeAtencion";
            this.Text = "CancelarFechaDeAtencion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboFechas;
        private System.Windows.Forms.Button btnCancelar;
    }
}