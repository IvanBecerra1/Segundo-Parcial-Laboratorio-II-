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
    public interface IJuegoDeCarta<T>
    {
        public List<T> CartasMazo { get; }
        public List<T> CartasMesa { get; }


        /// <summary>
        /// Llena el mazo de cartas
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public List<T> LlenarMazo(List<T> listaCartas);

        /// <summary>
        /// Barajar cartas es darle cartas a cada jugador.
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<T> BarajarCartas(List<T> listaCartas);

        /// <summary>
        /// Permite dar una carta,
        /// que esta en el mazo
        /// si no hay mas cartas devuelve nulo
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public T SiguienteCarta(List<T> listaCartas);

        /// <summary>
        /// Muestra las cartas disponibles en la Mesa.
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public List<T> CartasDisponibles(List<T> listaCartas);

        /// <summary>
        /// Agrega las cartas en mesa con los que se va a jugar
        /// </summary>
        /// <param name="carta"></param>
        public void AgregarCartasAlMeson(T carta);

        /// <summary>
        /// Metodo que servira para comparar las cartas
        /// dependiendo al juego que se lo aplique
        /// </summary>
        /// <param name="cartasSeleccionada"></param>
        /// <returns>Devuelve true si la regla del juego lo permite o falso si no</returns>
        public bool CompararCartas(List<T> cartasSeleccionada);

        /// <summary>
        /// Metodo que servira para mezclar las cartas que
        /// se encuentren en el mazo
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public List<T> MezclarMazo(List<T> listaCartas);

    }
}
