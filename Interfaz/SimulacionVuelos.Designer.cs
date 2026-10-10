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
            this.Panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Mover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel.Location = new System.Drawing.Point(634, 50);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(599, 599);
            this.Panel.TabIndex = 0;
            this.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(627, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(593, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(557, 613);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "599";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(1163, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "599";
            // 
            // Mover
            // 
            this.Mover.Location = new System.Drawing.Point(100, 222);
            this.Mover.Name = "Mover";
            this.Mover.Size = new System.Drawing.Size(336, 204);
            this.Mover.TabIndex = 4;
            this.Mover.Text = "Mover Vuelos";
            this.Mover.UseVisualStyleBackColor = true;
            this.Mover.Click += new System.EventHandler(this.Mover_Click);
            // 
            // SimulacionVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 749);
            this.Controls.Add(this.Mover);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Panel);
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
    }
}