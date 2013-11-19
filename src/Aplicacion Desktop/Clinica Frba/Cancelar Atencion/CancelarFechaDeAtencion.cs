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
    public partial class CancelarFechaDeAtencion : Form
    {

        string medico;

        public CancelarFechaDeAtencion(string medico)
        {
            InitializeComponent();
            this.medico = medico;
            btnCancelar.Enabled = false;
            DateTime da = DateTime.ParseExact(Configuration.getFecha(),
                "dd/MM/yyyy", CultureInfo.CurrentCulture);
            DateTime today = DateTime.ParseExact(Configuration.getFecha(),
                "dd/MM/yyyy", CultureInfo.CurrentCulture);
            for (int i = 0; i < 120; i++)
            {
                if (!da.Equals(today))
                {
                    comboFechas.Items.Add(da.ToShortDateString());
                    da = da.AddDays(1);
                    if (da.DayOfWeek == 0)
                    {
                        da = da.AddDays(1);
                    }
                }
                else
                {
                    da = da.AddDays(1);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DateTime fechaCan = DateTime.ParseExact(
                comboFechas.SelectedItem.ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture);
            new MotivoCancelacion(this.medico, fechaCan).ShowDialog();
        }

        private void comboFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCancelar.Enabled = true;
        }
    }
}
