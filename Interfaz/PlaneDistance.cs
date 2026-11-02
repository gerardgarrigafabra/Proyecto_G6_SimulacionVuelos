using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class PlaneDistance : Form
    {
        FlightPlan F1, F2;
        int fila;


        public PlaneDistance(FlightPlan F1, FlightPlan F2, int fila)
        {
            InitializeComponent();
            this.F1 = F1;
            this.F2 = F2;
            this.fila = fila;
        }
        private void PlaneDistance_Load(object sender, EventArgs e)
        {

            valor.Text = F1.Distancia(F2).ToString();
        }


    }
}
