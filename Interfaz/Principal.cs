using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Interfaz
{
    public partial class Principal : Form
    {
        FlightPlanList listaAviones = new FlightPlanList();
        FlightPlan F1;
        FlightPlan F2;

        int tiempoCiclo;
        int distSeguridad;
        public Principal()
        {
            InitializeComponent();
            TemaVisual.Aplicar(this);
            CrearInterfaz();
            AplicarEstiloMenu();
            CrearBarraEstado();
        }
        private void CrearInterfaz()
        {
            // Configuración de la ventana principal
            this.Text = "Flight Control Simulator";
            this.BackColor = Color.FromArgb(240, 244, 249);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1100, 700);

            Label titulo = new Label();
            titulo.Text = "Proyecto de Simulación de Vuelos";
            titulo.Font = new Font("Segoe UI", 26, FontStyle.Bold);
            titulo.ForeColor = Color.FromArgb(30, 55, 85);
            titulo.Location = new Point(50, 90);
            titulo.AutoSize = true;

            Label subtitulo = new Label();
            subtitulo.Text = "Grupo 6_Guillem Zapater, Pau Tondo, Gerard Garriga, Luca Romero";
            subtitulo.Font = new Font("Segoe UI", 12);
            subtitulo.ForeColor = Color.Gray;
            subtitulo.Location = new Point(53, 145);
            subtitulo.AutoSize = true;

            this.Controls.Add(titulo);
            this.Controls.Add(subtitulo);
        }

        private void AplicarEstiloMenu()
        {
            // Estilo del menú
            menuStrip1.BackColor = Color.FromArgb(30, 55, 85);
            menuStrip1.ForeColor = Color.White;
            menuStrip1.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            menuStrip1.Padding = new Padding(8, 5, 8, 5);

            menúSimulacionToolStripMenuItem.ForeColor = Color.White;
            menúSimulacionToolStripMenuItem.BackColor =
                Color.FromArgb(30, 55, 85);

            menúSimulacionToolStripMenuItem.DropDown.BackColor = Color.White;

            introducciónDeDatosToolStripMenuItem.BackColor = Color.White;
            introducciónDeDatosToolStripMenuItem.ForeColor =
                Color.FromArgb(40, 50, 65);

            distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem.BackColor =
                Color.White;
            distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem.ForeColor =
                Color.FromArgb(40, 50, 65);

            simulaciónDeVuelosToolStripMenuItem.BackColor = Color.White;
            simulaciónDeVuelosToolStripMenuItem.ForeColor =
                Color.FromArgb(40, 50, 65);
        }

        private void CrearBarraEstado()
        {
            // Creamos una barra de estado en la parte inferior de la ventana principal
            StatusStrip barra = new StatusStrip();

            barra.BackColor = Color.FromArgb(30, 55, 85);
            barra.ForeColor = Color.White;
            barra.SizingGrip = false;

            ToolStripStatusLabel nombre = new ToolStripStatusLabel();
            nombre.Text = "FLIGHT CONTROL SIMULATOR";
            nombre.ForeColor = Color.White;
            nombre.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            ToolStripStatusLabel estado = new ToolStripStatusLabel();
            estado.Text = "Sistema listo";
            estado.ForeColor = Color.LightGreen;
            estado.Spring = true;
            estado.TextAlign = ContentAlignment.MiddleRight;

            barra.Items.Add(nombre);
            barra.Items.Add(estado);

            this.Controls.Add(barra);
        }


        //Dependiendo de el boton, abrimos uno o otro formulario y nos pasamos la informacion
        private void introducciónDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Data1 form = new Data1();

            form.ShowDialog();

            

            listaAviones = form.GetFlightPlans();

            if (listaAviones.GetListSize() >= 2)
            {
                F1 = listaAviones.GetFlightPlan(0);
                F2 = listaAviones.GetFlightPlan(1);
            }
            else
            {
                MessageBox.Show("Por favor, introduzca los datos de los dos vuelos.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data2 form = new Data2();
            form.ShowDialog();
            tiempoCiclo = form.GetTiempoCiclo();
            distSeguridad = form.GetDistanciaSeguridad();

        }

        //Simulamos los vuelos y comprobamos si hay conflicto, si lo hay, preguntamos si queremos resolverlo automaticamente
        private void simulaciónDeVuelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (F1 != null && F2 != null && tiempoCiclo != 0)
            {
                bool conflicto = listaAviones.HayConflictoFuturo(distSeguridad);

                if (conflicto == true)
                {
                    DialogResult respuesta = MessageBox.Show("Los vuelos entrarán en conflicto. ¿Quieres resolverlo automáticamente?",
                        "Conflicto", MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        conflicto = listaAviones.ResolverConflictosLista(distSeguridad);

                        if (conflicto == false)
                        {
                            MessageBox.Show("Conflicto resuelto.");
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido resolver el conflicto cambiando la velocidad.");
                        }
                    }
                }
                //Si no hay conflicto, se haya resuelto o no, abrimos el formulario de simulación
                SimulacionVuelos form = new SimulacionVuelos(listaAviones, tiempoCiclo, distSeguridad);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, introduzca los datos de los vuelos antes de iniciar la simulación.");
            }
        }
    }
}
