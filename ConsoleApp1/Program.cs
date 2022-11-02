using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Libreria.Entidades;
using Libreria.Servicios;
using Modelo.Entidades;
using Modelo.Servicios;

namespace ConsoleApp1
{
    public class Program
    {
        private delegate bool VerificarCarta(CartaUno carta, CartaUno carta2);
      

        static void Main(string[] args)
        {
            UnoServicio unoServicio = new UnoServicio();


            List<Jugador> listajugadores = new List<Jugador>
            {
                new Jugador("ivan"),
                new Jugador("pepe"),
            };

            int turno  = 0;


            /// iniciar variables:
            /// 
            unoServicio.LlenarMazo(null);
            unoServicio.MezclarMazo(null);
            unoServicio.PonerCartaAlMeson();

            List<CartaUno> listaCartaMazo = unoServicio.CartasMazo;
            List<CartaUno> listaCartaMesa = unoServicio.CartasMesa;


            foreach (var aux in listajugadores)
            {
                aux.Cartas = unoServicio.BarajarCartas(null);
                Console.WriteLine($"{aux.Nombre}- cartas del jugador----");

                foreach (var aux2 in aux.Cartas)
                {
                    Console.WriteLine($"{aux2.ToString()} ");
                }
            }


            listaCartaMazo = unoServicio.CartasMazo;
            listaCartaMesa = unoServicio.CartasMesa;

            do
            {

                foreach (var aux in listajugadores)
                {

                    Console.WriteLine("----Turno jugador: " + aux.Nombre);

                    Console.WriteLine("Carta en mesa: ");
                    
                    
                    Console.WriteLine("1. Tirar carta");
                    Console.WriteLine("1. Recojer carta");

                }



            } while (++turno != 3);




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
