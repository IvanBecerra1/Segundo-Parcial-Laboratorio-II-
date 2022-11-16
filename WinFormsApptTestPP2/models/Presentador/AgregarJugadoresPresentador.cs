using Libreria.Entidades;
using Modelo.Enumeraciones;
using Modelo.Interfaces;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models.Interfaz;

namespace WinFormsApptTestPP2.models.Presentador
{
    /// <summary>
    /// Funciones logicas que 
    /// va tener el formulario AgregarJugador
    /// </summary>
    public class AgregarJugadoresPresentador
    {
        // interfaces
        private IAgregarJugador agregarJugador;
        private IRepositorio<Jugador> repositorio;

        // Binding source
        private BindingSource jugadoresBindingSource;
        private BindingSource jugadoresEnSalaBindingSource;

        // Listas
        private List<Jugador> listaJugadores;
        private List<Jugador> listaJugadoresEnSala;


        // Delegados
        private Predicate<String> validarTextBox = e => string.IsNullOrEmpty(e);

        /// <summary>
        /// Inicializacion de variables
        /// </summary>
        /// <param name="agregarJugador"></param>
        /// <param name="repositorio"></param>
        public AgregarJugadoresPresentador(
            IAgregarJugador agregarJugador, IRepositorio<Jugador> repositorio)
        {
            this.agregarJugador = agregarJugador;
            this.repositorio = repositorio;

            this.jugadoresBindingSource = new BindingSource();
            this.jugadoresEnSalaBindingSource = new BindingSource();

            this.listaJugadores = new List<Jugador>();
            this.listaJugadoresEnSala = new List<Jugador>();

            this.agregarJugador.EventoAgregarJugador += CatchEventoAgregarJugador;
            this.agregarJugador.EventoQuitarJugador += CatchEventoQuitarJugador;

            this.agregarJugador.EventoRegistrarJugador += CatchEventoRegistrarJugador;
            this.agregarJugador.EventoIniciarPartida += CatchEventoIniciarPartida;

            this.agregarJugador.EventAcciones += CatchEventoAcciones;

            this.agregarJugador.EnlazarJugadoresBindingSource(this.jugadoresBindingSource);
            this.agregarJugador.EnlazarJugadorSalaBindingSource(this.jugadoresEnSalaBindingSource);

            // cargar jugador
            CargarJugador();
        }
        /// <summary>
        /// Lista los jugadores que estan en la base datos
        /// y se los pasa al BindingSource para que se actualice
        /// </summary>
        public void CargarJugador()
        {
            this.listaJugadores = repositorio.obtenerTodo();
            this.jugadoresBindingSource.DataSource = this.listaJugadores;
            this.jugadoresBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// Lista los jugadores en la sala
        ///  y se los envia al binding correspondiente
        ///  En este caso particular, es necesario actualizar 
        ///  el binding source
        /// </summary>
        public void CargarJugadorSala()
        {
            this.jugadoresEnSalaBindingSource.DataSource = this.listaJugadoresEnSala;
            this.jugadoresEnSalaBindingSource.ResetBindings(true);
        }
        #region Captura de Eventos
        /// <summary>
        /// Evento para agregar un jugador a la sala
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void CatchEventoAgregarJugador(Object? obj, EventArgs e)
        {
            try
            {
                CargarJugador();// Evitamos problemas en los otros hilos

                if (this.jugadoresBindingSource.Current == null)
                {
                    MessageBox.Show($"Selecciona a un jugador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                Jugador jugadorSeleccionado = (Jugador)this.jugadoresBindingSource.Current;

                if (jugadorSeleccionado.Estado == EEstadoJugador.JUGANDO)
                {
                    MessageBox.Show($"Selecciona a un jugador que este disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                jugadorSeleccionado.Estado = EEstadoJugador.JUGANDO;
                this.repositorio.editar(jugadorSeleccionado);

                this.listaJugadoresEnSala.Add(jugadorSeleccionado);
                CargarJugadorSala();
                CargarJugador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Quita el jugador seleccionado de la sala
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void CatchEventoQuitarJugador(Object? obj, EventArgs e)
        {
            try
            {
                if (this.jugadoresEnSalaBindingSource.Current == null)
                {
                    MessageBox.Show($"Selecciona a un jugador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Jugador jugadorSeleccionado = (Jugador)this.jugadoresEnSalaBindingSource.Current;

                jugadorSeleccionado.Estado = EEstadoJugador.DISPONIBLE;
                this.repositorio.editar(jugadorSeleccionado);
                this.listaJugadoresEnSala.Remove(jugadorSeleccionado);
               
                // Actualizamos
                CargarJugadorSala();
                CargarJugador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Registra un jugador nuevo
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void CatchEventoRegistrarJugador(Object? obj, EventArgs e)
        {
            try
            {
                if (this.validarTextBox(this.agregarJugador.TextNombre)
                        && this.validarTextBox(this.agregarJugador.TextAlias))
                {
                    // Mensaje Box de rellenar campos
                    MessageBox.Show("Rellene los campos correspondiente", "Error", MessageBoxButtons.OK);
                    return;
                }

                if (this.repositorio.buscarPor(this.agregarJugador.TextAlias).Alias != null)
                {
                    // Mensaje box de que el usuario/alias
                    MessageBox.Show("Ese Alias se encuentra en uso", "Error", MessageBoxButtons.OK);
                    return;
                }

                Jugador jugador = new Jugador();
                jugador.Nombre = this.agregarJugador.TextNombre;
                jugador.Alias = this.agregarJugador.TextAlias;
                jugador.Estadisticas = new Estadisticas();
                this.repositorio.guardar(jugador);

                CargarJugador();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Se ha producido un error: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento para inicar la sala/partida
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void CatchEventoIniciarPartida(Object? obj, EventArgs e)
        {
            //botonCerrar = true;
            if (this.agregarJugador.Ronda <= 2)
            {
                MessageBox.Show($"Ingrese una ronda mayor a 2", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.listaJugadoresEnSala.Any() == false 
                || this.listaJugadoresEnSala.Count <= 1 
                    || this.listaJugadoresEnSala.Count > 4)
            {
                MessageBox.Show($"Ingrese almenos: 2-4 Jugadores", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.agregarJugador.SalaValida = true;
        }

        /// <summary>
        /// Evento para abrir el menu de acciones
        /// y poder manipular partes del Crud en usuarios
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void CatchEventoAcciones(Object? obj, EventArgs e)
        {
            if (this.jugadoresBindingSource.Current == null)
            {
                MessageBox.Show($"Selecciona a un jugador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Jugador jugadorSeleccionado = (Jugador)this.jugadoresBindingSource.Current;

            IAcciones iAcciones = new FormAcciones();
            IRepositorio<Jugador> iRepositorio = new JugadorRepositorio();
            AccionesPresentacion presentador = new AccionesPresentacion(iAcciones, iRepositorio, jugadorSeleccionado);
            ((FormAcciones)iAcciones).ShowDialog();

            this.CargarJugador();//actualizamos
        }
        #endregion

    }
}
