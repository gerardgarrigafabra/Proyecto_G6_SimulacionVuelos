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
        FlightPlanList listaAviones = new FlightPlanList();
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

            form.ShowDialog();

            

            listaAviones = form.GetFlightPlans();

            if (listaAviones.GetListSize() >= 2)
            {
                F1 = listaAviones.GetFlightPlan(0);
                F2 = listaAviones.GetFlightPlan(1);
            }
            else
            {
                MessageBox.Show("Por favor, introduzca los datos de los dos vuelos.");
            }
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
                bool conflicto = listaAviones.HabraConflicto(tiempoCiclo, distSeguridad);

                if (conflicto == true)
                {
                    DialogResult respuesta = MessageBox.Show("Los vuelos entrarán en conflicto. ¿Quieres resolverlo automáticamente?",
                        "Conflicto", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        conflicto = listaAviones.ResolverConflictosLista(distSeguridad);

                        if (conflicto == false)
                        {
                            MessageBox.Show("Conflicto resuelto.");
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido resolver el conflicto cambiando la velocidad.");
                        }
                    }
                }

                SimulacionVuelos form = new SimulacionVuelos(listaAviones, tiempoCiclo, distSeguridad);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, introduzca los datos de los vuelos antes de iniciar la simulación.");
            }
        }
    }
}
