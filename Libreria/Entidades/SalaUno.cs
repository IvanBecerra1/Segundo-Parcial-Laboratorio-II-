using Libreria.Entidades;
using Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class SalaUno : Sala
    {
        public List<Jugador> listaJugador;
        public Jugador turnoJugador;

        public SalaUno(IJuegoDeCarta<CartaUno> juego) : base(juego)
        {
            this.CargarPartida();
        }


        public void CargarPartida()
        {
            this.juego.LlenarMazo();
            this.juego.MezclarMazo();
            this.juego.PonerCartaAlMeson();
        }

        public List<CartaUno> DarCartaJugador()
        {
            return this.juego.BarajarCartas();
        }

        public CartaUno AgarrarCarta()
        {
            return this.juego.SiguienteCarta();
        }

        public bool DepositarCarta(CartaUno carta)
        {
            return this.juego.AgregarCartasAlMeson(carta);
        }
    }
}
