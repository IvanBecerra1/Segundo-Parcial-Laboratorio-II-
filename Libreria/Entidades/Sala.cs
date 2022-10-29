using Libreria.Interfaces;
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
        protected IJuegos juego;

        public Sala(int rondas, IJuegos juego)
        {
            this.listaJugadores = new List<Jugador>();
            this.rondas = rondas;
            this.juego = juego;
        }

        public int Rondas { get => rondas; set => rondas = value; }

        public abstract void IniciarJuego();
        public abstract bool TurnoJugador(Jugador aux);

        public void CargarJugadores(int maxJugadores)
        {
            // jugadores maximo por el momento solo 2
            if (this.listaJugadores.Count == maxJugadores)
            {
                return;
            }

            Console.WriteLine("/// JUGADORES PEPE Y RAMIREZ");
            Jugador jugador1 = new Jugador("pepe");
            Jugador jugador2 = new Jugador("ramirez");

            Console.WriteLine("/// REPARTIENDO CARTAS A CADA JUGADOR");

            jugador1.Cartas = this.juego.BarajarCartas(null);
            jugador2.Cartas = this.juego.BarajarCartas(null);

            Console.WriteLine("/// CARTAS JUADOR 1");
            jugador1.Cartas.ForEach(aux =>
            {
                Console.WriteLine(aux.ToString());
            });

            Console.WriteLine("/// CARTAS JUADOR 2");
            jugador2.Cartas.ForEach(aux =>
            {
                Console.WriteLine(aux.ToString());
            });

            this.listaJugadores.Add(jugador2);
            this.listaJugadores.Add(jugador1);
        }

    }
}
