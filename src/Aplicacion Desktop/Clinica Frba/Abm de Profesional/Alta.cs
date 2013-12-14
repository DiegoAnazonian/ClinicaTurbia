using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Clinica_Frba.Abm_de_Profesional
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
            calendario.Hide();
            llenarListEspecialidades();
        }

        private void agregarEspecialidad(String idEsp)
        {
            List<SqlParameter> espParam = Database.GenerarListaDeParametros(
                "dniDoc", this.dni.Text, "idEsp", int.Parse(idEsp),
                "agregar", true);
            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[MODIFICAR_ESPECIALIDADES_MEDICO]",
                espParam);
        }

        private void llenarListEspecialidades()
        {
            this.listEspecialidades.DataSource = null;
            this.listEspecialidades.Items.Clear();
            DataTable tablaEsp = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[LISTADO_ESPECIALIDAD]");
            this.listEspecialidades.DataSource = tablaEsp;
            this.listEspecialidades.DisplayMember = "ESP_DESCRIPCION";
            this.listEspecialidades.ValueMember = "ESP_CODIGO";
            this.listEspecialidades.SelectedIndices.Clear();
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            try{
            List<SqlParameter> parametros = Database.GenerarListaDeParametros(
                "dni", Convert.ToInt64(dni.Text), "nombre", nombre.Text, 
                "apellido", apellido.Text, "direccion", direccion.Text, 
                "telefono", Convert.ToInt64(telefono.Text), "mail", mail.Text, 
                "fecha", Convert.ToDateTime(fechaNacimiento.Text),
                "matricula", txtMatricula.Text);
                DataTable tablaMedicos = Database.GetInstance
                    .ExecuteQuery("[ClinicaTurbia].[AGREGAR_MEDICO]", parametros);
           
                for (int i = 0; i < listEspecialidades.Items.Count; i++)
                {
                    DataRowView item = (DataRowView)listEspecialidades.Items[i];
                    if (listEspecialidades.GetSelected(i))
                    {
                        agregarEspecialidad(item.Row["ESP_CODIGO"].ToString());
                    }
                }
                MessageBox.Show("El medico se ha creado exitosamente", "Clinica FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al crear el medico.\n Verifique que los datos obligatorios esten completos", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {
            guardar.Enabled = true;
        }

        private void dni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(dni.Text))
                {
                    Convert.ToInt64(dni.Text);
                }
            }
            catch (FormatException ex)
            {
                dni.Text = "";
            }
        }

        private void telefono_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(telefono.Text))
                {
                    Convert.ToInt64(telefono.Text);
                }
            }
            catch (FormatException ex)
            {
                telefono.Text = "";
            }
        }

        private void btnCale_Click(object sender, EventArgs e)
        {
            calendario.Show();
        }

        private void calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            fechaNacimiento.Text = calendario.SelectionStart.ToShortDateString();
            calendario.Hide();
            guardar.Enabled = true;

        }
        
    }
}
