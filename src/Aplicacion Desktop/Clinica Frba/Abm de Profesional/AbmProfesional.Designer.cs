namespace Clinica_Frba.Abm_de_Profesional
{
    partial class AbmProfesional
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
            this.alta = new System.Windows.Forms.Button();
            this.baja = new System.Windows.Forms.Button();
            this.modificar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.palabraClave = new System.Windows.Forms.TextBox();
            this.cantidadMedicos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.medicosBox = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.direccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.limpiar = new System.Windows.Forms.Button();
            this.volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.medicosBox)).BeginInit();
            this.SuspendLayout();
            // 
            // alta
            // 
            this.alta.Location = new System.Drawing.Point(52, 62);
            this.alta.Name = "alta";
            this.alta.Size = new System.Drawing.Size(60, 30);
            this.alta.TabIndex = 0;
            this.alta.Text = "Alta";
            this.alta.UseVisualStyleBackColor = true;
            this.alta.Click += new System.EventHandler(this.alta_Click);
            // 
            // baja
            // 
            this.baja.Enabled = false;
            this.baja.Location = new System.Drawing.Point(52, 98);
            this.baja.Name = "baja";
            this.baja.Size = new System.Drawing.Size(60, 30);
            this.baja.TabIndex = 0;
            this.baja.Text = "Baja";
            this.baja.UseVisualStyleBackColor = true;
            this.baja.Click += new System.EventHandler(this.baja_Click);
            // 
            // modificar
            // 
            this.modificar.Enabled = false;
            this.modificar.Location = new System.Drawing.Point(52, 134);
            this.modificar.Name = "modificar";
            this.modificar.Size = new System.Drawing.Size(60, 30);
            this.modificar.TabIndex = 0;
            this.modificar.Text = "Modificar";
            this.modificar.UseVisualStyleBackColor = true;
            this.modificar.Click += new System.EventHandler(this.modificar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ABM de un Profesional";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // palabraClave
            // 
            this.palabraClave.AccessibleDescription = "";
            this.palabraClave.AccessibleName = "";
            this.palabraClave.Location = new System.Drawing.Point(287, 51);
            this.palabraClave.Name = "palabraClave";
            this.palabraClave.Size = new System.Drawing.Size(246, 20);
            this.palabraClave.TabIndex = 3;
            this.palabraClave.TextChanged += new System.EventHandler(this.palabraClave_TextChanged);
            // 
            // cantidadMedicos
            // 
            this.cantidadMedicos.Location = new System.Drawing.Point(12, 168);
            this.cantidadMedicos.Name = "cantidadMedicos";
            this.cantidadMedicos.Size = new System.Drawing.Size(23, 20);
            this.cantidadMedicos.TabIndex = 6;
            this.cantidadMedicos.Text = "0";
            this.cantidadMedicos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Palabra Clave";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // medicosBox
            // 
            this.medicosBox.AllowUserToAddRows = false;
            this.medicosBox.AllowUserToDeleteRows = false;
            this.medicosBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medicosBox.Location = new System.Drawing.Point(12, 199);
            this.medicosBox.MultiSelect = false;
            this.medicosBox.Name = "medicosBox";
            this.medicosBox.ReadOnly = true;
            this.medicosBox.Size = new System.Drawing.Size(630, 242);
            this.medicosBox.TabIndex = 7;
            this.medicosBox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.medicosBox_CellContentClick);
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(287, 96);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 20);
            this.nombre.TabIndex = 8;
            this.nombre.TextChanged += new System.EventHandler(this.nombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nombre";
            // 
            // apellido
            // 
            this.apellido.Location = new System.Drawing.Point(287, 135);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(100, 20);
            this.apellido.TabIndex = 10;
            this.apellido.TextChanged += new System.EventHandler(this.apellido_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Apellido";
            // 
            // dni
            // 
            this.dni.Location = new System.Drawing.Point(433, 98);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(100, 20);
            this.dni.TabIndex = 12;
            this.dni.TextChanged += new System.EventHandler(this.dni_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "DNI";
            // 
            // direccion
            // 
            this.direccion.Location = new System.Drawing.Point(433, 134);
            this.direccion.Name = "direccion";
            this.direccion.Size = new System.Drawing.Size(100, 20);
            this.direccion.TabIndex = 14;
            this.direccion.TextChanged += new System.EventHandler(this.direccion_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(432, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Direccion";
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(567, 165);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 16;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(474, 165);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 18;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // AbmProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 453);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.direccion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dni);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.apellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.medicosBox);
            this.Controls.Add(this.cantidadMedicos);
            this.Controls.Add(this.palabraClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.baja);
            this.Controls.Add(this.alta);
            this.Name = "AbmProfesional";
            this.Text = "AbmProfesional";
            this.Load += new System.EventHandler(this.AbmProfesional_Load);
            ((System.ComponentModel.ISupportInitialize)(this.medicosBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button alta;
        private System.Windows.Forms.Button baja;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox palabraClave;
        private System.Windows.Forms.TextBox cantidadMedicos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView medicosBox;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dni;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox direccion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.Button volver;
    }
}