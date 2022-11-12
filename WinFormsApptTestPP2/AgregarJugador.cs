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

namespace WinFormsApptTestPP2
{
    public partial class AgregarJugador : Form
    {

        private JugadorRepositorio jugadorRepositorio;
        private EstadisticasRepositorio estadisticaRepositorio;
        private List<Jugador> listaJugadorEnSala;

        public delegate void EventoSala();
        public event EventoSala CatchEventMenu;


        private bool botonCerrar;
        public List<Jugador> ListaJugadorEnSala { 
            get
            {

                List<Jugador> lista = new List<Jugador>();
                foreach (var aux in this.listBoxJugadoresSala.Items)
                {
                    lista.Add((Jugador)aux);
                }

                return lista;
            } 
            set => listaJugadorEnSala = value;
        }

        public int CantidadRonda
        {
            get
            {
                return int.Parse(this.textBoxCantidadRondas.Text);
            }
        }
        public AgregarJugador()
        {
            this.jugadorRepositorio = new JugadorRepositorio();
            this.estadisticaRepositorio = new EstadisticasRepositorio();
            this.listaJugadorEnSala = new List<Jugador>();


            InitializeComponent();
            ActualizarListBoxJugadores();

            this.textBoxCantidadRondas.Text = "0";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxNombre.Text.Any() == false && this.textBoxAlias.Text.Any() == false)
                {
                    limpiarTextBox();
                    return;
                }

                if (this.jugadorRepositorio.buscarPor(this.textBoxAlias.Text).Alias != null)
                {
                    limpiarTextBox();
                    return;
                }

                string nombre = this.textBoxNombre.Text;
                string alias = this.textBoxAlias.Text;

                Jugador jugador = new Jugador();

                jugador.Nombre = nombre;
                jugador.Alias = alias;
                jugador.Estadisticas = new Estadisticas();


                this.jugadorRepositorio.guardar(jugador);

                ActualizarListBoxJugadores();
                limpiarTextBox();
            } catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex}", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            botonCerrar = true;
            if (int.Parse(this.textBoxCantidadRondas.Text) <= 3)
            {
                Task taskNotifiacion = Task.Run(() =>
                {
                    MessageBox.Show($"Ingrese una ronda mayor a 3", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
                return;
            }

            if (this.ListaJugadorEnSala.Any() == false || this.ListaJugadorEnSala.Count <= 1 || this.ListaJugadorEnSala.Count > 3)
            {
                Task tarea = Task.Run(() =>
                {
                    MessageBox.Show($"Ingrese almenos: 2-4 Jugadores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
                return;
            }

            this.CatchEventMenu.Invoke();
        }


        public void AbrirMenuSala()
        {
            FormJuego form = new FormJuego(this.ListaJugadorEnSala);
            new FormJuegoPresentador(form);
            form.Show();
        }

        public void ActualizarListBoxJugadores()
        {
            this.listBoxJugadoresRegistrados.DataSource = this.jugadorRepositorio.obtenerTodo();
        }
        public void limpiarTextBox()
        {
            this.textBoxNombre.Clear();
            this.textBoxAlias.Clear();
        }

        private void btnAgregarJugadorSala_Click(object sender, EventArgs e)
        {
            try
            {
                // Re actualizamos por si en algun otro hilo se hizo alguna seleccion al jugador.
                int id = this.listBoxJugadoresRegistrados.SelectedIndex;
                ActualizarListBoxJugadores();
                this.listBoxJugadoresRegistrados.SelectedIndex = id;


                if (this.listBoxJugadoresRegistrados.SelectedIndex == -1)
                {
                    MessageBox.Show($"Selecciona a un jugador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Jugador jugadorSeleccionado = (Jugador)this.listBoxJugadoresRegistrados.Items[this.listBoxJugadoresRegistrados.SelectedIndex];
    
                if (jugadorSeleccionado.Estado == EEstadoJugador.JUGANDO)
                {
                    MessageBox.Show($"Selecciona a un jugador que este disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                jugadorSeleccionado.Estado = EEstadoJugador.JUGANDO;
                this.jugadorRepositorio.editar(jugadorSeleccionado);

                this.listBoxJugadoresSala.Items.Add(jugadorSeleccionado);
                ActualizarListBoxJugadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            botonCerrar = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
              //  ActualizarListBoxJugadores();
                if (this.listBoxJugadoresSala.SelectedIndex == -1)
                {
                    MessageBox.Show($"Selecciona a un jugador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Jugador jugadorSeleccionado = (Jugador)this.listBoxJugadoresSala.Items[this.listBoxJugadoresSala.SelectedIndex];

                jugadorSeleccionado.Estado = EEstadoJugador.DISPONIBLE;
                this.jugadorRepositorio.editar(jugadorSeleccionado);
                //this.estadisticaRepositorio.editar(jugadorSeleccionado.Estadisticas);
                this.listBoxJugadoresSala.Items.Remove(jugadorSeleccionado);

                ActualizarListBoxJugadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActualizarListBoxJugadores();
        }

        private void AgregarJugador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.botonCerrar == true)
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
                jugadorRepositorio.editar((Jugador)aux);
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
    }
}
