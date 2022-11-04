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

        public SalaUno(int rondas, IJuegoDeCarta<CartaUno> juego) : base(rondas, juego)
        {
            this.CargarPartida();
        }


        public void CargarPartida()
        {
            this.juego.LlenarMazo();
            this.juego.MezclarMazo();
        }

        public List<CartaUno> DarCartaJugador()
        {
            return this.juego.BarajarCartas();
        }

        public bool tirarCarta()
        {

        }

    }
}
