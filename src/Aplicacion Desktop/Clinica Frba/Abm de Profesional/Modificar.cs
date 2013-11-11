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
    public partial class Modificar : Form
    {
        private Persona persona;

        public Modificar(Persona persona)
        {
            InitializeComponent();
            this.llenarTabla(persona);
            this.guardar.Enabled = false;
        }

        public void llenarTabla(Persona persona)
        {
            this.persona = persona;

            nombre.Text = persona.nombre.ToString();
            apellido.Text = persona.apellido.ToString();
            dni.Text = persona.dni.ToString();
            telefono.Text = persona.telefono.ToString();
            direccion.Text = persona.direccion.ToString();
            fecha_nacimiento.Text = persona.fecha.ToString();
            mail.Text = persona.mail;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<SqlParameter> parametros = Database.GenerarListaDeParametros("dni", Convert.ToInt64(dni.Text), "nombre", nombre.Text, "apellido", apellido.Text, "direccion", direccion.Text, "telefono", Convert.ToInt64(telefono.Text), "mail", mail.Text, "fecha", Convert.ToDateTime(fecha_nacimiento.Text));
                DataTable tablaMedicos = Database.GetInstance
                    .ExecuteQuery("[ClinicaTurbia].[MODIFICAR_MEDICO]", parametros);
                MessageBox.Show("El medico se ha modificado exitosamente", "Clinica FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probelmas al modificar el medico","Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.guardar.Enabled = false;
        }

        private void dni_TextChanged(object sender, EventArgs e)
        {
            
            if (!(this.persona.dni.ToString().Equals(this.dni.Text)))
            {
                this.guardar.Enabled = true;
            }
            else
            {
                this.guardar.Enabled = false;
            }
        }

        private void direccion_TextChanged(object sender, EventArgs e)
        {
            if (!(this.persona.direccion.ToString().Equals(this.direccion.Text)))
            {
                this.guardar.Enabled = true;
            }
            else
            {
                this.guardar.Enabled = false;
            }
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {
            if (!(this.persona.nombre.ToString().Equals(this.nombre.Text)))
            {
                this.guardar.Enabled = true;
            }
            else
            {
                this.guardar.Enabled = false;
            }
        }

        private void telefono_TextChanged(object sender, EventArgs e)
        {
            if (!(this.persona.telefono.ToString().Equals(this.telefono.Text)))
            {
                this.guardar.Enabled = true;
            }
            else
            {
                this.guardar.Enabled = false;
            }
        }

        private void apellido_TextChanged(object sender, EventArgs e)
        {
            if (!(this.persona.apellido.ToString().Equals(this.apellido.Text)))
            {
                this.guardar.Enabled = true;
            }
            else
            {
                this.guardar.Enabled = false;
            }
        }

        private void mail_TextChanged(object sender, EventArgs e)
        {
            if (!(this.persona.mail.ToString().Equals(this.mail.Text)))
            {
                this.guardar.Enabled = true;
            }
            else
            {
                this.guardar.Enabled = false;
            }
        }

        private void fecha_nacimiento_TextChanged(object sender, EventArgs e)
        {
            if (!(this.persona.fecha.ToString().Equals(this.fecha_nacimiento.Text)))
            {
                this.guardar.Enabled = true;
            }
            else
            {
                this.guardar.Enabled = false;
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modificar_Load(object sender, EventArgs e)
        {

        }
    }
}
