using Modelo.Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2
{
    public partial class FormColoresCarta : Form
    {
        private ETipoColor colorSeleccionado;

        public FormColoresCarta()
        {
            InitializeComponent();
        }

        public ETipoColor ColorSeleccionado 
        { 
            get => (ETipoColor)this.listBox1.Items[this.listBox1.SelectedIndex];
            set => this.colorSeleccionado = value; 
        }

        private void FormColoresCarta_Load(object sender, EventArgs e)
        {
            this.listBox1.Items.Add(ETipoColor.ROJO);
            this.listBox1.Items.Add(ETipoColor.VERDE);
            this.listBox1.Items.Add(ETipoColor.AMARILLO);
            this.listBox1.Items.Add(ETipoColor.AZUL);
            this.listBox1.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
