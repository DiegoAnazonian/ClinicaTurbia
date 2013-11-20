using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.Cancelar_Atencion
{
    public partial class MotivoCancelacion : Form
    {

        long numTurno = -1;
        DateTime fechaCancelacion;
        string medico;

        public MotivoCancelacion(long numTurno)
        {
            InitializeComponent();
            DataTable tablaTipoCan = Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[LISTADO_TIPO_CANCELACION]");
            comboTipoCan.DataSource = tablaTipoCan;
            comboTipoCan.DisplayMember = "TICAN_NOMBRE";
            comboTipoCan.ValueMember = "TICAN_ID";
            this.numTurno = numTurno;
        }

        public MotivoCancelacion(string medico, DateTime fechaCan)
        {
            InitializeComponent();
            DataTable tablaTipoCan = Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[LISTADO_TIPO_CANCELACION]");
            comboTipoCan.DataSource = tablaTipoCan;
            comboTipoCan.DisplayMember = "TICAN_NOMBRE";
            comboTipoCan.ValueMember = "TICAN_ID";
            this.fechaCancelacion = fechaCan;
            this.medico = medico;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (numTurno != -1)
            {
                List<SqlParameter> paramList = Database.GenerarListaDeParametros(
                    "motivo", txtDescMotivo.Text, "tipoCan", comboTipoCan.SelectedValue,
                    "turno", this.numTurno);
                Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[CANCELAR_TURNO]", paramList);
                MessageBox.Show("Turno cancelado con exito",
                        "Cancelacion satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                List<SqlParameter> paramList = Database.GenerarListaDeParametros(
                    "motivo", txtDescMotivo.Text, "tipoCan", comboTipoCan.SelectedValue,
                    "fecha", this.fechaCancelacion, "med", this.medico);
                Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[CANCELAR_TURNOS_EN_FECHA]", paramList);
                MessageBox.Show("Turno cancelado con exito",
                        "Cancelacion satisfactoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
