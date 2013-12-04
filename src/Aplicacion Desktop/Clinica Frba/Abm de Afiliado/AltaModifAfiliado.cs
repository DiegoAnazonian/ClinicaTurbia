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
    public partial class AltaModifAfiliado : Form
    {
        private bool nuevoAfiliado;
        private bool btnGuardarClicked = false;
        private bool owner;
        private static int indexAfiliado = 3;
        private static String codigoAfiliadoPrincipal;
        private static String endPointAfiliado = "01";
        private String nombreACargo;
        private String apellidoACargo;
        private long cantidadFamiliares;
        

        public AltaModifAfiliado(Boolean conFamiliares)
        {
            InitializeComponent();
            nuevoAfiliado = true;
            completarCombos();
            botonesFamiliares(false);
            

            if (conFamiliares)
            {
                this.botonesFamiliares(true);
                this.agregarDatosComboFamiliar();
            }
        }

        public AltaModifAfiliado(DataTable tablaAfiliado, bool owner)
        {
            InitializeComponent();
            nuevoAfiliado = false;
            this.owner = owner;
            completarCombos();
            completarDatos(tablaAfiliado);
            botonesFamiliares(false);
            codigoAfiliadoPrincipal = null;
            
        }

        private void agregarDatosComboFamiliar(){
            List<String> tipoFamiliares = new List<string>();

            tipoFamiliares.Add("Conyuge");
            tipoFamiliares.Add("Hijo");
            tipoFamiliares.Add("Hija");
            tipoFamiliares.Add("Otro Familiar");

            familiares.DataSource = tipoFamiliares;
        }

        private void botonesFamiliares(Boolean quieroAgregar)
        {
            
            
            if (quieroAgregar)
            {
                
                familiares.Visible = true;
            }
            else
            {
                
                familiares.Visible = false;
            }
            
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
        }

        private void AbmAfiliadoWindow_Shown(object sender, EventArgs e)
        {
            if (!nuevoAfiliado && owner)
            {
                MessageBox.Show("Verifique que sus datos esten completos y sean correctos.\n",
                    "Verifique sus datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimipiar_Click(object sender, EventArgs e)
        {
            comboEstadoCivil.SelectedItem = null;
            comboSexo.SelectedItem = null;
            comboTipoDoc.SelectedItem = null;
            txtDireccion.Text = "";
            txtFamiliares.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
            if (nuevoAfiliado)
            {
                comboPlanMedico.SelectedItem = null;
                txtNroDoc.Text = "";
                txtNombre.Text = "";
                txtFechaNac.Text = "";
                txtApellido.Text = "";
            }
        }

        private void asDefault()
        {
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtNroDoc.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtMail.Text = "";
            txtFechaNac.Text = "";
            comboEstadoCivil.SelectedItem = null;
            comboSexo.SelectedItem = null;
            comboTipoDoc.SelectedItem = null;
            comboPlanMedico.SelectedItem = null;
            txtFamiliares.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardarClicked = true;
            if (nuevoAfiliado)
            {
                
                    registrarNuevoAfiliado();
                
                if (!String.IsNullOrEmpty(txtFamiliares.Text))
                {
                    codigoAfiliadoPrincipal = txtNroDoc.Text;
                    nombreACargo = txtNombre.Text;
                    apellidoACargo = txtApellido.Text;
                    this.botonesFamiliares(true);
                    this.agregarDatosComboFamiliar();

                    for(int i = 0;i<cantidadFamiliares;i++)
                    {
                        new AltaModifAfiliado(true).ShowDialog();
                        this.Close();
                    }
                    this.Close();
                }
            }
            else
            {
                actualizarDatosDelAfiliado();
            }
        }

        private void actualizarDatosDelAfiliado()
        {
            if (hayCamposVacios())
            {
                var confirmResult = MessageBox.Show(
                    "Algunos de sus datos estan incompletos, desea continuar de todas formas?",
                    "Hay datos incompletos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmResult == DialogResult.No)
                {
                    btnGuardarClicked = false;
                    return;
                }
            }
            String sexoAfiliado = comboSexo.SelectedItem != null ? 
                comboSexo.SelectedItem.ToString().Substring(0, 1) : null;
            
            List<SqlParameter> paramsAfiliado = Database.GenerarListaDeParametros(
                "tiDoc", comboTipoDoc.SelectedValue, "dire", txtDireccion.Text,
                "tel", Convert.ToInt64(txtTelefono.Text), "mail", txtMail.Text, "sexo", sexoAfiliado,
                "estCivil", comboEstadoCivil.SelectedValue, "cantFam", txtFamiliares.Text, 
                "planMed", comboPlanMedico.SelectedValue, "numDoc", Convert.ToInt64(txtNroDoc.Text));
            DataTable tablaPlanMedico = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[MODIFICAR_AFILIADO]", paramsAfiliado);
            List<SqlParameter> paramsPrimerLogeo = Database.GenerarListaDeParametros(
                "numDoc", txtNroDoc.Text);
            Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[PRIMER_LOGIN_USUARIO]", paramsPrimerLogeo);
            this.Close();
        }

        private void registrarNuevoAfiliado()
        {

            ocultarMarcasDeFaltanDatos();
            if (faltanDatosObligatorios())
            {
                MessageBox.Show("Debe completar todos los datos obligatorios",
                    "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGuardarClicked = false;
                return;
            }
            if (hayCamposVacios())
            {
                var confirmResult = MessageBox.Show(
                    "Algunos de sus datos estan incompletos, desea continuar de todas formas?",
                    "Hay datos incompletos", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmResult == DialogResult.No)
                {
                    btnGuardarClicked = false;
                    return;
                }
            }

            try
            {
                String codigoNuevoAfiliado;
                if (!String.IsNullOrEmpty(codigoAfiliadoPrincipal))
                {

                    String familiar = familiares.SelectedItem.ToString();
                    if (familiar.Equals("Conyuge"))
                    {
                        
                        endPointAfiliado = "02";
                    }
                    else
                    {
                        
                        endPointAfiliado = Convert.ToString(0) + Convert.ToString(indexAfiliado);
                        indexAfiliado++;
                    }

                    codigoNuevoAfiliado = String.Concat(codigoAfiliadoPrincipal, endPointAfiliado);
                    
                }
                else
                {
                    
                    codigoNuevoAfiliado = String.Concat(txtNroDoc.Text, "01");
                    MessageBox.Show("Es un nuevo afiliado ",codigoNuevoAfiliado);
                }

                String sexoAfiliado = comboSexo.SelectedItem != null ?
                    comboSexo.SelectedItem.ToString().Substring(0, 1) : null;
                

                List<SqlParameter> paramsAfiliado = Database.GenerarListaDeParametros(
                    "nom", txtNombre.Text, "ape", txtApellido.Text, "fecha", Convert.ToDateTime(txtFechaNac.Text),
                    "tiDoc", comboTipoDoc.SelectedValue, "dire", txtDireccion.Text,
                    "tel", Convert.ToInt64(txtTelefono.Text), "mail", txtMail.Text, "sexo", sexoAfiliado,
                    "estCivil", comboEstadoCivil.SelectedValue, "cantFam", txtFamiliares.Text,
                    "planMed", comboPlanMedico.SelectedValue, "numDoc", Convert.ToInt64(txtNroDoc.Text), "numeroAfiliado", codigoNuevoAfiliado.ToString());

                DataTable tablaPlanMedico = Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[CREAR_AFILIADO]", paramsAfiliado);
                MessageBox.Show("El afiliado " +  txtNombre.Text + "," + txtApellido.Text +" se ha guardado correctamente. Su Codigo de afiliado es: " + codigoNuevoAfiliado, "Clinica Turbia FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {

                MessageBox.Show("Problemas al guardar el afiliado, error: " + e);   
            }
            
            
            }


        private bool hayCamposVacios()
        {
            if (comboSexo.SelectedItem == null)
            {
                return true;
            }
            if (comboEstadoCivil.SelectedItem == null)
            {
                return true;
            }
            if (comboTipoDoc.SelectedItem == null)
            {
                return true;
            }
            if ("".Equals(txtDireccion.Text))
            {
                return true;
            }
            if ("".Equals(txtFamiliares.Text))
            {
                return true;
            }
            if ("".Equals(txtMail.Text))
            {
                return true;
            }
            if ("".Equals(txtTelefono.Text))
            {
                return true;
            }
            return false;
        }

        /**
         * Retorna false si hay datos obligatorios sin completar, de lo contrario retorna true.
         */
        private bool faltanDatosObligatorios()
        {
            bool incompleto = false;
            if ("".Equals(txtNroDoc.Text))
            {
                incompleto = true;
                lblNroDocInc.Show();
            }
            if ("".Equals(txtNombre.Text))
            {
                incompleto = true;
                lblNombreInc.Show();
            }
            if ("".Equals(txtApellido.Text))
            {
                incompleto = true;
                lblApellidoInc.Show();
            }
            if ("".Equals(txtFechaNac.Text))
            {
                incompleto = true;
                lblFechaInc.Show();
            }
            if (comboPlanMedico.SelectedItem == null)
            {
                incompleto = true;
                lblPlanInc.Show();
            }
            return incompleto;
        }

        private void ocultarMarcasDeFaltanDatos()
        {
            lblPlanInc.Hide();
            lblNroDocInc.Hide();
            lblNombreInc.Hide();
            lblFechaInc.Hide();
            lblApellidoInc.Hide();
        }

        private void btnSelecFecha_Click(object sender, EventArgs e)
        {
            calendarNac.Show();
        }

        private void calendarNac_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaNac.Text = calendarNac.SelectionStart.ToShortDateString();
            calendarNac.Hide();
        }

        private void AbmAfiliadoWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnGuardarClicked)
            {
                btnGuardarClicked = false;
                var confirmResult = MessageBox.Show(
                    "Sus cambios no seran guardados, desea salir de todas formas?",
                    "Salir?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmResult == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
           
        }

        private void txtFamiliares_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFamiliares.Text))
            {
                cantidadFamiliares = Convert.ToInt64(txtFamiliares.Text);
            }
        }

       

        

        

        

       

    }
}
