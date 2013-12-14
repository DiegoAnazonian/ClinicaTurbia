using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;

namespace Clinica_Frba.Registro_de_LLegada
{
    public partial class RegistroLlegada : Form
    {
        String currentDate;
        String currentTime;
        bool noContar = false;

        public RegistroLlegada()
        {
            InitializeComponent();
            pnlPaciente.Hide();
            registrarLlegadabtn.Enabled = false;
            currentDate = System.Configuration.ConfigurationManager.AppSettings["fecha"];
            currentTime = System.Configuration.ConfigurationManager.AppSettings["horario"];

            fechaDeHoy.Text = String.Format("Fecha Actual: {0}", currentDate);
            horaActual.Text = String.Format("Hora Actual: {0}", currentTime);
            DataTable tablaEsp = Database.GetInstance.ExecuteQuery(
               "[ClinicaTurbia].[LISTADO_ESPECIALIDAD]");
            completarComboEspecialidades(tablaEsp);

            DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_TODOS_MEDICOS]");
            completarComboMedico(tablaMed);
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
                noContar = true;
                completarComboMedico(tablaMed);
            }
            else
            {
                List<SqlParameter> param =
                    Database.GenerarListaDeParametros("esp", comboEspecialidad.SelectedValue);
                DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[FILTRAR_X_ESPECIALIDAD]", param);
                noContar = true;
                completarComboMedico(tablaMed);
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bonosAfiliado_SelectedIndexChanged(object sender, EventArgs e)
        {
            registrarLlegadabtn.Visible = true;
        }

        private void registrarLlegada_Click(object sender, EventArgs e)
        {
            if (bonosAfiliado.SelectedValue == null)
            {
                return;
            }
            int numeroTurno = Convert.ToInt32(turnosMedico.Rows[turnosMedico.CurrentRow.Index].Cells[2].Value);
            String bono = bonosAfiliado.SelectedValue.ToString();
            int dniAfi = Convert.ToInt32(turnosMedico.Rows[turnosMedico.CurrentRow.Index].Tag);

            List<SqlParameter> param = Database.GenerarListaDeParametros(
                "numTurno", numeroTurno, "fecha", Convert.ToDateTime(currentDate),
                "bono", Convert.ToInt64(bono.ToString()), "dniAfi", dniAfi);
            DataTable llegadaRegistrada = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[REGISTRAR_LLEGADA]", param);

            MessageBox.Show("La llegada del afiliado se registro correctamente", "Clinica Turbia FRBA", MessageBoxButtons.OK);
            refrescarGridTurnos();
            pnlPaciente.Hide();
        }

        private void comboMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noContar || comboMedico.SelectedValue == null || comboMedico.SelectedValue.GetType().IsClass)
            {
                noContar = false;
                turnosMedico.Rows.Clear();
                return;
            }
            refrescarGridTurnos();
        }

        private void turnosMedico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.turnosMedico.Rows[e.RowIndex].DefaultCellStyle.Font != null)
            {
                pnlPaciente.Hide();
                registrarLlegadabtn.Enabled = false;
                return;
            }
            registrarLlegadabtn.Enabled = true;
            txtPaciente.Text = this.turnosMedico.Rows[e.RowIndex].Cells[1].Value.ToString();

            String dniAfiliado = this.turnosMedico.Rows[e.RowIndex].Tag.ToString();
            List<SqlParameter> param = Database.GenerarListaDeParametros("dni", dniAfiliado);
            DataTable bonos = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_BONOS]", param);

            this.bonosAfiliado.DataSource = null;
            this.bonosAfiliado.Items.Clear();
            this.bonosAfiliado.SelectedItem = null;

            if (bonos.Rows.Count == 0)
            {
                MessageBox.Show("El paciente no posee bonos consulta");
                return;
            }

            this.bonosAfiliado.DataSource = bonos;
            this.bonosAfiliado.DisplayMember = "BONOCON_ID";
            this.bonosAfiliado.ValueMember = "BONOCON_ID";
            pnlPaciente.Show();
        }

        private void refrescarGridTurnos()
        {
            turnosMedico.Rows.Clear();
            List<SqlParameter> param = Database.GenerarListaDeParametros(
                "dni", comboMedico.SelectedValue.ToString(),
                "fecha", Convert.ToDateTime(currentDate));
            DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_TURNOS_DE_MEDICO_PARA_FECHA]", param);

            if (tablaMed.Rows.Count == 0)
            {
                pnlPaciente.Hide();
                MessageBox.Show("El profesional "
                    + ((DataRowView)comboMedico.Items[comboMedico.SelectedIndex]).Row.ItemArray[3].ToString()
                    + " no registra turnos");
                return;
            }

            foreach (DataRow medico in tablaMed.Rows)
            {
                DataGridViewRow rou = new DataGridViewRow();

                DataGridViewCell horarioCell = new DataGridViewTextBoxCell();
                DataGridViewCell pacienteCell = new DataGridViewTextBoxCell();
                DataGridViewCell numTurnoCell = new DataGridViewTextBoxCell();

                horarioCell.Value = ((DateTime)medico[0]).ToShortTimeString();
                pacienteCell.Value = medico[2].ToString();
                rou.Tag = medico[3];
                numTurnoCell.Value = medico[4].ToString();

                rou.Cells.Add(horarioCell);
                rou.Cells.Add(pacienteCell);
                rou.Cells.Add(numTurnoCell);

                if (Convert.ToInt64(DateTime.Compare(Convert.ToDateTime(horarioCell.Value), Convert.ToDateTime(currentTime))) < 0)
                {
                    rou.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Strikeout);
                }
                this.turnosMedico.Rows.Add(rou);
            }
        }
 
         

      

    }
}
