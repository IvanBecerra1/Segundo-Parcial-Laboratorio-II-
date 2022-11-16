using Libreria.Entidades;
using Modelo.Archivos;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2.models.Interfaz
{
    public interface IJuego
    {
        public event EventHandler TirarCarta;
        public event EventHandler RecojerCarta;
        public event EventHandler PasarTurno;
        public event EventHandler abandonar;
        public event EventHandler CantarUno;
        public event EventHandler BotonMostrarCarta;

        void cartasJugadorBindingSource(BindingSource cartasJugador);
        void jugadoresDataSource(List<Jugador> jugadores);

        public int Rondas
        {
            get;
            set;
        }

        public List<CartaUno> ListaCartasJugador
        {
            get;
            set;
        }

        public CartaUno CartaMesa
        {
            get;
            set;
        }

        public List<CartaUno> ListaCartaMazo
        {
            get;
            set;
        }

        public List<Jugador> ListaJugadores
        {
            get;
            set;
        }

        public String Notificacion
        {
            get;
            set;
        }

        public bool TerminoRonda
        {
            set;
        }

        public bool MostrarCartasJugador
        {
            set;
        }

        public ArchivosLogs Archivos
        {
            set;
        }

        public string textTurnoJugador
        {
            set;
        }
    }
}
