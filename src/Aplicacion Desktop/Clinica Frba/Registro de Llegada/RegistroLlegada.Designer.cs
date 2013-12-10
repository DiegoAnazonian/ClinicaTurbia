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
            this.Horario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDeHoy = new System.Windows.Forms.Label();
            this.cancelar = new System.Windows.Forms.Button();
            this.horaActual = new System.Windows.Forms.Label();
            this.bonosAfiliado = new System.Windows.Forms.ComboBox();
            this.registrarLlegadabtn = new System.Windows.Forms.Button();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.lblbonos = new System.Windows.Forms.Label();
            this.pnlPaciente = new System.Windows.Forms.Panel();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.turnosMedico)).BeginInit();
            this.pnlPaciente.SuspendLayout();
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
            this.comboMedico.SelectedIndexChanged += new System.EventHandler(this.comboMedico_SelectedIndexChanged);
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
            this.turnosMedico.Location = new System.Drawing.Point(12, 77);
            this.turnosMedico.Name = "turnosMedico";
            this.turnosMedico.ReadOnly = true;
            this.turnosMedico.Size = new System.Drawing.Size(324, 287);
            this.turnosMedico.TabIndex = 6;
            this.turnosMedico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.turnosMedico_CellContentClick);
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
            // fechaDeHoy
            // 
            this.fechaDeHoy.AutoSize = true;
            this.fechaDeHoy.Location = new System.Drawing.Point(431, 8);
            this.fechaDeHoy.Name = "fechaDeHoy";
            this.fechaDeHoy.Size = new System.Drawing.Size(0, 13);
            this.fechaDeHoy.TabIndex = 8;
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(371, 300);
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
            this.bonosAfiliado.Location = new System.Drawing.Point(11, 120);
            this.bonosAfiliado.Name = "bonosAfiliado";
            this.bonosAfiliado.Size = new System.Drawing.Size(121, 21);
            this.bonosAfiliado.TabIndex = 12;
            this.bonosAfiliado.SelectedIndexChanged += new System.EventHandler(this.bonosAfiliado_SelectedIndexChanged);
            // 
            // registrarLlegadabtn
            // 
            this.registrarLlegadabtn.Location = new System.Drawing.Point(484, 300);
            this.registrarLlegadabtn.Name = "registrarLlegadabtn";
            this.registrarLlegadabtn.Size = new System.Drawing.Size(62, 23);
            this.registrarLlegadabtn.TabIndex = 13;
            this.registrarLlegadabtn.Text = "Registrar";
            this.registrarLlegadabtn.UseVisualStyleBackColor = true;
            this.registrarLlegadabtn.Visible = false;
            this.registrarLlegadabtn.Click += new System.EventHandler(this.registrarLlegada_Click);
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Location = new System.Drawing.Point(8, 7);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(49, 13);
            this.lblPaciente.TabIndex = 14;
            this.lblPaciente.Text = "Paciente";
            // 
            // lblbonos
            // 
            this.lblbonos.AutoSize = true;
            this.lblbonos.Location = new System.Drawing.Point(8, 93);
            this.lblbonos.Name = "lblbonos";
            this.lblbonos.Size = new System.Drawing.Size(135, 13);
            this.lblbonos.TabIndex = 15;
            this.lblbonos.Text = "Bonos consulta disponibles";
            // 
            // pnlPaciente
            // 
            this.pnlPaciente.Controls.Add(this.txtPaciente);
            this.pnlPaciente.Controls.Add(this.lblbonos);
            this.pnlPaciente.Controls.Add(this.lblPaciente);
            this.pnlPaciente.Controls.Add(this.bonosAfiliado);
            this.pnlPaciente.Location = new System.Drawing.Point(371, 77);
            this.pnlPaciente.Name = "pnlPaciente";
            this.pnlPaciente.Size = new System.Drawing.Size(174, 191);
            this.pnlPaciente.TabIndex = 16;
            // 
            // txtPaciente
            // 
            this.txtPaciente.Enabled = false;
            this.txtPaciente.Location = new System.Drawing.Point(11, 41);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(131, 20);
            this.txtPaciente.TabIndex = 16;
            // 
            // RegistroLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 376);
            this.Controls.Add(this.pnlPaciente);
            this.Controls.Add(this.registrarLlegadabtn);
            this.Controls.Add(this.horaActual);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.fechaDeHoy);
            this.Controls.Add(this.turnosMedico);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.comboMedico);
            this.Controls.Add(this.comboEspecialidad);
            this.Name = "RegistroLlegada";
            this.Text = "RegistroLlegada";
            ((System.ComponentModel.ISupportInitialize)(this.turnosMedico)).EndInit();
            this.pnlPaciente.ResumeLayout(false);
            this.pnlPaciente.PerformLayout();
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
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Label horaActual;
        private System.Windows.Forms.ComboBox bonosAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horario;
        private System.Windows.Forms.DataGridViewTextBoxColumn paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn numTurno;
        private System.Windows.Forms.Button registrarLlegadabtn;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Label lblbonos;
        private System.Windows.Forms.Panel pnlPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
    }
}