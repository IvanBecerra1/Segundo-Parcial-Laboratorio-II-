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

        public SalaUno(int rondas, IJuegoDeCarta<Carta> juego) : base(rondas, juego)
        {

            this.juego.LlenarMazo(null);
            this.juego.MezclarMazo(null);
            this.juego.BarajarCartas(null);

        }

        public List<CartaUno> tirarCarta()
        {

            return null;
        }

    }
}
