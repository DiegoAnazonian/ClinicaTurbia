﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Clinica_Frba.NewFolder10;
using Clinica_Frba.NewFolder12;
using Clinica_Frba.Compra_de_Bono;

namespace Clinica_Frba
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ComprarBono(false));
        }
    }
}
