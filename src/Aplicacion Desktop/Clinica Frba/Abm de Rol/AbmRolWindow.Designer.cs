namespace Clinica_Frba.Abm_de_Rol
{
    partial class AbmRolWindow
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
            this.dataGridRoles = new System.Windows.Forms.DataGridView();
            this.nombreRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnsEliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnsModificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnNuevoRol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRoles
            // 
            this.dataGridRoles.AllowUserToAddRows = false;
            this.dataGridRoles.AllowUserToDeleteRows = false;
            this.dataGridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreRol,
            this.btnsEliminar,
            this.btnsModificar});
            this.dataGridRoles.Location = new System.Drawing.Point(12, 12);
            this.dataGridRoles.Name = "dataGridRoles";
            this.dataGridRoles.ReadOnly = true;
            this.dataGridRoles.Size = new System.Drawing.Size(593, 197);
            this.dataGridRoles.TabIndex = 0;
            this.dataGridRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridRoles_CellContentClick);
            // 
            // nombreRol
            // 
            this.nombreRol.HeaderText = "Nombre";
            this.nombreRol.Name = "nombreRol";
            this.nombreRol.ReadOnly = true;
            this.nombreRol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nombreRol.Width = 350;
            // 
            // btnsEliminar
            // 
            this.btnsEliminar.HeaderText = "Eliminar";
            this.btnsEliminar.Name = "btnsEliminar";
            this.btnsEliminar.ReadOnly = true;
            this.btnsEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnsEliminar.Text = "Eliminar";
            this.btnsEliminar.UseColumnTextForButtonValue = true;
            // 
            // btnsModificar
            // 
            this.btnsModificar.HeaderText = "Modificar";
            this.btnsModificar.Name = "btnsModificar";
            this.btnsModificar.ReadOnly = true;
            this.btnsModificar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnsModificar.Text = "Modificar";
            this.btnsModificar.UseColumnTextForButtonValue = true;
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.Location = new System.Drawing.Point(462, 234);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(143, 24);
            this.btnNuevoRol.TabIndex = 2;
            this.btnNuevoRol.Text = "Nuevo Rol";
            this.btnNuevoRol.UseVisualStyleBackColor = true;
            this.btnNuevoRol.Click += new System.EventHandler(this.btnNuevoRol_Click);
            // 
            // AbmRolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 270);
            this.Controls.Add(this.btnNuevoRol);
            this.Controls.Add(this.dataGridRoles);
            this.Name = "AbmRolWindow";
            this.Text = "BajaRolWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridRoles;
        private System.Windows.Forms.Button btnNuevoRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreRol;
        private System.Windows.Forms.DataGridViewButtonColumn btnsEliminar;
        private System.Windows.Forms.DataGridViewButtonColumn btnsModificar;
    }
}