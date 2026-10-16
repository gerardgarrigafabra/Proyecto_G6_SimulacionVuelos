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
        int Fila;


        public PlaneDistance(FlightPlan F1, FlightPlan F2, int Fila)
        {
            InitializeComponent();
            this.F1 = F1;
            this.F2 = F2;
            this.Fila = Fila;
        }
        private void PlaneDistance_Load(object sender, EventArgs e)
        {   
            if(Fila == 1)
            {
                label2.Text = F1.GetCurrentPosition().Distancia(F2.GetCurrentPosition()).ToString();
            }
            else
            {
                label2.Text = F2.GetCurrentPosition().Distancia(F1.GetCurrentPosition()).ToString();
            }
        }


    }
}
