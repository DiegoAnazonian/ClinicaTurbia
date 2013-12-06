using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clinica_Frba.NewFolder10;
using System.Data.SqlClient;

namespace Clinica_Frba.Registro_Resultado_Atencion
{
    public partial class RegistroResultado : Form
    {
        public RegistroResultado()
        {
            InitializeComponent();
            refrescarDatagrid();
        }

        private void gridTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3 || e.RowIndex == gridTurnos.Rows.Count - 1) 
            {
                return;
            }
            DataGridViewRow rou = gridTurnos.Rows[e.RowIndex];
            string[] horario = rou.Cells[2].Value.ToString().Split(":".ToCharArray());
            new RegistroAtencion(horario[0], horario[1], rou.Cells[0].Value.ToString(), rou.Cells[1].Value.ToString()).ShowDialog();
            refrescarDatagrid();
        }

        private void refrescarDatagrid()
        {
            List<SqlParameter> paramList = Database.GenerarListaDeParametros(
                    "fecha", Configuration.getFecha(), "dni", LoginWindow.LOGGED_USER);
            DataTable tabTur = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_TURNOS_DE_MEDICO_PARA_FECHA]", paramList);

            this.gridTurnos.Rows.Clear();

            foreach (DataRow rou in tabTur.Rows)
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                DataGridViewCell cellnumTurno = new DataGridViewTextBoxCell();
                cellnumTurno.Value = rou[4].ToString();
                DataGridViewCell cellNumAf = new DataGridViewTextBoxCell();
                cellNumAf.Value = rou[3].ToString();
                DataGridViewCell cellHora = new DataGridViewTextBoxCell();
                cellHora.Value = ((DateTime)rou[0]).ToString("HH:mm");
                tempRow.Cells.Add(cellnumTurno);
                tempRow.Cells.Add(cellNumAf);
                tempRow.Cells.Add(cellHora);
                gridTurnos.Rows.Add(tempRow);
            }
        }
    }
}
