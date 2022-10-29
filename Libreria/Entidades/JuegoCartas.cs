using Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class JuegoCartas
    {

        /// <summary>
        /// Lista del mazo de cartas
        /// Solo debe haber 40 cartas
        /// y seran repartidas a los jugadores 3
        /// y debe haber 4 cartas en mesa
        /// </summary>
        private Stack<Carta> mazoDeCartas;

        /// <summary>
        /// Solo van a haber 4 cartas en mesa
        /// </summary>
        private List<Carta> mesaDeCartas;

        /// <summary>
        /// Estaditicas historicas de el juego
        /// </summary>
        private Estadisticas estadisticas;

        public Estadisticas Estadisticas { get => estadisticas; set => estadisticas = value; }
        public List<Carta> MesaDeCartas { get => mesaDeCartas; set => mesaDeCartas = value; }
        public Stack<Carta> MazoDeCartas { get => mazoDeCartas; set => mazoDeCartas = value; }

        public JuegoCartas()
        {
            this.mazoDeCartas = new Stack<Carta>();
            this.mesaDeCartas = new List<Carta>();
            this.estadisticas = new Estadisticas();
        }

    }
}
