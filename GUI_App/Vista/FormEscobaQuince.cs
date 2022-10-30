using GUI_App.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_App.Vista
{
    public partial class FormEscobaQuince : Form, IEscobaQuinceForm
    {
        public FormEscobaQuince()
        {
            InitializeComponent();

            this.btnAbandonar.Click += delegate { EventoAbandonarPartida?.Invoke(this, EventArgs.Empty); }; ;
            this.btnIniciarPartida.Click += delegate { EventoIniciarPartida?.Invoke(this, EventArgs.Empty); }; 
            this.btnEstadisticas.Click += delegate { EventoEstadisticas?.Invoke(this, EventArgs.Empty); }; ; 
        }

        public event EventHandler EventoIniciarPartida;
        public event EventHandler EventoAbandonarPartida;
        public event EventHandler EventoEstadisticas;

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
