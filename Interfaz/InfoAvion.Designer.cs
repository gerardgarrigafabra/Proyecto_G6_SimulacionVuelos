namespace Interfaz
{
    partial class InfoAvion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPosicion = new System.Windows.Forms.TextBox();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.txtVelocidad = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(93, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(93, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(93, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destino";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(93, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "Posición";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label5.Location = new System.Drawing.Point(93, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "Velocidad";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtId.Location = new System.Drawing.Point(269, 82);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(446, 44);
            this.txtId.TabIndex = 5;
            // 
            // txtPosicion
            // 
            this.txtPosicion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtPosicion.Location = new System.Drawing.Point(269, 253);
            this.txtPosicion.Name = "txtPosicion";
            this.txtPosicion.Size = new System.Drawing.Size(446, 44);
            this.txtPosicion.TabIndex = 6;
            // 
            // txtDestino
            // 
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtDestino.Location = new System.Drawing.Point(269, 311);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.Size = new System.Drawing.Size(446, 44);
            this.txtDestino.TabIndex = 7;
            // 
            // txtVelocidad
            // 
            this.txtVelocidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtVelocidad.Location = new System.Drawing.Point(269, 195);
            this.txtVelocidad.Name = "txtVelocidad";
            this.txtVelocidad.Size = new System.Drawing.Size(446, 44);
            this.txtVelocidad.TabIndex = 8;
            // 
            // txtEstado
            // 
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtEstado.Location = new System.Drawing.Point(269, 138);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(446, 44);
            this.txtEstado.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(691, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 41);
            this.button1.TabIndex = 10;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InfoAvion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtVelocidad);
            this.Controls.Add(this.txtDestino);
            this.Controls.Add(this.txtPosicion);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InfoAvion";
            this.Text = "InfoAvion";
            this.Load += new System.EventHandler(this.InfoAvion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPosicion;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.TextBox txtVelocidad;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Button button1;
    }
}