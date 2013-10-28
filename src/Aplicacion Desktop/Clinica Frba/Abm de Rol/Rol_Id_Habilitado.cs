using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba.Abm_de_Rol
{
    class Rol_Id_Habilitado
    {
        public int id;
        public bool habilitado;

        public Rol_Id_Habilitado(int id, bool hab)
        {
            this.id = id;
            this.habilitado = hab;
        }
    }
}
