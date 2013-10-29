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
    public partial class DetallesRolWindow : Form
    {
        private bool esNuevoRol;
        private int idRol;
        private string nombreRol;
        private bool habRol;
        private bool funcionesFueronModificadas = false;
        private List<DataRowView> funcionesViejas = new List<DataRowView>();

        /**
         * Constructor de ventana para generar un nuevo rol.
         */
        public DetallesRolWindow()
        {
            InitializeComponent();
            DataTable tablaUsuario = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[LISTADO_FUNCIONALIDADES]", Database.GenerarListaDeParametros());
            listFuncionalidades.DataSource = tablaUsuario;
            listFuncionalidades.DisplayMember = "FUN_NOMBRE";
            esNuevoRol = true;
        }

        /**
         * Constructor de ventana para modificar un rol ya creado.
         */
        public DetallesRolWindow(String nombreRol, List<String> funcs, bool hab, int id)
        {
            InitializeComponent();
            this.nombreRol = nombreRol;
            this.habRol = hab;
            this.esNuevoRol = false;
            this.idRol = id;
            textNombreRol.Text = nombreRol;
            checkBoxHabilitado.Checked = hab;
            DataTable tablaUsuario = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[LISTADO_FUNCIONALIDADES]", Database.GenerarListaDeParametros());
            listFuncionalidades.DataSource = tablaUsuario;
            listFuncionalidades.DisplayMember = "FUN_NOMBRE";
            listFuncionalidades.SelectedItems.Clear();
            foreach (String nombreFunc in funcs)
            {
                if (listFuncionalidades.FindStringExact(nombreFunc, 0) != -1)
                {
                    int selectedIndex = listFuncionalidades.FindStringExact(nombreFunc, 0);
                    listFuncionalidades.SetSelected(selectedIndex, true);
                    this.funcionesViejas.Add((DataRowView)listFuncionalidades.Items[selectedIndex]);
                }
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (esNuevoRol)
            {
                crearRol();
                this.Close();
            }
            else
            {
                if (this.habRol != checkBoxHabilitado.Checked || this.nombreRol != textNombreRol.Text)
                {
                    modificarNombreYHabilitado();
                }
                if (this.funcionesFueronModificadas)
                {
                    for (int i = 0; i < listFuncionalidades.Items.Count; i++)
                    {
                        DataRowView item = (DataRowView)listFuncionalidades.Items[i];
                        if (this.funcionesViejas.Contains(item) && !listFuncionalidades.GetSelected(i))
                        {
                            quitarFuncionalidad(item.Row[0].ToString());
                        }
                        else if (!this.funcionesViejas.Contains(item) && listFuncionalidades.GetSelected(i))
                        {
                            agregarFuncionalidad(item.Row[0].ToString());
                        }
                    }
                }
            }
            this.Close();
        }

        private void listFuncionalidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.funcionesFueronModificadas = true;
        }

        private void crearRol()
        {
            List<SqlParameter> nuevoRolParams = Database.GenerarListaDeParametros(
                    "nombre", textNombreRol.Text, "habilitado", checkBoxHabilitado.Checked);
            DataTable tablaRol = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[NUEVO_ROL]", nuevoRolParams);
            this.idRol = int.Parse(tablaRol.Rows[0][0].ToString());
            foreach (DataRowView item in listFuncionalidades.SelectedItems)
            {
                agregarFuncionalidad(item.Row[0].ToString());
            }
        }

        private void modificarNombreYHabilitado()
        {
            List<SqlParameter> rolModificadoParam = Database.GenerarListaDeParametros(
                        "nombre", textNombreRol.Text, "habilitado", checkBoxHabilitado.Checked,
                        "id", this.idRol);
            DataTable tablaRol = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[MODIFICAR_ROL]", rolModificadoParam);
        }

        private void quitarFuncionalidad(String idFunc)
        {
            List<SqlParameter> funcionalidadRolParam = Database.GenerarListaDeParametros(
                                "idRol", this.idRol, "idFunc", int.Parse(idFunc), "agregar", false);
            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[MODIFICAR_FUNCIONES_ROL]", funcionalidadRolParam);
        }

        private void agregarFuncionalidad(String idFunc)
        {
            List<SqlParameter> funcionalidadRolParam = Database.GenerarListaDeParametros(
                                "idRol", this.idRol, "idFunc", int.Parse(idFunc), "agregar", true);
            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[MODIFICAR_FUNCIONES_ROL]", funcionalidadRolParam);
        }
    }
}
