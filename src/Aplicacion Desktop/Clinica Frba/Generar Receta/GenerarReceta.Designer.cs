namespace Clinica_Frba.Generar_Receta
{
    partial class GenerarReceta
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
            this.comboBono = new System.Windows.Forms.ComboBox();
            this.txtMedicamento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidadString = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gridReceta = new System.Windows.Forms.DataGridView();
            this.medicamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.comboCant = new System.Windows.Forms.ComboBox();
            this.txtNumAf = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnCambiar = new System.Windows.Forms.Button();
            this.pnlOpcional = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridReceta)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.pnlOpcional.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de Bono Farmacia";
            // 
            // comboBono
            // 
            this.comboBono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBono.FormattingEnabled = true;
            this.comboBono.Location = new System.Drawing.Point(149, 63);
            this.comboBono.Name = "comboBono";
            this.comboBono.Size = new System.Drawing.Size(106, 21);
            this.comboBono.TabIndex = 1;
            this.comboBono.SelectedIndexChanged += new System.EventHandler(this.comboBono_SelectedIndexChanged);
            // 
            // txtMedicamento
            // 
            this.txtMedicamento.Location = new System.Drawing.Point(95, 8);
            this.txtMedicamento.Name = "txtMedicamento";
            this.txtMedicamento.Size = new System.Drawing.Size(103, 20);
            this.txtMedicamento.TabIndex = 2;
            this.txtMedicamento.TextChanged += new System.EventHandler(this.txtMedicamento_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Medicamento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cantidad";
            // 
            // txtCantidadString
            // 
            this.txtCantidadString.Enabled = false;
            this.txtCantidadString.Location = new System.Drawing.Point(164, 38);
            this.txtCantidadString.Name = "txtCantidadString";
            this.txtCantidadString.Size = new System.Drawing.Size(74, 20);
            this.txtCantidadString.TabIndex = 2;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(253, 35);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(98, 24);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gridReceta
            // 
            this.gridReceta.AllowUserToAddRows = false;
            this.gridReceta.AllowUserToDeleteRows = false;
            this.gridReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReceta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.medicamento,
            this.cantidad,
            this.eliminar});
            this.gridReceta.Location = new System.Drawing.Point(9, 80);
            this.gridReceta.Name = "gridReceta";
            this.gridReceta.ReadOnly = true;
            this.gridReceta.Size = new System.Drawing.Size(454, 128);
            this.gridReceta.TabIndex = 5;
            this.gridReceta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridReceta_CellContentClick);
            // 
            // medicamento
            // 
            this.medicamento.HeaderText = "Medicamento";
            this.medicamento.Name = "medicamento";
            this.medicamento.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar";
            this.eliminar.Name = "eliminar";
            this.eliminar.ReadOnly = true;
            this.eliminar.Text = "Eliminar";
            this.eliminar.UseColumnTextForButtonValue = true;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(346, 226);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(117, 39);
            this.btnGenerar.TabIndex = 4;
            this.btnGenerar.Text = "Generar Receta";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.comboCant);
            this.pnlPrincipal.Controls.Add(this.gridReceta);
            this.pnlPrincipal.Controls.Add(this.btnGenerar);
            this.pnlPrincipal.Controls.Add(this.btnAgregar);
            this.pnlPrincipal.Controls.Add(this.label3);
            this.pnlPrincipal.Controls.Add(this.label2);
            this.pnlPrincipal.Controls.Add(this.txtCantidadString);
            this.pnlPrincipal.Controls.Add(this.txtMedicamento);
            this.pnlPrincipal.Location = new System.Drawing.Point(8, 105);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(480, 285);
            this.pnlPrincipal.TabIndex = 6;
            // 
            // comboCant
            // 
            this.comboCant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCant.FormattingEnabled = true;
            this.comboCant.Location = new System.Drawing.Point(95, 37);
            this.comboCant.Name = "comboCant";
            this.comboCant.Size = new System.Drawing.Size(43, 21);
            this.comboCant.TabIndex = 6;
            this.comboCant.SelectedIndexChanged += new System.EventHandler(this.comboCant_SelectedIndexChanged);
            // 
            // txtNumAf
            // 
            this.txtNumAf.Location = new System.Drawing.Point(106, 12);
            this.txtNumAf.Name = "txtNumAf";
            this.txtNumAf.Size = new System.Drawing.Size(103, 20);
            this.txtNumAf.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Numero de Afiliado";
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(234, 10);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(98, 24);
            this.btnCargar.TabIndex = 4;
            this.btnCargar.Text = "Cargar Afiliado";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnCambiar
            // 
            this.btnCambiar.Location = new System.Drawing.Point(355, 10);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(98, 24);
            this.btnCambiar.TabIndex = 4;
            this.btnCambiar.Text = "Cambiar Afiliado";
            this.btnCambiar.UseVisualStyleBackColor = true;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // pnlOpcional
            // 
            this.pnlOpcional.Controls.Add(this.btnCambiar);
            this.pnlOpcional.Controls.Add(this.btnCargar);
            this.pnlOpcional.Controls.Add(this.label4);
            this.pnlOpcional.Controls.Add(this.txtNumAf);
            this.pnlOpcional.Location = new System.Drawing.Point(8, 3);
            this.pnlOpcional.Name = "pnlOpcional";
            this.pnlOpcional.Size = new System.Drawing.Size(480, 43);
            this.pnlOpcional.TabIndex = 7;
            // 
            // GenerarReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 402);
            this.Controls.Add(this.pnlOpcional);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.comboBono);
            this.Controls.Add(this.label1);
            this.Name = "GenerarReceta";
            this.Text = "GenerarReceta";
            ((System.ComponentModel.ISupportInitialize)(this.gridReceta)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.pnlOpcional.ResumeLayout(false);
            this.pnlOpcional.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBono;
        private System.Windows.Forms.TextBox txtMedicamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidadString;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView gridReceta;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.TextBox txtNumAf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Panel pnlOpcional;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewButtonColumn eliminar;
        private System.Windows.Forms.ComboBox comboCant;
    }
}