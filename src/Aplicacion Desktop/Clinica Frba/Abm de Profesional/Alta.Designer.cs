namespace Clinica_Frba.Abm_de_Profesional
{
    partial class Alta
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
            this.cancelar = new System.Windows.Forms.Button();
            this.guardar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fechaNacimiento = new System.Windows.Forms.TextBox();
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
            this.listEspecialidades = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.btnCale = new System.Windows.Forms.Button();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(63, 363);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 46;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(170, 363);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 45;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Fecha Nacimiento *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(155, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Mail";
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Enabled = false;
            this.fechaNacimiento.Location = new System.Drawing.Point(12, 152);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.Size = new System.Drawing.Size(130, 20);
            this.fechaNacimiento.TabIndex = 42;
            // 
            // mail
            // 
            this.mail.Location = new System.Drawing.Point(160, 109);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(151, 20);
            this.mail.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(155, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Telefono";
            // 
            // telefono
            // 
            this.telefono.Location = new System.Drawing.Point(157, 66);
            this.telefono.Name = "telefono";
            this.telefono.Size = new System.Drawing.Size(151, 20);
            this.telefono.TabIndex = 39;
            this.telefono.TextChanged += new System.EventHandler(this.telefono_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Direccion";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(157, 27);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(151, 20);
            this.direccion.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Apellido *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Nombre *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "DNI *";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(12, 109);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(130, 20);
            this.apellido.TabIndex = 33;
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(12, 66);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(130, 20);
            this.nombre.TabIndex = 32;
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(12, 27);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(130, 20);
            this.dni.TabIndex = 31;
            this.dni.TextChanged += new System.EventHandler(this.dni_TextChanged);
            // 
            // listEspecialidades
            // 
            this.listEspecialidades.FormattingEnabled = true;
            this.listEspecialidades.Location = new System.Drawing.Point(12, 250);
            this.listEspecialidades.Name = "listEspecialidades";
            this.listEspecialidades.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listEspecialidades.Size = new System.Drawing.Size(296, 95);
            this.listEspecialidades.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Especialidades";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Matricula";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(13, 200);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(129, 20);
            this.txtMatricula.TabIndex = 49;
            this.txtMatricula.TextChanged += new System.EventHandler(this.txtMatricula_TextChanged);
            // 
            // btnCale
            // 
            this.btnCale.Location = new System.Drawing.Point(170, 150);
            this.btnCale.Name = "btnCale";
            this.btnCale.Size = new System.Drawing.Size(117, 23);
            this.btnCale.TabIndex = 52;
            this.btnCale.Text = "Seleccionar fecha";
            this.btnCale.UseVisualStyleBackColor = true;
            this.btnCale.Click += new System.EventHandler(this.btnCale_Click);
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(74, 72);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 53;
            this.calendario.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateSelected);
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 430);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.btnCale);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.listEspecialidades);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fechaNacimiento);
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
            this.Name = "Alta";
            this.Text = "Alta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button guardar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fechaNacimiento;
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
        private System.Windows.Forms.ListBox listEspecialidades;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Button btnCale;
        private System.Windows.Forms.MonthCalendar calendario;
    }
}