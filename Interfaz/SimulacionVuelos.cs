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

        private void SimulacionVuelos_Load(object sender, EventArgs e)
        {
            avion1 = new PictureBox();
            avion1.Width = 20;
            avion1.Height = 20;
            avion1.BackColor = Color.Red;
            avion1.ClientSize = new Size(20, 20);
            avion1.Location = new Point(20, 50);
            Panel.Controls.Add(avion1);

            avion2 = new PictureBox();
            avion2.Width = 20;
            avion2.Height = 20;
            avion1.BackColor = Color.Blue;
            avion2.ClientSize = new Size(20, 20);
            avion2.Location = new Point(100, 120);
            Panel.Controls.Add(avion2);





        }
    }
}
