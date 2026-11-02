using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaz
{
    public partial class SimulacionVuelos : Form
    {
        FlightPlan F1, F2;
        int tiempoCiclo;
        PictureBox avion1, avion2;

        int distanciaSeguridad;


        public SimulacionVuelos(FlightPlan F1, FlightPlan F2, int tiempoCiclo, int distSeguridad)
        {
            InitializeComponent();
            this.F1 = F1;
            this.F2 = F2;
            this.tiempoCiclo = tiempoCiclo;
            this.distanciaSeguridad = distSeguridad;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen1 = new Pen(Color.Blue);
            Pen myPen2 = new Pen(Color.Green);

            e.Graphics.DrawLine(myPen1,
                (float)F1.GetInitialPosition().GetX(), (float)F1.GetInitialPosition().GetY(),
                (float)F1.GetFinalPosition().GetX(), (float)F1.GetFinalPosition().GetY());

            e.Graphics.DrawLine(myPen2,
                (float)F2.GetInitialPosition().GetX(), (float)F2.GetInitialPosition().GetY(),
                (float)F2.GetFinalPosition().GetX(), (float)F2.GetFinalPosition().GetY());

            myPen1.Dispose();
            myPen2.Dispose();

            using (Graphics g = Panel.CreateGraphics())
            using (Pen pen = new Pen(Color.Red, 2))
            {
                int radio = distanciaSeguridad;
                int diametro = radio * 2;

                // Elipse alrededor del primer avión
                g.DrawEllipse(
                    pen,
                    (float)F1.GetCurrentPosition().GetX() - radio,
                    (float)F1.GetCurrentPosition().GetY() - radio,
                    diametro,
                    diametro
                );

                // Elipse alrededor del segundo avión
                g.DrawEllipse(
                    pen,
                    (float)F2.GetCurrentPosition().GetX() - radio,
                    (float)F2.GetCurrentPosition().GetY() - radio,
                    diametro,
                    diametro
                );
            }
        }

        private void Mover_Click(object sender, EventArgs e)
        {
            // Muevo un ciclo y actualizo la posicion en el panel
            F1.Mover(tiempoCiclo);
            F2.Mover(tiempoCiclo);

            Panel.Refresh();

            // resto 10 para corregir la posicion del avion y que se vea centrado
            avion1.Location = new Point(Convert.ToInt32(F1.GetCurrentPosition().GetX()) - 10, Convert.ToInt32(F1.GetCurrentPosition().GetY()) - 10);
            avion2.Location = new Point(Convert.ToInt32(F2.GetCurrentPosition().GetX()) - 10, Convert.ToInt32(F2.GetCurrentPosition().GetY()) - 10);

            if (F1.Conflicto(F2, distanciaSeguridad) == true)
            {
                // FASE 10: aviso al usuario de que los vuelos estan a menos de la distancia de seguridad
                double distancia = F1.GetCurrentPosition().Distancia(F2.GetCurrentPosition());
                labelAlarma.Text = "¡ALERTA! Distancia entre vuelos: " + distancia.ToString("F2");
                labelAlarma.Visible = true;

            }
            else
            {
                // Si ya no hay conflicto, quito el aviso
                labelAlarma.Visible = false;
            }
        }

        // FASE 10: informa de si los vuelos entraran en conflicto o no
        private void buttonConflicto_Click(object sender, EventArgs e)
        {
            // Trabajo con copias de los vuelos (desde su posicion actual),
            // asi los vuelos reales de la simulacion no se mueven
            FlightPlan plan_a = new FlightPlan(F1.GetId(), F1.GetCurrentPosition().GetX(), F1.GetCurrentPosition().GetY(),
                F1.GetFinalPosition().GetX(), F1.GetFinalPosition().GetY(), F1.GetVelocidad());
            FlightPlan plan_b = new FlightPlan(F2.GetId(), F2.GetCurrentPosition().GetX(), F2.GetCurrentPosition().GetY(),
                F2.GetFinalPosition().GetX(), F2.GetFinalPosition().GetY(), F2.GetVelocidad());

            // Si ya empiezan en conflicto no hace falta simular
            bool conflicto = plan_a.Conflicto(plan_b, distanciaSeguridad);

            int ciclos = 0;
            int maxCiclos = 100000; // limite para no quedarnos en un bucle infinito (por ejemplo con velocidad 0)

            // Simulo ciclo a ciclo hasta que los dos lleguen o se detecte conflicto
            while (conflicto == false && (plan_a.HasArrived() == false || plan_b.HasArrived() == false) && ciclos < maxCiclos)
            {
                plan_a.Mover(tiempoCiclo);
                plan_b.Mover(tiempoCiclo);

                if (plan_a.Conflicto(plan_b, distanciaSeguridad) == true)
                    conflicto = true;

                ciclos = ciclos + 1;
            }

            if (conflicto == true)
                MessageBox.Show("Los vuelos entrarán en conflicto.");
            else
                MessageBox.Show("Los vuelos no entrarán en conflicto.");
        }

        private void MovAuto_Click(object sender, EventArgs e)
        {
            if (AutoMov.Text == "Movimiento Automatico")
            {
                timer1.Interval = 100;
                timer1.Start();

                AutoMov.Text = "PARAR";
            }
            else
            {
                timer1.Stop();
                AutoMov.Text = "Movimiento Automatico";
            }
        }

        private void MoverVuelosBtn_Click(object sender, EventArgs e)
        {
            DataGridForm form = new DataGridForm(F1, F2);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int nuevaVel = Convert.ToInt32(textBox2.Text);
                string id = textBox1.Text;
                if (nuevaVel > 0)
                {
                    if (id == F1.GetId() || id == F2.GetId())
                    {
                        if (id == F1.GetId())
                        {
                            F1.SetVelocidad(nuevaVel);
                            F1.Restart();
                            F2.Restart();
                            MessageBox.Show("Velocidad del vuelo 1 cambiada a " + nuevaVel);
                        }
                        if (id == F2.GetId())
                        {
                            F2.SetVelocidad(nuevaVel);
                            F1.Restart();
                            F2.Restart();
                            MessageBox.Show("Velocidad del vuelo 2 cambiada a " + nuevaVel);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe ningun vuelo con ese ID");
                    }
                }
                else
                {
                    MessageBox.Show("Introduce un numero entero positivo");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Introduce un numero entero");
            }
        }


        private void SimulacionVuelos_Load(object sender, EventArgs e)
        {
            Panel.Dock = DockStyle.None;
            Panel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Panel.Size = new Size(500, 500);
            Panel.MinimumSize = new Size(500, 500);
            Panel.MaximumSize = new Size(500, 500);

            avion1 = new PictureBox();
            avion1.Size = new Size(20, 20);
            avion1.SizeMode = PictureBoxSizeMode.StretchImage;
            avion1.Image = new Bitmap("Avion.gif");
            avion1.Location = new Point(Convert.ToInt32(F1.GetCurrentPosition().GetX()) - (avion1.Width / 2), Convert.ToInt32(F1.GetCurrentPosition().GetY()) - (avion1.Width / 2));
            avion1.Tag = F1;
            avion1.Click += new System.EventHandler(this.evento);
            Panel.Controls.Add(avion1);

            avion2 = new PictureBox();
            avion2.Size = new Size(20, 20);
            avion2.SizeMode = PictureBoxSizeMode.StretchImage;
            avion2.Image = new Bitmap("Avion.gif");
            avion2.Location = new Point(Convert.ToInt32(F2.GetCurrentPosition().GetX()) - (avion2.Width / 2), Convert.ToInt32(F2.GetCurrentPosition().GetY()) - (avion2.Width / 2));
            avion2.Tag = F2;
            avion2.Click += new System.EventHandler(this.evento);
            Panel.Controls.Add(avion2);

        }

        private void evento(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            FlightPlan avionEscogido = (FlightPlan)p.Tag;

            InfoAvion form = new InfoAvion(avionEscogido);
            form.ShowDialog();
        }

    }
}
