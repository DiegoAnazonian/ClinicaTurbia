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
        public Modificar(Persona persona)
        {
            InitializeComponent();
            this.llenarTabla(persona);
        }

        public void llenarTabla(Persona persona)
        {
            nombre.Text = persona.nombre;
            apellido.Text = persona.apellido;
            dni.Text = persona.dni.ToString();
            telefono.Text = persona.telefono.ToString();
            direccion.Text = persona.telefono.ToString();
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
            List<SqlParameter> parametros = Database.GenerarListaDeParametros("dni", Convert.ToInt64(dni.Text),"nombre",nombre.Text,"apellido",apellido.Text,"direccion",direccion.Text,"telefono",Convert.ToInt64(telefono.Text),"mail",mail.Text,"fecha",Convert.ToDateTime(fecha_nacimiento.Text));
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[MODIFICAR_MEDICO]", parametros);
           
        }
    }
}
