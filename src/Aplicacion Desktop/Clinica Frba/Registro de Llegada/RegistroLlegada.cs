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

        public RegistroLlegada()
        {

            InitializeComponent();
            currentDate = System.Configuration.ConfigurationManager.AppSettings["fecha"];
            currentTime = System.Configuration.ConfigurationManager.AppSettings["horario"];
            turnosMedico.Click += new EventHandler(this.activarBono);

            fechaDeHoy.Text = String.Format("Fecha Actual: {0}", currentDate);
            horaActual.Text = String.Format("Hora Actual: {0}", currentTime);
            DataTable tablaEsp = Database.GetInstance.ExecuteQuery(
               "[ClinicaTurbia].[LISTADO_ESPECIALIDAD]");
            completarComboEspecialidades(tablaEsp);

            DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[TRAER_TODOS_MEDICOS]");
            completarComboMedico(tablaMed);
        }

        private void activarBono(Object sender, EventArgs e)
        {
            this.bonosAfiliado.Visible = true;
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

       

        private void RegistroLlegada_Load(object sender, EventArgs e)
        {

        }

        private void traerBonosConsultaDe(String numeroDeTurno)
        {
            List<SqlParameter> param =
                    Database.GenerarListaDeParametros("esp", comboEspecialidad.SelectedValue);
            DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                "[ClinicaTurbia].[Llegada]", param);
            completarComboMedico(tablaMed);

        }

        private void traerTurnos_Click(object sender, EventArgs e)
        {
            if (comboMedico.SelectedValue != null)
            {
                try
                {
                    List<SqlParameter> param = Database.GenerarListaDeParametros("dni", comboMedico.SelectedValue.ToString(), "fecha", Convert.ToDateTime(currentDate));
                    DataTable tablaMed = Database.GetInstance.ExecuteQuery(
                        "[ClinicaTurbia].[TRAER_TURNOS_DE_MEDICO_PARA_FECHA]", param);
                    
                    int index = 0;
                    foreach(DataRow medico in tablaMed.Rows)
                    {
                        DataGridViewRow datagrid = new DataGridViewRow();
                        
                        DataGridViewCell horario = new DataGridViewTextBoxCell();
                        DataGridViewCell paciente = new DataGridViewTextBoxCell();
                        DataGridViewCell numTurno = new DataGridViewTextBoxCell();

                        horario.Value = ((DateTime)medico[0]).ToShortTimeString();
                        paciente.Value = medico[2].ToString();
                        datagrid.Tag = medico[3];
                        numTurno.Value = medico[4].ToString();

                        datagrid.Cells.Add(horario);
                        datagrid.Cells.Add(paciente);
                        datagrid.Cells.Add(numTurno);
                        
                        this.turnosMedico.Rows.Add(datagrid);

                        if (Convert.ToInt64(DateTime.Compare(Convert.ToDateTime(horario.Value), Convert.ToDateTime(currentTime))) < 0)
                        {
                            //turnosMedico.Rows[index].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Strikeout);
                            turnosMedico.Rows[index].Visible = false;
                        }
                        index++;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problemas al traer horarios del medico","Clinica Turbia FRBA",MessageBoxButtons.OK);
                }
            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void turnosMedico_SelectedIndexChanged(object sender, EventArgs e)
        {

            

        }

        private void turnosMedico_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String dniAfiliado = this.turnosMedico.Rows[e.RowIndex].Tag.ToString();
                List<SqlParameter> param = Database.GenerarListaDeParametros("dni", dniAfiliado);
                DataTable bonos = Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[TRAER_BONOS]", param);

                this.bonosAfiliado.DataSource = bonos;
                this.bonosAfiliado.DisplayMember = "BONOCON_ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probelmas con afiliado");

            }
        }

        private void bonosAfiliado_SelectedIndexChanged(object sender, EventArgs e)
        {
            registrarLlegadabtn.Visible = true;
        }

        private void registrarLlegada_Click(object sender, EventArgs e)
        {
            if (bonosAfiliado.SelectedValue != null)
            {
                try
                {
                    int numeroTurno = Convert.ToInt32(turnosMedico.Rows[turnosMedico.CurrentRow.Index].Cells[2].Value);
                    String bono = (String)bonosAfiliado.SelectedValue;

                    this.registrarLlegada(numeroTurno, bono);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problemas al registrar la llegada del afiliado");
                    
                }
            }
        }

        private void registrarLlegada(int turno,String bono){

            try
            {
                List<SqlParameter> param = Database.GenerarListaDeParametros("turno", turno, "fecha", Convert.ToDateTime(currentDate), "bono", Convert.ToInt64(bono.ToString()));
                DataTable llegadaRegistrada = Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[INSERTAR_LLEGADA]", param);

                MessageBox.Show("La llegada del afiliado se inserto correctamente","Clinica Turbia FRBA",MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al insertar la llegada del afiliado", "Clinica Turbia FRBA", MessageBoxButtons.OK);
            }
        
        
        }
 
         

      

    }
}
