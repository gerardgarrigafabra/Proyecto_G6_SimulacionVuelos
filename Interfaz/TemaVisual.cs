using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Interfaz
{
    public class TemaVisual
    {
        public static void Aplicar(Form formulario)
        {
            formulario.BackColor = Color.FromArgb(242, 245, 250);
            formulario.ForeColor = Color.FromArgb(40, 50, 65);
            formulario.Font = new Font("Segoe UI", 10);
            formulario.StartPosition = FormStartPosition.CenterScreen;

            AplicarAControles(formulario.Controls);
        }

        private static void AplicarAControles(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is Button)
                {
                    Button boton = (Button)control;

                    boton.FlatStyle = FlatStyle.Flat;
                    boton.FlatAppearance.BorderSize = 0;
                    boton.BackColor = Color.FromArgb(40, 105, 180);
                    boton.ForeColor = Color.White;
                    boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    boton.Cursor = Cursors.Hand;
                }
                else if (control is TextBox)
                {
                    TextBox caja = (TextBox)control;

                    caja.BackColor = Color.White;
                    caja.ForeColor = Color.FromArgb(40, 50, 65);
                    caja.Font = new Font("Segoe UI", 10);
                }
                else if (control is Label)
                {
                    control.ForeColor = Color.FromArgb(40, 50, 65);
                    control.Font = new Font("Segoe UI", 10);
                }
                else if (control is DataGridView)
                {
                    DataGridView tabla = (DataGridView)control;

                    tabla.BackgroundColor = Color.White;
                    tabla.BorderStyle = BorderStyle.None;
                    tabla.EnableHeadersVisualStyles = false;

                    tabla.ColumnHeadersDefaultCellStyle.BackColor =
                        Color.FromArgb(40, 105, 180);

                    tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    tabla.ColumnHeadersDefaultCellStyle.Font =
                        new Font("Segoe UI", 10, FontStyle.Bold);

                    tabla.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                    tabla.DefaultCellStyle.SelectionBackColor =
                        Color.FromArgb(210, 225, 245);

                    tabla.DefaultCellStyle.SelectionForeColor =
                        Color.FromArgb(40, 50, 65);

                    tabla.AlternatingRowsDefaultCellStyle.BackColor =
                        Color.FromArgb(240, 244, 250);
                }
                else if (control is MenuStrip)
                {
                    MenuStrip menu = (MenuStrip)control;

                    menu.BackColor = Color.FromArgb(30, 55, 85);
                    menu.ForeColor = Color.White;
                    menu.Font = new Font("Segoe UI", 10);
                }

                if (control.HasChildren)
                {
                    AplicarAControles(control.Controls);
                }
            }
        }
    }
}

