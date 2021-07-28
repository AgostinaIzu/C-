
namespace Bateria_Eventos
{
    partial class Form1
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
            this.Boton_OnOff = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Boton_Cargar = new System.Windows.Forms.Button();
            this.Boton_Usar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Boton_OnOff
            // 
            this.Boton_OnOff.Location = new System.Drawing.Point(154, 219);
            this.Boton_OnOff.Name = "Boton_OnOff";
            this.Boton_OnOff.Size = new System.Drawing.Size(283, 25);
            this.Boton_OnOff.TabIndex = 8;
            this.Boton_OnOff.Text = "Apagar";
            this.Boton_OnOff.UseVisualStyleBackColor = true;
            this.Boton_OnOff.Click += new System.EventHandler(this.Boton_OnOff_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(154, 148);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(283, 50);
            this.progressBar1.TabIndex = 7;
            // 
            // Boton_Cargar
            // 
            this.Boton_Cargar.Location = new System.Drawing.Point(323, 91);
            this.Boton_Cargar.Name = "Boton_Cargar";
            this.Boton_Cargar.Size = new System.Drawing.Size(114, 37);
            this.Boton_Cargar.TabIndex = 6;
            this.Boton_Cargar.Text = "Cargar";
            this.Boton_Cargar.UseVisualStyleBackColor = true;
            this.Boton_Cargar.Click += new System.EventHandler(this.Boton_Cargar_Click);
            // 
            // Boton_Usar
            // 
            this.Boton_Usar.Location = new System.Drawing.Point(154, 91);
            this.Boton_Usar.Name = "Boton_Usar";
            this.Boton_Usar.Size = new System.Drawing.Size(114, 37);
            this.Boton_Usar.TabIndex = 5;
            this.Boton_Usar.Text = "Usar";
            this.Boton_Usar.UseVisualStyleBackColor = true;
            this.Boton_Usar.Click += new System.EventHandler(this.Boton_Usar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 335);
            this.Controls.Add(this.Boton_OnOff);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Boton_Cargar);
            this.Controls.Add(this.Boton_Usar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Boton_OnOff;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Boton_Cargar;
        private System.Windows.Forms.Button Boton_Usar;
    }
}

