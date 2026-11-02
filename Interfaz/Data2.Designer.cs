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
            this.button1 = new System.Windows.Forms.Button();
            this.Cerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Distancia de seguridad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tiempo de ciclo";
            // 
            // distanciaSeguridad1
            // 
            this.distanciaSeguridad1.Location = new System.Drawing.Point(212, 51);
            this.distanciaSeguridad1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.distanciaSeguridad1.Name = "distanciaSeguridad1";
            this.distanciaSeguridad1.Size = new System.Drawing.Size(89, 22);
            this.distanciaSeguridad1.TabIndex = 6;
            this.distanciaSeguridad1.Text = "50";
            // 
            // tiempoCiclo1
            // 
            this.tiempoCiclo1.Location = new System.Drawing.Point(212, 121);
            this.tiempoCiclo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tiempoCiclo1.Name = "tiempoCiclo1";
            this.tiempoCiclo1.Size = new System.Drawing.Size(89, 22);
            this.tiempoCiclo1.TabIndex = 7;
            this.tiempoCiclo1.Text = "10";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 204);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 35);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cerrar
            // 
            this.Cerrar.Location = new System.Drawing.Point(275, 278);
            this.Cerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cerrar.Name = "Cerrar";
            this.Cerrar.Size = new System.Drawing.Size(68, 23);
            this.Cerrar.TabIndex = 11;
            this.Cerrar.Text = "Cerrar";
            this.Cerrar.UseVisualStyleBackColor = true;
            this.Cerrar.Click += new System.EventHandler(this.Cerrar_Click);
            // 
            // Data2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 310);
            this.Controls.Add(this.Cerrar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tiempoCiclo1);
            this.Controls.Add(this.distanciaSeguridad1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Cerrar;
    }
}