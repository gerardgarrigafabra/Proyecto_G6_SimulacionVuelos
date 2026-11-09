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
     
        int tiempoCiclo;
        List<PictureBox> listaPictureBoxes = new List<PictureBox>(); // Llista de pictureboxes
        FlightPlanList listaAviones = new FlightPlanList();
        int distanciaSeguridad;


        public SimulacionVuelos(FlightPlanList listaAviones, int tiempoCiclo, int distSeguridad)
        {
            InitializeComponent();
            this.listaAviones = listaAviones;
            this.tiempoCiclo = tiempoCiclo;
            this.distanciaSeguridad = distSeguridad;
            
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {   
            for ( int i = 0; i < listaAviones.GetListSize(); i++ )
            {
                Pen myPen = new Pen(Color.Blue);
                e.Graphics.DrawLine(myPen,
                    (float)listaAviones.GetFlightPlan(i).GetInitialPosition().GetX(), (float)listaAviones.GetFlightPlan(i).GetInitialPosition().GetY(),
                    (float)listaAviones.GetFlightPlan(i).GetFinalPosition().GetX(), (float)listaAviones.GetFlightPlan(i).GetFinalPosition().GetY());

                myPen.Dispose();

                using (Graphics g = Panel.CreateGraphics())
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    int radio = distanciaSeguridad;
                    int diametro = radio * 2;

                    g.DrawEllipse(
                        pen,
                        (float)listaAviones.GetFlightPlan(i).GetCurrentPosition().GetX() - radio,
                        (float)listaAviones.GetFlightPlan(i).GetCurrentPosition().GetY() - radio,
                        diametro,
                        diametro);

                }
            }
        }

        private void Mover_Click(object sender, EventArgs e)
        {
            listaAviones.Mover(tiempoCiclo);
            Panel.Refresh();

            for (int i = 0; i<listaAviones.GetListSize(); i++)
            {
                listaPictureBoxes[i].Location = new Point(
                    Convert.ToInt32(listaAviones.GetFlightPlan(i).GetCurrentPosition().GetX()) - 10,
                    Convert.ToInt32(listaAviones.GetFlightPlan(i).GetCurrentPosition().GetY()) - 10);
            }

            if (listaAviones.HayConflicto(distanciaSeguridad) == true)
            {
                labelAlarma.Text = ("¡ALERTA! Vuelos En Conflicto");
                labelAlarma.Visible = true;
            }
            else
            {
                labelAlarma.Visible = false;
            }
        }

        // informa de si los vuelos entraran en conflicto o no
        private void buttonConflicto_Click(object sender, EventArgs e)
        {
            bool conflicto = listaAviones.HabraConflicto(tiempoCiclo, distanciaSeguridad);

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

        private void MostarVuelosBtn_Click(object sender, EventArgs e)
        {
            DataGridForm form = new DataGridForm(listaAviones);
            form.ShowDialog();
        }

        private void CambiarVelocidadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int nuevaVel = Convert.ToInt32(textBoxNuevaVelocidad.Text);
                string id = textBoxID.Text;
                if (nuevaVel > 0)
                {
                    bool encontrado = false;
                    for (int i = 0; i < listaAviones.GetListSize(); i++)
                    {
                        if (id == listaAviones.GetFlightPlan(i).GetId())
                        {
                            listaAviones.GetFlightPlan(i).SetVelocidad(nuevaVel);
                            listaAviones.RestartList();
                            MessageBox.Show("Velocidad del vuelo cambiada");
                            encontrado = true;
                        }
                    }
                    if (encontrado == false)
                    {
                        MessageBox.Show("No existe ningún vuelo con esa ID");
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

            // primer PictureBox

            for (int i = 0; i < listaAviones.GetListSize(); i++)
            {
                PictureBox avion = new PictureBox();

                avion.Size = new Size(20, 20);
                avion.SizeMode = PictureBoxSizeMode.StretchImage;
                avion.Image = new Bitmap("Avion.gif");

                avion.Location = new Point(
                    Convert.ToInt32(listaAviones.GetFlightPlan(i).GetCurrentPosition().GetX()) - 10,
                    Convert.ToInt32(listaAviones.GetFlightPlan(i).GetCurrentPosition().GetY()) - 10);

                avion.Tag = listaAviones.GetFlightPlan(i); 
                avion.Click += new System.EventHandler(this.evento);
                listaPictureBoxes.Add(avion);
                Panel.Controls.Add(avion);
            }
        }

        private void evento(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            FlightPlan avionEscogido = (FlightPlan)p.Tag;

            InfoAvion form = new InfoAvion(avionEscogido);
            form.ShowDialog();
        }
        
        private void buttonDistMin_Click(object sender, EventArgs e)
        {
            // 2 vols com a mínim
            if (listaAviones.GetListSize() < 2)
            {
                MessageBox.Show("Hacen falta al menos dos vuelos.");
                return;
            }
            double dMin = listaAviones.GetFlightPlan(0).DistanciaMinima(listaAviones.GetFlightPlan(1));
            string id1 = listaAviones.GetFlightPlan(0).GetId();
            string id2 = listaAviones.GetFlightPlan(1).GetId();

            int i = 0;
            while (i < listaAviones.GetListSize())
            {
                int j = i + 1;
                while (j < listaAviones.GetListSize())
                {
                    double d = listaAviones.GetFlightPlan(i).DistanciaMinima(listaAviones.GetFlightPlan(j));

                    if (d < dMin)
                    {
                        dMin = d;
                        id1 = listaAviones.GetFlightPlan(i).GetId();
                        id2 = listaAviones.GetFlightPlan(j).GetId();
                    }
                    j = j + 1;
                }
                i = i + 1;
            }

            MessageBox.Show("Distancia mínima: " + dMin.ToString("F2") + " entre los vuelos " + id1 + " y " + id2);
        }
    }
}
