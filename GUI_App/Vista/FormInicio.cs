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
    public partial class FormInicio : Form, I_Inicio
    {
        public FormInicio()
        {
            InitializeComponent();
            this.btnIniciarSala.Click += delegate { MostrarJuegoCartas?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler MostrarJuegoCartas;
    }
}
