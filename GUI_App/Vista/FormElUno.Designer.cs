namespace GUI_App.Vista
{
    partial class FormElUno
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
            this.listBoxCartaMesa = new System.Windows.Forms.ListBox();
            this.listBoxCartasJugador = new System.Windows.Forms.ListBox();
            this.btnTirarCarta = new System.Windows.Forms.Button();
            this.btnPasarTurno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxCartaMazo = new System.Windows.Forms.ListBox();
            this.btnAgarrarCarta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxCartaMesa
            // 
            this.listBoxCartaMesa.FormattingEnabled = true;
            this.listBoxCartaMesa.ItemHeight = 15;
            this.listBoxCartaMesa.Location = new System.Drawing.Point(262, 67);
            this.listBoxCartaMesa.Name = "listBoxCartaMesa";
            this.listBoxCartaMesa.Size = new System.Drawing.Size(225, 94);
            this.listBoxCartaMesa.TabIndex = 0;
            // 
            // listBoxCartasJugador
            // 
            this.listBoxCartasJugador.FormattingEnabled = true;
            this.listBoxCartasJugador.ItemHeight = 15;
            this.listBoxCartasJugador.Location = new System.Drawing.Point(183, 269);
            this.listBoxCartasJugador.Name = "listBoxCartasJugador";
            this.listBoxCartasJugador.Size = new System.Drawing.Size(357, 94);
            this.listBoxCartasJugador.TabIndex = 1;
            // 
            // btnTirarCarta
            // 
            this.btnTirarCarta.Location = new System.Drawing.Point(80, 380);
            this.btnTirarCarta.Name = "btnTirarCarta";
            this.btnTirarCarta.Size = new System.Drawing.Size(142, 48);
            this.btnTirarCarta.TabIndex = 2;
            this.btnTirarCarta.Text = "Tirar carta";
            this.btnTirarCarta.UseVisualStyleBackColor = true;
            this.btnTirarCarta.Click += new System.EventHandler(this.btnTirarCarta_Click);
            // 
            // btnPasarTurno
            // 
            this.btnPasarTurno.Location = new System.Drawing.Point(595, 390);
            this.btnPasarTurno.Name = "btnPasarTurno";
            this.btnPasarTurno.Size = new System.Drawing.Size(135, 48);
            this.btnPasarTurno.TabIndex = 3;
            this.btnPasarTurno.Text = "Pasar turno";
            this.btnPasarTurno.UseVisualStyleBackColor = true;
            this.btnPasarTurno.Click += new System.EventHandler(this.btnPasarTurno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione una carta antes de tirar";
            // 
            // listBoxCartaMazo
            // 
            this.listBoxCartaMazo.FormattingEnabled = true;
            this.listBoxCartaMazo.ItemHeight = 15;
            this.listBoxCartaMazo.Location = new System.Drawing.Point(553, 21);
            this.listBoxCartaMazo.Name = "listBoxCartaMazo";
            this.listBoxCartaMazo.Size = new System.Drawing.Size(235, 49);
            this.listBoxCartaMazo.TabIndex = 5;
            // 
            // btnAgarrarCarta
            // 
            this.btnAgarrarCarta.Location = new System.Drawing.Point(553, 85);
            this.btnAgarrarCarta.Name = "btnAgarrarCarta";
            this.btnAgarrarCarta.Size = new System.Drawing.Size(193, 41);
            this.btnAgarrarCarta.TabIndex = 6;
            this.btnAgarrarCarta.Text = "btnAgarrarCarta";
            this.btnAgarrarCarta.UseVisualStyleBackColor = true;
            // 
            // FormElUno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAgarrarCarta);
            this.Controls.Add(this.listBoxCartaMazo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPasarTurno);
            this.Controls.Add(this.btnTirarCarta);
            this.Controls.Add(this.listBoxCartasJugador);
            this.Controls.Add(this.listBoxCartaMesa);
            this.Name = "FormElUno";
            this.Text = "FormElUno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCartaMesa;
        private System.Windows.Forms.ListBox listBoxCartasJugador;
        private System.Windows.Forms.Button btnTirarCarta;
        private System.Windows.Forms.Button btnPasarTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxCartaMazo;
        private System.Windows.Forms.Button btnAgarrarCarta;
    }
}