using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.NewFolder10;

namespace Clinica_Frba.Generar_Receta
{
    public partial class GenerarReceta : Form
    {
        private string docAfiliado;
        List<string> listaMedicamentos = new List<string>();

        public GenerarReceta()
        {
            InitializeComponent();
            comboBono.Enabled = false;
            pnlPrincipal.Enabled = false;
            btnCambiar.Enabled = false;
            btnGenerar.Enabled = false;
            comboCant.Items.Add(1);
            comboCant.Items.Add(2);
            comboCant.Items.Add(3);
        }

        public GenerarReceta(string docAf)
        {
            InitializeComponent();
            this.docAfiliado = docAf;
            this.pnlPrincipal.Enabled = false;
            cargarComboBonos();
            pnlOpcional.Hide();
            comboCant.Items.Add(1);
            comboCant.Items.Add(2);
            comboCant.Items.Add(3);
            btnGenerar.Enabled = false;
            if (comboBono.Items.Count == 0) {
                MessageBox.Show("El afiliado no posee bonos farmacia");
                this.Close();
            }
        }

        private void comboBono_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pnlPrincipal.Enabled = true;
        }

        private void cargarComboBonos()
        {
            List<SqlParameter> paramList = Database.GenerarListaDeParametros(
                    "docAfiliado", this.docAfiliado, "fecha", Configuration.getFecha());
            DataTable tabBon = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_BONOS_FARMACIA_AFILIADO]", paramList);
            comboBono.DataSource = tabBon;
            comboBono.DisplayMember = "BONOFAR_ID";
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            this.docAfiliado = this.txtNumAf.Text;
            cargarComboBonos();
            txtNumAf.Enabled = false;
            btnCargar.Enabled = false;
            comboBono.Enabled = true;
            btnCambiar.Enabled = true;
            btnAgregar.Enabled = false;
            if (comboBono.Items.Count == 0)
            {
                MessageBox.Show("El afiliado no posee bonos de farmacia validos");
                this.Close();
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Enabled = false;
            gridReceta.Rows.Clear();
            btnCambiar.Enabled = false;
            btnCargar.Enabled = true;
            comboBono.Enabled = false;
            btnGenerar.Enabled = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rou in gridReceta.Rows)
            {
                List<SqlParameter> paramList = Database.GenerarListaDeParametros(
                       "bono", comboBono.Text, "medi", rou.Cells[0].Value.ToString(),
                       "cant", rou.Cells[1].Value.ToString(), "prof", LoginWindow.LOGGED_USER,
                       "fecha", Configuration.getFecha(), "pac", docAfiliado);
                DataTable tabBon = Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[GENERAR_RECETA]", paramList);
            }
            MessageBox.Show("Receta generada con exito");
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (listaMedicamentos.Contains(txtMedicamento.Text))
            {
                MessageBox.Show("No puede incluir mas de una vez el mismo medicamento en una receta");
                return;
            }
            if (txtMedicamento.Text.Length > 0)
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                DataGridViewCell cellMed = new DataGridViewTextBoxCell();
                cellMed.Value = txtMedicamento.Text;
                listaMedicamentos.Add(txtMedicamento.Text);
                DataGridViewCell cellCant = new DataGridViewTextBoxCell();
                cellCant.Value = comboCant.SelectedItem;
                tempRow.Cells.Add(cellMed);
                tempRow.Cells.Add(cellCant);
                gridReceta.Rows.Add(tempRow);
                txtMedicamento.Text = "";
                txtCantidadString.Text = "";
                btnGenerar.Enabled = true;
                btnAgregar.Enabled = false;
                comboCant.SelectedItem = null;
            }
            if (gridReceta.Rows.Count == 5)
            {
                btnAgregar.Enabled = false;
                comboCant.Enabled = false;
                txtMedicamento.Enabled = false;
            }
        }

        private void gridReceta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 2)
            {
                return;
            }
            listaMedicamentos.Remove(gridReceta.Rows[e.RowIndex].ToString());
            gridReceta.Rows.RemoveAt(e.RowIndex);
            if (gridReceta.Rows.Count > 0)
            {
                btnGenerar.Enabled = true;
            }
            else
            {
                btnGenerar.Enabled = false;
            }
            comboCant.Enabled = true;
            txtMedicamento.Enabled = true;
        }

        private void txtMedicamento_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidadString.Text.Length > 0)
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }

        private void comboCant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCant.SelectedItem == null)
            {
                return;
            }
            if ((int) comboCant.SelectedItem == 1)
            {
                txtCantidadString.Text = "Uno";
            }
            else if ((int)comboCant.SelectedItem == 2)
            {
                txtCantidadString.Text = "Dos";
            }
            else if ((int)comboCant.SelectedItem == 3)
            {
                txtCantidadString.Text = "Tres";
            }
            if (txtCantidadString.Text.Length > 0 && txtMedicamento.Text.Length > 0)
            {
                btnAgregar.Enabled = true;
            }
            else
            {
                btnAgregar.Enabled = false;
            }
        }
    }
}
