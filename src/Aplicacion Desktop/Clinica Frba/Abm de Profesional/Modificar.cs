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
    public partial class Modificar : Form
    {
        private Persona persona;
        List<DataRowView> espViejas = new List<DataRowView>();
        bool espFueronModificadas = false;

        public Modificar(Persona persona)
        {
            InitializeComponent();
            calendario.Hide();
            llenarListEspecialidades();
            this.llenarTabla(persona);
            this.guardar.Enabled = false;
            this.marcarEspecialidades();
        }

        public void llenarTabla(Persona persona)
        {
            this.persona = persona;

            nombre.Text = persona.nombre.ToString();
            apellido.Text = persona.apellido.ToString();
            dni.Text = persona.dni.ToString();
            telefono.Text = persona.telefono.ToString();
            direccion.Text = persona.direccion.ToString();
            fecha_nacimiento.Text = persona.fecha.ToShortDateString();
            mail.Text = persona.mail;
            txtMatricula.Text = persona.matricula;

        }

        private void guardar_Click(object sender, EventArgs e)
        {
            this.guardar.Enabled = false;
            List<SqlParameter> parametros = Database.GenerarListaDeParametros(
                "dni", dni.Text, "nombre", nombre.Text, "apellido", apellido.Text,
                "direccion", direccion.Text, "telefono", telefono.Text, 
                "mail", mail.Text, "fecha", fecha_nacimiento.Text,
                "matricula", txtMatricula.Text);
            DataTable tablaMedicos = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[MODIFICAR_MEDICO]", parametros);
            if (this.espFueronModificadas)
            {
                for (int i = 0; i < listEspecialidades.Items.Count; i++)
                {
                    DataRowView item = (DataRowView)listEspecialidades.Items[i];
                    if (this.espViejas.Contains(item) && !listEspecialidades.GetSelected(i))
                    {
                        quitarEspecialidad(item.Row["ESP_CODIGO"].ToString());
                    }
                    else if (!this.espViejas.Contains(item) && listEspecialidades.GetSelected(i))
                    {
                        agregarEspecialidad(item.Row["ESP_CODIGO"].ToString());
                    }
                }
            }
            MessageBox.Show("El medico se ha modificado exitosamente", "Clinica FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
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

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void marcarEspecialidades()
        {
            DataTable tablaEsp = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[LISTADO_ESPECIALIDAD_PARA_MEDICO]",
                Database.GenerarListaDeParametros("dni", persona.dni.ToString()));
            foreach(DataRow rou in tablaEsp.Rows)
            {
                int index = listEspecialidades.FindStringExact(
                    rou["ESP_DESCRIPCION"].ToString());
                listEspecialidades.SetSelected(index, true);
                this.espViejas.Add((DataRowView)listEspecialidades.Items[index]);
            }
        }

        private void listEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            espFueronModificadas = true;
            guardar.Enabled = true;
        }

        private void quitarEspecialidad(String idEsp)
        {
            List<SqlParameter> espParam = Database.GenerarListaDeParametros(
                "dniDoc", this.persona.dni.ToString(), "idEsp", int.Parse(idEsp),
                "agregar", false);
            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[MODIFICAR_ESPECIALIDADES_MEDICO]",
                espParam);
        }

        private void agregarEspecialidad(String idEsp)
        {
            List<SqlParameter> espParam = Database.GenerarListaDeParametros(
                "dniDoc", this.persona.dni.ToString(), "idEsp", int.Parse(idEsp),
                "agregar", true);
            Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[MODIFICAR_ESPECIALIDADES_MEDICO]",
                espParam);
        }

        private void txtMatricula_TextChanged(object sender, EventArgs e)
        {
            guardar.Enabled = true;
        }

        private void btnCale_Click(object sender, EventArgs e)
        {
            calendario.Show();
        }

        private void calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            fecha_nacimiento.Text = calendario.SelectionStart.ToShortDateString();
            calendario.Hide();
            guardar.Enabled = true;

        }
    }
}
