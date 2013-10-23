using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Clinica_Frba.Login
{
    public partial class FuncionalidadesWindow : Form
    {
        public FuncionalidadesWindow(String rol)
        {
            InitializeComponent();
            List<SqlParameter> checkFuncionalidades = new List<SqlParameter>();
            checkFuncionalidades.Add(new SqlParameter("rol", rol));
            DataTable tablaUsuario = Database.GetInstance
                .ExecuteQuery("[ClinicaTurbia].[CONSULTA_FUNCIONALIDADES]", checkFuncionalidades);
            int leftOffset = 30;
            int topOffset = 30;
            foreach (DataRow row in tablaUsuario.Rows)
            {
                String nombreFunc = row[0].ToString();
//                switch (nombreFunc)
//                {
//                    case "ASD":
                        Button btn = new Button();
                        btn.Text = nombreFunc;
                        btn.Top = topOffset;
                        btn.Left = leftOffset;
                        SizeF size = this.CreateGraphics().MeasureString(nombreFunc, btn.Font);
                        btn.Width = (int) size.Width;
                        this.Controls.Add(btn);
//                        break;
//                }
                topOffset += 10;
            }
        }

        private void FuncionalidadesWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.UserClosing))
            {
                Application.Exit();
            }
        }
    }
}
