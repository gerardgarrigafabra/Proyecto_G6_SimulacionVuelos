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
    public partial class Data2 : Form
    {
        public Data2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int tiempoCiclo = Convert.ToInt32(tiempoCiclo1.Text);
                int distSeguridad = Convert.ToInt32(distanciaSeguridad1.Text);

            }
            catch(FormatException)
            {
                MessageBox.Show("ERROR");
            }
        }
    }
}
