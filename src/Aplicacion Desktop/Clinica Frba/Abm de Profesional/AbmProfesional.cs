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
            this.ActiveControl = searchBox;
            InitializeComponent();
            DataTable medicos = this.traerTodosLosMedicos();
            this.llenarCheckedBoxMedicos(medicos);
            
        }

        private void searchBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
        }

        private void searchBox_KeyDown(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
            List<SqlParameter> nomParcial = Database.GenerarListaDeParametros("nombreParcial", searchBox.Text);
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_POR_NOMBRE_MEDICO]", nomParcial);
            
            this.llenarCheckedBoxMedicos(tablaMedicos);
        }
        private void llenarCheckedBoxMedicos(DataTable medicos)
        {
            List<String> medNombres = new List<string>();

            foreach(DataRow reg in medicos.Rows){

                medNombres.Add(reg["MED_NOMBRE"].ToString() +" "+ reg["MED_APELLIDO"].ToString().ToUpper());
                
            }
            
            this.medicosBox.DataSource = medNombres;
        }

        private DataTable traerTodosLosMedicos(){
            return Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[TRAER_TODOS_MEDICOS]");        
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> nomParcial = Database.GenerarListaDeParametros("nombreParcial", searchBox.Text);
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_POR_NOMBRE_MEDICO]", nomParcial);

            this.llenarCheckedBoxMedicos(tablaMedicos);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
