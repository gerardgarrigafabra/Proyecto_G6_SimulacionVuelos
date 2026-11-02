namespace Interfaz
{
    partial class PlaneDistance
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
            this.distancia = new System.Windows.Forms.Label();
            this.valor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // distancia
            // 
            this.distancia.AutoSize = true;
            this.distancia.Location = new System.Drawing.Point(56, 98);
            this.distancia.Name = "distancia";
            this.distancia.Size = new System.Drawing.Size(79, 20);
            this.distancia.TabIndex = 0;
            this.distancia.Text = "Distancia:";
            // 
            // valor
            // 
            this.valor.AutoSize = true;
            this.valor.Location = new System.Drawing.Point(171, 98);
            this.valor.Name = "valor";
            this.valor.Size = new System.Drawing.Size(51, 20);
            this.valor.TabIndex = 1;
            this.valor.Text = "label2";
            // 
            // PlaneDistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 212);
            this.Controls.Add(this.valor);
            this.Controls.Add(this.distancia);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PlaneDistance";
            this.Text = "PlaneDistance";
            this.Load += new System.EventHandler(this.PlaneDistance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label distancia;
        private System.Windows.Forms.Label valor;
    }
}