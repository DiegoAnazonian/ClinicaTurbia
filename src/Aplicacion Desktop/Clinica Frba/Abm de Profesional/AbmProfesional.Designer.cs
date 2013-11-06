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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.cantidadMedicos = new System.Windows.Forms.TextBox();
            this.medicosBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.alta.Click += new System.EventHandler(this.button1_Click);
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
            this.baja.Click += new System.EventHandler(this.button1_Click);
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
            this.modificar.Click += new System.EventHandler(this.button1_Click);
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
            // searchBox
            // 
            this.searchBox.AccessibleDescription = "";
            this.searchBox.AccessibleName = "";
            this.searchBox.Location = new System.Drawing.Point(172, 28);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(381, 20);
            this.searchBox.TabIndex = 3;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // cantidadMedicos
            // 
            this.cantidadMedicos.Location = new System.Drawing.Point(143, 62);
            this.cantidadMedicos.Name = "cantidadMedicos";
            this.cantidadMedicos.Size = new System.Drawing.Size(23, 20);
            this.cantidadMedicos.TabIndex = 6;
            this.cantidadMedicos.Text = "0";
            this.cantidadMedicos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // medicosBox
            // 
            this.medicosBox.FormattingEnabled = true;
            this.medicosBox.Location = new System.Drawing.Point(172, 62);
            this.medicosBox.Name = "medicosBox";
            this.medicosBox.Size = new System.Drawing.Size(381, 173);
            this.medicosBox.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingrese un nombre/apellido a buscar";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // AbmProfesional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 253);
            this.Controls.Add(this.medicosBox);
            this.Controls.Add(this.cantidadMedicos);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modificar);
            this.Controls.Add(this.baja);
            this.Controls.Add(this.alta);
            this.Name = "AbmProfesional";
            this.Text = "AbmProfesional";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button alta;
        private System.Windows.Forms.Button baja;
        private System.Windows.Forms.Button modificar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.TextBox cantidadMedicos;
        private System.Windows.Forms.ListBox medicosBox;
        private System.Windows.Forms.Label label2;
    }
}