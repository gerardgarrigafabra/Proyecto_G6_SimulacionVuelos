namespace Interfaz
{
    partial class SimulacionVuelos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Mover = new System.Windows.Forms.Button();
            this.AutoMov = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MostrarVuelosBtn = new System.Windows.Forms.Button();
            this.buttonConflicto = new System.Windows.Forms.Button();
            this.labelAlarma = new System.Windows.Forms.Label();
            this.CambiarVelocidadBtn = new System.Windows.Forms.Button();
            this.LabelIdCv = new System.Windows.Forms.Label();
            this.labelNuevaVel = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxNuevaVelocidad = new System.Windows.Forms.TextBox();
            this.buttonDistMin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel.Location = new System.Drawing.Point(563, 40);
            this.Panel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(654, 618);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(557, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(527, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(497, 627);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "499";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(1159, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "499";
            // 
            // Mover
            // 
            this.Mover.Location = new System.Drawing.Point(181, 83);
            this.Mover.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Mover.Name = "Mover";
            this.Mover.Size = new System.Drawing.Size(171, 84);
            this.Mover.TabIndex = 4;
            this.Mover.Text = "Mover Vuelos";
            this.Mover.UseVisualStyleBackColor = true;
            this.Mover.Click += new System.EventHandler(this.Mover_Click);
            // 
            // AutoMov
            // 
            this.AutoMov.Location = new System.Drawing.Point(181, 188);
            this.AutoMov.Name = "AutoMov";
            this.AutoMov.Size = new System.Drawing.Size(171, 87);
            this.AutoMov.TabIndex = 5;
            this.AutoMov.Text = "Movimiento Automatico";
            this.AutoMov.UseVisualStyleBackColor = true;
            this.AutoMov.Click += new System.EventHandler(this.MovAuto_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Mover_Click);
            // 
            // MostrarVuelosBtn
            // 
            this.MostrarVuelosBtn.Location = new System.Drawing.Point(181, 300);
            this.MostrarVuelosBtn.Name = "MostrarVuelosBtn";
            this.MostrarVuelosBtn.Size = new System.Drawing.Size(171, 77);
            this.MostrarVuelosBtn.TabIndex = 6;
            this.MostrarVuelosBtn.Text = "Mostar Vuelos";
            this.MostrarVuelosBtn.UseVisualStyleBackColor = true;
            this.MostrarVuelosBtn.Click += new System.EventHandler(this.MostarVuelosBtn_Click);
            // 
            // buttonConflicto
            // 
            this.buttonConflicto.Location = new System.Drawing.Point(181, 397);
            this.buttonConflicto.Name = "buttonConflicto";
            this.buttonConflicto.Size = new System.Drawing.Size(171, 77);
            this.buttonConflicto.TabIndex = 7;
            this.buttonConflicto.Text = "¿Habrá conflicto?";
            this.buttonConflicto.UseVisualStyleBackColor = true;
            this.buttonConflicto.Click += new System.EventHandler(this.buttonConflicto_Click);
            // 
            // labelAlarma
            // 
            this.labelAlarma.AutoSize = true;
            this.labelAlarma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelAlarma.ForeColor = System.Drawing.Color.Red;
            this.labelAlarma.Location = new System.Drawing.Point(30, 620);
            this.labelAlarma.Name = "labelAlarma";
            this.labelAlarma.Size = new System.Drawing.Size(96, 25);
            this.labelAlarma.TabIndex = 8;
            this.labelAlarma.Text = "ALERTA";
            this.labelAlarma.Visible = false;
            // 
            // CambiarVelocidadBtn
            // 
            this.CambiarVelocidadBtn.Location = new System.Drawing.Point(35, 500);
            this.CambiarVelocidadBtn.Name = "CambiarVelocidadBtn";
            this.CambiarVelocidadBtn.Size = new System.Drawing.Size(171, 78);
            this.CambiarVelocidadBtn.TabIndex = 9;
            this.CambiarVelocidadBtn.Text = "Cambiar Velocidad";
            this.CambiarVelocidadBtn.UseVisualStyleBackColor = true;
            this.CambiarVelocidadBtn.Click += new System.EventHandler(this.CambiarVelocidadBtn_Click);
            // 
            // LabelIdCv
            // 
            this.LabelIdCv.AutoSize = true;
            this.LabelIdCv.Location = new System.Drawing.Point(314, 520);
            this.LabelIdCv.Name = "LabelIdCv";
            this.LabelIdCv.Size = new System.Drawing.Size(20, 16);
            this.LabelIdCv.TabIndex = 10;
            this.LabelIdCv.Text = "ID";
            // 
            // labelNuevaVel
            // 
            this.labelNuevaVel.AutoSize = true;
            this.labelNuevaVel.Location = new System.Drawing.Point(222, 554);
            this.labelNuevaVel.Name = "labelNuevaVel";
            this.labelNuevaVel.Size = new System.Drawing.Size(112, 16);
            this.labelNuevaVel.TabIndex = 11;
            this.labelNuevaVel.Text = "Nueva Velocidad";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(359, 517);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 22);
            this.textBoxID.TabIndex = 12;
            // 
            // textBoxNuevaVelocidad
            // 
            this.textBoxNuevaVelocidad.Location = new System.Drawing.Point(359, 548);
            this.textBoxNuevaVelocidad.Name = "textBoxNuevaVelocidad";
            this.textBoxNuevaVelocidad.Size = new System.Drawing.Size(100, 22);
            this.textBoxNuevaVelocidad.TabIndex = 13;
            // 
            // buttonDistMin
            // 
            this.buttonDistMin.Location = new System.Drawing.Point(377, 412);
            this.buttonDistMin.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDistMin.Name = "buttonDistMin";
            this.buttonDistMin.Size = new System.Drawing.Size(145, 47);
            this.buttonDistMin.TabIndex = 14;
            this.buttonDistMin.Text = "Distancia Mínima";
            this.buttonDistMin.UseVisualStyleBackColor = true;

            // 
            // SimulacionVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 675);
            this.Controls.Add(this.buttonDistMin);
            this.Controls.Add(this.textBoxNuevaVelocidad);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelNuevaVel);
            this.Controls.Add(this.LabelIdCv);
            this.Controls.Add(this.CambiarVelocidadBtn);
            this.Controls.Add(this.labelAlarma);
            this.Controls.Add(this.buttonConflicto);
            this.Controls.Add(this.MostrarVuelosBtn);
            this.Controls.Add(this.AutoMov);
            this.Controls.Add(this.Mover);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Panel);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "SimulacionVuelos";
            this.Text = "SimulacionVuelos";
            this.Load += new System.EventHandler(this.SimulacionVuelos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Mover;
        private System.Windows.Forms.Button AutoMov;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button MostrarVuelosBtn;
        private System.Windows.Forms.Button buttonConflicto;
        private System.Windows.Forms.Label labelAlarma;
        private System.Windows.Forms.Button CambiarVelocidadBtn;
        private System.Windows.Forms.Label LabelIdCv;
        private System.Windows.Forms.Label labelNuevaVel;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxNuevaVelocidad;
        private System.Windows.Forms.Button buttonDistMin;
    }
}
