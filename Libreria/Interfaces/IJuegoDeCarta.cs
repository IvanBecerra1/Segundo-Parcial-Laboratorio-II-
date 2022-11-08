using Libreria.Entidades;
using Libreria.Enumeraciones;
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
        public List<T> LlenarMazo();

        /// <summary>
        /// Barajar cartas es darle cartas a cada jugador.
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<T> BarajarCartas();

        /// <summary>
        /// Permite dar una carta,
        /// que esta en el mazo
        /// si no hay mas cartas devuelve nulo
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public T SiguienteCarta();

        /// <summary>
        /// Muestra las cartas disponibles en la Mesa.
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public List<T> CartasDisponibles();

        /// <summary>
        /// Agrega las cartas en mesa que el jugador selecciono
        /// </summary>
        /// <param name="carta"></param>
        public bool AgregarCartasAlMeson(T carta);

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
        public List<T> MezclarMazo();


        /// <summary>
        /// Devuelve la carta que este en Mesa.
        /// </summary>
        /// <returns></returns>
        public T MostrarCartaMesa();

        /// <summary>
        /// Funcion donde se verifica si la carta que esta
        /// puesta en mesa es una especial
        /// </summary>
        /// <returns>Devolvera la lista modificada</returns>
        public List<T> VerificarCartasEspeciales(out ETipoCarta accion);

        /// <summary>
        /// Pone una carta en mesa
        /// </summary>
        public void PonerCartaAlMeson();
    }
}
