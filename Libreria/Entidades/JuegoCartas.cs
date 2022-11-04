using Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class JuegoCartas<T>
    {

        /// <summary>
        /// Lista del mazo de cartas
        /// total
        /// </summary>
        private Stack<T> mazoDeCartas;

        /// <summary>
        /// Lista de las cantidad de cartas puestas en mesa
        /// </summary>
        private Stack<T> mesaDeCartas;

        public Stack<T> MesaDeCartas { get => mesaDeCartas; set => mesaDeCartas = value; }
        public Stack<T> MazoDeCartas { get => mazoDeCartas; set => mazoDeCartas = value; }

        public JuegoCartas()
        {
            this.mazoDeCartas = new Stack<T>();
            this.mesaDeCartas = new Stack<T>();
        }

    }
}
