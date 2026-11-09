using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Registro : Form
    {

        UsuarioList usuarios; 

        public Registro(UsuarioList usuarios)
        {
            InitializeComponent();
            this.usuarios = usuarios;
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxUsuario.Text;
            string contrasena = textBoxPassword.Text;

            if (nombre == "" || contrasena == "")
            {
                MessageBox.Show("Rellena el usuario y la contraseña");
            }
            else if (nombre.Contains(";") || contrasena.Contains(";"))
            {
                MessageBox.Show("No se puede usar el carácter ;");
            }
            else if (contrasena != textBoxPassword2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else if (usuarios.Registrar(nombre, contrasena) == false)
            {
                MessageBox.Show("Ese usuario ya existe");
            }
            else
            {
                MessageBox.Show("Usuario registrado correctamente");
                Close();
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
