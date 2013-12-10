using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class CancelarTurno : Form
    {
        string paciente;

        public CancelarTurno(String paciente)
        {
            InitializeComponent();
            this.paciente = paciente;
            refrescarGridTurnos();
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            if (turnosGrid.SelectedRows.Count > 0)
            {
                long numTurno = long.Parse(turnosGrid.SelectedRows[0].Cells[0].Value.ToString());
                new MotivoCancelacion(numTurno).ShowDialog();
            }
            else if (turnosGrid.SelectedCells.Count > 0)
            {
                int rowIndex = turnosGrid.SelectedCells[0].RowIndex;
                long numTurno = long.Parse(turnosGrid.Rows[rowIndex].Cells[0].Value.ToString());
                new MotivoCancelacion(numTurno).ShowDialog();
                refrescarGridTurnos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un turno de la tabla",
                    "Seleccione un turno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void refrescarGridTurnos()
        {
            turnosGrid.Rows.Clear();
            DataTable tablaTurnos = Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[LISTADO_TURNOS_PACIENTE]",
                Database.GenerarListaDeParametros("pac", paciente, "fecha", Configuration.getFecha()));
            string today = Configuration.getFecha();
            for (int i = tablaTurnos.Rows.Count - 1; i >= 0; i--)
            {
                string fechaTurno = tablaTurnos.Rows[i]["FECHA"].ToString().Substring(0, 10);
                if (fechaTurno.Equals(today))
                {
                    tablaTurnos.Rows.RemoveAt(i);
                }
            }
            turnosGrid.DataSource = tablaTurnos;
        }
    }
}
