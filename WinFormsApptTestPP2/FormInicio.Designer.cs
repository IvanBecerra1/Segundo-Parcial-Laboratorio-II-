namespace WinFormsApptTestPP2
{
    partial class FormInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIniciar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdministrador = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIniciar.Location = new System.Drawing.Point(86, 235);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(278, 60);
            this.btnIniciar.TabIndex = 0;
            this.btnIniciar.Text = "Crear sala";
            this.btnIniciar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(86, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(278, 61);
            this.button1.TabIndex = 1;
            this.button1.Text = "Estadisticas de partidas";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAdministrador
            // 
            this.btnAdministrador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdministrador.Location = new System.Drawing.Point(86, 386);
            this.btnAdministrador.Name = "btnAdministrador";
            this.btnAdministrador.Size = new System.Drawing.Size(278, 55);
            this.btnAdministrador.TabIndex = 2;
            this.btnAdministrador.Text = "-----";
            this.btnAdministrador.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(75, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 54);
            this.label1.TabIndex = 3;
            this.label1.Text = "JUEGO EL UNO";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(420, 472);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdministrador);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnIniciar);
            this.MaximumSize = new System.Drawing.Size(558, 530);
            this.MinimumSize = new System.Drawing.Size(337, 459);
            this.Name = "FormInicio";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdministrador;
        private System.Windows.Forms.Label label1;
    }
}
