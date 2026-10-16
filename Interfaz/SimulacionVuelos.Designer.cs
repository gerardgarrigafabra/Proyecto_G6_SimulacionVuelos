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
            this.button1 = new System.Windows.Forms.Button();
            this.buttonConflicto = new System.Windows.Forms.Button();
            this.labelAlarma = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel.Location = new System.Drawing.Point(564, 40);
            this.Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(581, 552);
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
            this.label3.Location = new System.Drawing.Point(499, 561);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "499";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(1086, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "499";
            // 
            // Mover
            // 
            this.Mover.Location = new System.Drawing.Point(181, 159);
            this.Mover.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Mover.Name = "Mover";
            this.Mover.Size = new System.Drawing.Size(171, 84);
            this.Mover.TabIndex = 4;
            this.Mover.Text = "Mover Vuelos";
            this.Mover.UseVisualStyleBackColor = true;
            this.Mover.Click += new System.EventHandler(this.Mover_Click);
            // 
            // AutoMov
            // 
            this.AutoMov.Location = new System.Drawing.Point(181, 269);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 77);
            this.button1.TabIndex = 6;
            this.button1.Text = "Mostar Vuelos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            //
            // buttonConflicto
            //
            this.buttonConflicto.Location = new System.Drawing.Point(181, 487);
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
            this.labelAlarma.Size = new System.Drawing.Size(200, 25);
            this.labelAlarma.TabIndex = 8;
            this.labelAlarma.Text = "ALERTA";
            this.labelAlarma.Visible = false;
            // 
            // SimulacionVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 847);
            this.Controls.Add(this.labelAlarma);
            this.Controls.Add(this.buttonConflicto);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AutoMov);
            this.Controls.Add(this.Mover);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonConflicto;
        private System.Windows.Forms.Label labelAlarma;
    }
}
