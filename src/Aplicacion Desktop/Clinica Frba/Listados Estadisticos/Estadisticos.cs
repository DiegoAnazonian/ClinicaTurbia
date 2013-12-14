using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.Listados_Estadisticos
{
    public partial class Estadisticos : Form
    {
        private bool evitarAn = false;
        private bool evitarSem = false;

        public Estadisticos()
        {
            InitializeComponent();
            comboTop.Items.Add("Top 5 de especialidades que mas registraron cancelaciones");
            comboTop.Items.Add("Top 5 de bonos farmacia vencidos por afiliado");
            comboTop.Items.Add("Top 5 de especialidades con mas recetas realizadas");
            comboTop.Items.Add("Top 10 de afiliados que usaron bonos que ellos mismos no compraron");
            comboSem.Items.Add("Primero");
            comboSem.Items.Add("Segundo");
            for (int i = 2010; i < 2021; i++)
            {
                comboAn.Items.Add(i);
            }
            comboSem.SelectedItem = null;
            comboAn.SelectedItem = null;
            comboTop.SelectedItem = null;
            comboSem.Enabled = false;
            comboAn.Enabled = false;
        }

        private void comboTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboAn.Enabled = true;
            comboSem.Enabled = false;
            if (comboAn.SelectedItem != null)
            {
                evitarAn = true;
                comboAn.SelectedItem = null;
            }
            if (comboAn.SelectedItem != null)
            {
                evitarSem = true;
                comboSem.SelectedItem = null;
            }
        }

        private void ComboAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (evitarAn) { evitarAn = false;  return; }
            if (comboSem.SelectedItem != null)
            {
                evitarSem = true;
                comboSem.SelectedItem = null;
            }
            comboSem.Enabled = true;
        }

        private void comboSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (evitarSem) { evitarSem = false; return; }
            switch (comboTop.SelectedIndex)
            {
                case 0:
                    completarGrid(top5CancelacionesPorEspecialidad());
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void completarGrid(DataTable table)
        {
            dataGridView1.Rows.Clear();
            foreach (DataRow rou in table.Rows)
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                DataGridViewCell cell0 = new DataGridViewTextBoxCell();
                cell0.Value = rou[0].ToString();
                DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                cell1.Value = rou[1].ToString();
                DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                cell2.Value = rou[2].ToString();
                tempRow.Cells.Add(cell0);
                tempRow.Cells.Add(cell1);
                tempRow.Cells.Add(cell2);
                dataGridView1.Rows.Add(tempRow);
            }
            dataGridView1.Columns[0].HeaderText = table.Columns[0].ColumnName;
            dataGridView1.Columns[1].HeaderText = table.Columns[1].ColumnName;
            dataGridView1.Columns[2].HeaderText = table.Columns[2].ColumnName;
        }

        private DataTable top5BonosVencidos()
        {
            List<SqlParameter> listP = Database.GenerarListaDeParametros(
                "fechaActual", Configuration.getFecha(),
                "anio", comboAn.SelectedIndex + 2010, "semestre", comboSem.SelectedIndex + 1);
            return Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[TOP5_BONOS_VENCIDOS]", listP);
        }

        private DataTable top10BonosAjenos()
        {
            List<SqlParameter> listP = Database.GenerarListaDeParametros(
                "anio", comboAn.SelectedIndex + 2010, "semestre", comboSem.SelectedIndex + 1);
            return Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[TOP10_BONOS_AJENOS]", listP);
        }

        private DataTable top5RecetasPorEspecialidades()
        {
            List<SqlParameter> listP = Database.GenerarListaDeParametros(
                "anio", comboAn.SelectedIndex + 2010, "semestre", comboSem.SelectedIndex + 1);
            return Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[TOP5_RECETAS_POR_ESPECIALIDAD]", listP);
        }

        private DataTable top5CancelacionesPorEspecialidad()
        {
            List<SqlParameter> listP = Database.GenerarListaDeParametros(
                "anio", comboAn.SelectedIndex + 2010, "semestre", comboSem.SelectedIndex + 1);
            return Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[TOP5_ESPECIALIDADES_CANCELACIONES]", listP);
        }
    }
}
