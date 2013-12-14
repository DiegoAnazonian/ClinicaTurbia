using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class CambioDePlan : Form
    {
        string planV;
        string planN;
        string pac;

        public CambioDePlan(string planViejo, string planNuevo, string paciente)
        {
            InitializeComponent();
            this.planN = planNuevo;
            this.planV = planViejo;
            this.pac = paciente;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[AGREGAR_HISTORICO_PLAN]", 
                Database.GenerarListaDeParametros("pac", this.pac, "planV", this.planV,
                "planN", this.planN, "fecha", Configuration.getFecha(), "motivo", textBox1.Text));
            this.Close();
        }
    }
}
