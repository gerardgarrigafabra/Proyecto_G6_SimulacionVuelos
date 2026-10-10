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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                tiempoCiclo = Convert.ToInt32(tiempoCiclo1.Text);
                distSeguridad = Convert.ToInt32(distanciaSeguridad1.Text);
                MessageBox.Show("Datos introducidos correctamente");
                
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
