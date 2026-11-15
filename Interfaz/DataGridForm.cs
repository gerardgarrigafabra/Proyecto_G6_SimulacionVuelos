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
            dataGridView1.Columns.Add("ColCompany", "Compañía");
            dataGridView1.Columns.Add("Col2", "Velocidad");
            dataGridView1.Columns.Add("Col3", "Posicion");
            dataGridView1.Columns.Add("Col4", "Destino");

            for (int i = 0; i < listaAviones.GetListSize(); i++)
            {
                FlightPlan F = listaAviones.GetFlightPlan(i);
                string posicion = F.GetCurrentPosition().GetX().ToString("F2") + ", " + F.GetCurrentPosition().GetY().ToString("F2");
                string destino = F.GetFinalPosition().GetX().ToString("F2") + ", " + F.GetFinalPosition().GetY().ToString("F2");

               
                dataGridView1.Rows.Add(F.GetId(), F.GetCompany(), F.GetVelocidad(), posicion, destino);
            }
        }

    }
}
