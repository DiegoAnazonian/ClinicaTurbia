using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using Clinica_Frba.NewFolder10;

namespace Clinica_Frba.Registrar_Agenda
{
    public partial class RegistrarAgenda : Form
    {
        List<DateTime> diasCargados = new List<DateTime>();

        public RegistrarAgenda()
        {
            InitializeComponent();
            pnlHorarios.Enabled = false;
            calendario.Hide();
            
            DataTable tablaDias = Database.GetInstance.ExecuteQuery(
                    "[ClinicaTurbia].[TRAER_DIAS_AGENDADOS_PARA_MEDICO]",
                    Database.GenerarListaDeParametros("dni", LoginWindow.LOGGED_USER));
            foreach (DataRow rou in tablaDias.Rows)
            {
                diasCargados.Add((DateTime)rou[0]);
            }
            Controls.Add(calendario);
            calendario.Left = 50;
            calendario.Top = 50;
            calendario.MinDate = DateTime.ParseExact(Configuration.getFecha(),
                            "dd/MM/yyyy", CultureInfo.CurrentCulture);
            calendario.MaxDate = DateTime.ParseExact(Configuration.getFecha(),
                            "dd/MM/yyyy", CultureInfo.CurrentCulture).AddDays(120);
        }

        private void btnDesde_Click(object sender, EventArgs e)
        {
            calendario.Show();
            Controls.SetChildIndex(calendario, 0);
            calendario.Tag = false;
        }

        private void btnHasta_Click(object sender, EventArgs e)
        {
            calendario.Show();
            Controls.SetChildIndex(calendario, 0);
            calendario.Tag = true;
        }

        private void calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            if ((bool)calendario.Tag)
            {
                if (txtDesde.Text != "")
                {
                    if (calendario.SelectionStart.CompareTo(
                            DateTime.ParseExact(txtDesde.Text,
                            "dd/MM/yyyy", CultureInfo.CurrentCulture)) < 0)
                    {
                        MessageBox.Show("La fecha hasta debe ser mayor a la fecha desde");
                    }
                    else
                    {
                        txtHasta.Text = calendario.SelectionStart.ToShortDateString();
                        validarSeleccionDesdeHasta();
                        pnlHorarios.Enabled = true;
                        habilitarDias(txtDesde.Text, txtHasta.Text);
                    }
                }
                else
                {
                    txtHasta.Text = calendario.SelectionStart.ToShortDateString();
                }
            }
            else
            {
                if (txtHasta.Text != "")
                {
                    if (calendario.SelectionStart.CompareTo(
                                DateTime.ParseExact(txtHasta.Text,
                                "dd/MM/yyyy", CultureInfo.CurrentCulture)) > 0)
                    {
                        MessageBox.Show("La fecha desde debe ser menor a la fecha hasta");
                    }
                    else
                    {
                        txtDesde.Text = calendario.SelectionStart.ToShortDateString();
                        validarSeleccionDesdeHasta();
                        pnlHorarios.Enabled = true;
                        habilitarDias(txtDesde.Text, txtHasta.Text);
                    }
                }
                else
                {
                    txtDesde.Text = calendario.SelectionStart.ToShortDateString();
                }
            }
            calendario.Hide();
        }

        private void validarHora(TextBox txt)
        {
            try
            {
                int hora = int.Parse(txt.Text);
                if (hora < 7 || hora > 20)
                {
                    MessageBox.Show("El profesional no puede trabajar antes de las 7\n"
                    + "o luego de las 20 horas");
                    txt.Text = "";
                }
            }
            catch (FormatException ex)
            {
                txt.Text = "";
            }
        }

        private void validarHoraSabado(TextBox txt)
        {
            try
            {
                int hora = int.Parse(txt.Text);
                if (hora < 10 || hora > 15)
                {
                    MessageBox.Show("El profesional no puede trabajar antes de las 10\n"
                    + "o luego de las 15 horas los dias sabado");
                    txt.Text = "";
                }
            }
            catch (FormatException ex)
            {
                txt.Text = "";
            }
        }

        private void checkLunes_CheckedChanged(object sender, EventArgs e)
        {
            pnlLun.Enabled = ((CheckBox)sender).Checked;
        }

        private void checkMar_CheckedChanged(object sender, EventArgs e)
        {
            pnlMar.Enabled = ((CheckBox)sender).Checked;
        }

        private void checkMier_CheckedChanged(object sender, EventArgs e)
        {
            pnlMier.Enabled = ((CheckBox)sender).Checked;
        }

        private void checkJue_CheckedChanged(object sender, EventArgs e)
        {
            pnlJue.Enabled = ((CheckBox)sender).Checked;
        }

        private void checkVier_CheckedChanged(object sender, EventArgs e)
        {
            pnlVier.Enabled = ((CheckBox)sender).Checked;
        }

        private void checkSab_CheckedChanged(object sender, EventArgs e)
        {
            pnlSab.Enabled = ((CheckBox)sender).Checked;
        }

        private void txtHora_Leave(object sender, EventArgs e)
        {
            validarHora((TextBox)sender);
        }

        private void habilitarDias(string desde, string hasta)
        {
            deshabilitarDias();
            DateTime diaDesde = DateTime.ParseExact(desde,
                   "dd/MM/yyyy", CultureInfo.CurrentCulture);
            DateTime diaHasta = DateTime.ParseExact(hasta,
                "dd/MM/yyyy", CultureInfo.CurrentCulture);
            double diasEnMedio = (diaHasta - diaDesde).TotalDays;
            if (diasEnMedio > 6)
            {
                habilitarPanelesDias(1, 2, 3, 4, 5, 6, 7);
            }
            else
            {
                int weekday = ((int)diaDesde.DayOfWeek) + 1;
                for (int i = 0; i < diasEnMedio + 1 && i < 7; i++)
                {
                    habilitarPanelesDias(weekday);
                    weekday += 1;
                }
            }
        }

        private void deshabilitarDias()
        {
            checkLunes.Enabled = false;
            checkLunes.Checked = false;
            checkMar.Enabled = false;
            checkMar.Checked = false;
            checkMier.Enabled = false;
            checkMier.Checked = false;
            checkJue.Enabled = false;
            checkJue.Checked = false;
            checkVier.Enabled = false;
            checkVier.Checked = false;
            checkSab.Enabled = false;
            checkSab.Checked = false;
        }

        private void habilitarPanelesDias(params int[] dias)
        {
            foreach (int dia in dias)
            {
                switch (dia)
                {
                    case 1:
                        break;
                    case 2:
                        checkLunes.Enabled = true;
                        checkLunes.Checked = true;
                        break;
                    case 3:
                        checkMar.Enabled = true;
                        checkMar.Checked = true;
                        break;
                    case 4:
                        checkMier.Enabled = true;
                        checkMier.Checked = true;
                        break;
                    case 5:
                        checkJue.Enabled = true;
                        checkJue.Checked = true;
                        break;
                    case 6:
                        checkVier.Enabled = true;
                        checkVier.Checked = true;
                        break;
                    case 7:
                        checkSab.Enabled = true;
                        checkSab.Checked = true;
                        break;
                }
            }
        }

        private void txtSabHora_Leave(object sender, EventArgs e)
        {
            validarHoraSabado((TextBox)sender);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!validarFinalizacion())
            {
                MessageBox.Show("Verifique que todos los dias trabajados tengan"
                    + " horas especificadas.\nLas horas desde deben ser menores"
                    + " a las horas hasta");
                return;
            }
            if (sumaDeHoras() > 48)
            {
                MessageBox.Show("Un medico no puede trabajar mas de 48 horas semanales.");
                return;
            }
            DateTime diaDesde = DateTime.ParseExact(txtDesde.Text,
                   "dd/MM/yyyy", CultureInfo.CurrentCulture);
            DateTime diaHasta = DateTime.ParseExact(txtHasta.Text,
                "dd/MM/yyyy", CultureInfo.CurrentCulture);
            int tope = 0;
            while (diaDesde <= diaHasta && tope < 7)
            {
                tope += 1;
                string horaDesde = null;
                string horaHasta = null;
                bool persiste = false;
                bool trabaja = false;
                switch ((int) diaDesde.DayOfWeek)
                {
                    case 0:
                        break;
                    case 1:
                        horaDesde = txtLunesHoraDesde.Text;
                        horaHasta = txtLunesHoraHasta.Text;
                        persiste = checkLunes.Enabled;
                        trabaja = checkLunes.Checked;
                        break;
                    case 2:
                        horaDesde = txtMartesHoraDesde.Text;
                        horaHasta = txtMarHoraHasta.Text;
                        persiste = checkMar.Enabled;
                        trabaja = checkMar.Checked;
                        break;
                    case 3:
                        horaDesde = txtMiercolesHoraDesde.Text;
                        horaHasta = txtMierHoraHasta.Text;
                        persiste = checkMier.Enabled;
                        trabaja = checkMier.Checked;
                        break;
                    case 4:
                        horaDesde = txtJueHoraDesde.Text;
                        horaHasta = txtJueHoraHasta.Text;
                        persiste = checkJue.Enabled;
                        trabaja = checkJue.Checked;
                        break;
                    case 5:
                        horaDesde = txtVieHoraDesde.Text;
                        horaHasta = txtVierHoraHasta.Text;
                        persiste = checkVier.Enabled;
                        trabaja = checkVier.Checked;
                        break;
                    case 6:
                        horaDesde = txtSabHoraDesde.Text;
                        horaHasta = txtSabHoraHasta.Text;
                        persiste = checkSab.Enabled;
                        trabaja = checkSab.Checked;
                        break;
                }
                if (persiste)
                {
                    List<SqlParameter> agendaParam =
                    Database.GenerarListaDeParametros("dni", LoginWindow.LOGGED_USER,
                    "diaDesde", diaDesde, "diaHasta", diaHasta,
                    "horaDesde", horaDesde, "horaHasta", horaHasta,
                    "trabaja", trabaja);
                    DataTable tablaUsuario = Database.GetInstance.ExecuteQuery(
                        "[ClinicaTurbia].[CARGAR_AGENDA]", agendaParam);
                }
                diaDesde = diaDesde.AddDays(1);
            }
            MessageBox.Show("Dias agendados satisfactoriamente");
            this.Close();
                
        }

        private bool validarFinalizacion()
        {
            bool ret = true;
            if (checkLunes.Checked)
            {
                ret = txtLunesHoraDesde.Text != "" && txtLunesHoraHasta.Text != "" ?
                    int.Parse(txtLunesHoraDesde.Text) < int.Parse(txtLunesHoraHasta.Text) : false;
            }
            if (checkMar.Checked)
            {
                ret = txtMarHoraHasta.Text != "" && txtMartesHoraDesde.Text != "" ?
                    int.Parse(txtMarHoraHasta.Text) > int.Parse(txtMartesHoraDesde.Text) : false;
            }
            if (checkMier.Checked)
            {
                ret = txtMiercolesHoraDesde.Text != "" && txtMierHoraHasta.Text != "" ?
                    int.Parse(txtMiercolesHoraDesde.Text) < int.Parse(txtMierHoraHasta.Text) : false;
            }
            if (checkJue.Checked)
            {
                ret = txtJueHoraDesde.Text != "" && txtJueHoraHasta.Text != "" ?
                    int.Parse(txtJueHoraDesde.Text) < int.Parse(txtJueHoraHasta.Text) : false;
            }
            if (checkVier.Checked)
            {
                ret = txtVieHoraDesde.Text != "" && txtVierHoraHasta.Text != "" ?
                    int.Parse(txtVieHoraDesde.Text) < int.Parse(txtVierHoraHasta.Text) : false;
            }
            if (checkSab.Checked)
            {
                ret = txtSabHoraDesde.Text != "" && txtSabHoraHasta.Text != "" ?
                    int.Parse(txtSabHoraDesde.Text) < int.Parse(txtSabHoraHasta.Text) : false;
            }
            return ret;
        }

        private void validarSeleccionDesdeHasta()
        {
            DateTime diaDesde = DateTime.ParseExact(txtDesde.Text,
                   "dd/MM/yyyy", CultureInfo.CurrentCulture);
            DateTime diaHasta = DateTime.ParseExact(txtHasta.Text,
                "dd/MM/yyyy", CultureInfo.CurrentCulture);
            List<DateTime> diasInmutables = new List<DateTime>();
            while (diaDesde <= diaHasta)
            {
                if (diasCargados.Contains(diaDesde))
                {
                    diasInmutables.Add(diaDesde);
                }
                diaDesde = diaDesde.AddDays(1);
            }
            if (diasInmutables.Count > 0)
            {
                string mess = "Los siguientes dias ya fueron cargados.\n";
                int i = 0;
                bool primero = true;
                foreach (DateTime dia in diasInmutables)
                {
                    string separador;
                    if (i == 4)
                    {
                        separador = "\n   ";
                        i = 0;
                    }
                    else
                    {
                        separador = primero ? "   " : "  -  ";
                    }
                    mess += separador + dia.ToShortDateString();
                    i += 1;
                    primero = false;
                }
                mess += "\nLos datos ingresados para dichos dias no seran tenidos en cuenta.";
                MessageBox.Show(mess);
            }
        }

        private int sumaDeHoras()
        {
            int suma = 0;
            if (checkLunes.Checked)
            {
                suma +=  - int.Parse(txtLunesHoraDesde.Text) + int.Parse(txtLunesHoraHasta.Text);
            }
            if (checkMar.Checked)
            {
                suma += int.Parse(txtMarHoraHasta.Text) - int.Parse(txtMartesHoraDesde.Text);
            }
            if (checkMier.Checked)
            {
                suma += - int.Parse(txtMiercolesHoraDesde.Text) + int.Parse(txtMierHoraHasta.Text);
            }
            if (checkJue.Checked)
            {
                suma += - int.Parse(txtJueHoraDesde.Text) + int.Parse(txtJueHoraHasta.Text);
            }
            if (checkVier.Checked)
            {
                suma += - int.Parse(txtVieHoraDesde.Text) + int.Parse(txtVierHoraHasta.Text);
            }
            if (checkSab.Checked)
            {
                suma += - int.Parse(txtSabHoraDesde.Text) + int.Parse(txtSabHoraHasta.Text);
            }
            return suma;
        }
    }
}
