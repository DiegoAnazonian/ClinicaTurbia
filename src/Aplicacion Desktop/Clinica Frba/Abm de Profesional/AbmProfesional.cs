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
            alta.Click += new EventHandler(this.mostrarAlta);
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

        private void mostrarAlta(Object sender,EventArgs e)
        {
            MessageBox.Show("Muestro alta");
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

        private void medicosBox_Changed()
        {
            MessageBox.Show("HOLI");
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
        }
    }
}
