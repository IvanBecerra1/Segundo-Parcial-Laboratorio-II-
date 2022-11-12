namespace WinFormsApptTestPP2
{
    partial class FormEstadisticas
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
            this.dataGridViewJugadores = new System.Windows.Forms.DataGridView();
            this.rowId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowPartidasGanadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowPartidaPerdidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowPartidaAbandonadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowPartidasTotales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.rowId_table2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowNombre_table2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowAlias_table2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowTop_15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPartidas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalirEstadistica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJugadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewJugadores
            // 
            this.dataGridViewJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJugadores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowId,
            this.rowNombre,
            this.rowAlias,
            this.rowPartidasGanadas,
            this.rowPartidaPerdidas,
            this.rowPartidaAbandonadas,
            this.rowPartidasTotales});
            this.dataGridViewJugadores.Location = new System.Drawing.Point(49, 126);
            this.dataGridViewJugadores.Name = "dataGridViewJugadores";
            this.dataGridViewJugadores.RowTemplate.Height = 25;
            this.dataGridViewJugadores.Size = new System.Drawing.Size(745, 150);
            this.dataGridViewJugadores.TabIndex = 0;
            // 
            // rowId
            // 
            this.rowId.HeaderText = "#Id";
            this.rowId.Name = "rowId";
            this.rowId.ReadOnly = true;
            // 
            // rowNombre
            // 
            this.rowNombre.HeaderText = "Nombre";
            this.rowNombre.Name = "rowNombre";
            this.rowNombre.ReadOnly = true;
            // 
            // rowAlias
            // 
            this.rowAlias.HeaderText = "Alias";
            this.rowAlias.Name = "rowAlias";
            this.rowAlias.ReadOnly = true;
            // 
            // rowPartidasGanadas
            // 
            this.rowPartidasGanadas.HeaderText = "Ganados";
            this.rowPartidasGanadas.Name = "rowPartidasGanadas";
            this.rowPartidasGanadas.ReadOnly = true;
            // 
            // rowPartidaPerdidas
            // 
            this.rowPartidaPerdidas.HeaderText = "Perdidos";
            this.rowPartidaPerdidas.Name = "rowPartidaPerdidas";
            this.rowPartidaPerdidas.ReadOnly = true;
            // 
            // rowPartidaAbandonadas
            // 
            this.rowPartidaAbandonadas.HeaderText = "Abandonadas";
            this.rowPartidaAbandonadas.Name = "rowPartidaAbandonadas";
            this.rowPartidaAbandonadas.ReadOnly = true;
            // 
            // rowPartidasTotales
            // 
            this.rowPartidasTotales.HeaderText = "Partidas totales";
            this.rowPartidasTotales.Name = "rowPartidasTotales";
            this.rowPartidasTotales.ReadOnly = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowId_table2,
            this.rowNombre_table2,
            this.rowAlias_table2,
            this.rowTop_15});
            this.dataGridView2.Location = new System.Drawing.Point(49, 365);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(443, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // rowId_table2
            // 
            this.rowId_table2.HeaderText = "#Posicion";
            this.rowId_table2.Name = "rowId_table2";
            this.rowId_table2.ReadOnly = true;
            // 
            // rowNombre_table2
            // 
            this.rowNombre_table2.HeaderText = "nombre";
            this.rowNombre_table2.Name = "rowNombre_table2";
            this.rowNombre_table2.ReadOnly = true;
            // 
            // rowAlias_table2
            // 
            this.rowAlias_table2.HeaderText = "Alias";
            this.rowAlias_table2.Name = "rowAlias_table2";
            this.rowAlias_table2.ReadOnly = true;
            // 
            // rowTop_15
            // 
            this.rowTop_15.HeaderText = "Partidas ganadas";
            this.rowTop_15.Name = "rowTop_15";
            this.rowTop_15.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(49, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Top 15 de jugadores por partida ganadas";
            // 
            // comboBoxPartidas
            // 
            this.comboBoxPartidas.FormattingEnabled = true;
            this.comboBoxPartidas.Location = new System.Drawing.Point(49, 68);
            this.comboBoxPartidas.Name = "comboBoxPartidas";
            this.comboBoxPartidas.Size = new System.Drawing.Size(643, 23);
            this.comboBoxPartidas.TabIndex = 3;
            this.comboBoxPartidas.SelectedIndexChanged += new System.EventHandler(this.comboBoxPartidas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(49, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Partidas historicas";
            // 
            // btnSalirEstadistica
            // 
            this.btnSalirEstadistica.Location = new System.Drawing.Point(325, 549);
            this.btnSalirEstadistica.Name = "btnSalirEstadistica";
            this.btnSalirEstadistica.Size = new System.Drawing.Size(167, 33);
            this.btnSalirEstadistica.TabIndex = 5;
            this.btnSalirEstadistica.Text = "Salir";
            this.btnSalirEstadistica.UseVisualStyleBackColor = true;
            this.btnSalirEstadistica.Click += new System.EventHandler(this.btnSalirEstadistica_Click);
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(840, 608);
            this.Controls.Add(this.btnSalirEstadistica);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPartidas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridViewJugadores);
            this.Name = "FormEstadisticas";
            this.Text = "FormEstadisticas";
            this.Load += new System.EventHandler(this.FormEstadisticas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJugadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewJugadores;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowId;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowPartidasGanadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowPartidaPerdidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowPartidaAbandonadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowPartidasTotales;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowId_table2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNombre_table2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowAlias_table2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowTop_15;
        private System.Windows.Forms.ComboBox comboBoxPartidas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnSalirEstadistica;
    }
}