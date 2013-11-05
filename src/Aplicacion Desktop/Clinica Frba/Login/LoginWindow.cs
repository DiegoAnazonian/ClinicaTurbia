using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Login;
using Clinica_Frba.Abm_de_Rol;
using Clinica_Frba.NewFolder12;
using Clinica_Frba.Abm_de_Especialidades_Medicas;
using Clinica_Frba.Abm_de_Profesional;

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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            List<SqlParameter> checkUsuarioParam = Database.GenerarListaDeParametros("usuario", txtUsuario.Text);
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
                if (!reg["USUARIO_PASSWORD"].ToString().Equals(txtPassword.Text))
                {
                    MessageBox.Show("Password incorrecta.\n", "Error de login",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnLogin.Enabled = true;
                    return;
                }
                else
                {
                    if ((bool)reg["USUARIO_PRIMER_LOGIN"])
                    {
                        List<SqlParameter> afiliadoParam = 
                            Database.GenerarListaDeParametros("dni", txtUsuario.Text);
                        DataTable tablaAfiliado = Database.GetInstance.ExecuteQuery
                            ("[ClinicaTurbia].[EXISTE_AFILIADO]", afiliadoParam);
                        if (tablaAfiliado.Rows.Count > 0)
                        {
                            //ES UN PACIENTE
                            new AbmAfiliadoWindow(tablaAfiliado).ShowDialog();
                        }
                        else
                        {
                            //DataTable tablaMedico = Database.GetInstance.ExecuteQuery
                            //("[ClinicaTurbia].[EXISTE_MEDICO]", afiliadoParam);
                            MessageBox.Show("Es un medico");

                        }
                    }
                    String rol = obtenerRolDelUsuario();
                    ocultarLoginYMostrarLogout(rol);
                    obtenerYMostrarFuncionesDeUnRol(rol);                    
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

        private void ocultarLoginYMostrarLogout(String nombreRol)
        {
            this.Text = "Clinica Turbia - " + nombreRol;
            panelLogin.Hide();
            Button btnLogout = new Button();
            btnLogout.Text = "Logout";
            btnLogout.Top = 10;
            btnLogout.Left = 525;
            btnLogout.Width = 100;
            btnLogout.Click += (otroSender, args) =>
            {
                logout();
            };
            this.Controls.Add(btnLogout);
        }

        /**
         * Retorna el nombre del rol seleccionado por el usuario.
         */
        private String obtenerRolDelUsuario()
        {
            List<SqlParameter> checkRolesParam = Database.GenerarListaDeParametros("usuario", txtUsuario.Text);
            DataTable tablaRoles = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[CONSULTA_ROLES_POR_USUARIO]", checkRolesParam);
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
            return rol;
        }

        private void obtenerYMostrarFuncionesDeUnRol(String rol)
        {
            List<SqlParameter> checkFuncionalidades = Database.GenerarListaDeParametros("rol", rol);
            DataTable tablaFuncs = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[CONSULTA_FUNCIONALIDADES_POR_ROL]", checkFuncionalidades);
            int leftOffset = 30;
            int topOffset = 60;
            foreach (DataRow row in tablaFuncs.Rows)
            {
                String nombreFunc = row[0].ToString();
                Button btn = new Button();
                btn.Text = nombreFunc;
                btn.Top = topOffset;
                btn.Left = leftOffset;
                int nombreFuncWidth = (int)this.CreateGraphics().MeasureString(nombreFunc, btn.Font).Width;
                btn.Width = nombreFuncWidth + 15;
                switch (nombreFunc)
                {
                    case "ABM de Roles":
                        btn.Click += (ssender, args) =>
                        {
                            new AbmRolWindow().ShowDialog();
                        };
                        break;
                    case "ABM de Afiliado":
                        btn.Click += (ssender, args) =>
                        {
                            new AbmAfiliadoWindow().ShowDialog();
                        };
                        break;
                    case "ABM de Especialidad":
                    btn.Click += (ssender, args) =>
                    {

                        new EspecialidadesWindow().ShowDialog();
                    };
                    break;
                    case "ABM de Profesional":
                    {
                        new AbmProfesional().ShowDialog();
                    }
                    break;
                }
                this.Controls.Add(btn);
                topOffset += 30;
            }
        }

        private void logout()
        {
            Panel panelLogin = this.panelLogin;
            this.Controls.Clear();
            this.Controls.Add(panelLogin);
            txtUsuario.Clear();
            txtPassword.Clear();
            this.Controls[0].Show();
        }
    }
}
