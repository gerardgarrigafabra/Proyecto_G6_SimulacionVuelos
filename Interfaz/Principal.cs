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
        FlightPlan F1;
        FlightPlan F2;
        int tiempoCiclo;
        int distSeguridad;
        public Principal()
        {
            InitializeComponent();
        }



        private void introducciónDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data1 form = new Data1();
            //recuperar fight plans
            form.ShowDialog();
            F1 = form.GetFlightPlan1();
            F2 = form.GetFlightPlan2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data2 form = new Data2();
            form.ShowDialog();
            tiempoCiclo = form.GetTiempoCiclo();
            distSeguridad = form.GetDistanciaSeguridad();
            
        }

        private void simulaciónDeVuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F1 != null && F2 != null && tiempoCiclo != 0)
            {
                SimulacionVuelos form = new SimulacionVuelos(F1, F2, tiempoCiclo, distSeguridad);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, introduzca los datos de los vuelos antes de iniciar la simulación.");
            }
        }
    }
}
