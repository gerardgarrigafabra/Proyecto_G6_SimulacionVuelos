using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Interfaz
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }



        private void introducciónDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data1 form = new Data1();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
