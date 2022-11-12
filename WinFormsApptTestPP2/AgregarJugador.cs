using Libreria.Entidades;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo.Enumeraciones;
using WinFormsApptTestPP2.models.Presentador;
using WinFormsApptTestPP2.models.Interfaz;

namespace WinFormsApptTestPP2
{
    public partial class AgregarJugador : Form, IAgregarJugador
    {
        public bool salaValida;

        #region Propiedades
        public string TextNombre
        {
            get => this.textBoxNombre.Text;
            set => this.textBoxNombre.Text = value;
        }
        public string TextAlias
        {
            get => this.textBoxAlias.Text;
            set => this.textBoxAlias.Text = value;
        }
        public int Ronda
        {
            get => int.Parse(this.textBoxCantidadRondas.Text);
            set => this.textBoxCantidadRondas.Text = value.ToString();
        }
        public bool SalaValida 
        { 
            get => this.salaValida;
            set => this.salaValida = value;
        }

        public List<Jugador> ListaJugadorEnSala
        {
            get
            {
                List<Jugador> lista = new List<Jugador>();
                foreach (var aux in this.listBoxJugadoresSala.Items)
                {
                    lista.Add((Jugador)aux);
                }

                return lista;
            }
        }
        #endregion

        #region Eventos
        public event EventHandler EventoRegistrarJugador;
        public event EventHandler EventoIniciarPartida;
        public event EventHandler EventoQuitarJugador;
        public event EventHandler EventoAgregarJugador;
        #endregion

        public AgregarJugador()
        {

            InitializeComponent();

            this.textBoxCantidadRondas.Text = "0";

            // Registra jugador
            this.btnAgregar.Click += delegate
            {
                this.EventoRegistrarJugador?.Invoke(this, EventArgs.Empty);
                limpiarTextBox();
            };

            // Termina y inicia la partida
            this.btnTerminar.Click += delegate
            {
                this.EventoIniciarPartida?.Invoke(this, EventArgs.Empty);

                if (salaValida == true)
                {
                    this.DialogResult = DialogResult.OK;
                }
            };

            // Quita el jugador de la sala
            this.button2.Click += delegate
            {
                this.EventoQuitarJugador?.Invoke(this, EventArgs.Empty);
            };

            // Agrega el jugador a la sala
            this.btnAgregarJugadorSala.Click += delegate
            {
                this.EventoAgregarJugador?.Invoke(this, EventArgs.Empty);
            };

            /// cerrar fom
            this.button3.Click += delegate
            {
                this.Close();
            };

        }

        public void limpiarTextBox()
        {
            this.textBoxNombre.Clear();
            this.textBoxAlias.Clear();
        }

        private void AgregarJugador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (salaValida == true)
            {
                return;
            }

            RestablecerSeleccionados();
        }
        public void RestablecerSeleccionados()
        {
            foreach (var aux in this.listBoxJugadoresSala.Items)
            {
                ((Jugador)aux).Estado = EEstadoJugador.DISPONIBLE;
                new JugadorRepositorio().editar((Jugador)aux);
            }
        }
        private void textBoxCantidadRondas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public void EnlazarJugadoresBindingSource(BindingSource jugadores)
        {
            this.listBoxJugadoresRegistrados.DataSource = jugadores;
        }
        public void EnlazarJugadorSalaBindingSource(BindingSource jugadorSala)
        {
            this.listBoxJugadoresSala.DataSource = jugadorSala;

        }
    }
}
