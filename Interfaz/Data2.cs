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
    public partial class Data2 : Form
    {
        int tiempoCiclo;
        int distSeguridad;
        public Data2()
        {
            InitializeComponent();
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            try
            {
                tiempoCiclo = Convert.ToInt32(tiempoCiclo1.Text);
                distSeguridad = Convert.ToInt32(distanciaSeguridad1.Text);
                MessageBox.Show("Datos introducidos correctamente");
                if (tiempoCiclo < 0 || distSeguridad < 0)
                {
                    MessageBox.Show("ERROR: Los valores no pueden ser negativos");
                }

            }
            catch(FormatException)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonAutomatico2_Click(object sender, EventArgs e)
        {
            distanciaSeguridad1.Text = "50";
            tiempoCiclo1.Text = "10";
        }
        public int GetTiempoCiclo()
        {
            return tiempoCiclo;
        }
        public int GetDistanciaSeguridad()
        {
            return distSeguridad;
        }


    }
}
