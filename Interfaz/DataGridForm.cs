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

        public DataGridForm(FlightPlan F1, FlightPlan F2)
        {
            InitializeComponent();
            this.F1 = F1;
            this.F2 = F2;
        }
        
        private void DataGridForm_Load(object sender, EventArgs e)
        {

            dataGridView1.Columns.Add("Col1", "ID");
            dataGridView1.Columns.Add("Col2", "Estado");
            dataGridView1.Columns.Add("Col3", "Velocidad");
            dataGridView1.Columns.Add("Col4", "Posicion");
            dataGridView1.Columns.Add("Col5", "Destino");

            dataGridView1.Rows.Add(F1.GetId(), "", F1.GetVelocidad(), F1.GetCurrentPosition().GetX().ToString("F2") +", "+ F1.GetCurrentPosition().GetY().ToString("F2"), F1.GetFinalPosition().GetX().ToString("F2") + ", "+ F1.GetFinalPosition().GetY().ToString("F2"));
            dataGridView1.Rows.Add(F2.GetId(), "", F2.GetVelocidad(), F2.GetCurrentPosition().GetX().ToString("F2") + ", " + F2.GetCurrentPosition().GetY().ToString("F2"), F2.GetFinalPosition().GetX().ToString("F2") + ", " + F2.GetFinalPosition().GetY().ToString("F2"));

        }
    }
}
