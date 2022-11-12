using Libreria.Entidades;
using Modelo.DTO;
using Modelo.Entidades;
using Modelo.Interfaces;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models.Interfaz;

namespace WinFormsApptTestPP2.models.Presentador
{
    public class EstadisticaPresentador
    {

        private IEstadistica estadistica;
        private IRepositorio<Partida> repositorio;

        private BindingSource partidaBindingSource;
        private BindingSource jugadorBindingSource;
        private BindingSource jugadorTop15BindingSource;

        private List<Partida> listaPartida;
        private List<JugadorDTO> listaJugadorDTO;
        private List<JugadorTopDTO> listaTopJugadorDTO;

        public EstadisticaPresentador(IEstadistica estadistica, IRepositorio<Partida> repositorio)
        {

            this.estadistica = estadistica;
            this.repositorio = repositorio;

            this.partidaBindingSource = new BindingSource();
            this.jugadorBindingSource = new BindingSource();
            this.jugadorTop15BindingSource = new BindingSource();

            this.listaPartida = new List<Partida>();
            this.listaJugadorDTO = new List<JugadorDTO>();
            this.listaTopJugadorDTO = new List<JugadorTopDTO>();

            this.estadistica.EnlazarJugadorBindigSource(jugadorBindingSource);
            this.estadistica.EnlazarPartidaBindigSource(partidaBindingSource);
            this.estadistica.EnlazarTopBindigSource(jugadorTop15BindingSource);

            this.estadistica.EventoClickComboBox += CapturaEventoClickComboBox;

            this.CargarPartida();
            this.CargarJugadorTop15();
        }

        #region Metodos 
        /// <summary>
        /// Carga las partidas registradas de la DB
        /// Se enlaza con el binding source para actualizarse
        /// </summary>
        public void CargarPartida()
        {
            this.listaPartida = this.repositorio.obtenerTodo();
            this.partidaBindingSource.DataSource = this.listaPartida;
        }
        /// <summary>
        /// Carga los jugadores de la partida
        /// actualiza y se enlaza con el binding source 
        /// </summary>
        public void CargarJugador()
        {
            Partida partidaSeleccionada = (Partida)this.partidaBindingSource.Current;

            foreach (Jugador aux in partidaSeleccionada.Jugadores)
            {
                this.listaJugadorDTO.Add(JugadorDTO.MapperEntidad(aux));
            }
            this.jugadorBindingSource.DataSource = this.listaJugadorDTO;
        }

        /// <summary>
        /// Carga el top 15 y actualiza el data grid con 
        /// binding source asociado
        /// </summary>
        public void CargarJugadorTop15()
        {
            List<Jugador> lista = new PartidaRepositorio().ConsultarPorPartidasGanadas_Top();

            foreach (Jugador aux in lista)
            {
                this.listaTopJugadorDTO.Add(JugadorTopDTO.MapperEntidad(aux));
            }

            this.jugadorTop15BindingSource.DataSource = this.listaTopJugadorDTO;
        }

        #endregion

        #region Captura de eventos

        /// <summary>
        /// Evento cuando se cambia o se selecciona un index 
        /// en el combo box
        /// Llamamos al metodo cargar jugador
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void CapturaEventoClickComboBox(Object? obj, EventArgs e)
        {
            CargarJugador();
        }
        #endregion

    }
}
