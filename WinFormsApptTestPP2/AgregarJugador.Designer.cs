namespace WinFormsApptTestPP2
{
    partial class AgregarJugador
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
            this.listBoxJugadoresRegistrados = new System.Windows.Forms.ListBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAlias = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxJugadoresSala = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarJugadorSala = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCantidadRondas = new System.Windows.Forms.TextBox();
            this.btnAcciones = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxJugadoresRegistrados
            // 
            this.listBoxJugadoresRegistrados.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxJugadoresRegistrados.FormattingEnabled = true;
            this.listBoxJugadoresRegistrados.ItemHeight = 15;
            this.listBoxJugadoresRegistrados.Location = new System.Drawing.Point(38, 139);
            this.listBoxJugadoresRegistrados.Name = "listBoxJugadoresRegistrados";
            this.listBoxJugadoresRegistrados.Size = new System.Drawing.Size(267, 169);
            this.listBoxJugadoresRegistrados.TabIndex = 0;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(15, 37);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(119, 23);
            this.textBoxNombre.TabIndex = 1;
            this.textBoxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombre_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre jugador:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(15, 68);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(261, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.Text = "Registrar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTerminar.Location = new System.Drawing.Point(38, 401);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(267, 46);
            this.btnTerminar.TabIndex = 4;
            this.btnTerminar.Text = "Iniciar partida";
            this.btnTerminar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxAlias);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Location = new System.Drawing.Point(38, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 97);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar jugador";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(157, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Alias ";
            // 
            // textBoxAlias
            // 
            this.textBoxAlias.Location = new System.Drawing.Point(157, 37);
            this.textBoxAlias.Name = "textBoxAlias";
            this.textBoxAlias.Size = new System.Drawing.Size(119, 23);
            this.textBoxAlias.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lista de jugadores registrados";
            // 
            // listBoxJugadoresSala
            // 
            this.listBoxJugadoresSala.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxJugadoresSala.FormattingEnabled = true;
            this.listBoxJugadoresSala.ItemHeight = 15;
            this.listBoxJugadoresSala.Location = new System.Drawing.Point(340, 142);
            this.listBoxJugadoresSala.Name = "listBoxJugadoresSala";
            this.listBoxJugadoresSala.Size = new System.Drawing.Size(272, 169);
            this.listBoxJugadoresSala.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lista de jugadores en mi sala";
            // 
            // btnAgregarJugadorSala
            // 
            this.btnAgregarJugadorSala.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarJugadorSala.Location = new System.Drawing.Point(179, 323);
            this.btnAgregarJugadorSala.Name = "btnAgregarJugadorSala";
            this.btnAgregarJugadorSala.Size = new System.Drawing.Size(126, 42);
            this.btnAgregarJugadorSala.TabIndex = 9;
            this.btnAgregarJugadorSala.Text = "Agregar jugador";
            this.btnAgregarJugadorSala.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(340, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(272, 48);
            this.button2.TabIndex = 10;
            this.button2.Text = "Quitar jugador";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Location = new System.Drawing.Point(340, 401);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(267, 46);
            this.button3.TabIndex = 11;
            this.button3.Text = "Cancelar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxCantidadRondas);
            this.groupBox2.Location = new System.Drawing.Point(402, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuracion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Cantidad Rondas";
            // 
            // textBoxCantidadRondas
            // 
            this.textBoxCantidadRondas.Location = new System.Drawing.Point(109, 68);
            this.textBoxCantidadRondas.Name = "textBoxCantidadRondas";
            this.textBoxCantidadRondas.Size = new System.Drawing.Size(80, 23);
            this.textBoxCantidadRondas.TabIndex = 0;
            this.textBoxCantidadRondas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCantidadRondas_KeyPress);
            // 
            // btnAcciones
            // 
            this.btnAcciones.Location = new System.Drawing.Point(42, 323);
            this.btnAcciones.Name = "btnAcciones";
            this.btnAcciones.Size = new System.Drawing.Size(130, 42);
            this.btnAcciones.TabIndex = 13;
            this.btnAcciones.Text = "Acciones";
            this.btnAcciones.UseVisualStyleBackColor = true;
            // 
            // AgregarJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(648, 458);
            this.Controls.Add(this.btnAcciones);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAgregarJugadorSala);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxJugadoresSala);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.listBoxJugadoresRegistrados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AgregarJugador";
            this.Text = "AgregarJugador";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgregarJugador_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxJugadoresRegistrados;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxJugadoresSala;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregarJugadorSala;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCantidadRondas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAlias;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnAcciones;
    }
}