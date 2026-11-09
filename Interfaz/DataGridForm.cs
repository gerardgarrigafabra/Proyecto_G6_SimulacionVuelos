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
    public partial class DataGridForm : Form
    {
        FlightPlan F1, F2;
        FlightPlanList listaAviones;

        public DataGridForm(FlightPlanList listaAviones)
        {
            InitializeComponent();
            this.listaAviones = listaAviones;
            F1 = listaAviones.GetFlightPlan(0);
            F2 = listaAviones.GetFlightPlan(1);
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;
            PlaneDistance form = new PlaneDistance(F1, F2, fila);
            form.ShowDialog();
        }

        private void DataGridForm_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns.Add("Col1", "ID");
            dataGridView1.Columns.Add("Col2", "Velocidad");
            dataGridView1.Columns.Add("Col3", "Posicion");
            dataGridView1.Columns.Add("Col4", "Destino");

            for (int i = 0; i < listaAviones.GetListSize(); i++)
            {
                dataGridView1.Rows.Add(listaAviones.GetFlightPlan(i).GetId(), listaAviones.GetFlightPlan(i).GetVelocidad(), listaAviones.GetFlightPlan(i).GetCurrentPosition().GetX().ToString("F2") + ", " + listaAviones.GetFlightPlan(i).GetCurrentPosition().GetY().ToString("F2"), listaAviones.GetFlightPlan(i).GetFinalPosition().GetX().ToString("F2") + ", " + listaAviones.GetFlightPlan(i).GetFinalPosition().GetY().ToString("F2"));
            }
        }

    }
}
