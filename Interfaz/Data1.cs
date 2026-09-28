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

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            try
            {

                FlightPlan F1 = new FlightPlan(id1.Text, Convert.ToDouble(initialPositionX1.Text), Convert.ToDouble(initialPositionY1.Text), Convert.ToDouble(finalPositionX1.Text), Convert.ToDouble(finalPositionY1.Text), Convert.ToDouble(velocidad1.Text));
                FlightPlan F2 = new FlightPlan(id2.Text, Convert.ToDouble(initialPositionX2.Text), Convert.ToDouble(initialPositionY1.Text), Convert.ToDouble(finalPositionX2.Text), Convert.ToDouble(finalPositionY2.Text), Convert.ToDouble(velocidad2.Text));
                MessageBox.Show("Datos cargados correctamente");
            }
            catch (FormatException)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
