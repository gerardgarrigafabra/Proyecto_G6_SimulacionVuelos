using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        FlightPlanList listaAviones = new FlightPlanList();
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

                listaAviones.AddFlightPlan(F1);
                listaAviones.AddFlightPlan(F2);

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
        private void buttonAutomatico_Click(object sender, EventArgs e)
        {

            id1.Text = "A";
            initialPositionX1.Text = "20";
            initialPositionY1.Text = "20";
            finalPositionX1.Text = "480";
            finalPositionY1.Text = "480";
            velocidad1.Text = "10";


            id2.Text = "B";
            initialPositionX2.Text = "480";
            initialPositionY2.Text = "20";
            finalPositionX2.Text = "20";
            finalPositionY2.Text = "480";
            velocidad2.Text = "10";
        }

        public FlightPlanList GetFlightPlans()
        {
            return listaAviones;
        }

        private void CargarFichero_Click(object sender, EventArgs e)
        { // Se carga datos desde un fichero. En la carpeta se llama FlightPlans.txt -> carga 3 vuelos
            try
            {
                string fichero = nombreFichero.Text;
                listaAviones = new FlightPlanList();
                listaAviones.leerFichero(fichero);
                MessageBox.Show("Datos cargados correctamente");
            }
            catch (FormatException)
            {
                MessageBox.Show("ERROR: formato incorrecto");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("ERROR: fichero no encontrado");
            } 
        }
    }
}
