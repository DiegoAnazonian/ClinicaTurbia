using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.Abm_de_Especialidades_Medicas
{
    public partial class EspecialidadesWindow : Form
    {
        public EspecialidadesWindow()
        {
            InitializeComponent();
            DataTable tablaEsp = Database.GetInstance.ExecuteQuery(
               "[ClinicaTurbia].[LISTADO_ESPECIALIDAD]");
            foreach (DataRow datarow in tablaEsp.Rows)
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                DataGridViewCell cellNombreEsp = new DataGridViewTextBoxCell();
                cellNombreEsp.Value = datarow[0].ToString();
                DataGridViewCell cellTipoEsp = new DataGridViewTextBoxCell();
                cellTipoEsp.Value = datarow[1].ToString();
                tempRow.Cells.Add(cellNombreEsp);
                tempRow.Cells.Add(cellTipoEsp);
                dataGridView1.Rows.Add(tempRow);
            }
        }
    }
}
