namespace Interfaz
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menúSimulacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.introducciónDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulaciónDeVuelosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1052, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúSimulacionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1313, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menúSimulacionToolStripMenuItem
            // 
            this.menúSimulacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.introducciónDeDatosToolStripMenuItem,
            this.distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem,
            this.simulaciónDeVuelosToolStripMenuItem});
            this.menúSimulacionToolStripMenuItem.Name = "menúSimulacionToolStripMenuItem";
            this.menúSimulacionToolStripMenuItem.Size = new System.Drawing.Size(162, 29);
            this.menúSimulacionToolStripMenuItem.Text = "Menú simulacion";
            // 
            // introducciónDeDatosToolStripMenuItem
            // 
            this.introducciónDeDatosToolStripMenuItem.Name = "introducciónDeDatosToolStripMenuItem";
            this.introducciónDeDatosToolStripMenuItem.Size = new System.Drawing.Size(451, 34);
            this.introducciónDeDatosToolStripMenuItem.Text = "Introducción de Flight Plans";
            this.introducciónDeDatosToolStripMenuItem.Click += new System.EventHandler(this.introducciónDeDatosToolStripMenuItem_Click);
            // 
            // distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem
            // 
            this.distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem.Name = "distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem";
            this.distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem.Size = new System.Drawing.Size(451, 34);
            this.distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem.Text = "Distancias de seguridad y tiempos de ciclo";
            this.distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem.Click += new System.EventHandler(this.distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem_Click);
            // 
            // simulaciónDeVuelosToolStripMenuItem
            // 
            this.simulaciónDeVuelosToolStripMenuItem.Name = "simulaciónDeVuelosToolStripMenuItem";
            this.simulaciónDeVuelosToolStripMenuItem.Size = new System.Drawing.Size(451, 34);
            this.simulaciónDeVuelosToolStripMenuItem.Text = "Simulación de vuelos";
            this.simulaciónDeVuelosToolStripMenuItem.Click += new System.EventHandler(this.simulaciónDeVuelosToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 718);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Text = "Principal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menúSimulacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem introducciónDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem distanciasDeSeguridadYTiemposDeCicloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulaciónDeVuelosToolStripMenuItem;
    }
}

