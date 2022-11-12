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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPartidas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalirEstadistica = new System.Windows.Forms.Button();
            this.dataGridViewJugador = new System.Windows.Forms.DataGridView();
            this.dataGridViewTop = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJugador)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(49, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Top 15 de jugadores por partida ganadas";
            // 
            // comboBoxPartidas
            // 
            this.comboBoxPartidas.FormattingEnabled = true;
            this.comboBoxPartidas.Location = new System.Drawing.Point(50, 102);
            this.comboBoxPartidas.Name = "comboBoxPartidas";
            this.comboBoxPartidas.Size = new System.Drawing.Size(643, 23);
            this.comboBoxPartidas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(50, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Partidas historicas";
            // 
            // btnSalirEstadistica
            // 
            this.btnSalirEstadistica.Location = new System.Drawing.Point(51, 23);
            this.btnSalirEstadistica.Name = "btnSalirEstadistica";
            this.btnSalirEstadistica.Size = new System.Drawing.Size(167, 33);
            this.btnSalirEstadistica.TabIndex = 5;
            this.btnSalirEstadistica.Text = "Salir";
            this.btnSalirEstadistica.UseVisualStyleBackColor = true;
            // 
            // dataGridViewJugador
            // 
            this.dataGridViewJugador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJugador.Location = new System.Drawing.Point(51, 135);
            this.dataGridViewJugador.Name = "dataGridViewJugador";
            this.dataGridViewJugador.Size = new System.Drawing.Size(744, 150);
            this.dataGridViewJugador.TabIndex = 6;
            // 
            // dataGridViewTop
            // 
            this.dataGridViewTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTop.Location = new System.Drawing.Point(51, 334);
            this.dataGridViewTop.Name = "dataGridViewTop";
            this.dataGridViewTop.RowTemplate.Height = 25;
            this.dataGridViewTop.Size = new System.Drawing.Size(537, 150);
            this.dataGridViewTop.TabIndex = 7;
            // 
            // FormEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(838, 496);
            this.Controls.Add(this.dataGridViewTop);
            this.Controls.Add(this.dataGridViewJugador);
            this.Controls.Add(this.btnSalirEstadistica);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPartidas);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(854, 535);
            this.MinimumSize = new System.Drawing.Size(854, 535);
            this.Name = "FormEstadisticas";
            this.Text = "FormEstadisticas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJugador)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPartidas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnSalirEstadistica;
        private System.Windows.Forms.DataGridView dataGridViewJugador;
        private System.Windows.Forms.DataGridView dataGridViewTop;
    }
}