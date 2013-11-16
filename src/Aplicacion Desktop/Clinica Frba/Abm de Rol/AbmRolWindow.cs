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
    public partial class AbmRolWindow : Form
    {
        public AbmRolWindow()
        {
            InitializeComponent();
            dataGridRoles.AllowUserToAddRows = false;
            refrescarDatagrid();        
        }

        private void dataGridRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                return;
            }
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;
            String nombreRol = dataGridRoles.Rows.SharedRow(rowIndex).Cells[0].Value.ToString();
            if (columnIndex == 2)
            {
                modificarRol(nombreRol, rowIndex);
            }
            else if (columnIndex == 1)
            {
                eliminarRol(rowIndex);
            }
            refrescarDatagrid();
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            new DetallesRolWindow().ShowDialog();
            refrescarDatagrid();
        }

        private void refrescarDatagrid()
        {
            dataGridRoles.Rows.Clear();
            DataTable tablaUsuario = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[LISTADO_ROLES]");
            foreach (DataRow datarow in tablaUsuario.Rows)
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                DataGridViewCell cellRolName = new DataGridViewTextBoxCell();
                cellRolName.Value = datarow[1].ToString();
                tempRow.Tag = new Rol_Id_Habilitado(int.Parse(datarow[0].ToString()), bool.Parse(datarow[2].ToString()));
                tempRow.Cells.Add(cellRolName);
                dataGridRoles.Rows.Add(tempRow);
            }
        }

        private void modificarRol(String nombreRol, int rowIndex)
        {
            Rol_Id_Habilitado idHab = (Rol_Id_Habilitado) dataGridRoles.Rows.SharedRow(rowIndex).Tag;
            List<SqlParameter> checkFuncionalidades = Database.GenerarListaDeParametros("rol", nombreRol);
            DataTable tablaFuncsRol = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[CONSULTA_FUNCIONALIDADES_POR_ROL]", checkFuncionalidades);
            List<String> funcsRol = new List<String>();
            foreach (DataRow row in tablaFuncsRol.Rows)
            {
                funcsRol.Add(row[0].ToString());
            }
            new DetallesRolWindow(nombreRol, funcsRol, idHab.habilitado, idHab.id).ShowDialog();
        }

        private void eliminarRol(int rowIndex)
        {
            int id = ((Rol_Id_Habilitado)dataGridRoles.Rows.SharedRow(rowIndex).Tag).id;
            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[ELIMINAR_ROL]",
                Database.GenerarListaDeParametros("id", id));
        }
    }
}
