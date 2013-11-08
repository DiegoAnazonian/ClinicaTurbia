using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinica_Frba
{
     public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public long telefono { get; set; }
        public long dni { get; set; }
        public string direccion { get; set; }
        public string mail { get; set; }
        public DateTime fecha { get; set; }

        public Persona()
        {
        }

        public Persona(string nombre,string apellido,DateTime fecha,string mail,long dni,long telefono,string direccion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.telefono = telefono;
            this.direccion = direccion;
            this.mail = mail;
            this.fecha = fecha;
        }

        

        

   }
}
