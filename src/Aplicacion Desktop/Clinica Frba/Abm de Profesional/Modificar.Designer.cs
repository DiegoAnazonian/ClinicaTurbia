namespace Clinica_Frba.Abm_de_Profesional
{
    partial class Modificar
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
            this.guardar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fecha_nacimiento = new System.Windows.Forms.TextBox();
            this.mail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.telefono = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.dni = new System.Windows.Forms.TextBox();
            this.cancelar = new System.Windows.Forms.Button();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listEspecialidades = new System.Windows.Forms.ListBox();
            this.btnCale = new System.Windows.Forms.Button();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(231, 387);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 29;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Fecha Nacimiento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Mail";
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.Enabled = false;
            this.fecha_nacimiento.Location = new System.Drawing.Point(10, 165);
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            this.fecha_nacimiento.Size = new System.Drawing.Size(130, 20);
            this.fecha_nacimiento.TabIndex = 26;
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(155, 122);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(151, 20);
            this.mail.TabIndex = 25;
            this.mail.TextChanged += new System.EventHandler(this.mail_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Telefono";
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(155, 79);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(151, 20);
            this.telefono.TabIndex = 23;
            this.telefono.TextChanged += new System.EventHandler(this.telefono_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Direccion";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(155, 40);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(151, 20);
            this.direccion.TabIndex = 21;
            this.direccion.TextChanged += new System.EventHandler(this.direccion_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "DNI";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(10, 122);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(130, 20);
            this.apellido.TabIndex = 17;
            this.apellido.TextChanged += new System.EventHandler(this.apellido_TextChanged);
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(10, 79);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(130, 20);
            this.nombre.TabIndex = 16;
            this.nombre.TextChanged += new System.EventHandler(this.nombre_TextChanged);
            // 
            // dni
            // 
            this.dni.Enabled = false;
            this.dni.Location = new System.Drawing.Point(10, 40);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(130, 20);
            this.dni.TabIndex = 15;
            this.dni.TextChanged += new System.EventHandler(this.dni_TextChanged);
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(14, 387);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 30;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(10, 209);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(151, 20);
            this.txtMatricula.TabIndex = 25;
            this.txtMatricula.TextChanged += new System.EventHandler(this.txtMatricula_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Matricula";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Especialidades";
            // 
            // listEspecialidades
            // 
            this.listEspecialidades.FormattingEnabled = true;
            this.listEspecialidades.Location = new System.Drawing.Point(10, 262);
            this.listEspecialidades.Name = "listEspecialidades";
            this.listEspecialidades.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listEspecialidades.Size = new System.Drawing.Size(296, 95);
            this.listEspecialidades.TabIndex = 32;
            this.listEspecialidades.SelectedIndexChanged += new System.EventHandler(this.listEspecialidades_SelectedIndexChanged);
            // 
            // btnCale
            // 
            this.btnCale.Location = new System.Drawing.Point(166, 163);
            this.btnCale.Name = "btnCale";
            this.btnCale.Size = new System.Drawing.Size(107, 23);
            this.btnCale.TabIndex = 53;
            this.btnCale.Text = "Seleccionar fecha";
            this.btnCale.UseVisualStyleBackColor = true;
            this.btnCale.Click += new System.EventHandler(this.btnCale_Click);
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(79, 111);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 54;
            this.calendario.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateSelected);
            // 
            // Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 483);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.btnCale);
            this.Controls.Add(this.listEspecialidades);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.fecha_nacimiento);
            this.Controls.Add(this.mail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.telefono);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.direccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.dni);
            this.Name = "Modificar";
            this.Text = "Modificar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fecha_nacimiento;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox telefono;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listEspecialidades;
        private System.Windows.Forms.Button btnCale;
        private System.Windows.Forms.MonthCalendar calendario;

    }
}