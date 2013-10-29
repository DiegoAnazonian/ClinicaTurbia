using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            comboSexo.SelectedItem = "";
            //TIPO DOCUMENTO
            DataTable tablaTipoDoc = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[LISTADO_TIPO_DOCUMENTO]", Database.GenerarListaParametros());
            comboTipoDoc.DataSource = tablaTipoDoc;
            comboTipoDoc.DisplayMember = "TIDOC_NOMBRE";
            comboTipoDoc.SelectedItem = "";
            //ESTADO CIVIL
            DataTable tablaEstadoCivil = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[LISTADO_ESTADO_CIVIL]", Database.GenerarListaParametros());
            comboEstadoCivil.DataSource = tablaEstadoCivil;
            comboEstadoCivil.DisplayMember = "ECIVIL_NOMBRE";
            comboEstadoCivil.SelectedItem = "";
            //PLAN MEDICO
            DataTable tablaPlanMedico = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[LISTADO_PLAN_MEDICO]", Database.GenerarListaParametros());
            comboPlanMedico.DataSource = tablaPlanMedico;
            comboPlanMedico.DisplayMember = "PLAN_DESCRIPCION";
            comboPlanMedico.SelectedItem = "";
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
            btnSelecFecha.Enabled = false;
            txtDireccion.Text = rowAfiliado[7].ToString();
            txtDireccion.ReadOnly = true;
            txtDireccion.Enabled = false;
            txtTelefono.Text = rowAfiliado[8].ToString();
            txtTelefono.ReadOnly = true;
            txtTelefono.Enabled = false;
            txtMail.Text = rowAfiliado[9].ToString();
            txtMail.ReadOnly = true;
            txtMail.Enabled = false;
            comboPlanMedico.SelectedItem = rowAfiliado[11].ToString();
            comboPlanMedico.Enabled = false;
        }

        private void AbmAfiliadoWindow_Shown(object sender, EventArgs e)
        {
            if (!nuevoAfiliado)
            {
                MessageBox.Show("Verifique que sus datos esten completos y sean correctos");
            }
        }
    }
}
