namespace Clinica_Frba.Registro_Resultado_Atencion
{
    partial class RegistroResultado
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
            this.gridTurnos = new System.Windows.Forms.DataGridView();
            this.numTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regAtencion = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTurnos
            // 
            this.gridTurnos.AllowUserToAddRows = false;
            this.gridTurnos.AllowUserToDeleteRows = false;
            this.gridTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numTurno,
            this.numAfiliado,
            this.horario,
            this.regAtencion});
            this.gridTurnos.Location = new System.Drawing.Point(12, 12);
            this.gridTurnos.MultiSelect = false;
            this.gridTurnos.Name = "gridTurnos";
            this.gridTurnos.ReadOnly = true;
            this.gridTurnos.Size = new System.Drawing.Size(552, 333);
            this.gridTurnos.TabIndex = 0;
            this.gridTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTurnos_CellContentClick);
            // 
            // numTurno
            // 
            this.numTurno.HeaderText = "Numero de Turno";
            this.numTurno.Name = "numTurno";
            this.numTurno.ReadOnly = true;
            // 
            // numAfiliado
            // 
            this.numAfiliado.HeaderText = "Numero de afiliado";
            this.numAfiliado.Name = "numAfiliado";
            this.numAfiliado.ReadOnly = true;
            // 
            // horario
            // 
            this.horario.HeaderText = "Horario";
            this.horario.Name = "horario";
            this.horario.ReadOnly = true;
            // 
            // regAtencion
            // 
            this.regAtencion.HeaderText = "Registrar Atencion";
            this.regAtencion.Name = "regAtencion";
            this.regAtencion.ReadOnly = true;
            this.regAtencion.Text = "Registrar";
            this.regAtencion.UseColumnTextForButtonValue = true;
            // 
            // RegistroResultado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 357);
            this.Controls.Add(this.gridTurnos);
            this.Name = "RegistroResultado";
            this.Text = "Turnos para hoy";
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn numAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn horario;
        private System.Windows.Forms.DataGridViewButtonColumn regAtencion;
    }
}