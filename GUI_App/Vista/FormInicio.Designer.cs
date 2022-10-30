namespace GUI_App.Vista
{
    partial class FormInicio
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
            this.btnIniciarSala = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIniciarSala
            // 
            this.btnIniciarSala.Location = new System.Drawing.Point(155, 580);
            this.btnIniciarSala.Name = "btnIniciarSala";
            this.btnIniciarSala.Size = new System.Drawing.Size(262, 82);
            this.btnIniciarSala.TabIndex = 0;
            this.btnIniciarSala.Text = "Iniciar sala";
            this.btnIniciarSala.UseVisualStyleBackColor = true;
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(615, 753);
            this.Controls.Add(this.btnIniciarSala);
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarSala;
    }
}