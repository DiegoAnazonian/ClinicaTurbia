using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class AbmProfesional : Form
    {
        

        public AbmProfesional()
        {

            InitializeComponent();
            limpiar.Click += new EventHandler(this.modoDefecto);
            medicosBox.Click += new EventHandler(this.activarBotones);
            this.ActiveControl = palabraClave;
            
            DataTable medicos = this.traerTodosLosMedicos();
            this.llenarCheckedBoxMedicos(medicos);
            this.cambiarNombreColumnas();
            
        }

        private void activarBotones(Object sender, EventArgs e)
        {
            baja.Enabled = true;
            modificar.Enabled = true;
        }

        private void cambiarNombreColumnas()
        {   
            
            this.medicosBox.Columns[0].HeaderText = "DNI";
            this.medicosBox.Columns[1].HeaderText = "NOMBRE";
            this.medicosBox.Columns[2].HeaderText = "APELLIDO";
            this.medicosBox.Columns[3].HeaderText = "DIRECCION";
            this.medicosBox.Columns[4].HeaderText = "TELEFONO";
            this.medicosBox.Columns[5].HeaderText = "MAIL";
            this.medicosBox.Columns[6].HeaderText = "FECHA NACIMIENTO";
            
        }

       
        private void palabraClave_Click(object sender, EventArgs e)
        {
            
        }


        private void llenarCheckedBoxMedicos(DataTable medicos)
        {
            cantidadMedicos.Text = new StringConverter().ConvertToString(medicos.Rows.Count);
            this.medicosBox.DataSource = medicos;
            
        }

        private DataTable traerTodosLosMedicos(){
            return Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[TRAER_TODOS_MEDICOS]");        
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void medicosBox_Click(object sender, EventArgs e)
        {
            
            
        }
        private void modoDefecto(object sender, EventArgs e)
        {
            baja.Enabled = false;
            modificar.Enabled = false;
            nombre.Clear();
            apellido.Clear();
            dni.Clear();
            palabraClave.Clear();
            direccion.Clear();
            
        }
        private void palabraClave_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> nomParcial = Database.GenerarListaDeParametros("nombreParcial", palabraClave.Text);
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_POR_NOMBRE_MEDICO]", nomParcial);

            this.llenarCheckedBoxMedicos(tablaMedicos);
        }


        private void alta_OnClick(object sender, EventArgs e)
        {
            
        }

        private void medicosBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.modificar.Enabled = true;
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> nomParcial = Database.GenerarListaDeParametros("nombre", nombre.Text);
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_X_NOMBRE]", nomParcial);
            this.llenarCheckedBoxMedicos(tablaMedicos);
        }

        private void refrescarTabla()
        {
            List<SqlParameter> nomParcial = Database.GenerarListaDeParametros("nombreParcial", "");
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_POR_NOMBRE_MEDICO]", nomParcial);

            this.llenarCheckedBoxMedicos(tablaMedicos);
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            

            persona.dni = Convert.ToInt64(medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[0].Value);
            persona.nombre = medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[1].Value.ToString();
            persona.apellido = medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[2].Value.ToString();
            persona.direccion = medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[3].Value.ToString();
            persona.telefono = Convert.ToInt64(medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[4].Value);
            persona.mail = medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[5].Value.ToString();
            persona.fecha = (DateTime) medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[6].Value;

            new Modificar(persona).ShowDialog();
            this.asDefault();

        }

        private void buscar_Click(object sender, EventArgs e)
        {


        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void apellido_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> apeParcial = Database.GenerarListaDeParametros("apellido", apellido.Text);
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_X_APELLIDO]", apeParcial);
            this.llenarCheckedBoxMedicos(tablaMedicos);
        }

        private void dni_TextChanged(object sender, EventArgs e)
        {
                        
            List<SqlParameter> dniParcial = Database.GenerarListaDeParametros("dni", this.dni.Text);
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_X_DNI]", dniParcial);
            this.llenarCheckedBoxMedicos(tablaMedicos);

        }

        private void direccion_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> direParcial = Database.GenerarListaDeParametros("direccion", direccion.Text);
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_X_DIRECCION]", direParcial);
            this.llenarCheckedBoxMedicos(tablaMedicos);
        }

        private void medicosBox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void alta_Click(object sender, EventArgs e)
        {
            new Alta().ShowDialog();
            this.asDefault();
        }

        private void eliminarMedico(long documento)
        {
            try
            {
                List<SqlParameter> parametros = Database.GenerarListaDeParametros("dni", Convert.ToInt64(documento));
                DataTable tablaMedicos = Database.GetInstance
                    .ExecuteQuery("[ClinicaTurbia].[BORRAR_MEDICO]", parametros);
                MessageBox.Show("El medico se ha eliminado exitosamente", "Clinica FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probelmas al eliminar el medico", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.refrescarTabla();

        }

        private void asDefault()
        {
            this.modificar.Enabled = false;
            this.baja.Enabled = false;
            this.refrescarTabla();
        }

        private void baja_Click(object sender, EventArgs e)
        {
            long documento = Convert.ToInt64(medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[0].Value);
            string nom = Convert.ToString(medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[1].Value);
            string ape = Convert.ToString(medicosBox.Rows[medicosBox.CurrentRow.Index].Cells[2].Value);

            if(MessageBox.Show("Seguro desea eliminar a " + ape + ", " + nom + ".\n DNI: " + documento + "", "ClinicaTurbia FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.eliminarMedico(documento);
            }

            this.asDefault();
        }

        private void AbmProfesional_Load(object sender, EventArgs e)
        {

        }
    }
}
