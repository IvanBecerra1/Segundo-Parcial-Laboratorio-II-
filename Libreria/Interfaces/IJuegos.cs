using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Interfaces
{
    /// <summary>
    /// Aplico todos los metodos porque si quiero agregar
    /// otro juego, ejemplo el Uno, puedo utilizar estos Metodos para ese tipo de juego
    /// 
    /// </summary>
    public interface IJuegos
    {

        public List<Carta> LlenarMazo(List<Carta> listaCartas);

        /// <summary>
        /// Barajar cartas es darle cartas a cada jugador.
        /// en este caso seria solo 3 Cartas por jugador
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Carta> BarajarCartas(List<Carta> listaCartas);

        /// <summary>
        /// Permite dar una carta,
        /// que esta en la baraja
        /// si no hay mas cartas devuelve nulo
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public Carta SiguienteCarta(List<Carta> listaCartas);

        /// <summary>
        /// Muestra las cartas disponibles en la Mesa.
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public List<Carta> CartasDisponibles(List<Carta> listaCartas);

        /// <summary>
        /// Agrega las cartas en mesa con los que se va a jugar
        /// 
        /// </summary>
        /// <param name="carta"></param>
        public void AgregarCartasAlMeson(Carta carta);

        /// <summary>
        /// Metodo que servira para comparar si las cartas
        /// seleccionadas lograron llegar al numero 15
        /// </summary>
        /// <param name="cartasSeleccionada"></param>
        /// <returns></returns>
        public bool CompararCartas(List<Carta> cartasSeleccionada);

        /// <summary>
        /// Metodo que servira para mezclar las cartas que
        /// se encuentren en el mazo
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public List<Carta> MezclarMazo(List<Carta> listaCartas);

    }
}
