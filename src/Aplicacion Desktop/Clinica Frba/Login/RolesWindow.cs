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
        public RolesWindow(List<String> roles)
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            button1.Enabled = false;
            foreach (String rol in roles)
            {
                comboBox1.Items.Add(rol);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FuncionalidadesWindow(comboBox1.Text).Show();
            this.Close();
        }

        private void RolesWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                MessageBox.Show("sad");
                Application.Exit();
            }
        }
    }
}
