namespace Clinica_Frba.Registro_de_LLegada
{
    partial class RegistroLlegada
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
            this.lblMedico = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.comboMedico = new System.Windows.Forms.ComboBox();
            this.comboEspecialidad = new System.Windows.Forms.ComboBox();
            this.turnosMedico = new System.Windows.Forms.DataGridView();
            this.fechaDeHoy = new System.Windows.Forms.Label();
            this.traerTurnos = new System.Windows.Forms.Button();
            this.cancelar = new System.Windows.Forms.Button();
            this.horaActual = new System.Windows.Forms.Label();
            this.bonosAfiliado = new System.Windows.Forms.ComboBox();
            this.Horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registrarLlegadabtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.turnosMedico)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMedico
            // 
            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(195, 16);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(42, 13);
            this.lblMedico.TabIndex = 4;
            this.lblMedico.Text = "Medico";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(12, 16);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblEspecialidad.TabIndex = 5;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // comboMedico
            // 
            this.comboMedico.FormattingEnabled = true;
            this.comboMedico.Location = new System.Drawing.Point(191, 32);
            this.comboMedico.Name = "comboMedico";
            this.comboMedico.Size = new System.Drawing.Size(209, 21);
            this.comboMedico.TabIndex = 2;
            // 
            // comboEspecialidad
            // 
            this.comboEspecialidad.FormattingEnabled = true;
            this.comboEspecialidad.Location = new System.Drawing.Point(12, 32);
            this.comboEspecialidad.Name = "comboEspecialidad";
            this.comboEspecialidad.Size = new System.Drawing.Size(147, 21);
            this.comboEspecialidad.TabIndex = 3;
            this.comboEspecialidad.SelectedIndexChanged += new System.EventHandler(this.comboEspecialidad_SelectedIndexChanged);
            // 
            // turnosMedico
            // 
            this.turnosMedico.AllowUserToAddRows = false;
            this.turnosMedico.AllowUserToDeleteRows = false;
            this.turnosMedico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.turnosMedico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Horario,
            this.paciente,
            this.numTurno});
            this.turnosMedico.Location = new System.Drawing.Point(12, 59);
            this.turnosMedico.Name = "turnosMedico";
            this.turnosMedico.ReadOnly = true;
            this.turnosMedico.Size = new System.Drawing.Size(346, 252);
            this.turnosMedico.TabIndex = 6;
            this.turnosMedico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.turnosMedico_CellContentClick_1);
            // 
            // fechaDeHoy
            // 
            this.fechaDeHoy.AutoSize = true;
            this.fechaDeHoy.Location = new System.Drawing.Point(431, 8);
            this.fechaDeHoy.Name = "fechaDeHoy";
            this.fechaDeHoy.Size = new System.Drawing.Size(0, 13);
            this.fechaDeHoy.TabIndex = 8;
            // 
            // traerTurnos
            // 
            this.traerTurnos.Location = new System.Drawing.Point(364, 59);
            this.traerTurnos.Name = "traerTurnos";
            this.traerTurnos.Size = new System.Drawing.Size(75, 23);
            this.traerTurnos.TabIndex = 9;
            this.traerTurnos.Text = "Traer turnos";
            this.traerTurnos.UseVisualStyleBackColor = true;
            this.traerTurnos.Click += new System.EventHandler(this.traerTurnos_Click);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(481, 323);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(64, 23);
            this.cancelar.TabIndex = 10;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // horaActual
            // 
            this.horaActual.AutoSize = true;
            this.horaActual.Location = new System.Drawing.Point(431, 32);
            this.horaActual.Name = "horaActual";
            this.horaActual.Size = new System.Drawing.Size(0, 13);
            this.horaActual.TabIndex = 11;
            // 
            // bonosAfiliado
            // 
            this.bonosAfiliado.FormattingEnabled = true;
            this.bonosAfiliado.Location = new System.Drawing.Point(12, 317);
            this.bonosAfiliado.Name = "bonosAfiliado";
            this.bonosAfiliado.Size = new System.Drawing.Size(121, 21);
            this.bonosAfiliado.TabIndex = 12;
            this.bonosAfiliado.Text = "Bonos";
            this.bonosAfiliado.Visible = false;
            this.bonosAfiliado.SelectedIndexChanged += new System.EventHandler(this.bonosAfiliado_SelectedIndexChanged);
            // 
            // Horario
            // 
            this.Horario.Frozen = true;
            this.Horario.HeaderText = "Horario";
            this.Horario.Name = "Horario";
            this.Horario.ReadOnly = true;
            this.Horario.Width = 60;
            // 
            // paciente
            // 
            this.paciente.HeaderText = "Paciente";
            this.paciente.Name = "paciente";
            this.paciente.ReadOnly = true;
            // 
            // numTurno
            // 
            this.numTurno.HeaderText = "Numero Turno";
            this.numTurno.Name = "numTurno";
            this.numTurno.ReadOnly = true;
            // 
            // registrarLlegadabtn
            // 
            this.registrarLlegadabtn.Location = new System.Drawing.Point(413, 323);
            this.registrarLlegadabtn.Name = "registrarLlegadabtn";
            this.registrarLlegadabtn.Size = new System.Drawing.Size(62, 23);
            this.registrarLlegadabtn.TabIndex = 13;
            this.registrarLlegadabtn.Text = "Registrar";
            this.registrarLlegadabtn.UseVisualStyleBackColor = true;
            this.registrarLlegadabtn.Visible = false;
            this.registrarLlegadabtn.Click += new System.EventHandler(this.registrarLlegada_Click);
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 358);
            this.Controls.Add(this.registrarLlegadabtn);
            this.Controls.Add(this.bonosAfiliado);
            this.Controls.Add(this.horaActual);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.traerTurnos);
            this.Controls.Add(this.fechaDeHoy);
            this.Controls.Add(this.turnosMedico);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.comboMedico);
            this.Controls.Add(this.comboEspecialidad);
            this.Name = "RegistroLlegada";
            this.Text = "RegistroLlegada";
            this.Load += new System.EventHandler(this.RegistroLlegada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.turnosMedico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox comboMedico;
        private System.Windows.Forms.ComboBox comboEspecialidad;
        private System.Windows.Forms.DataGridView turnosMedico;
        private System.Windows.Forms.Label fechaDeHoy;
        private System.Windows.Forms.Button traerTurnos;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label horaActual;
        private System.Windows.Forms.ComboBox bonosAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTurno;
        private System.Windows.Forms.Button registrarLlegadabtn;
    }
}