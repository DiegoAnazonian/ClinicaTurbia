using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.Login
{
    public partial class RolesWindow : Form
    {

        public String rolSeleccionado { get; set; } 
        public RolesWindow(List<String> roles)
        {
            InitializeComponent();
            comboBoxRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            btnAceptar.Enabled = false;
            foreach (String rol in roles)
            {
                comboBoxRoles.Items.Add(rol);
            }
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRoles.Text == "")
            {
                btnAceptar.Enabled = false;
            }
            else
            {
                btnAceptar.Enabled = true;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RolesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            String rol = this.comboBoxRoles.Text;
            if ("".Equals(rol))
            {
                MessageBox.Show("Seleccione un rol antes de cerrar esta ventana");
                e.Cancel = true;
            }
            else
            {
                rolSeleccionado = rol;
            }
        }
    }
}
