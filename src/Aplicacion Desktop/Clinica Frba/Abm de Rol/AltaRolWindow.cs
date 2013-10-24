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
    public partial class AltaRolWindow : Form
    {
        public AltaRolWindow()
        {
            InitializeComponent();
            DataTable tablaUsuario = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[LISTADO_FUNCIONALIDADES]", new List<SqlParameter>());
            listFuncionalidades.DataSource = tablaUsuario;
            listFuncionalidades.DisplayMember = "FUN_NOMBRE"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> nuevoRolParams = new List<SqlParameter>();
            nuevoRolParams.Add(new SqlParameter("nombre", textNombreRol.Text));
            nuevoRolParams.Add(new SqlParameter("habilitado", radioHabilitado.Checked));
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
        }
    }
}
