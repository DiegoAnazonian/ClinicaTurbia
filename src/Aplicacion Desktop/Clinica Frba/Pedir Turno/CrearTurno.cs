using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using Clinica_Frba.NewFolder10;
using System;
using System.Collections.Generic;

namespace Clinica_Frba.Pedir_Turno
{
    public partial class CrearTurno : Form
    {
        public CrearTurno()
        {
            InitializeComponent();
            comboFecha.Enabled = false;
            comboHorario.Enabled = false;
            btnCrearTurno.Enabled = false;
            DataTable tablaEsp = Database.GetInstance.ExecuteQuery(
               "[ClinicaTurbia].[LISTADO_ESPECIALIDAD]");
            completarComboEspecialidades(tablaEsp);

            DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_TODOS_MEDICOS]");
            completarComboMedico(tablaMed);
            completarComboFecha();
        }

        private void completarComboEspecialidades(DataTable tablaEsp)
        {
            DataRow emptyRow = tablaEsp.NewRow();
            emptyRow["ESP_DESCRIPCION"] = "";
            emptyRow["ESP_CODIGO"] = 0;
            tablaEsp.Rows.Add(emptyRow);
            DataView newView =
                new DataView(tablaEsp, "", "ESP_DESCRIPCION", DataViewRowState.CurrentRows);
            comboEspecialidad.DataSource = newView;
            comboEspecialidad.DisplayMember = "ESP_DESCRIPCION";
            comboEspecialidad.ValueMember = "ESP_CODIGO";
            comboEspecialidad.SelectedItem = null;
        }

        private void completarComboMedico(DataTable tablaMed)
        {
            foreach (DataRow rou in tablaMed.Rows)
            {
                rou["MED_APELLIDO"] = rou["MED_APELLIDO"].ToString().ToUpper();
            }
            tablaMed.Columns.Add("MED_APENOM", typeof(string), "MED_APELLIDO + ' ' + MED_NOMBRE");
            comboMedico.DataSource = tablaMed;
            comboMedico.DisplayMember = "MED_APENOM";
            comboMedico.ValueMember = "MED_DNI";
            comboMedico.SelectedItem = null;
            comboFecha.Enabled = false;
            comboHorario.Enabled = false;
            comboFecha.SelectedItem = null;
            comboHorario.SelectedItem = null;
        }

        private void completarComboFecha()
        {
            DateTime da = DateTime.ParseExact(Configuration.getFecha(),
                "dd/MM/yyyy", CultureInfo.CurrentCulture);
            for (int i = 0; i < 120; i++)
            {
                comboFecha.Items.Add(da.ToShortDateString());
                da = da.AddDays(1);
                if (da.DayOfWeek == 0)
                {
                    da = da.AddDays(1);
                }
            }
        }

        private void comboMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboFecha.Enabled = true;
            comboHorario.Enabled = false;
            comboFecha.SelectedItem = null;
        }

        private void comboEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboEspecialidad.SelectedValue == null || comboEspecialidad.SelectedValue.GetType().IsClass)
            {
                return;
            }
            if (comboEspecialidad.SelectedValue.ToString().Equals("0"))
            {
                DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_TODOS_MEDICOS]");
                completarComboMedico(tablaMed);
            }
            else
            {
                List<SqlParameter> param =
                    Database.GenerarListaDeParametros("esp", comboEspecialidad.SelectedValue);
                DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[FILTRAR_X_ESPECIALIDAD]", param);
                completarComboMedico(tablaMed);
            }
        }

        private void comboFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboFecha.SelectedItem == null)
            {
                return;
            }
            comboHorario.SelectedItem = null;
            comboHorario.Items.Clear();
            comboHorario.Enabled = true;
            DateTime da = DateTime.ParseExact(comboFecha.SelectedItem.ToString(),
                "dd/MM/yyyy", CultureInfo.CurrentCulture);
            List<SqlParameter> paramHorario = Database.GenerarListaDeParametros(
                "dni", comboMedico.SelectedValue, "dia", (int)da.DayOfWeek);
            DataTable tablaHorarios = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_HORARIOS_MEDICO]", paramHorario);
            DateTime horaDesde = DateTime.ParseExact(tablaHorarios.Rows[0][0].ToString(),
                "HH:mm", CultureInfo.CurrentCulture);
            DateTime horaHasta = DateTime.ParseExact(tablaHorarios.Rows[0][1].ToString(),
                "HH:mm", CultureInfo.CurrentCulture);

            while (horaDesde < horaHasta)
            {
                comboHorario.Items.Add(horaDesde.ToShortTimeString());
                horaDesde = horaDesde.AddMinutes(30);
            }

            List<SqlParameter> paramTurnos = Database.GenerarListaDeParametros(
                "dni", comboMedico.SelectedValue, "fecha", da);
            DataTable tablaTurnos = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_TURNOS_DE_MEDICO_PARA_FECHA]", paramTurnos);

            foreach (DataRow rou in tablaTurnos.Rows)
            {
                if (rou[1].Equals(true))
                {
                    MessageBox.Show("El profesional no estara disponible en esta fecha",
                        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comboHorario.Items.Clear();
                    break;
                }
                comboHorario.Items.Remove(((DateTime)rou[0]).ToShortTimeString());
            }
        }

        private void btnCrearTurno_Click(object sender, EventArgs e)
        {
            String hora = comboHorario.SelectedItem.ToString().Length == 5 ?
                comboHorario.SelectedItem.ToString() :
                "0" + comboHorario.SelectedItem.ToString();
            DateTime fecha = DateTime.ParseExact(comboFecha.SelectedItem.ToString() + " " + hora,
                "dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);
            List<SqlParameter> param = Database.GenerarListaDeParametros(
                "med", comboMedico.SelectedValue, "pac", LoginWindow.LOGGED_USER,
                "fecha", fecha);
            DataTable tablaHorarios = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[CREAR_TURNO]", param);
            comboHorario.Items.Remove(comboHorario.SelectedItem);
            comboHorario.SelectedItem = null;
            btnCrearTurno.Enabled = false;
        }

        private void comboHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboHorario.SelectedItem != null)
            {
                btnCrearTurno.Enabled = true;
            }
            else
            {
                btnCrearTurno.Enabled = false;
            }
        }
    }
}

