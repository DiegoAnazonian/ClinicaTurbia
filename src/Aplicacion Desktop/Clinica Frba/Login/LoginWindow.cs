using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Login;

namespace Clinica_Frba.NewFolder10
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
            btnLogin.Enabled = false;
            this.ActiveControl = txtUsuario;
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
                    List<SqlParameter> checkRolesParam = new List<SqlParameter>();
                    checkRolesParam.Add(new SqlParameter("usuario", txtUsuario.Text));
                    DataTable tablaRoles = Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[CONSULTA_ROLES]", checkRolesParam);
                    if (tablaRoles.Rows.Count > 1)
                    {
                        List<string> roles = new List<string>();
                        foreach (DataRow row in tablaRoles.Rows)
                        {
                            roles.Add(row[0].ToString());
                        }
                        this.Close();
                        new RolesWindow(roles).Show();
                    }
                    else
                    {
                        this.Close();
                        new FuncionalidadesWindow(tablaRoles.Rows[0][0].ToString()).Show();
                    }
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

        private void LoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.UserClosing)) 
            {
                Application.Exit();
            }
        }
    }
}
