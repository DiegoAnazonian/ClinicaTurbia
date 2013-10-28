using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Login;
using Clinica_Frba.Abm_de_Rol;

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
                    this.Text = "Clinica Turbia";
                    panelLogin.Hide();
                    Button btnLogout = new Button();
                    btnLogout.Text = "Logout";
                    btnLogout.Top = 10;
                    btnLogout.Left = 525;
                    btnLogout.Width = 100;
                    btnLogout.Click += (ssender, args) =>
                    {
                        //LOGOUT();
                    };
                    this.Controls.Add(btnLogout);
                    List<SqlParameter> checkRolesParam = new List<SqlParameter>();
                    checkRolesParam.Add(new SqlParameter("usuario", txtUsuario.Text));
                    DataTable tablaRoles = Database.GetInstance.ExecuteQuery(
                        "[ClinicaTurbia].[CONSULTA_ROLES]", checkRolesParam);
                    String rol;
                    if (tablaRoles.Rows.Count > 1)
                    {
                        List<string> roles = new List<string>();
                        foreach (DataRow row in tablaRoles.Rows)
                        {
                            roles.Add(row[0].ToString());
                        }
                        RolesWindow rolesForm = new RolesWindow(roles);
                        rolesForm.ShowDialog();
                        rol = rolesForm.rolSeleccionado;
                    }
                    else
                    {
                        rol = tablaRoles.Rows[0][0].ToString();
                    }
                    List<SqlParameter> checkFuncionalidades = new List<SqlParameter>();
                    checkFuncionalidades.Add(new SqlParameter("rol", rol));
                    DataTable tablaFuncs = Database.GetInstance
                        .ExecuteQuery("[ClinicaTurbia].[CONSULTA_FUNCIONALIDADES]", checkFuncionalidades);
                    int leftOffset = 30;
                    int topOffset = 60;
                    foreach (DataRow row in tablaFuncs.Rows)
                    {
                        String nombreFunc = row[0].ToString();
                        //                switch (nombreFunc)
                        //                {
                        //                    case "ASD":
                        Button btn = new Button();
                        btn.Text = nombreFunc;
                        btn.Top = topOffset;
                        btn.Left = leftOffset;
                        btn.Width = (int) this.CreateGraphics().MeasureString(nombreFunc, btn.Font).Width;
                        this.Controls.Add(btn);
                        btn.Click += (ssender, args) =>
                        {
                            new AbmRolWindow().ShowDialog();
                        };
                        //                        break;
                        //                }
                        topOffset += 30;
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
    }
}
