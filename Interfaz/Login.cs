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
            usuarios.CargarDeFichero();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
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