namespace WinFormsApptTestPP2
{
    partial class FormJuego
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
            this.listBoxCartaJugador = new System.Windows.Forms.ListBox();
            this.listBoxCartaMesa = new System.Windows.Forms.ListBox();
            this.btnTirarCarta = new System.Windows.Forms.Button();
            this.btnPasarTurno = new System.Windows.Forms.Button();
            this.btnAgarrarCarta = new System.Windows.Forms.Button();
            this.listBoxCartaMazo = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRondas = new System.Windows.Forms.TextBox();
            this.listBoxJugadores = new System.Windows.Forms.ListBox();
            this.btnCantarUno = new System.Windows.Forms.Button();
            this.btnAbandonar = new System.Windows.Forms.Button();
            this.lblTurno = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxArchivos = new System.Windows.Forms.ListBox();
            this.lblNotificacion = new System.Windows.Forms.Label();
            this.lblNombreJugador = new System.Windows.Forms.Label();
            this.btnMostrarCarta = new System.Windows.Forms.Button();
            this.lblMostrarMensajeCartas = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxCartaJugador
            // 
            this.listBoxCartaJugador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxCartaJugador.FormattingEnabled = true;
            this.listBoxCartaJugador.ItemHeight = 15;
            this.listBoxCartaJugador.Location = new System.Drawing.Point(39, 361);
            this.listBoxCartaJugador.Name = "listBoxCartaJugador";
            this.listBoxCartaJugador.Size = new System.Drawing.Size(649, 94);
            this.listBoxCartaJugador.TabIndex = 0;
            // 
            // listBoxCartaMesa
            // 
            this.listBoxCartaMesa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxCartaMesa.FormattingEnabled = true;
            this.listBoxCartaMesa.ItemHeight = 15;
            this.listBoxCartaMesa.Location = new System.Drawing.Point(196, 192);
            this.listBoxCartaMesa.Name = "listBoxCartaMesa";
            this.listBoxCartaMesa.Size = new System.Drawing.Size(399, 94);
            this.listBoxCartaMesa.TabIndex = 1;
            // 
            // btnTirarCarta
            // 
            this.btnTirarCarta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTirarCarta.Location = new System.Drawing.Point(285, 469);
            this.btnTirarCarta.Name = "btnTirarCarta";
            this.btnTirarCarta.Size = new System.Drawing.Size(127, 43);
            this.btnTirarCarta.TabIndex = 2;
            this.btnTirarCarta.Text = "Tirar carta";
            this.btnTirarCarta.UseVisualStyleBackColor = true;
            // 
            // btnPasarTurno
            // 
            this.btnPasarTurno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPasarTurno.Location = new System.Drawing.Point(418, 469);
            this.btnPasarTurno.Name = "btnPasarTurno";
            this.btnPasarTurno.Size = new System.Drawing.Size(132, 43);
            this.btnPasarTurno.TabIndex = 3;
            this.btnPasarTurno.Text = "pasar turno";
            this.btnPasarTurno.UseVisualStyleBackColor = true;
            // 
            // btnAgarrarCarta
            // 
            this.btnAgarrarCarta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgarrarCarta.Location = new System.Drawing.Point(556, 469);
            this.btnAgarrarCarta.Name = "btnAgarrarCarta";
            this.btnAgarrarCarta.Size = new System.Drawing.Size(132, 43);
            this.btnAgarrarCarta.TabIndex = 4;
            this.btnAgarrarCarta.Text = "agarrar carta";
            this.btnAgarrarCarta.UseVisualStyleBackColor = true;
            // 
            // listBoxCartaMazo
            // 
            this.listBoxCartaMazo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxCartaMazo.FormattingEnabled = true;
            this.listBoxCartaMazo.ItemHeight = 15;
            this.listBoxCartaMazo.Location = new System.Drawing.Point(807, 476);
            this.listBoxCartaMazo.Name = "listBoxCartaMazo";
            this.listBoxCartaMazo.Size = new System.Drawing.Size(408, 49);
            this.listBoxCartaMazo.TabIndex = 5;
            this.listBoxCartaMazo.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rondas";
            // 
            // textBoxRondas
            // 
            this.textBoxRondas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxRondas.Location = new System.Drawing.Point(352, 57);
            this.textBoxRondas.Name = "textBoxRondas";
            this.textBoxRondas.Size = new System.Drawing.Size(221, 23);
            this.textBoxRondas.TabIndex = 8;
            // 
            // listBoxJugadores
            // 
            this.listBoxJugadores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxJugadores.FormattingEnabled = true;
            this.listBoxJugadores.ItemHeight = 15;
            this.listBoxJugadores.Location = new System.Drawing.Point(807, 226);
            this.listBoxJugadores.Name = "listBoxJugadores";
            this.listBoxJugadores.Size = new System.Drawing.Size(408, 139);
            this.listBoxJugadores.TabIndex = 10;
            // 
            // btnCantarUno
            // 
            this.btnCantarUno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCantarUno.Location = new System.Drawing.Point(161, 467);
            this.btnCantarUno.Name = "btnCantarUno";
            this.btnCantarUno.Size = new System.Drawing.Size(118, 43);
            this.btnCantarUno.TabIndex = 11;
            this.btnCantarUno.Text = "Cantar uno";
            this.btnCantarUno.UseVisualStyleBackColor = true;
            // 
            // btnAbandonar
            // 
            this.btnAbandonar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAbandonar.Location = new System.Drawing.Point(31, 21);
            this.btnAbandonar.Name = "btnAbandonar";
            this.btnAbandonar.Size = new System.Drawing.Size(170, 43);
            this.btnAbandonar.TabIndex = 12;
            this.btnAbandonar.Text = "Cancelar Partida";
            this.btnAbandonar.UseVisualStyleBackColor = true;
            // 
            // lblTurno
            // 
            this.lblTurno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTurno.Location = new System.Drawing.Point(169, 109);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(243, 37);
            this.lblTurno.TabIndex = 14;
            this.lblTurno.Text = "Turno del jugador: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.listBoxArchivos);
            this.groupBox1.Location = new System.Drawing.Point(807, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 185);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logs";
            // 
            // listBoxArchivos
            // 
            this.listBoxArchivos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxArchivos.FormattingEnabled = true;
            this.listBoxArchivos.ItemHeight = 15;
            this.listBoxArchivos.Location = new System.Drawing.Point(17, 22);
            this.listBoxArchivos.Name = "listBoxArchivos";
            this.listBoxArchivos.Size = new System.Drawing.Size(391, 139);
            this.listBoxArchivos.TabIndex = 20;
            // 
            // lblNotificacion
            // 
            this.lblNotificacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNotificacion.AutoSize = true;
            this.lblNotificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNotificacion.ForeColor = System.Drawing.Color.Red;
            this.lblNotificacion.Location = new System.Drawing.Point(39, 319);
            this.lblNotificacion.Name = "lblNotificacion";
            this.lblNotificacion.Size = new System.Drawing.Size(105, 21);
            this.lblNotificacion.TabIndex = 0;
            this.lblNotificacion.Text = "Notificacion";
            // 
            // lblNombreJugador
            // 
            this.lblNombreJugador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNombreJugador.AutoSize = true;
            this.lblNombreJugador.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombreJugador.ForeColor = System.Drawing.Color.Fuchsia;
            this.lblNombreJugador.Location = new System.Drawing.Point(403, 109);
            this.lblNombreJugador.Name = "lblNombreJugador";
            this.lblNombreJugador.Size = new System.Drawing.Size(243, 37);
            this.lblNombreJugador.TabIndex = 17;
            this.lblNombreJugador.Text = "Turno del jugador: ";
            // 
            // btnMostrarCarta
            // 
            this.btnMostrarCarta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMostrarCarta.Location = new System.Drawing.Point(39, 465);
            this.btnMostrarCarta.Name = "btnMostrarCarta";
            this.btnMostrarCarta.Size = new System.Drawing.Size(116, 45);
            this.btnMostrarCarta.TabIndex = 18;
            this.btnMostrarCarta.Text = "Mostrar cartas";
            this.btnMostrarCarta.UseVisualStyleBackColor = true;
            // 
            // lblMostrarMensajeCartas
            // 
            this.lblMostrarMensajeCartas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMostrarMensajeCartas.AutoSize = true;
            this.lblMostrarMensajeCartas.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMostrarMensajeCartas.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMostrarMensajeCartas.Location = new System.Drawing.Point(50, 412);
            this.lblMostrarMensajeCartas.Name = "lblMostrarMensajeCartas";
            this.lblMostrarMensajeCartas.Size = new System.Drawing.Size(139, 28);
            this.lblMostrarMensajeCartas.TabIndex = 19;
            this.lblMostrarMensajeCartas.Text = "Cartas ocultas!";
            this.lblMostrarMensajeCartas.Visible = false;
            // 
            // FormJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1263, 524);
            this.Controls.Add(this.lblNotificacion);
            this.Controls.Add(this.btnMostrarCarta);
            this.Controls.Add(this.lblNombreJugador);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.btnAbandonar);
            this.Controls.Add(this.btnCantarUno);
            this.Controls.Add(this.listBoxJugadores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRondas);
            this.Controls.Add(this.listBoxCartaMazo);
            this.Controls.Add(this.btnAgarrarCarta);
            this.Controls.Add(this.btnPasarTurno);
            this.Controls.Add(this.btnTirarCarta);
            this.Controls.Add(this.listBoxCartaMesa);
            this.Controls.Add(this.listBoxCartaJugador);
            this.Controls.Add(this.lblMostrarMensajeCartas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormJuego";
            this.Text = "FormJuego";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormJuego_FormClosing_1);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCartaJugador;
        private System.Windows.Forms.ListBox listBoxCartaMesa;
        private System.Windows.Forms.Button btnTirarCarta;
        private System.Windows.Forms.Button btnPasarTurno;
        private System.Windows.Forms.Button btnAgarrarCarta;
        private System.Windows.Forms.ListBox listBoxCartaMazo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRondas;
        private System.Windows.Forms.ListBox listBoxJugadores;
        private System.Windows.Forms.Button btnCantarUno;
        private System.Windows.Forms.Button btnAbandonar;
        private System.Windows.Forms.Button btnVerEstadisticaJugador;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNotificacion;
        private System.Windows.Forms.Label lblNombreJugador;
        private System.Windows.Forms.Button btnMostrarCarta;
        private System.Windows.Forms.Label lblMostrarMensajeCartas;
        private System.Windows.Forms.ListBox listBoxArchivos;
    }
}