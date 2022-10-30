using Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class SalaCartas : Sala
    {
        private IEscobaQuince escobaQuince;

        public SalaCartas(int rondas, IJuegos juegos, IEscobaQuince escobaQuince) : base(rondas, juegos)
        {
            this.escobaQuince = escobaQuince;
        }

        public List<Carta> cartasEnElMesaTest()
        {
            return this.escobaQuince.CartasMesa;
        }

        public override void IniciarJuego()
        {
            // llena el mazo
            this.juego.LlenarMazo(null);
            this.juego.AgregarCartasAlMeson(null);
            this.juego.MezclarMazo(null);
         //   this.CargarJugadores(1);

       /**     Console.WriteLine("---------- Cargando partida ------------");
            do
            {

                Console.WriteLine("**** RONDA: "+ this.Rondas);
                foreach (var aux in this.listaJugadores)
                {
                    this.TurnoJugador(aux);
                }
                this.rondas--;
            } while (this.rondas != 0);
       */
        }

        public override bool TurnoJugador(Jugador aux)
        {
           

            int opt = 0;
            do
            {
                Console.WriteLine("**********[ TURNO JUGADOR:  " + aux.Nombre + " ] **********");
                MostrarCartasJugador(aux);

                Console.WriteLine("..........OPCIONES........");
                Console.WriteLine("1. Seleccionar mis cartas");
                Console.WriteLine("2. Ver mis cartas de mi bodega");
                Console.WriteLine("3. Pasar mi turno");

                Console.WriteLine("Opcion: ");
                opt = int.Parse(Console.ReadLine());

                switch (opt)
                {
                    case 2:
                        aux.CartasEnBodega.ForEach(delegate (Carta aux)
                        {
                            Console.WriteLine(aux.ToString());
                        });
                        break;
                    case 3:
                        return true;
                }

            } while (opt != 3);
            Console.WriteLine("----------Finalizo Tu turno---------");

            return true;
        }

        /// <summary>
        /// Muestra las cartas del jugador en particular.
        /// </summary>
        /// <param name="jugador"></param>
        /// <returns></returns>
        public List<Carta> MostrarCartasJugador(Jugador jugador)
        {
            Jugador jugadorAux = base.listaJugadores.Find(aux => aux == jugador);

            Console.WriteLine("=====TUS CARTAS SON:  ========");
            foreach (var cartasJugador in jugadorAux.Cartas)
            {
                Console.WriteLine(cartasJugador.ToString());
            }

            return jugadorAux.Cartas;
        }

        /// <summary>
        /// Permite seleccionar mis cartas.
        /// </summary>
        /// <param name="aux"></param>
        /// <returns></returns>
        public List<Carta> SeleccionarMisCartas(Jugador aux)
        {
            Console.WriteLine("--------- Seleccionando TUS Cartas----- ");

            HashSet<Carta> cartasSeleccionada = new HashSet<Carta>();
            MostrarCartasJugador(aux);
            do
            {
                Console.WriteLine("Selecciona el id de tus carta: ");
                int id = int.Parse(Console.ReadLine());

                cartasSeleccionada.Add(aux.Cartas.Find(aux => aux.Id == id));
                Console.WriteLine("Seleccionar otro? si = 1 | no = 0: ");

            } while (int.Parse(Console.ReadLine()) == 1);

            return new List<Carta>(cartasSeleccionada);

        }

        /// <summary>
        /// Permite seleccionar cartas de la mesa
        /// </summary>
        /// <returns></returns>
        public List<Carta> seleccionarCartasMesa()
        {

            List<Carta> cartasSeleccionadaMesa = new List<Carta>();

            base.juego.CartasDisponibles(null);
            Console.WriteLine("--------- Seleccionando CARTAS DEL MAZO----- ");

            do
            {
                Console.WriteLine("Selecciona el id de las cartas de mesa: ");
                int id = int.Parse(Console.ReadLine());

                cartasSeleccionadaMesa.Add(this.escobaQuince.CartasMesa.Find(aux => aux.Id == id));
                Console.WriteLine("Seleccionar otro? si = 1 | no = 0: ");

            } while (int.Parse(Console.ReadLine()) == 1);

            return cartasSeleccionadaMesa;
        }

        /// <summary>
        /// Verifica si las cartas llegaron a sumar 15
        /// </summary>
        /// <param name="cartasSeleccionada"></param>
        /// <param name="jugador"></param>
        /// <returns>Devuelve true si se llego a 15, o falso en caso contrario</returns>
        public bool VerificarCartas(List<Carta> cartasSeleccionada, out Jugador jugador)
        {
            jugador = new Jugador(); 

            bool isQuince = base.juego.CompararCartas(cartasSeleccionada);

            // Podria sumar puntos
            if (isQuince == true)
            {
                Console.WriteLine("Tus cartas sumaron quince");
                jugador.CartasEnBodega.AddRange(cartasSeleccionada.ToArray());
            }
            else
            {
                Console.WriteLine("Tus cartas no sumaron quince");
            }

            return isQuince;
        }
    }
}
