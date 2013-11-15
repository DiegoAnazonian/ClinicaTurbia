using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Clinica_Frba
{
    class Configuration
    {
        public static string getConnectionString()
        {
            return ConfigurationManager.AppSettings["connectionString"];
        }
        public static string getFecha()
        {
            return ConfigurationManager.AppSettings["fecha"];
        }
    }
}
