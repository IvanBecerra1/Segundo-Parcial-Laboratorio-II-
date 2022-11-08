using Libreria.Entidades;
using Libreria.Enumeraciones;
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

        public List<CartaUno> CartaMazo()
        {
            return this.juego.CartasMazo;
        }
        public CartaUno MostrarCartaMesa()
        {
            return this.juego.MostrarCartaMesa();
        }

        public List<CartaUno> VerificarCartasEspeciales(out ETipoCarta accion)
        {
            accion = ETipoCarta.NONE;
            return this.juego.VerificarCartasEspeciales(out accion);
        }

        public List<CartaUno> DevolverDosCartas()
        {
            List<CartaUno> cartas = new List<CartaUno>();

            for (int i = 0;i < 2; i++)
            {
                cartas.Add(this.juego.SiguienteCarta());
            }

            return cartas;
        }

    }
}
