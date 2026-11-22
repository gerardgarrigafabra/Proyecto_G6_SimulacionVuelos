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
        FlightPlanList listaAviones;
        int fila;


        public PlaneDistance(FlightPlanList listaAviones, int fila)
        {
            InitializeComponent();
            this.listaAviones = listaAviones;
            this.fila = fila;
            TemaVisual.Aplicar(this);
        }
        private void PlaneDistance_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Col1", "ID");
            dataGridView1.Columns.Add("ColCompany", "Compañía");
            dataGridView1.Columns.Add("ColDistancia", "Distancia");
            //añadimos a la tabla los datos de los aviones y la distancia entre ellos
            for (int i = 0; i < listaAviones.GetListSize(); i++)
            {
                if (listaAviones.GetFlightPlan(i) != listaAviones.GetFlightPlan(fila))
                {
                    dataGridView1.Rows.Add(listaAviones.GetFlightPlan(i).GetId(), listaAviones.GetFlightPlan(i).GetCompany(), listaAviones.GetFlightPlan(i).Distancia(listaAviones.GetFlightPlan(fila)));
                }
            }
           
            
        }


    }
}
