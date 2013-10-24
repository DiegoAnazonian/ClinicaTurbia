using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.Abm_de_Rol
{
    public partial class AltaRolWindow : Form
    {
        public AltaRolWindow()
        {
            InitializeComponent();
            DataTable tablaUsuario = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[LISTADO_FUNCIONALIDADES]", new List<SqlParameter>());
            listBox1.DataSource = tablaUsuario;
            listBox1.DisplayMember = "FUN_NOMBRE"; 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
