using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class RolWindow : Form
    {
        private bool nuevoRol;
        private int idRolModificado;
        private string nombreRol;
        private bool habRol;
        private bool funcionesModificadas = false;
        private List<DataRowView> funcionesViejas = new List<DataRowView>();

        public RolWindow()
        {
            InitializeComponent();
            DataTable tablaUsuario = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[LISTADO_FUNCIONALIDADES]", new List<SqlParameter>());
            listFuncionalidades.DataSource = tablaUsuario;
            listFuncionalidades.DisplayMember = "FUN_NOMBRE";
            nuevoRol = true;
        }

        public RolWindow(String nombreRol, List<String> funcs, bool hab, int id)
        {
            InitializeComponent();
            this.nombreRol = nombreRol;
            this.habRol = hab;
            textNombreRol.Text = nombreRol;
            checkBoxHabilitado.Checked = hab;
            DataTable tablaUsuario = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[LISTADO_FUNCIONALIDADES]", new List<SqlParameter>());
            listFuncionalidades.DataSource = tablaUsuario;
            listFuncionalidades.DisplayMember = "FUN_NOMBRE";
            listFuncionalidades.SelectedItems.Clear();
            foreach(String nombreFunc in funcs)
            {
                if (listFuncionalidades.FindStringExact(nombreFunc, 0) != -1)
                {
                    int selectedIndex = listFuncionalidades.FindStringExact(nombreFunc, 0);
                    listFuncionalidades.SetSelected(selectedIndex, true);
                    funcionesViejas.Add((DataRowView)listFuncionalidades.Items[selectedIndex]);
                }
            }
            nuevoRol = false;
            idRolModificado = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nuevoRol)
            {
                List<SqlParameter> nuevoRolParams = new List<SqlParameter>();
                nuevoRolParams.Add(new SqlParameter("nombre", textNombreRol.Text));
                nuevoRolParams.Add(new SqlParameter("habilitado", checkBoxHabilitado.Checked));
                DataTable tablaRol = Database.GetInstance
                    .ExecuteQuery("[ClinicaTurbia].[NUEVO_ROL]", nuevoRolParams);
                int idNuevoRol = int.Parse(tablaRol.Rows[0][0].ToString());
                foreach (DataRowView item in listFuncionalidades.SelectedItems)
                {
                    List<SqlParameter> funcionalidadRolParam = new List<SqlParameter>();
                    funcionalidadRolParam.Add(new SqlParameter("idRol", idNuevoRol));
                    funcionalidadRolParam.Add(new SqlParameter("nombreFunc", item.Row[0].ToString()));
                    funcionalidadRolParam.Add(new SqlParameter("agregar", true));
                    Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[MODIFICAR_ROL]", funcionalidadRolParam);
                }
                this.Close();
            }
            else
            {
                if (this.habRol != checkBoxHabilitado.Checked || this.nombreRol != textNombreRol.Text)
                {
                    List<SqlParameter> rolModificadoParam = new List<SqlParameter>();
                    rolModificadoParam.Add(new SqlParameter("nombre", textNombreRol.Text));
                    rolModificadoParam.Add(new SqlParameter("habilitado", checkBoxHabilitado.Checked));
                    rolModificadoParam.Add(new SqlParameter("id", this.idRolModificado));
                    DataTable tablaRol = Database.GetInstance
                        .ExecuteQuery("[ClinicaTurbia].[MODIFICAR_ROL]", rolModificadoParam);
                }
                if (this.funcionesModificadas)
                {
                    for (int i = 0; i < listFuncionalidades.Items.Count; i++ )
                    {
                        DataRowView item = (DataRowView) listFuncionalidades.Items[i];
                        if (this.funcionesViejas.Contains(item) && !listFuncionalidades.GetSelected(i))
                        {
                            List<SqlParameter> funcionalidadRolParam = new List<SqlParameter>();
                            funcionalidadRolParam.Add(new SqlParameter("idRol", this.idRolModificado));
                            funcionalidadRolParam.Add(new SqlParameter("nombreFunc", item.Row[0].ToString()));
                            funcionalidadRolParam.Add(new SqlParameter("agregar", false));
                            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[MODIFICAR_FUNCIONES_ROL]", funcionalidadRolParam);
                        }
                        else if (!this.funcionesViejas.Contains(item) && listFuncionalidades.GetSelected(i))
                        {
                            List<SqlParameter> funcionalidadRolParam = new List<SqlParameter>();
                            funcionalidadRolParam.Add(new SqlParameter("idRol", this.idRolModificado));
                            funcionalidadRolParam.Add(new SqlParameter("nombreFunc", item.Row[0].ToString()));
                            funcionalidadRolParam.Add(new SqlParameter("agregar", true));
                            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[MODIFICAR_FUNCIONES_ROL]", funcionalidadRolParam);
                        }
                    }
                        
                }
            }
            this.Close();
        }

        private void listFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.funcionesModificadas = true;
        }

        private void refrescarLista()
        {

        }
    }
}
