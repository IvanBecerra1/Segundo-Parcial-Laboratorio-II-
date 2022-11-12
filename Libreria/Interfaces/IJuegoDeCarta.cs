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
    /// Interfaz que tendra las funcionalidades
    /// comunes en la especialidad de juego de cartas
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
        /// Barajar cartas, es darle cartas a cada jugador.
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
        /// Agrega las cartas en mesa que el jugador selecciono
        /// </summary>
        /// <param name="carta"></param>
        public bool AgregarCartasAlMeson(T carta);

        /// <summary>
        /// Metodo que servira para mezclar las cartas que
        /// se encuentren en el mazo
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public List<T> MezclarMazo();


        /// <summary>
        /// Muestra la carta que este en Mesa.
        /// </summary>
        /// <returns>Carta que este</returns>
        public T MostrarCartaMesa();

        /// <summary>
        /// Funcion donde se verifica si la carta que esta
        /// puesta en mesa es una especial
        /// </summary>
        /// <returns>Devolvera la lista modificada</returns>
        public List<T> VerificarCartasEspeciales(out ETipoCarta accion);

        /// <summary>
        /// Pone una carta del mezo al meson
        /// </summary>
        public void PonerCartaAlMeson();
    }
}
