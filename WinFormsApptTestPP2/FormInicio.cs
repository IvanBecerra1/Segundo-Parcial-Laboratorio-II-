using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models;
using WinFormsApptTestPP2.models.Interfaz;
using WinFormsApptTestPP2.models.Presentador;

namespace WinFormsApptTestPP2
{
    public partial class FormInicio : Form, IInicio
    {
        public FormInicio()
        {
            InitializeComponent();

            //Asociar Eventos directo con delegados
            this.btnIniciar.Click += delegate
            {
                this.EventoMostrarAgregarJugador?.Invoke(this, EventArgs.Empty);
            };

            //Asociacion click Estadistica
            this.button1.Click += delegate
            {
                this.EventoMostrarEstadistica?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// Eventos
        /// </summary>
        public event EventHandler EventoMostrarAgregarJugador;
        public event EventHandler EventoMostrarEstadistica;
    }
}
