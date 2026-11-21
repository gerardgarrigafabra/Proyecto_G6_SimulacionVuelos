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
            this.deshacerBtn = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCerrar = new System.Windows.Forms.Button();
            this.reiniciarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel.Location = new System.Drawing.Point(422, 32);
            this.Panel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(490, 502);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(418, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(396, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(372, 510);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "499";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(870, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "499";
            // 
            // Mover
            // 
            this.Mover.Location = new System.Drawing.Point(60, 68);
            this.Mover.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Mover.Name = "Mover";
            this.Mover.Size = new System.Drawing.Size(128, 68);
            this.Mover.TabIndex = 4;
            this.Mover.Text = "Mover Vuelos";
            this.Mover.UseVisualStyleBackColor = true;
            this.Mover.Click += new System.EventHandler(this.Mover_Click);
            // 
            // AutoMov
            // 
            this.AutoMov.Location = new System.Drawing.Point(60, 150);
            this.AutoMov.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AutoMov.Name = "AutoMov";
            this.AutoMov.Size = new System.Drawing.Size(128, 68);
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
            this.MostrarVuelosBtn.Location = new System.Drawing.Point(60, 239);
            this.MostrarVuelosBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MostrarVuelosBtn.Name = "MostrarVuelosBtn";
            this.MostrarVuelosBtn.Size = new System.Drawing.Size(128, 68);
            this.MostrarVuelosBtn.TabIndex = 6;
            this.MostrarVuelosBtn.Text = "Mostar Vuelos";
            this.MostrarVuelosBtn.UseVisualStyleBackColor = true;
            this.MostrarVuelosBtn.Click += new System.EventHandler(this.MostarVuelosBtn_Click);
            // 
            // buttonConflicto
            // 
            this.buttonConflicto.Location = new System.Drawing.Point(218, 239);
            this.buttonConflicto.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonConflicto.Name = "buttonConflicto";
            this.buttonConflicto.Size = new System.Drawing.Size(128, 68);
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
            this.labelAlarma.Location = new System.Drawing.Point(22, 504);
            this.labelAlarma.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAlarma.Name = "labelAlarma";
            this.labelAlarma.Size = new System.Drawing.Size(78, 20);
            this.labelAlarma.TabIndex = 8;
            this.labelAlarma.Text = "ALERTA";
            this.labelAlarma.Visible = false;
            // 
            // CambiarVelocidadBtn
            // 
            this.CambiarVelocidadBtn.Location = new System.Drawing.Point(26, 406);
            this.CambiarVelocidadBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CambiarVelocidadBtn.Name = "CambiarVelocidadBtn";
            this.CambiarVelocidadBtn.Size = new System.Drawing.Size(128, 63);
            this.CambiarVelocidadBtn.TabIndex = 9;
            this.CambiarVelocidadBtn.Text = "Cambiar Velocidad";
            this.CambiarVelocidadBtn.UseVisualStyleBackColor = true;
            this.CambiarVelocidadBtn.Click += new System.EventHandler(this.CambiarVelocidadBtn_Click);
            // 
            // LabelIdCv
            // 
            this.LabelIdCv.AutoSize = true;
            this.LabelIdCv.Location = new System.Drawing.Point(236, 422);
            this.LabelIdCv.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelIdCv.Name = "LabelIdCv";
            this.LabelIdCv.Size = new System.Drawing.Size(18, 13);
            this.LabelIdCv.TabIndex = 10;
            this.LabelIdCv.Text = "ID";
            // 
            // labelNuevaVel
            // 
            this.labelNuevaVel.AutoSize = true;
            this.labelNuevaVel.Location = new System.Drawing.Point(166, 450);
            this.labelNuevaVel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNuevaVel.Name = "labelNuevaVel";
            this.labelNuevaVel.Size = new System.Drawing.Size(89, 13);
            this.labelNuevaVel.TabIndex = 11;
            this.labelNuevaVel.Text = "Nueva Velocidad";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(270, 420);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(76, 20);
            this.textBoxID.TabIndex = 12;
            // 
            // textBoxNuevaVelocidad
            // 
            this.textBoxNuevaVelocidad.Location = new System.Drawing.Point(270, 445);
            this.textBoxNuevaVelocidad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxNuevaVelocidad.Name = "textBoxNuevaVelocidad";
            this.textBoxNuevaVelocidad.Size = new System.Drawing.Size(76, 20);
            this.textBoxNuevaVelocidad.TabIndex = 13;
            // 
            // deshacerBtn
            // 
            this.deshacerBtn.Location = new System.Drawing.Point(216, 68);
            this.deshacerBtn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.deshacerBtn.Name = "deshacerBtn";
            this.deshacerBtn.Size = new System.Drawing.Size(128, 68);
            this.deshacerBtn.TabIndex = 15;
            this.deshacerBtn.Text = "Mover Vuelos Para Atras";
            this.deshacerBtn.UseVisualStyleBackColor = true;
            this.deshacerBtn.Click += new System.EventHandler(this.deshacerBtn_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(300, 10);
            this.buttonGuardar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(92, 34);
            this.buttonGuardar.TabIndex = 16;
            this.buttonGuardar.Text = "Guardar Vuelos";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCerrar
            // 
            this.buttonCerrar.Location = new System.Drawing.Point(8, 10);
            this.buttonCerrar.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonCerrar.Name = "buttonCerrar";
            this.buttonCerrar.Size = new System.Drawing.Size(92, 34);
            this.buttonCerrar.TabIndex = 17;
            this.buttonCerrar.Text = "Cerrar";
            this.buttonCerrar.UseVisualStyleBackColor = true;
            this.buttonCerrar.Click += new System.EventHandler(this.buttonCerrar_Click);
            // 
            // reiniciarBtn
            // 
            this.reiniciarBtn.Location = new System.Drawing.Point(216, 150);
            this.reiniciarBtn.Name = "reiniciarBtn";
            this.reiniciarBtn.Size = new System.Drawing.Size(128, 68);
            this.reiniciarBtn.TabIndex = 18;
            this.reiniciarBtn.Text = "Reiniciar vuelos";
            this.reiniciarBtn.UseVisualStyleBackColor = true;
            this.reiniciarBtn.Click += new System.EventHandler(this.reiniciarBtn_Click);
            // 
            // SimulacionVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 549);
            this.Controls.Add(this.reiniciarBtn);
            this.Controls.Add(this.buttonCerrar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.deshacerBtn);
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
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
        private System.Windows.Forms.Button deshacerBtn;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCerrar;
        private System.Windows.Forms.Button reiniciarBtn;
    }
}
