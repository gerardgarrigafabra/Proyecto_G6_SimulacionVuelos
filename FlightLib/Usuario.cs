using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class Usuario
    {
        string nombre;
        string contrasena;

        public Usuario(string nombre, string contrasena)
        {
            this.nombre = nombre;
            this.contrasena = contrasena;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public string GetContrasena()
        {
            return contrasena;
        }
    }
}
