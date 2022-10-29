using System;
using System.Runtime.InteropServices;
using Libreria.Entidades;
using Libreria.Servicios;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            EscobaQuinceServicio escoba = new EscobaQuinceServicio();

            Sala sala = new SalaCartas(3, escoba, escoba);

            ////
            sala.IniciarJuego();


            /*
            
            /// 
            sala.CargarJugadores();

             
             */
            
        }
    }
}
