using Libreria.Entidades;
using Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Libreria.Enumeraciones;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using Modelo.Entidades;
using Modelo.Enumeraciones;
using System.ComponentModel;

namespace Modelo.Servicios
{
    /// <summary>
    /// Funciones del juego el Uno
    /// </summary>
    public class UnoServicio : IJuegoDeCarta<CartaUno>
    {
        public JuegoCartas<CartaUno> juego = new JuegoCartas<CartaUno>();

        private delegate bool VerificarCarta(CartaUno carta, CartaUno carta2);
        private VerificarCarta verificar;

        private delegate bool VerificarCartaEspeciales(CartaUno carta);
        private VerificarCartaEspeciales verificarEspeciales;

        public UnoServicio()
        {
            this.verificar = new VerificarCarta(verificarCarta);

        }

        private bool verificarCarta(CartaUno carta, CartaUno carta2)
        {
            return (carta.Color == carta2.Color) || (carta.NumeroPalo == carta2.NumeroPalo);
        }

        public List<CartaUno> CartasMazo
        {
            get => new List<CartaUno>(this.juego.MazoDeCartas);
        }
        public List<CartaUno> CartasMesa { get => new List<CartaUno>(this.juego.MazoDeCartas); }

        /// <summary>
        /// Funcion que cumple para agregar cartas 
        /// </summary>
        /// <param name="carta">Carta a enviar</param>
        /// <returns>Devuelve true o false si se pudo agregar la carta</returns>
        public bool AgregarCartasAlMeson(CartaUno carta)
        {
            if (this.verificar(this.juego.MesaDeCartas.Peek(), carta) == false)
            {
                return false;
            }

            this.juego.MesaDeCartas.Push(carta);
            return true;
        }

        public void PonerCartaAlMeson()
        {
            this.juego.MesaDeCartas.Push(this.SiguienteCarta());
        }

        public List<CartaUno> BarajarCartas()
        {
            if (!this.juego.MazoDeCartas.Any())
            {
                return null;
            }
            List<CartaUno> cartasDevueltas = new List<CartaUno>();

            do
            {
                cartasDevueltas.Add(SiguienteCarta());
            } while (cartasDevueltas.Count <= 6);

            return cartasDevueltas;
        }

        /// <summary>
        /// Cartas disponibles del jugador. si tiene 0 es el ganador
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<CartaUno> CartasDisponibles()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Cambiar de tipo list a carta seleccionada
        /// </summary>
        /// <param name="cartasSeleccionada"></param>
        /// <returns></returns>
        public bool CompararCartas(List<CartaUno> cartasSeleccionada)
        {

            Stack<CartaUno> cartasStack = new Stack <CartaUno> (this.juego.MesaDeCartas);
            CartaUno cartaMesonUltima = cartasStack.Peek();

            return verificar(cartaMesonUltima, cartasSeleccionada[0]);
          
        }

        public List<CartaUno> LlenarMazo()
        {
            if (this.juego.MazoDeCartas == null)
            {
                return null;
            }
          
            // cartas comunes
            for (int i = 0; i < 9; i++)
            {
                if (i == 0)
                {
                    this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.NONE, i, ETipoColor.ROJO));
                    this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.NONE, i, ETipoColor.VERDE));
                    this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.NONE, i, ETipoColor.AZUL));
                    this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.NONE, i, ETipoColor.AMARILLO));
                }

                this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.NONE, i + 1, ETipoColor.ROJO));
                this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.NONE, i + 1, ETipoColor.VERDE));
                this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.NONE, i + 1, ETipoColor.AZUL));
                this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.NONE, i + 1, ETipoColor.AMARILLO));
            }
            /*

            ROBA_DOS,
              ROBA_CUATRO,
              INVERTIR_RONDA,
              CAMBIAR_COLOR,
              SALTEAR_JUGADOR
           */
            // cartas especiales
            for (int i = 0; i <= 3; i++)
            {
                if (i <= 1)
                {
                    this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.ROBA_DOS, i + 1, ETipoColor.ROJO));
                    this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.INVERTIR_RONDA, i + 1, ETipoColor.VERDE));
                    this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.SALTEAR_JUGADOR, i + 1, ETipoColor.AZUL));
                }

                this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.CAMBIAR_COLOR, i + 1, ETipoColor.ROJO));
                this.juego.MazoDeCartas.Push(new CartaUno(ETipoCarta.ROBA_CUATRO, i + 1, ETipoColor.VERDE));
            }


            return new List<CartaUno>(this.juego.MazoDeCartas);
        }

        public List<CartaUno> MezclarMazo()
        {
            var random = new Random();
            List<CartaUno> auxList = new List<CartaUno>(this.juego.MazoDeCartas);
            List<CartaUno> test2 = new List<CartaUno>(auxList.OrderBy(item => random.Next()));

            this.juego.MazoDeCartas = new Stack<CartaUno>(test2);
            return this.CartasMazo;
        }


        public CartaUno SiguienteCarta()
        {

            if (this.juego.MazoDeCartas == null || !this.juego.MazoDeCartas.Any())
            {
                return null;
            }

            return this.juego.MazoDeCartas.Pop();
        }


        public CartaUno MostrarCartaMesa()
        { 
            if (this.juego.MesaDeCartas.Any() == false)
            {
                return null;
            }

            return this.juego.MesaDeCartas.Peek();
        }

        /// <summary>
        /// Funcion que verifica las cartas especiales
        /// </summary>
        /// <param name="cartas">recibe la cartas del jugador</param>
        /// <returns>Devuelve la cartas modificadas</returns>
        public List<CartaUno> VerificarCartasEspeciales(List<CartaUno> cartas, out ETipoCarta accion)
        {
            accion = ETipoCarta.NONE;
            if (this.MostrarCartaMesa().Palo == ETipoCarta.ROBA_DOS || (this.MostrarCartaMesa().Palo == ETipoCarta.ROBA_CUATRO))
            {
                int fin = (int) this.MostrarCartaMesa().Palo;

                for (int i = 0; i < fin; i++)
                {
                    cartas.Add(SiguienteCarta());
                }

            }
               
            accion = this.MostrarCartaMesa().Palo;
            return cartas;
        }
    }
}
