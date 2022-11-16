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

            this.dataGridView1.CellClick += delegate
            {
                this.EventoClickCell?.Invoke(this, EventArgs.Empty);
            };

            this.btnActualizar.Click += delegate
            {
                EventoActualizarTabla?.Invoke(this, EventArgs.Empty);
            };
        }

        /// <summary>
        /// Eventos
        /// </summary>
        public event EventHandler EventoMostrarAgregarJugador;
        public event EventHandler EventoMostrarEstadistica;
        public event EventHandler EventoClickCell;
        public event EventHandler EventoActualizarTabla;

        /// <summary>
        /// Enlaza el menu de Salas
        /// Utilizo un IvokeRequired por si se encuentra en otro hilo
        /// </summary>
        /// <param name="enlazar"></param>
        public void EnlazarMenus(BindingSource enlazar)
        {

            if (this.dataGridView1.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate () {

                    this.dataGridView1.DataSource = enlazar;
                });
            }
            else
            {
                this.dataGridView1.DataSource = enlazar;
            }
        }
    }
}
