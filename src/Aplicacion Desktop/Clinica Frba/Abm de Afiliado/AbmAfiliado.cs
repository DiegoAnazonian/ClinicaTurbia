using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.NewFolder12;


namespace Clinica_Frba.Abm_de_Afiliado
{
    public partial class AbmAfiliado : Form
    {
        

        public AbmAfiliado()
        {
            InitializeComponent();
            limpiar.Click += new EventHandler(this.modoDefecto);
            afiliadosBox.Click += new EventHandler(this.activarBotones);
            this.ActiveControl = palabraClave;
            
            DataTable pacientes = this.traerTodosLosPacientes();
            llenarCheckedBoxAfiliados(pacientes);
        }

        private void activarBotones(Object sender, EventArgs e)
        {
            baja.Enabled = true;
            modificar.Enabled = true;
        }

        private void llenarCheckedBoxAfiliados(DataTable afiliados)
        {
            cantidadAfiliados.Text = afiliados.Rows.Count.ToString();
            this.afiliadosBox.DataSource = afiliados;
            
        }

        private DataTable traerTodosLosPacientes(){
            return Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[LISTADO_PACIENTES]");        
        }

        private void modoDefecto(object sender, EventArgs e)
        {
            baja.Enabled = false;
            modificar.Enabled = false;
            nombre.Clear();
            apellido.Clear();
            dni.Clear();
            palabraClave.Clear();
            direccion.Clear();
            
        }
        private void palabraClave_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> nomParcial = Database.GenerarListaDeParametros("nombreParcial", palabraClave.Text);
            DataTable tablaAfs = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_POR_PALABRACLAVE_PACIENTE]", nomParcial);

            this.llenarCheckedBoxAfiliados(tablaAfs);
        }

        private void afiliadosBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.modificar.Enabled = true;
        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> nomParcial = Database.GenerarListaDeParametros("nombre", nombre.Text);
            DataTable tablaAfs = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_X_NOMBRE_PACIENTES]", nomParcial);
            this.llenarCheckedBoxAfiliados(tablaAfs);
        }

        private void refrescarTabla()
        {
            List<SqlParameter> nomParcial = Database.GenerarListaDeParametros("nombreParcial", "");
            DataTable tablaAfs = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_POR_PALABRACLAVE_PACIENTE]", nomParcial);

            this.llenarCheckedBoxAfiliados(tablaAfs);
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            List<SqlParameter> afiliadoParam = Database.GenerarListaDeParametros(
                "dni", afiliadosBox.Rows[afiliadosBox.CurrentRow.Index].Cells[3].Value.ToString());
            DataTable tablaAfiliado = Database.GetInstance.ExecuteQuery
                ("[ClinicaTurbia].[EXISTE_AFILIADO]", afiliadoParam);
            new AltaModifAfiliado(tablaAfiliado, false).ShowDialog();

            this.asDefault();

        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void apellido_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> apeParcial = Database.GenerarListaDeParametros("apellido", apellido.Text);
            DataTable tablaAfs = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_X_APELLIDO_PACIENTES]", apeParcial);
            this.llenarCheckedBoxAfiliados(tablaAfs);
        }

        private void dni_TextChanged(object sender, EventArgs e)
        {
                        
            List<SqlParameter> dniParcial = Database.GenerarListaDeParametros("dni", this.dni.Text);
            DataTable tablaAfs = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_X_DNI_PACIENTES]", dniParcial);
            this.llenarCheckedBoxAfiliados(tablaAfs);

        }

        private void direccion_TextChanged(object sender, EventArgs e)
        {
            List<SqlParameter> direParcial = Database.GenerarListaDeParametros("direccion", direccion.Text);
            DataTable tablaAfs = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[FILTRAR_X_DIRECCION_PACIENTES]", direParcial);
            this.llenarCheckedBoxAfiliados(tablaAfs);
        }

        private void alta_Click(object sender, EventArgs e)
        {
            new AltaModifAfiliado(false).ShowDialog();
            this.asDefault();
        }

        private void asDefault()
        {
            this.modificar.Enabled = false;
            this.baja.Enabled = false;
            this.refrescarTabla();
            palabraClave.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            dni.Text = "";
            direccion.Text = "";
        }

        private void eliminarAfiliado(long documento)
        {
            try
            {
                List<SqlParameter> parametros = Database.GenerarListaDeParametros("dni", documento);
                DataTable tablaMedicos = Database.GetInstance
                    .ExecuteQuery("[ClinicaTurbia].[BORRAR_AFILIADO]", parametros);
                MessageBox.Show("El afiliado se ha eliminado exitosamente", "Clinica Turbia FRBA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas al eliminar el afiliado", "Clinica Turbia FRBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.refrescarTabla();
        }

        private void baja_Click(object sender, EventArgs e)
        {
            long documento = Convert.ToInt64(afiliadosBox.Rows[afiliadosBox.CurrentRow.Index].Cells[3].Value);
            String nom = Convert.ToString(afiliadosBox.Rows[afiliadosBox.CurrentRow.Index].Cells[0].Value);
            String ape = Convert.ToString(afiliadosBox.Rows[afiliadosBox.CurrentRow.Index].Cells[1].Value);

            if (MessageBox.Show("Seguro desea eliminar a " + ape + ", " + nom + ".\n DNI: " + documento + "", "ClinicaTurbia FRBA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.eliminarAfiliado(documento);
                Database.GetInstance.ExecuteQuery("[ClinicaTurbia].[AGREGAR_HISTORICO_PLAN]",
                    Database.GenerarListaDeParametros("pac", documento, "fecha", Configuration.getFecha()));
            }

            this.asDefault();
        
        
        }















    }
}
