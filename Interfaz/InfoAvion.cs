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
    public partial class InfoAvion : Form
    {
        FlightPlan avionEscogido;
        public InfoAvion(FlightPlan avionEscogido)
        {
            InitializeComponent();
            this.avionEscogido = avionEscogido;
        }

        private void InfoAvion_Load(object sender, EventArgs e)
        {
            txtId.Text = avionEscogido.GetId();
            txtVelocidad.Text = avionEscogido.GetVelocidad().ToString();
            txtPosicion.Text = avionEscogido.GetCurrentPosition().GetX().ToString() + ", " + avionEscogido.GetCurrentPosition().GetY().ToString();
            txtDestino.Text= avionEscogido.GetFinalPosition().GetX().ToString() + ", " + avionEscogido.GetFinalPosition().GetY().ToString();
            if (avionEscogido.HasArrived())
            {
                txtEstado.Text = "Ha llegado al destino";
            }
            else
                txtEstado.Text = "En route";
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
