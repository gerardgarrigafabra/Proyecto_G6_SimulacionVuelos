namespace Interfaz
{
    partial class Data2
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.distanciaSeguridad1 = new System.Windows.Forms.TextBox();
            this.tiempoCiclo1 = new System.Windows.Forms.TextBox();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.buttonAutomatico2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Distancia de seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tiempo de ciclo";
            // 
            // distanciaSeguridad1
            // 
            this.distanciaSeguridad1.Location = new System.Drawing.Point(317, 80);
            this.distanciaSeguridad1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.distanciaSeguridad1.Name = "distanciaSeguridad1";
            this.distanciaSeguridad1.Size = new System.Drawing.Size(132, 31);
            this.distanciaSeguridad1.TabIndex = 6;
            // 
            // tiempoCiclo1
            // 
            this.tiempoCiclo1.Location = new System.Drawing.Point(317, 189);
            this.tiempoCiclo1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tiempoCiclo1.Name = "tiempoCiclo1";
            this.tiempoCiclo1.Size = new System.Drawing.Size(132, 31);
            this.tiempoCiclo1.TabIndex = 7;
            // 
            // buttonCargar
            // 
            this.buttonCargar.Location = new System.Drawing.Point(123, 319);
            this.buttonCargar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(245, 55);
            this.buttonCargar.TabIndex = 10;
            this.buttonCargar.Text = "Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(412, 435);
            this.Cerrar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(101, 36);
            this.Cerrar.TabIndex = 11;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // buttonAutomatico2
            // 
            this.buttonAutomatico2.Location = new System.Drawing.Point(527, 125);
            this.buttonAutomatico2.Name = "buttonAutomatico2";
            this.buttonAutomatico2.Size = new System.Drawing.Size(287, 45);
            this.buttonAutomatico2.TabIndex = 12;
            this.buttonAutomatico2.Text = "Rellenar Automáticamente";
            this.buttonAutomatico2.UseVisualStyleBackColor = true;
            this.buttonAutomatico2.Click += new System.EventHandler(this.buttonAutomatico2_Click);
            // 
            // Data2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 496);
            this.Controls.Add(this.buttonAutomatico2);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.buttonCargar);
            this.Controls.Add(this.tiempoCiclo1);
            this.Controls.Add(this.distanciaSeguridad1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Data2";
            this.Text = "Data2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox distanciaSeguridad1;
        private System.Windows.Forms.TextBox tiempoCiclo1;
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.Button Cerrar;
        private System.Windows.Forms.Button buttonAutomatico2;
    }
}