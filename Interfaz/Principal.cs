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
        List<FlightPlan> listaAviones = new List<FlightPlan>();
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

            if (listaAviones.Count == 2)
            {
                F1 = listaAviones[0];
                F2 = listaAviones[1];
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
                // Respecte la fase 11 les copies i la simulació ja es tenen en compte a flightplanlist.cs i aqui nomes creo una llista de comprovació de conflicte
                FlightPlanList listaComprobacion = new FlightPlanList();

                listaComprobacion.AddFlightPlan(F1);
                listaComprobacion.AddFlightPlan(F2);

                bool conflicto = listaComprobacion.HabraConflicto(tiempoCiclo, distSeguridad);

                if (conflicto == true)
                {
                    DialogResult respuesta = MessageBox.Show("Los vuelos entrarán en conflicto. ¿Quieres resolverlo automáticamente?",
                        "Conflicto", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        // Resuelvo el conflicto bajando la velocidad del vuelo 2 un 5% cada vez
                        // y repitiendo la comprobacion hasta que ya no haya conflicto
                        double velocidadNueva = F2.GetVelocidad();
                        int intentos = 0;

                        while (conflicto == true && intentos < 40)
                        {
                            velocidadNueva = velocidadNueva * 0.95;
                            FlightPlan prueba = new FlightPlan(F2.GetId(), F2.GetCurrentPosition().GetX(), F2.GetCurrentPosition().GetY(),
                                                             F2.GetFinalPosition().GetX(), F2.GetFinalPosition().GetY(), velocidadNueva);

                            conflicto = F1.DistanciaMinima(prueba) < distSeguridad;
                            intentos = intentos + 1;
                        }

                        conflicto = listaComprobacion.ResolverConflictosLista(distSeguridad);

                        if (conflicto == false)
                        {
                            // Cambio la velocidad del vuelo real y se simulará con la nueva velocidad
                            F2.SetVelocidad(velocidadNueva);
                            MessageBox.Show("Conflicto resuelto. Nueva velocidad del vuelo " + F2.GetId() + ": " + velocidadNueva.ToString("F2"));
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido resolver el conflicto cambiando la velocidad.");
                        }
                    }
                }

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
