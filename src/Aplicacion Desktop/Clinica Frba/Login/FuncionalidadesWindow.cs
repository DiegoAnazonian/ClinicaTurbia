using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Clinica_Frba.Abm_de_Rol;

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
                        btn.Click += (sender, args) =>
                        {
                            new Abm_de_Rol.AltaRolWindow().Show();
                            this.Close();
                        };
//                        break;
//                }
                topOffset += 10;
            }
        }
    }
}
