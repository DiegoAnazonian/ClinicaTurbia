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
    public partial class Alta : Form
    {
        public Alta()
        {
            
            InitializeComponent();
            this.fechaNacimiento.GotFocus += new EventHandler(this.gotFocus);
            this.fechaNacimiento.LostFocus += new EventHandler(this.lostFocus);
            this.fechaNacimiento.Text = "dd/mm/aaaa";
            

        }

        private void lostFocus(object sender, EventArgs e)
        {
            if (this.fechaNacimiento.Text.Equals(""))
            {
                this.fechaNacimiento.Text = ("dd/mm/aaaa");
            }
        }

        private void gotFocus(object sender, EventArgs e)
        {
            if (this.fechaNacimiento.Text.Equals("dd/mm/aaaa") || this.fechaNacimiento.Text.Equals(""))
            {
                this.fechaNacimiento.Text = "";
            }
        }

        private void fechaNacimiento_GotFocus(object sender, EventArgs e)
        {
            this.fechaNacimiento.Text = "";
            this.fechaNacimiento.ForeColor = System.Drawing.Color.Black;
        }

        private void fechaNacimiento_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            try{
            List<SqlParameter> parametros = Database.GenerarListaDeParametros("dni", Convert.ToInt64(dni.Text), "nombre", nombre.Text, "apellido", apellido.Text, "direccion", direccion.Text, "telefono", Convert.ToInt64(telefono.Text), "mail", mail.Text, "fecha", Convert.ToDateTime(fechaNacimiento.Text));
                DataTable tablaMedicos = Database.GetInstance
                    .ExecuteQuery("[ClinicaTurbia].[AGREGAR_MEDICO]", parametros);
                MessageBox.Show("El medico se ha modificado exitosamente", "Clinica FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al modificar el medico","Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        
    }
}
