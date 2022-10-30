using GUI_App.Interfaces;
using Libreria.Entidades;
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
    public partial class FormAgregarJugadores : Form, IAgregarJugadoresForm
    {
        public FormAgregarJugadores()
        {
            InitializeComponent();
            IniciarlizarEventos();

        }

        private void IniciarlizarEventos()
        {
            this.btnAceptar.Click += delegate { this.Close(); };
            this.btnAgregarJugador.Click += delegate { EventoAgregarJugador?.Invoke(this, EventArgs.Empty); };
        }

        public string TextNombre { get => this.textBoxNombre.Text; set => this.textBoxNombre.Text = value; }
        public List<Jugador> ListaJugadores {
            get {
                List<Jugador> listaJugadores = new List<Jugador>();

                foreach (var aux in this.listBox1.Items)
                {
                    listaJugadores.Add((Jugador)aux);
                }
                return listaJugadores; 
            
            }
        }


        public event EventHandler EventoAceptar;
        public event EventHandler EventoAgregarJugador;

        public void AgregarJugadoresBindigSource(BindingSource listaJugadores)
        {
            this.listBox1.DataSource = listaJugadores;
        }

    }
}
