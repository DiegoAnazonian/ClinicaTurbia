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

namespace Clinica_Frba.Compra_de_Bono
{
    public partial class ComprarBono : Form
    {

        long planMedId;
        double costoBonoFarmacia;
        double costoBonoConsulta;
        bool initialized = false;
        bool afiliado;

        public ComprarBono(bool afiliado)
        {
            InitializeComponent();
            this.afiliado = afiliado;
            if (afiliado)
            {
                arreglarVentanaParaAfiliado();
            }
            for (int i = 0; i < 51; i++)
            {
                comboConsulta.Items.Add(i);
                comboFarmacia.Items.Add(i);
            }
            comboConsulta.SelectedIndex = 0;
            comboFarmacia.SelectedIndex = 0;
            txtMonto.Text = "0";
            initialized = true;
        }

        private void arreglarVentanaParaAfiliado()
        {
            btnValidar.Hide();
            lblNumAfiliado.Hide();
            txtNumAfiliado.Hide();
            panelAfiliado.Top = panelAfiliado.Top - 35;
            panelAfiliado.Enabled = true;
            DataTable tablePlan = Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[COSTO_BONOS_PACIENTE]",
                Database.GenerarListaDeParametros("pacDoc", /*LoginWindow.LOGGED_USER*/ 1113058));
            this.planMedId = long.Parse(tablePlan.Rows[0][0].ToString());
            this.costoBonoConsulta = double.Parse(tablePlan.Rows[0][1].ToString());
            this.costoBonoFarmacia = double.Parse(tablePlan.Rows[0][2].ToString());
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            List<SqlParameter> paramlist = Database.GenerarListaDeParametros(
                "cantCon", comboConsulta.SelectedIndex, "cantFar", comboFarmacia.SelectedIndex,
                "monto", txtMonto.Text, "fecha", Configuration.getFecha(), "plan", this.planMedId);
            if (this.afiliado)
            {
                paramlist.Add(new SqlParameter("pacDoc", LoginWindow.LOGGED_USER));
            }
            else
            {
                paramlist.Add(new SqlParameter("numAf", txtNumAfiliado.Text));
            }
            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[COMPRAR_BONO]",
                paramlist);
            MessageBox.Show("Bonos comprados con exito",
                        "Transaccion satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            DataTable tablePlan = Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[COSTO_BONOS_PACIENTE]",
                Database.GenerarListaDeParametros("numAf", txtNumAfiliado.Text));
            if (tablePlan.Rows.Count > 0)
            {
                this.planMedId = long.Parse(tablePlan.Rows[0][0].ToString());
                this.costoBonoConsulta = double.Parse(tablePlan.Rows[0][1].ToString());
                this.costoBonoFarmacia = double.Parse(tablePlan.Rows[0][2].ToString());
                panelAfiliado.Enabled = true;
            }
            else
            {
                MessageBox.Show("No existe un afiliado con numero " + txtNumAfiliado.Text,
                        "Validacion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialized)
            {
                double montoTotal = double.Parse(comboConsulta.Text) * this.costoBonoConsulta;
                montoTotal += double.Parse(comboFarmacia.Text) * this.costoBonoFarmacia;
                txtMonto.Text = montoTotal.ToString();
            }
        }

        private void comboFarmacia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initialized)
            {
                double montoTotal = double.Parse(comboConsulta.Text) * this.costoBonoConsulta;
                montoTotal += double.Parse(comboFarmacia.Text) * this.costoBonoFarmacia;
                txtMonto.Text = montoTotal.ToString();
            }
        }
    }
}