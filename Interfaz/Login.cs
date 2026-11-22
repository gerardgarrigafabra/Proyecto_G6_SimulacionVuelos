using FlightLib;
using Microsoft.Win32;
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
    public partial class Login : Form
    {
        UsuarioList usuarios = new UsuarioList();
        bool autenticado = false;
        public Login()
        {
            InitializeComponent();

            //miramos si existe la base de datos
            bool existeBD = usuarios.CrearBaseDeDatos();

            if (existeBD == false)
            {
                MessageBox.Show("ERROR: No se encuentra el archivo de la base de datos de usuarios.");
                buttonEntrar.Enabled = false;
                buttonRegistrar.Enabled = false;
            }

            TemaVisual.Aplicar(this);
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            //comprobamos si es correcto
            if (usuarios.Autenticar(textBoxUsuario.Text, textBoxPassword.Text) == true)
            {
                autenticado = true;
                Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            //si no se tiene usuario, se abre el formulario de registro
            Registro form = new Registro(usuarios);
            form.ShowDialog();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool GetAutenticado()
        {
            return autenticado;
        }

       
    }


}