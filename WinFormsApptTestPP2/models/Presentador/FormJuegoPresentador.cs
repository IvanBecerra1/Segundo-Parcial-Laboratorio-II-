using Libreria.Entidades;
using Libreria.Enumeraciones;
using Modelo.Entidades;
using Modelo.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models.Interfaz;
using Modelo.Enumeraciones;
using Modelo.Repositorio;
using Modelo.Archivos;

namespace WinFormsApptTestPP2.models.Presentador
{
    public class FormJuegoPresentador
    {

        private int turno = 0;
        private int rondasInicio;


        private bool agarrarCarta;
        private bool tirarCarta;
        private bool invertir;
        private bool ganador;

        private SalaUno salaCarta;
        private IJuego presentador;

        //Enlaces
        private BindingSource cartasJugadorBindingSource;
        private BindingSource archibosBindingSource;

        //Lista
        private List<ArchivosLogs> listaLogs;

        //Entidad
        private Jugador turnoJugador;

        //Repositorio
        private JugadorRepositorio repositorioJugador;
        private EstadisticasRepositorio repositorioEstadistica;


        public FormJuegoPresentador(IJuego presentador)
        {
            this.presentador = presentador;

            this.salaCarta = new SalaUno(new UnoServicio());
            this.repositorioJugador = new JugadorRepositorio();
            this.repositorioEstadistica = new EstadisticasRepositorio();


            this.cartasJugadorBindingSource = new SyncBindingSource();
            this.archibosBindingSource = new SyncBindingSource();

            this.listaLogs = new List<ArchivosLogs>();
            this.turnoJugador = new Jugador();

            //Eventos
            this.presentador.TirarCarta += funcionTirarCarta;
            this.presentador.RecojerCarta += funcionRecojerCarta;
            this.presentador.abandonar += funcionAbandonar;
            this.presentador.PasarTurno += funcionPasarTurno;
            this.presentador.CantarUno += funcionCantarUno;
            this.presentador.BotonMostrarCarta += funcionMostrarCarta;

            // Enlazando el control BindingSource 
            this.presentador.cartasJugadorBindingSource(this.cartasJugadorBindingSource);
            this.presentador.jugadoresDataSource(this.presentador.ListaJugadores);
            CargarDatosPrincipales();


            this.presentador.MostrarCartasJugador = false;
            this.rondasInicio = this.presentador.Rondas;

        }
        /// <summary>
        /// Se carga datos principales del juego
        /// y se reparte las cartas a los jugadores
        /// </summary>
        private void CargarDatosPrincipales()
        {
            this.salaCarta.CargarPartida();

            foreach (var aux in this.presentador.ListaJugadores)
            {
                List<CartaUno> carta = new List<CartaUno>();
                //       aux.Cartas.Add(new CartaUno(ETipoCarta.CAMBIAR_COLOR, 1, Modelo.Enumeraciones.ETipoColor.ROJO));
                //      aux.Cartas.Add(new CartaUno(ETipoCarta.CAMBIAR_COLOR, 2, Modelo.Enumeraciones.ETipoColor.VERDE));


                //  carta.Add(new CartaUno(ETipoCarta.INVERTIR_RONDA, 3, Modelo.Enumeraciones.ETipoColor.AZUL));
                // carta.Add(new CartaUno(ETipoCarta.INVERTIR_RONDA, 3, Modelo.Enumeraciones.ETipoColor.AMARILLO));




                aux.Cartas = this.salaCarta.DarCartaJugador();
                aux.Cartas.AddRange(carta);
            }



            CambiarTurno();
        }

        #region Eventos

        /// <summary>
        /// Manejo de evento, donde se podra cantar uno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void funcionCantarUno(object? sender, EventArgs e)
        {
            if (!this.turnoJugador.CantarUno)
            {
                this.presentador.Notificacion = $"No puedes cantar uno ahora.";
                return;
            }

            this.turnoJugador.CantarUno = false;
            this.presentador.Notificacion = $"El jugador {this.turnoJugador.Nombre} canto Uno!!!";
            NotificarLogs("Canto uno!!!");
            return;
        }

        /// <summary>
        /// Manejo del evento para mostrar las cartas del jugador al momento que se cambia de turno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void funcionMostrarCarta(object? sender, EventArgs e)
        {
            if (validarTirarCarta())
            {
                this.presentador.Notificacion = $"Espere a que se cambie de mano.";
                return;
            }
            this.cartasJugadorBindingSource.ResetBindings(true);
            this.presentador.MostrarCartasJugador = true;
        }

        /// <summary>
        /// Manejo de evento cuando al hacer click se pase de turno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void funcionPasarTurno(object? sender, EventArgs e)
        {
            if (validarTirarCarta())
            {
                return;
            }

            if (this.agarrarCarta == true)
            {
                MostrarMessageBox($"Es necesario que agarre una carta para pasar el turno");
                return;
            }

            NotificarLogs("Paso su turno");
            this.tirarCarta = true;
            this.presentador.MostrarCartasJugador = false;
            ControlarTask();
        }


        /// <summary>
        /// Evento click del boton abandonar partida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void funcionAbandonar(object? sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Seguro que quieres abandonar la partida?", "Juego", MessageBoxButtons.OKCancel);

            if (respuesta == DialogResult.OK)
            {
                NotificarLogs("Abandono la partida");
                this.turnoJugador.Estadisticas.PartidasAbandonadas++;
                RestablecerEstadoJugador();
                this.presentador.TerminoRonda = true;

            }
        }

        /// <summary>
        /// Manejo del evento click para recojer una carta del mazo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void funcionRecojerCarta(object? sender, EventArgs e)
        {
            if (this.tirarCarta == true)
            {
                return;
            }

            if (this.agarrarCarta == false)
            {
                MostrarMessageBox("Solo puedes agarrar una carta");
                return;
            }

            CartaUno cartaObtenida = this.salaCarta.AgarrarCarta();

            this.turnoJugador.Cartas.Add(cartaObtenida);
            this.cartasJugadorBindingSource.ResetBindings(true);
            this.agarrarCarta = false;

            NotificarLogs("Recogio una carta del mazo");
            MostrarMessageBox($"Obtuviste la carta: {cartaObtenida.ToString()}");

        }

        /// <summary>
        /// Evento click para tirar una carta en la mesa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void funcionTirarCarta(object? sender, EventArgs e)
        {
            if (this.tirarCarta == true)
            {
                return;
            }
            CartaUno cartaSeleccionada = (CartaUno)cartasJugadorBindingSource.Current; // Devuelve la carta seleccionada


            if (cartaSeleccionada.Palo == ETipoCarta.CAMBIAR_COLOR)
            {
                CambiarColorCarta(cartaSeleccionada);
            }

            if (this.salaCarta.DepositarCarta(cartaSeleccionada))
            {

                this.turnoJugador.Cartas.Remove(cartaSeleccionada);
                this.cartasJugadorBindingSource.ResetBindings(true);

                this.cartasJugadorBindingSource.Position = 0;
                this.tirarCarta = true;
                this.presentador.MostrarCartasJugador = false;
                NotificarLogs($"Tiro su carta: {cartaSeleccionada.Color.ToString()} * {cartaSeleccionada.Palo.ToString()}  * {cartaSeleccionada.NumeroPalo}");

                VerificarCantarUno();
                ControlarTask();
            }
            else
            {
                MostrarMessageBox($"No puedes tirar esta carta, verifique: COLOR, TIPO, NUMERO\n{cartaSeleccionada.ToString()}");
            }
        }
        #endregion


        #region Funciones del juego
        
        /// <summary>
        /// Funcion donde se crea el hilo para darle tiempo al jugador de cantar mano si 
        /// es que tiene una carta.
        /// </summary>
        public void ControlarTask()
        {
            this.presentador.Notificacion = $"Cambiando ronda....";

            var hilo = Task.Run(() =>
            {

                for (int i = 0; i < 5; i++)
                {

                    this.presentador.Notificacion = $"***Cambiando mano en: {(i + 1)}/5 SEG ";
                    Thread.Sleep(1000);
                }

                CambiarTurno();
                this.presentador.Notificacion = $"**********";
            });

        }

        /// <summary>
        /// Metodo que cambia el turno del jugador
        /// </summary>
        public void CambiarTurno()
        {

            this.presentador.CartaMesa = this.salaCarta.MostrarCartaMesa();

            CambiarRonda(this.presentador.CartaMesa);
            InvertirRonda(invertir);

            this.turnoJugador = this.presentador.ListaJugadores[this.turno];
            this.presentador.Rondas--;

            this.presentador.textTurnoJugador = this.turnoJugador.Nombre + " - " + this.turnoJugador.Alias;
            //this.presentador.Archivos = new ArchivosLogs(this.turnoJugador.Nombre, "tiene la mano*******");

            this.NotificarLogs("tiene la mano*******");

            VerificarCartaEnMesa();
            ActualizarDatos();
        }

        /// <summary>
        /// Metodo para comprobar si hay que invertir la ronda
        /// </summary>
        /// <param name="invertir"></param>
        public void InvertirRonda(bool invertir)
        {
            if (invertir == false)
            {
                this.turno++;

                if (this.turno >= this.presentador.ListaJugadores.Count())
                {
                    this.turno = 0;
                }
            }
            else // true = ronda invertida
            {
                this.turno--;

                if (this.turno < 0 || this.turno >= this.presentador.ListaJugadores.Count())
                {
                    this.turno = this.presentador.ListaJugadores.Count() - 1;
                }

            }
        }

        /// <summary>
        /// Metodo para verificar si el jugador tiene ultima carta
        /// y deba cantar uno, o si ya no tiene mas y es el ganador.
        /// </summary>
        /// <returns></returns>
        public void VerificarUltimaCarta()
        {
            if (ganador == true)
            {
                return;
            }
            if (this.presentador.Rondas <= 0)
            {
                Jugador aux = devolverJugador();
                MensajeGanador(aux);

                return;
            }

            foreach (var aux in this.presentador.ListaJugadores)
            {
                if (aux.Cartas.Any() == false)
                {
                    MensajeGanador(aux);
                    break;
                }

                if (aux.CantarUno == true)
                {
                    aux.Cartas.AddRange(this.salaCarta.DevolverDosCartas());
                    aux.CantarUno = false;
                    this.presentador.Notificacion = $"El jugador {aux.Nombre} recibio dos cartas por no cantar Uno";
                    this.NotificarLogs($"se llevo dos cartas por no cantar Uno.");
                }
            }
        }

        public Jugador devolverJugador()
        {
            Jugador jugador = new Jugador();
            int countMin = 100;

            foreach (var aux in this.presentador.ListaJugadores)
            {
                //5 < 100 ? yes; 
                if (aux.Cartas.Count < countMin)
                {
                    countMin = aux.Cartas.Count;
                    jugador = aux;
                }

            }

            return jugador;

        }
        /// <summary>
        /// Metodo para actualizar los datos del jugador en turno
        /// </summary>
        public void ActualizarDatos()
        {
            this.presentador.ListaCartaMazo = this.salaCarta.CartaMazo();
            this.cartasJugadorBindingSource.DataSource = this.turnoJugador.Cartas;//Set data source.

            this.agarrarCarta = true;
            this.tirarCarta = false;
            VerificarUltimaCarta();
        }

        /// <summary>
        /// Metodo para verificar la ultima carta en mesa, si es alguna carta especial
        /// 
        /// </summary>
        public void VerificarCartaEnMesa()
        {

            if (this.presentador.CartaMesa.Accion == true)
            {
                return;
            }

            ETipoCarta tipo = this.presentador.CartaMesa.Palo;
            List<CartaUno> cartasComidas = new List<CartaUno>();
            cartasComidas = this.salaCarta.VerificarCartasEspeciales(out tipo);

            if (tipo == ETipoCarta.ROBA_CUATRO || tipo == ETipoCarta.ROBA_DOS)
            {
                this.turnoJugador.Cartas.AddRange(cartasComidas);
                this.presentador.CartaMesa.Accion = true;

                MostrarMessageBox($"Te tiraron un {tipo.ToString()} y perdiste tu turno");
                this.NotificarLogs($"Se llevo puesto un {tipo.ToString()}");
                CambiarTurno();
                return;
            }

            if (tipo == ETipoCarta.CAMBIAR_COLOR)
            {
                CambiarColorCarta(this.presentador.CartaMesa);
                this.presentador.CartaMesa.Accion = true;
                return;
            }

            if (tipo == ETipoCarta.SALTEAR_JUGADOR)
            {
                MostrarMessageBox($"Te saltearon tu turno");
                this.NotificarLogs("Fue salteado");
                this.presentador.CartaMesa.Accion = true;

                CambiarTurno();
                return;
            }
        }
        /// <summary>
        /// Metodo que tendra la logica de cuando se tira 
        /// una carta y es la de invertir ronda
        /// </summary>
        /// <param name="cartaSeleccionada"></param>
        public void CambiarRonda(CartaUno cartaSeleccionada)
        {

            if (cartaSeleccionada.Palo != ETipoCarta.INVERTIR_RONDA)
            {
                return;
            }

            if (this.presentador.CartaMesa.Accion == true)
            {
                return;
            }

            this.invertir = (this.invertir == false ? true : false);

            cartaSeleccionada.Accion = true;
            MostrarMessageBox($"Se invirtio la Ronda");
            //   this.presentador.Archivos = new ArchivosLogs("Juego", "Se invirtio la ronda //////]");

            this.NotificarLogs("Se invirtio la ronda ()()()()()");
        }

        /// <summary>
        /// Metodo para cuando se tira una carta que cambia color
        /// </summary>
        /// <param name="cartaSeleccionada"></param>
        /// <returns></returns>
        public CartaUno CambiarColorCarta(CartaUno cartaSeleccionada)
        {
            MostrarMessageBox($"Seleccione un color para definirla en la mesa de carta");
            FormColoresCarta formColoresCarta = new FormColoresCarta();

            formColoresCarta.ShowDialog();
            cartaSeleccionada.Color = formColoresCarta.ColorSeleccionado;
            cartaSeleccionada.Accion = true;

            NotificarLogs($"Cambio el color de la carta: {cartaSeleccionada.Color.ToString()}");
            return cartaSeleccionada;
        }

        /// <summary>
        /// Metodo para verificar si el jugador necesita cantar uno o no
        /// 
        /// </summary>
        /// <returns></returns>
        public void VerificarCantarUno()
        {

            if (this.turnoJugador.Cartas.Count() <= 1)
            {
                this.turnoJugador.CantarUno = true;
            }
            else
            {
                this.turnoJugador.CantarUno = false;
            }
        }

        /// <summary>
        /// Metodo que muetra el ganador de la sala.
        /// </summary>
        /// <param name="jugadorGanador"></param>
        public void MensajeGanador(Jugador jugadorGanador)
        {
            this.ganador = true;
            GuardarPartida(jugadorGanador);

            FormPartidaTerminada formPartidaTerminada = new FormPartidaTerminada();
            formPartidaTerminada.ListaJugadores = this.presentador.ListaJugadores;
            formPartidaTerminada.JugadorGanador = jugadorGanador;

            this.presentador.TerminoRonda = true;
            AsignarEstadisticas(jugadorGanador);
            formPartidaTerminada.ShowDialog();

            RestablecerEstadoJugador();
        }

        public void GuardarPartida(Jugador jugadorGanador)
        {
            Partida partida = new Partida();
            DateTime fecha = DateTime.Today;

            partida.Ganador = jugadorGanador;
            partida.Jugadores = this.presentador.ListaJugadores;
            partida.Fecha = fecha;
            partida.Rondas = this.rondasInicio - this.presentador.Rondas;

            PartidaRepositorio repositorioPartida = new PartidaRepositorio();
            repositorioPartida.guardar(partida);
        }
        /// <summary>
        /// Metodo que cambia el estado del jugador marcando a que ya no esta jugando en ninguna sala
        /// </summary>
        public void RestablecerEstadoJugador()
        {
            foreach (var aux in this.presentador.ListaJugadores)
            {
                aux.Estado = EEstadoJugador.DISPONIBLE;

                repositorioJugador.editar(aux);
            }
        }

        /// <summary>
        /// Asigna las estadisticas a los jugadores
        /// </summary>
        public void AsignarEstadisticas(Jugador ganador)
        {
            foreach (var aux in this.presentador.ListaJugadores)
            {
                aux.Estado = EEstadoJugador.DISPONIBLE;

                if (aux == ganador)
                {
                    aux.Estadisticas.PartidasGanadas++;
                }
                else
                {
                    aux.Estadisticas.PartidasPerdidas++;
                }

                aux.Estadisticas.PartidasTotales++; // partidas totales;
                this.repositorioJugador.editar(aux);
                this.repositorioEstadistica.editar(aux.Estadisticas);
            }
        }
        #endregion

        #region Algunas funciones pequeñas
        public void NotificarLogs(string mensaje)
        {
            this.presentador.Archivos = new ArchivosLogs(this.turnoJugador.Nombre, mensaje);
        }

        public bool validarTirarCarta()
        {
            return (this.tirarCarta == true);
        }
        public void MostrarMessageBox(string args)
        {
            MessageBox.Show(args, "Juego");
        }
        #endregion

    }
}
