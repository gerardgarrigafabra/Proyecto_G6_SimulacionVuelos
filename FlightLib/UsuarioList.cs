using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FlightLib
{
    public class UsuarioList
    {
        List<Usuario> usuarios = new List<Usuario>();


        public void CargarDeFichero()
        {
            if (File.Exists("usuarios.txt") == true)
            {
                StreamReader lector = new StreamReader("usuarios.txt");
                string linea = lector.ReadLine();
                while (linea != null)
                {
                    string[] trozos = linea.Split(';');
                    if (trozos.Length == 2)
                        usuarios.Add(new Usuario(trozos[0], trozos[1]));
                    linea = lector.ReadLine();
                }
                lector.Close();
            }
        }


        public bool Existe(string nombre)
        {
            int i = 0;
            while (i < usuarios.Count)
            {
                if (usuarios[i].GetNombre() == nombre)
                    return true;
                i = i + 1;
            }
            return false;
        }

        // miramos si el nombre y la contraseña coinciden con los de un usuario
        public bool Autenticar(string nombre, string contrasena)
        {
            int i = 0;
            while (i < usuarios.Count)
            {
                if (usuarios[i].GetNombre() == nombre && usuarios[i].GetContrasena() == contrasena)
                    return true;
                i = i + 1;
            }
            return false;
        }

        public bool Registrar(string nombre, string contrasena)
        {
            if (Existe(nombre) == true)
                return false;

            usuarios.Add(new Usuario(nombre, contrasena));

            StreamWriter escritor = new StreamWriter("usuarios.txt", true);
            escritor.WriteLine(nombre + ";" + contrasena);
            escritor.Close();
            return true;
        }
    }
}
