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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRondas = new System.Windows.Forms.TextBox();
            this.listBoxJugadores = new System.Windows.Forms.ListBox();
            this.btnCantarUno = new System.Windows.Forms.Button();
            this.btnAbandonar = new System.Windows.Forms.Button();
            this.btnVerEstadisticaJugador = new System.Windows.Forms.Button();
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
            this.listBoxCartaJugador.Location = new System.Drawing.Point(31, 402);
            this.listBoxCartaJugador.Name = "listBoxCartaJugador";
            this.listBoxCartaJugador.Size = new System.Drawing.Size(761, 94);
            this.listBoxCartaJugador.TabIndex = 0;
            // 
            // listBoxCartaMesa
            // 
            this.listBoxCartaMesa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxCartaMesa.FormattingEnabled = true;
            this.listBoxCartaMesa.ItemHeight = 15;
            this.listBoxCartaMesa.Location = new System.Drawing.Point(219, 168);
            this.listBoxCartaMesa.Name = "listBoxCartaMesa";
            this.listBoxCartaMesa.Size = new System.Drawing.Size(399, 94);
            this.listBoxCartaMesa.TabIndex = 1;
            // 
            // btnTirarCarta
            // 
            this.btnTirarCarta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTirarCarta.Location = new System.Drawing.Point(207, 553);
            this.btnTirarCarta.Name = "btnTirarCarta";
            this.btnTirarCarta.Size = new System.Drawing.Size(198, 43);
            this.btnTirarCarta.TabIndex = 2;
            this.btnTirarCarta.Text = "btnTirarCarta";
            this.btnTirarCarta.UseVisualStyleBackColor = true;
            // 
            // btnPasarTurno
            // 
            this.btnPasarTurno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPasarTurno.Location = new System.Drawing.Point(422, 553);
            this.btnPasarTurno.Name = "btnPasarTurno";
            this.btnPasarTurno.Size = new System.Drawing.Size(184, 43);
            this.btnPasarTurno.TabIndex = 3;
            this.btnPasarTurno.Text = "btnPasarTurno";
            this.btnPasarTurno.UseVisualStyleBackColor = true;
            // 
            // btnAgarrarCarta
            // 
            this.btnAgarrarCarta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgarrarCarta.Location = new System.Drawing.Point(623, 553);
            this.btnAgarrarCarta.Name = "btnAgarrarCarta";
            this.btnAgarrarCarta.Size = new System.Drawing.Size(184, 43);
            this.btnAgarrarCarta.TabIndex = 4;
            this.btnAgarrarCarta.Text = "btnAgarrarCartaMazo";
            this.btnAgarrarCarta.UseVisualStyleBackColor = true;
            // 
            // listBoxCartaMazo
            // 
            this.listBoxCartaMazo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxCartaMazo.FormattingEnabled = true;
            this.listBoxCartaMazo.ItemHeight = 15;
            this.listBoxCartaMazo.Location = new System.Drawing.Point(865, 502);
            this.listBoxCartaMazo.Name = "listBoxCartaMazo";
            this.listBoxCartaMazo.Size = new System.Drawing.Size(331, 94);
            this.listBoxCartaMazo.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(128, 301);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Turno del jugador:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Rondas";
            // 
            // textBoxRondas
            // 
            this.textBoxRondas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxRondas.Location = new System.Drawing.Point(128, 330);
            this.textBoxRondas.Name = "textBoxRondas";
            this.textBoxRondas.Size = new System.Drawing.Size(100, 23);
            this.textBoxRondas.TabIndex = 8;
            // 
            // listBoxJugadores
            // 
            this.listBoxJugadores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxJugadores.FormattingEnabled = true;
            this.listBoxJugadores.ItemHeight = 15;
            this.listBoxJugadores.Location = new System.Drawing.Point(865, 282);
            this.listBoxJugadores.Name = "listBoxJugadores";
            this.listBoxJugadores.Size = new System.Drawing.Size(331, 139);
            this.listBoxJugadores.TabIndex = 10;
            // 
            // btnCantarUno
            // 
            this.btnCantarUno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCantarUno.Location = new System.Drawing.Point(31, 553);
            this.btnCantarUno.Name = "btnCantarUno";
            this.btnCantarUno.Size = new System.Drawing.Size(170, 43);
            this.btnCantarUno.TabIndex = 11;
            this.btnCantarUno.Text = "Cantar uno";
            this.btnCantarUno.UseVisualStyleBackColor = true;
            // 
            // btnAbandonar
            // 
            this.btnAbandonar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAbandonar.Location = new System.Drawing.Point(12, 26);
            this.btnAbandonar.Name = "btnAbandonar";
            this.btnAbandonar.Size = new System.Drawing.Size(170, 43);
            this.btnAbandonar.TabIndex = 12;
            this.btnAbandonar.Text = "Abandonar partida";
            this.btnAbandonar.UseVisualStyleBackColor = true;
            // 
            // btnVerEstadisticaJugador
            // 
            this.btnVerEstadisticaJugador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVerEstadisticaJugador.Location = new System.Drawing.Point(865, 427);
            this.btnVerEstadisticaJugador.Name = "btnVerEstadisticaJugador";
            this.btnVerEstadisticaJugador.Size = new System.Drawing.Size(175, 43);
            this.btnVerEstadisticaJugador.TabIndex = 13;
            this.btnVerEstadisticaJugador.Text = "Ver estadisticas del jugador";
            this.btnVerEstadisticaJugador.UseVisualStyleBackColor = true;
            // 
            // lblTurno
            // 
            this.lblTurno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTurno.Location = new System.Drawing.Point(219, 88);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(243, 37);
            this.lblTurno.TabIndex = 14;
            this.lblTurno.Text = "Turno del jugador: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.listBoxArchivos);
            this.groupBox1.Location = new System.Drawing.Point(788, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 185);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notificaciones";
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
            this.lblNotificacion.AutoSize = true;
            this.lblNotificacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNotificacion.ForeColor = System.Drawing.Color.Red;
            this.lblNotificacion.Location = new System.Drawing.Point(31, 368);
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
            this.lblNombreJugador.Location = new System.Drawing.Point(468, 88);
            this.lblNombreJugador.Name = "lblNombreJugador";
            this.lblNombreJugador.Size = new System.Drawing.Size(243, 37);
            this.lblNombreJugador.TabIndex = 17;
            this.lblNombreJugador.Text = "Turno del jugador: ";
            // 
            // btnMostrarCarta
            // 
            this.btnMostrarCarta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMostrarCarta.Location = new System.Drawing.Point(31, 502);
            this.btnMostrarCarta.Name = "btnMostrarCarta";
            this.btnMostrarCarta.Size = new System.Drawing.Size(169, 45);
            this.btnMostrarCarta.TabIndex = 18;
            this.btnMostrarCarta.Text = "MostrarCartas";
            this.btnMostrarCarta.UseVisualStyleBackColor = true;
            // 
            // lblMostrarMensajeCartas
            // 
            this.lblMostrarMensajeCartas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMostrarMensajeCartas.AutoSize = true;
            this.lblMostrarMensajeCartas.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMostrarMensajeCartas.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMostrarMensajeCartas.Location = new System.Drawing.Point(31, 442);
            this.lblMostrarMensajeCartas.Name = "lblMostrarMensajeCartas";
            this.lblMostrarMensajeCartas.Size = new System.Drawing.Size(423, 28);
            this.lblMostrarMensajeCartas.TabIndex = 19;
            this.lblMostrarMensajeCartas.Text = "Cartas ocultas, espere a que se cambie de turno";
            this.lblMostrarMensajeCartas.Visible = false;
            // 
            // FormJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1223, 635);
            this.Controls.Add(this.lblNotificacion);
            this.Controls.Add(this.btnMostrarCarta);
            this.Controls.Add(this.lblNombreJugador);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.btnVerEstadisticaJugador);
            this.Controls.Add(this.btnAbandonar);
            this.Controls.Add(this.btnCantarUno);
            this.Controls.Add(this.listBoxJugadores);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRondas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBoxCartaMazo);
            this.Controls.Add(this.btnAgarrarCarta);
            this.Controls.Add(this.btnPasarTurno);
            this.Controls.Add(this.btnTirarCarta);
            this.Controls.Add(this.listBoxCartaMesa);
            this.Controls.Add(this.listBoxCartaJugador);
            this.Controls.Add(this.lblMostrarMensajeCartas);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
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