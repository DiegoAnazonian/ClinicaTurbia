namespace Clinica_Frba.Cancelar_Atencion
{
    partial class CancelarTurno
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
            this.turnosGrid = new System.Windows.Forms.DataGridView();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.turnosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // turnosGrid
            // 
            this.turnosGrid.AllowUserToAddRows = false;
            this.turnosGrid.AllowUserToDeleteRows = false;
            this.turnosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.turnosGrid.Location = new System.Drawing.Point(12, 12);
            this.turnosGrid.MultiSelect = false;
            this.turnosGrid.Name = "turnosGrid";
            this.turnosGrid.ReadOnly = true;
            this.turnosGrid.Size = new System.Drawing.Size(457, 193);
            this.turnosGrid.TabIndex = 0;
            // 
            // btnCancelarTurno
            // 
            this.btnCancelarTurno.Location = new System.Drawing.Point(315, 231);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Size = new System.Drawing.Size(141, 35);
            this.btnCancelarTurno.TabIndex = 1;
            this.btnCancelarTurno.Text = "Cancelar Turno";
            this.btnCancelarTurno.UseVisualStyleBackColor = true;
            this.btnCancelarTurno.Click += new System.EventHandler(this.btnCancelarTurno_Click);
            // 
            // CancelarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 286);
            this.Controls.Add(this.btnCancelarTurno);
            this.Controls.Add(this.turnosGrid);
            this.Name = "CancelarTurno";
            this.Text = "Cancelar Turno";
            ((System.ComponentModel.ISupportInitialize)(this.turnosGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView turnosGrid;
        private System.Windows.Forms.Button btnCancelarTurno;
    }
}