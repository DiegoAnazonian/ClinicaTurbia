using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Generar_Receta;

namespace Clinica_Frba.Registro_Resultado_Atencion
{
    public partial class RegistroAtencion : Form
    {
        public RegistroAtencion(string hora, string mins, string turno, string afiliado)
        {
            InitializeComponent();
            txtHora.Text = hora;
            txtMinutos.Text = mins;
            txtTurno.Text = turno;
            txtAfiliado.Text = afiliado;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            List<SqlParameter> paramList = Database.GenerarListaDeParametros(
                    "numTurno", txtTurno.Text, "sinto", txtSint.Text,
                    "enfe", txtEnf.Text);
            DataTable tabTur = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[REGISTRAR_ATENCION]", paramList);
            btnRegistrar.Enabled = false;
        }

        private void btnReceta_Click(object sender, EventArgs e)
        {
            new GenerarReceta(txtAfiliado.Text).ShowDialog();
        }
    }
}
