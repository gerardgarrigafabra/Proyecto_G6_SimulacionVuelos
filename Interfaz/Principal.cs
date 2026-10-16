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
                // FASE 11: antes de simular compruebo si los vuelos entraran en conflicto.
                // Uso copias de los vuelos (desde su posicion actual) para no moverlos de verdad
                FlightPlan plan_a = new FlightPlan(F1.GetId(), F1.GetCurrentPosition().GetX(), F1.GetCurrentPosition().GetY(),
                    F1.GetFinalPosition().GetX(), F1.GetFinalPosition().GetY(), F1.GetVelocidad());
                FlightPlan plan_b = new FlightPlan(F2.GetId(), F2.GetCurrentPosition().GetX(), F2.GetCurrentPosition().GetY(),
                    F2.GetFinalPosition().GetX(), F2.GetFinalPosition().GetY(), F2.GetVelocidad());

                bool conflicto = plan_a.Conflicto(plan_b, distSeguridad);
                int ciclos = 0;
                int maxCiclos = 100000; // limite para evitar bucles infinitos

                while (conflicto == false && (plan_a.HasArrived() == false || plan_b.HasArrived() == false) && ciclos < maxCiclos)
                {
                    plan_a.Mover(tiempoCiclo);
                    plan_b.Mover(tiempoCiclo);

                    if (plan_a.Conflicto(plan_b, distSeguridad) == true)
                        conflicto = true;

                    ciclos = ciclos + 1;
                }

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

                            // Copias nuevas, el vuelo 2 con la velocidad nueva
                            plan_a = new FlightPlan(F1.GetId(), F1.GetCurrentPosition().GetX(), F1.GetCurrentPosition().GetY(),
                                F1.GetFinalPosition().GetX(), F1.GetFinalPosition().GetY(), F1.GetVelocidad());
                            plan_b = new FlightPlan(F2.GetId(), F2.GetCurrentPosition().GetX(), F2.GetCurrentPosition().GetY(),
                                F2.GetFinalPosition().GetX(), F2.GetFinalPosition().GetY(), velocidadNueva);

                            conflicto = plan_a.Conflicto(plan_b, distSeguridad);
                            ciclos = 0;

                            while (conflicto == false && (plan_a.HasArrived() == false || plan_b.HasArrived() == false) && ciclos < maxCiclos)
                            {
                                plan_a.Mover(tiempoCiclo);
                                plan_b.Mover(tiempoCiclo);

                                if (plan_a.Conflicto(plan_b, distSeguridad) == true)
                                    conflicto = true;

                                ciclos = ciclos + 1;
                            }

                            intentos = intentos + 1;
                        }

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
