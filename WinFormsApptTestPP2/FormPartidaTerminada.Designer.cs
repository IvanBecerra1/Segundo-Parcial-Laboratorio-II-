namespace WinFormsApptTestPP2
{
    partial class FormPartidaTerminada
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
            this.listBoxJugadores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreGanador = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxJugadores
            // 
            this.listBoxJugadores.FormattingEnabled = true;
            this.listBoxJugadores.ItemHeight = 15;
            this.listBoxJugadores.Location = new System.Drawing.Point(12, 94);
            this.listBoxJugadores.Name = "listBoxJugadores";
            this.listBoxJugadores.Size = new System.Drawing.Size(375, 94);
            this.listBoxJugadores.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lista de jugadores";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jugador Ganador:";
            // 
            // lblNombreGanador
            // 
            this.lblNombreGanador.AutoSize = true;
            this.lblNombreGanador.BackColor = System.Drawing.Color.Aquamarine;
            this.lblNombreGanador.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombreGanador.Location = new System.Drawing.Point(188, 215);
            this.lblNombreGanador.Name = "lblNombreGanador";
            this.lblNombreGanador.Size = new System.Drawing.Size(89, 28);
            this.lblNombreGanador.TabIndex = 5;
            this.lblNombreGanador.Text = "Nombre.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(124, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fin de la partida";
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(87, 371);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(221, 44);
            this.btnTerminar.TabIndex = 7;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // FormPartidaTerminada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(432, 445);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNombreGanador);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxJugadores);
            this.Name = "FormPartidaTerminada";
            this.Text = "FormPartidaTerminada";
            this.Load += new System.EventHandler(this.FormPartidaTerminada_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxJugadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreGanador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTerminar;
    }
}