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
        PictureBox avion1, avion2;


        public SimulacionVuelos(FlightPlan F1, FlightPlan F2)
        {
            InitializeComponent();
            this.F1 = F1;
            this.F2 = F2;
        }

        private void Mover_Click(object sender, EventArgs e)
        {
            F1.Mover()
        }

        }

        private void SimulacionVuelos_Load(object sender, EventArgs e)
        {
            avion1 = new PictureBox();
            avion1.Size = new Size(50, 50);
            avion1.SizeMode = PictureBoxSizeMode.StretchImage;
            avion1.Image = new Bitmap("Avion.gif");
            avion1.Location = new Point(Convert.ToInt32(F1.GetCurrentPosition().GetX()), Convert.ToInt32(F1.GetCurrentPosition().GetY()));
            Panel.Controls.Add(avion1);

            avion2 = new PictureBox();
            avion2.Size = new Size(50, 50);
            avion2.SizeMode = PictureBoxSizeMode.StretchImage;
            avion2.Image = new Bitmap("Avion.gif");
            avion2.Location = new Point(Convert.ToInt32(F2.GetCurrentPosition().GetX()), Convert.ToInt32(F2.GetCurrentPosition().GetY()));
            Panel.Controls.Add(avion2);





        }
            
    }
}
