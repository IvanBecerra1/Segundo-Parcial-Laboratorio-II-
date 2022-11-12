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
    /// <summary>
    /// Sala solo para el juego UNO
    /// </summary>
    public class SalaUno : Sala
    {
        public SalaUno(IJuegoDeCarta<CartaUno> juego) : base(juego)
        {
            this.CargarPartida();
        }

        /// <summary>
        /// Carga datos principales del juego
        /// </summary>
        public void CargarPartida()
        {
            this.juego.LlenarMazo();
            this.juego.MezclarMazo();
            this.juego.PonerCartaAlMeson();
        }

        /// <summary>
        /// Metodo para dar cartas a los jugadores
        /// </summary>
        /// <returns>Lista de cartas devuelta por el metodo baraja Cartas</returns>
        public List<CartaUno> DarCartaJugador()
        {
            return this.juego.BarajarCartas();
        }

        /// <summary>
        /// Devuelve una carta del Mazo
        /// </summary>
        /// <returns></returns>
        public CartaUno AgarrarCarta()
        {
            return this.juego.SiguienteCarta();
        }

        /// <summary>
        /// Deposita una carta en mesa
        /// </summary>
        /// <param name="carta">Carta que se va a enviar</param>
        /// <returns>Si se pudo o no ingresar la carta</returns>
        public bool DepositarCarta(CartaUno carta)
        {
            return this.juego.AgregarCartasAlMeson(carta);
        }

        /// <summary>
        /// Conexion entre la propiedad de cartaMazo
        /// </summary>
        /// <returns></returns>
        public List<CartaUno> CartaMazo()
        {
            return this.juego.CartasMazo;
        }

        /// <summary>
        /// Muestra la carta que esta sobre la mesa
        /// </summary>
        /// <returns>Devuelve la carta</returns>
        public CartaUno MostrarCartaMesa()
        {
            return this.juego.MostrarCartaMesa();
        }

        /// <summary>
        /// Verifica la carta especial, particularmente
        /// el roba dos y roba cuatro
        /// </summary>
        /// <param name="accion"></param>
        /// <returns>Una lista de cartas que se le añadira al jugador</returns>
        public List<CartaUno> VerificarCartasEspeciales(out ETipoCarta accion)
        {
            accion = ETipoCarta.NONE;
            return this.juego.VerificarCartasEspeciales(out accion);
        }

        /// <summary>
        /// Devuelve dos cartas del mazo
        /// </summary>
        /// <returns></returns>
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
