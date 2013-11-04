using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.NewFolder12
{
    public partial class AbmAfiliadoWindow : Form
    {
        private bool nuevoAfiliado;

        public AbmAfiliadoWindow()
        {
            InitializeComponent();
            nuevoAfiliado = true;
            completarCombos();
        }

        public AbmAfiliadoWindow(DataTable tablaAfiliado)
        {
            InitializeComponent();
            nuevoAfiliado = false;
            completarCombos();
            completarDatos(tablaAfiliado);
        }

        private void completarCombos()
        {
            //SEXO
            List<String> listaSexo = new List<String>(3);
            listaSexo.Add("Masculino");
            listaSexo.Add("Femenino");
            listaSexo.Add("Indefinido");
            comboSexo.DataSource = listaSexo;
            comboSexo.SelectedItem = null;
            //TIPO DOCUMENTO
            DataTable tablaTipoDoc = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[LISTADO_TIPO_DOCUMENTO]");
            comboTipoDoc.DataSource = tablaTipoDoc;
            comboTipoDoc.DisplayMember = "TIDOC_NOMBRE";
            comboTipoDoc.ValueMember = "TIDOC_ID";
            comboTipoDoc.SelectedItem = null;
            //ESTADO CIVIL
            DataTable tablaEstadoCivil = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[LISTADO_ESTADO_CIVIL]");
            comboEstadoCivil.DataSource = tablaEstadoCivil;
            comboEstadoCivil.DisplayMember = "ECIVIL_NOMBRE";
            comboEstadoCivil.ValueMember = "ECIVIL_ID";
            comboEstadoCivil.SelectedItem = null;
            //PLAN MEDICO
            DataTable tablaPlanMedico = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[LISTADO_PLAN_MEDICO]");
            comboPlanMedico.DataSource = tablaPlanMedico;
            comboPlanMedico.DisplayMember = "PLAN_DESCRIPCION";
            comboPlanMedico.ValueMember = "PLAN_CODIGO";
            comboPlanMedico.SelectedItem = null;
        }

        private void completarDatos(DataTable tablaAfiliado)
        {
            DataRow rowAfiliado = tablaAfiliado.Rows[0];
            txtNombre.Text = rowAfiliado[0].ToString();
            txtNombre.ReadOnly = true;
            txtNombre.Enabled = false;
            txtApellido.Text = rowAfiliado[1].ToString();
            txtApellido.ReadOnly = true;
            txtApellido.Enabled = false;
            txtNroDoc.Text = rowAfiliado[3].ToString();
            txtNroDoc.ReadOnly = true;
            txtNroDoc.Enabled = false;
            txtFechaNac.Text = rowAfiliado[5].ToString();
            txtFechaNac.ReadOnly = true;
            txtFechaNac.Enabled = false;
            btnSelecFecha.Hide();
            txtDireccion.Text = rowAfiliado[7].ToString();
            txtTelefono.Text = rowAfiliado[8].ToString();
            txtMail.Text = rowAfiliado[9].ToString();
            comboPlanMedico.SelectedIndex = comboPlanMedico.FindStringExact(rowAfiliado[11].ToString());
            if (rowAfiliado[4] != DBNull.Value)
            {
                comboSexo.SelectedIndex = comboSexo.FindString(rowAfiliado[4].ToString());
            }
            if (rowAfiliado[2] != DBNull.Value)
            {
                comboTipoDoc.SelectedIndex = (int) rowAfiliado[2] - 1;
            }
            if (rowAfiliado[6] != DBNull.Value)
            {
                comboEstadoCivil.SelectedIndex = (int) rowAfiliado[6] - 1;
            }
            //PAC_NOMBRE, PAC_APELLIDO, PAC_TIPO_DOCUMENTO, PAC_DNI, PAC_SEXO, PAC_FECHA_NACIMIENTO, 
		    //PAC_ESTADO_CIVIL, PAC_DIRECCION, PAC_TELEFONO, PAC_MAIL, PAC_CANT_HIJOS, PLAN_DESCRIPCION
            //if (rowAfiliado[9].ToString())
        }

        private void AbmAfiliadoWindow_Shown(object sender, EventArgs e)
        {
            if (!nuevoAfiliado)
            {
                MessageBox.Show("Verifique que sus datos esten completos y sean correctos.\n",
                    "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimipiar_Click(object sender, EventArgs e)
        {
            comboEstadoCivil.SelectedItem = null;
            comboPlanMedico.SelectedItem = null;
            comboSexo.SelectedItem = null;
            comboTipoDoc.SelectedItem = null;
            txtDireccion.Text = "";
            txtFamiliares.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
            if (nuevoAfiliado)
            {
                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtFechaNac.Text = "";
                txtApellido.Text = "";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (nuevoAfiliado)
            {
                //REGISTRAR NUEVO AFILIADO EN LA BASE DE PACIENTES Y DE USUARIOS
            }
            else
            {
                actualizarDatosDelAfiliado();
            }
        }

        private void actualizarDatosDelAfiliado()
        {
            String sexoAfiliado = comboSexo.SelectedItem != null ? 
                comboSexo.SelectedItem.ToString().Substring(0, 1) : null;
            List<SqlParameter> paramsAfiliado = Database.GenerarListaDeParametros(
                "tiDoc", comboTipoDoc.SelectedValue, "dire", txtDireccion.Text,
                "tel", txtTelefono.Text, "mail", txtMail.Text,
                "sexo", sexoAfiliado, "estCivil", comboEstadoCivil.SelectedValue, 
                "planMed", comboPlanMedico.SelectedValue, "cantFam", txtFamiliares.Text,
                "numDoc", txtNroDoc.Text);
            DataTable tablaPlanMedico = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[MODIFICAR_AFILIADO]", paramsAfiliado);
            this.Close();
        }
    }
}
