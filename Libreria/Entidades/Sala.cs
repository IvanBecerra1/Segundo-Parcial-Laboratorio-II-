using Libreria.Interfaces;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    /// <summary>
    /// Se implementara los distintos juegos que se desarrollen.
    /// Abstracto para no alterar el comportamiento de la clase
    /// Principio solid: Abierto / Cerrado
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Sala 
    {
        protected int rondas;
        protected List<Jugador> listaJugadores;


        //  private JuegoEscoba juego; // T => EscobaQuince u otro;
        /// <summary>
        /// Ahora La clase sala podra ser cualquier tipo de juego que implemente IJuegos
        /// </summary>
        protected IJuegoDeCarta<CartaUno> juego;

        public Sala(int rondas, IJuegoDeCarta<CartaUno> juego)
        {
            this.listaJugadores = new List<Jugador>();
            this.rondas = rondas;
            this.juego = juego;
        }

    }
}
