using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.NewFolder10
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
            btnLogin.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            List<SqlParameter> checkUsuarioParam = new List<SqlParameter>();
            checkUsuarioParam.Add(new SqlParameter("usuario", txtUsuario.Text));
            DataTable tablaUsuario = Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[CONSULTA_LOGIN]", checkUsuarioParam);
            if (tablaUsuario == null)
            {
                MessageBox.Show("El usuario no existe.\n", "Error de login",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnLogin.Enabled = true;
                return;
            }
            else
            {
                DataRow reg = tablaUsuario.Rows[0];
                if (!(bool) reg["USUARIO_HABILITADO"]) {
                    MessageBox.Show("El usuario se encuentra bloqueado.\n", "Error de login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLogin.Enabled = true;
                    return;
                }
                if (reg["USUARIO_PASSWORD"].ToString().Equals(txtPassword.Text))
                {
                    MessageBox.Show("Estas adentro.\n", "Login satisfactorio",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLogin.Enabled = true;
                    return;
                }
                else
                {
                    MessageBox.Show("Password incorrecta.\n", "Error de login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLogin.Enabled = true;
                    return;
                }
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if ("".Equals(txtUsuario.Text))
            {
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
