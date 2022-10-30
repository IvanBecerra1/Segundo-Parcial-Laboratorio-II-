using Libreria.Entidades;
using Libreria.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Servicios
{
    public class EscobaQuinceServicio : IJuegos, IEscobaQuince
    {
        private JuegoCartas juego;

        public List<Carta> CartasMazo { 
            get => new List<Carta>(this.juego.MazoDeCartas); 
        }
        public List<Carta> CartasMesa { get => this.juego.MesaDeCartas; }

        public EscobaQuinceServicio()
        {
            this.juego = new JuegoCartas();
        }


        /// <summary>
        /// Barajar cartas
        /// Carga 3 cartas para cada jugador
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns>Devuelve las cartas cargadas</returns>
        public List<Carta> BarajarCartas(List<Carta> listaCartas)
        {
            if (!this.juego.MazoDeCartas.Any())
            {
                return null;
            }
            List<Carta> cartasDevueltas = new List<Carta>();

            do
            {
                cartasDevueltas.Add(SiguienteCarta(listaCartas));
            } while (cartasDevueltas.Count <= 2);

            return cartasDevueltas;
        }


        /// <summary>
        /// Esta funcion sirvira para cuando
        /// tengamos que repartir cartas a los jugadores
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        public Carta SiguienteCarta(List<Carta> listaCartas)
        {
            if (this.juego.MazoDeCartas == null || !this.juego.MazoDeCartas.Any())
            {
                return null;
            }

            return this.juego.MazoDeCartas.Pop();
        }

        /// <summary>
        /// Muestra las cartas que estan sobre la Mesa.
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns>Devuelve la lista de cartas que se encuentran en mesa</returns>
        public List<Carta> CartasDisponibles(List<Carta> listaCartas)
        {
            if (this.juego.MazoDeCartas == null || this.juego.MazoDeCartas.Any() == false)
            {
                return null;
            }
            foreach (var aux in this.juego.MesaDeCartas)
            {
                Console.WriteLine(aux.ToString());
            }
            return this.juego.MesaDeCartas;
        }

        /// <summary>
        /// Llena al mazo de cartas 
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns>Devuelve las cartas del mazo llenos.</returns>
        public List<Carta> LlenarMazo(List<Carta> listaCartas)
        {
            if (this.juego.MazoDeCartas == null)
            {
                return null;
            }
            for (int i = 0; i < 10; i++)
            {
                this.juego.MazoDeCartas.Push(new Carta(Enumeraciones.EPalos.ESPADA, i + 1));

                this.juego.MazoDeCartas.Push(new Carta(Enumeraciones.EPalos.BASTON, i + 1));

                this.juego.MazoDeCartas.Push(new Carta(Enumeraciones.EPalos.COPA, i + 1));

                this.juego.MazoDeCartas.Push(new Carta(Enumeraciones.EPalos.ORO, i + 1));
            }

            return new List<Carta>(this.juego.MazoDeCartas);
        }

        /// <summary>
        /// Agrega cartas al Meson 
        /// solo podra ser un maximo de 4 cartas
        /// </summary>
        /// <param name="carta"></param>
        public void AgregarCartasAlMeson(Carta carta)
        {
            // Solo es permitido 4 cartas en la mesa
            if (this.juego.MesaDeCartas.Count >= 3)
            {
                return;
            }

            do
            {
                this.juego.MesaDeCartas.Add(this.juego.MazoDeCartas.Pop());
            } while (this.juego.MesaDeCartas.Count <= 3);
        }

        /// <summary>
        /// Funcion donde verificara si las cartas lograron 
        /// llegar al numero 15
        /// </summary>
        /// <param name="cartasSeleccionada"></param>
        /// <returns>Devuelve verdadero si llegaron a juntar 15 o falso si no.</returns>
        public bool CompararCartas(List<Carta> cartasSeleccionada)
        {
            int llegoQuince = 0;

            Console.WriteLine("----COMPARANDO CARTAS---");
            foreach (var aux in cartasSeleccionada)
            {
                Console.WriteLine(aux.ToString());
                llegoQuince += aux.NumeroPalo;
            }

            return llegoQuince == 15 ? true : false;
        }

        /// <summary>
        /// Elimina las cartas que coincidieron
        /// </summary>
        /// <param name="cartasSeleccionada"></param>
        /// <returns></returns>
        public bool SacarCartaDelMeson(List<Carta> cartasSeleccionada)
        {
            
            foreach (var aux in cartasSeleccionada)
            {
                this.CartasMesa.Remove(aux);
            }

            return true;
        }
        /// <summary>
        /// Mezcla el mazo de cartas
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns>Devuelve el mazo de cartas mezclado.</returns>
        public List<Carta> MezclarMazo(List<Carta> listaCartas)
        {
            var random = new Random();
            List<Carta> auxList = new List<Carta>(this.juego.MazoDeCartas);
            List<Carta> test2 = new List<Carta>(auxList.OrderBy(item => random.Next()));

            this.juego.MazoDeCartas = new Stack<Carta>(test2);
            return this.CartasMazo;
        }
    }
}
