using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Libreria.Entidades;
using Libreria.Enumeraciones;
using Modelo.Entidades;
using Modelo.Servicios;

namespace ConsoleApp1
{

    public class test
    {
        public int Valor { get; set; }
    }
    public class Program
    {
        private delegate bool VerificarCarta(CartaUno carta, CartaUno carta2);

 
        public static bool carta(CartaUno carta, CartaUno  carta2)
        {
            return true;
        }
        static void Main(string[] args)
        {
            VerificarTareas();
            Console.ReadLine();
            //  Console.WriteLine( test(0, out tipoDevuelto)  + " tipo: " + tipoDevuelto);
            #region 
            /*

           VerificarCarta verificar;
           verificar = new VerificarCarta(verificarNumeroCarta);
       //   verificar += verificarNumeroCarta;


           CartaUno carta = new CartaUno(Libreria.Enumeraciones.ETipoCarta.NONE, 10, Modelo.Enumeraciones.ETipoColor.VERDE);
           CartaUno carta2 = new CartaUno(Libreria.Enumeraciones.ETipoCarta.NONE, 12, Modelo.Enumeraciones.ETipoColor.VERDE);

           Console.WriteLine(verificar(carta, carta2));

           Console.ReadLine();

            */
            #endregion

        }
        static void VerificarTareas()
        {
            var tarea1 = Task.Run(() =>
            {
                verificarCarta();
            });

            Task.WaitAll(tarea1);
            
            var tarea3 = Task.Run(() =>
            {
                CambiarRonda();
            });


        }
        static void verificarCarta()
        {
            Console.WriteLine("Posibilidad de cantar Uno .....");
            Thread.Sleep(5000);
        }

        static void CambiarRonda()
        {
            Console.WriteLine("Se cambio la ronda al siguiente jugador .....");
        }

        public static bool test(int i, out string tipo)
        {

            UnoServicio unoServicio = new UnoServicio();


            VerificarCarta test = new VerificarCarta(carta);

            List<Jugador> listajugadores = new List<Jugador>
            {
                new Jugador("ivan"),
                new Jugador("pepe"),
            };

            int turno = 0;


            /// iniciar variables:
            /// 
            unoServicio.LlenarMazo();
            unoServicio.MezclarMazo();
            unoServicio.PonerCartaAlMeson();

            List<CartaUno> listaCartaMazo = unoServicio.CartasMazo;
            List<CartaUno> listaCartaMesa = unoServicio.CartasMesa;


            foreach (var aux in listajugadores)
            {
                aux.Cartas = unoServicio.BarajarCartas();
                Console.WriteLine($"{aux.Nombre}- cartas del jugador----");

                foreach (var aux2 in aux.Cartas)
                {
                    Console.WriteLine($"{aux2.ToString()} ");
                }
            }


            listaCartaMazo = unoServicio.CartasMazo;
            listaCartaMesa = unoServicio.CartasMesa;

            string option = "";
            do
            {

                foreach (var aux in listajugadores)
                {

                    Console.WriteLine("CARTA EN MESA");
               

                    Console.WriteLine("----Turno jugador: " + aux.Nombre);

                    Console.WriteLine("Carta en mesa: ");


                    Console.WriteLine("1. Tirar carta");
                    Console.WriteLine("2. Recojer carta");
                    Console.WriteLine("3. Pasar turno");

                    option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":

                            Console.WriteLine("Cartas disponible");
                            aux.Cartas.ForEach(aux =>
                            {
                                Console.WriteLine(aux);
                            });

                            int id = int.Parse(Console.ReadLine());

                            // si no se pudo agregar
                            if (unoServicio.AgregarCartasAlMeson(seleccionarCarta(id, aux.Cartas)) == false)
                            {
                                /// Podria implementar un bucle pero es solo testeo.
                                Console.WriteLine("No se pudo agregar la carta, pierdes el turno");

                            }
                            else
                            {
                                aux.Cartas.Remove(seleccionarCarta(id, aux.Cartas));
                                Console.WriteLine("Se agrego tu carta al meson, y se borro la carta tirada.");
                            }
                            // Si se pudo agregar solo le removemos la carta.


                            // Restar cartas.

                            break;
                        case "2":

                            aux.Cartas.Add(unoServicio.SiguienteCarta());

                            Console.WriteLine("tus nuevas cartas");
                            aux.Cartas.ForEach(aux =>
                            {
                                Console.WriteLine(aux);
                            });

                            break;

                        case "3":

                            aux.Cartas.Add(unoServicio.SiguienteCarta());

                            /// Podria implementar un metodo que no termine o pase el turno hasta que seleccione una carta.
                            /// 
                            Console.WriteLine("Para pasar es necesario que agarres una carta");
                            aux.Cartas.ForEach(aux =>
                            {
                                Console.WriteLine(aux);
                            });
                            break;
                    }
                }
            } while (++turno != 3);




            string tipoDevuelto = "";


            bool isvalid = false;
            tipo = "";

            if (i == 1)
            {
                tipo = "te comiste 4";

            }

            if (i == 2)
            {
                tipo = "perdiste tu turno";

            }

            if (i == 2)
            {
                tipo = "se cambia inverte la ronda";

            }

            if (i == 3)
            {
                tipo = "se cambia los colores de carta";
            }

            return isvalid;
        }
        public static CartaUno seleccionarCarta(int id, List<CartaUno> lista)
        {

            return lista.Find(aux => aux.Id == id);

        }

        private static bool verificarNumeroCarta(CartaUno carta, CartaUno carta2)
        {
            return ((carta.Color == carta2.Color) || (carta.NumeroPalo == carta2.NumeroPalo));
        }

        private static bool verificarColorCarta(CartaUno carta, CartaUno carta2)
        {
            return (carta.NumeroPalo == carta2.NumeroPalo);
        }

    }
}
