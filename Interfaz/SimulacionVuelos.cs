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
            Pen myPen = new Pen(Color.Red);

            e.Graphics.DrawLine(myPen,
                (float)F1.GetInitialPosition().GetX(), (float)F1.GetInitialPosition().GetY(),
                (float)F1.GetFinalPosition().GetX(), (float)F1.GetFinalPosition().GetY());

            e.Graphics.DrawLine(myPen,
                (float)F2.GetInitialPosition().GetX(), (float)F2.GetInitialPosition().GetY(),
                (float)F2.GetFinalPosition().GetX(), (float)F2.GetFinalPosition().GetY());

            myPen.Dispose();
        }

        private void Mover_Click(object sender, EventArgs e)
        {
            // Muevo un ciclo y actualizo la posicion en el panel
            F1.Mover(tiempoCiclo);
            F2.Mover(tiempoCiclo);

            Panel.Refresh();

            // resto 10 para corregir la posicion del avion y que se vea centrado
            avion1.Location = new Point(Convert.ToInt32(F1.GetCurrentPosition().GetX())-10, Convert.ToInt32(F1.GetCurrentPosition().GetY())-10);
            avion2.Location = new Point(Convert.ToInt32(F2.GetCurrentPosition().GetX())-10, Convert.ToInt32(F2.GetCurrentPosition().GetY())-10);

            if (F1.Conflicto(F2, distanciaSeguridad) == true)
            {
                
                using (Graphics g = Panel.CreateGraphics())
                using (Pen pen = new Pen(Color.Orange, 2))
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
