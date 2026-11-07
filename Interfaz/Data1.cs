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
    public partial class Data1 : Form
    {
        public Data1()
        {
            InitializeComponent();
        }
        List<FlightPlan> listaAviones = new List<FlightPlan>();
        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                FlightPlan F1 = new FlightPlan(
                    id1.Text,
                    Convert.ToDouble(initialPositionX1.Text),
                    Convert.ToDouble(initialPositionY1.Text),
                    Convert.ToDouble(finalPositionX1.Text),
                    Convert.ToDouble(finalPositionY1.Text),
                    Convert.ToDouble(velocidad1.Text)
                );

                FlightPlan F2 = new FlightPlan(
                    id2.Text,
                    Convert.ToDouble(initialPositionX2.Text),
                    Convert.ToDouble(initialPositionY2.Text),
                    Convert.ToDouble(finalPositionX2.Text),
                    Convert.ToDouble(finalPositionY2.Text),
                    Convert.ToDouble(velocidad2.Text)
                );

                if (F1.GetVelocidad() < 0 || F2.GetVelocidad() < 0)
                {
                    MessageBox.Show("ERROR: La velocidad no puede ser negativa");
                    return;
                }

                listaAviones.Clear();

                listaAviones.Add(F1);
                listaAviones.Add(F2);

                MessageBox.Show("Datos cargados correctamente");
            }
            catch (FormatException)
            {
                MessageBox.Show("ERROR: formato incorrecto");
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public List<FlightPlan> GetFlightPlans()
        {
            return listaAviones;
        }
    }
}
