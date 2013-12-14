namespace Clinica_Frba.Pedir_Turno
{
    partial class PedirTurno
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
            this.comboEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.comboMedico = new System.Windows.Forms.ComboBox();
            this.lblMedico = new System.Windows.Forms.Label();
            this.comboFecha = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.comboHorario = new System.Windows.Forms.ComboBox();
            this.lblHorario = new System.Windows.Forms.Label();
            this.btnCrearTurno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboEspecialidad
            // 
            this.comboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEspecialidad.FormattingEnabled = true;
            this.comboEspecialidad.Location = new System.Drawing.Point(12, 33);
            this.comboEspecialidad.Name = "comboEspecialidad";
            this.comboEspecialidad.Size = new System.Drawing.Size(147, 21);
            this.comboEspecialidad.TabIndex = 0;
            this.comboEspecialidad.SelectedIndexChanged += new System.EventHandler(this.comboEspecialidad_SelectedIndexChanged);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(12, 17);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.lblEspecialidad.TabIndex = 1;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // comboMedico
            // 
            this.comboMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMedico.FormattingEnabled = true;
            this.comboMedico.Location = new System.Drawing.Point(208, 33);
            this.comboMedico.Name = "comboMedico";
            this.comboMedico.Size = new System.Drawing.Size(209, 21);
            this.comboMedico.TabIndex = 0;
            this.comboMedico.SelectedIndexChanged += new System.EventHandler(this.comboMedico_SelectedIndexChanged);
            // 
            // lblMedico
            // 
            this.lblMedico.AutoSize = true;
            this.lblMedico.Location = new System.Drawing.Point(208, 17);
            this.lblMedico.Name = "lblMedico";
            this.lblMedico.Size = new System.Drawing.Size(42, 13);
            this.lblMedico.TabIndex = 1;
            this.lblMedico.Text = "Medico";
            // 
            // comboFecha
            // 
            this.comboFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFecha.FormattingEnabled = true;
            this.comboFecha.Location = new System.Drawing.Point(12, 122);
            this.comboFecha.Name = "comboFecha";
            this.comboFecha.Size = new System.Drawing.Size(195, 21);
            this.comboFecha.TabIndex = 0;
            this.comboFecha.SelectedIndexChanged += new System.EventHandler(this.comboFecha_SelectedIndexChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 106);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(37, 13);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha";
            // 
            // comboHorario
            // 
            this.comboHorario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHorario.FormattingEnabled = true;
            this.comboHorario.Location = new System.Drawing.Point(258, 122);
            this.comboHorario.Name = "comboHorario";
            this.comboHorario.Size = new System.Drawing.Size(147, 21);
            this.comboHorario.TabIndex = 0;
            this.comboHorario.SelectedIndexChanged += new System.EventHandler(this.comboHorario_SelectedIndexChanged);
            // 
            // lblHorario
            // 
            this.lblHorario.AutoSize = true;
            this.lblHorario.Location = new System.Drawing.Point(258, 106);
            this.lblHorario.Name = "lblHorario";
            this.lblHorario.Size = new System.Drawing.Size(41, 13);
            this.lblHorario.TabIndex = 1;
            this.lblHorario.Text = "Horario";
            // 
            // btnCrearTurno
            // 
            this.btnCrearTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearTurno.Location = new System.Drawing.Point(281, 221);
            this.btnCrearTurno.Name = "btnCrearTurno";
            this.btnCrearTurno.Size = new System.Drawing.Size(135, 27);
            this.btnCrearTurno.TabIndex = 2;
            this.btnCrearTurno.Text = "Confirmar";
            this.btnCrearTurno.UseVisualStyleBackColor = true;
            this.btnCrearTurno.Click += new System.EventHandler(this.btnCrearTurno_Click);
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 262);
            this.Controls.Add(this.btnCrearTurno);
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHorario);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.comboMedico);
            this.Controls.Add(this.comboFecha);
            this.Controls.Add(this.comboHorario);
            this.Controls.Add(this.comboEspecialidad);
            this.Name = "PedirTurno";
            this.Text = "PedirTurno";
            this.Load += new System.EventHandler(this.PedirTurno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboEspecialidad;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox comboMedico;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox comboFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox comboHorario;
        private System.Windows.Forms.Label lblHorario;
        private System.Windows.Forms.Button btnCrearTurno;
    }
}