namespace Clinica_Frba.Abm_de_Rol
{
    partial class RolWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.textNombreRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listFuncionalidades = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del Rol";
            // 
            // textNombreRol
            // 
            this.textNombreRol.Location = new System.Drawing.Point(12, 25);
            this.textNombreRol.Name = "textNombreRol";
            this.textNombreRol.Size = new System.Drawing.Size(209, 20);
            this.textNombreRol.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidad disponibles";
            // 
            // listFuncionalidades
            // 
            this.listFuncionalidades.FormattingEnabled = true;
            this.listFuncionalidades.Location = new System.Drawing.Point(12, 76);
            this.listFuncionalidades.Name = "listFuncionalidades";
            this.listFuncionalidades.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listFuncionalidades.Size = new System.Drawing.Size(209, 121);
            this.listFuncionalidades.TabIndex = 3;
            this.listFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.listFuncionalidades_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(15, 212);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(73, 17);
            this.checkBoxHabilitado.TabIndex = 5;
            this.checkBoxHabilitado.Text = "Habilitado";
            this.checkBoxHabilitado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // RolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 292);
            this.Controls.Add(this.checkBoxHabilitado);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listFuncionalidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textNombreRol);
            this.Controls.Add(this.label1);
            this.Name = "RolWindow";
            this.Text = "AltaRolWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombreRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listFuncionalidades;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
    }
}