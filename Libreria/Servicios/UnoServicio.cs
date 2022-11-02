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
        public List<CartaUno> CartasMesa { get => this.juego.MesaDeCartas; }

        public void AgregarCartasAlMeson(CartaUno carta)
        {

            this.juego.MesaDeCartas.Add(carta);
        }

        public void PonerCartaAlMeson()
        {
            this.juego.MesaDeCartas.Add(this.SiguienteCarta(null));
        }

        public List<CartaUno> BarajarCartas(List<CartaUno> listaCartas)
        {
            if (!this.juego.MazoDeCartas.Any())
            {
                return null;
            }
            List<CartaUno> cartasDevueltas = new List<CartaUno>();

            do
            {
                cartasDevueltas.Add(SiguienteCarta(listaCartas));
            } while (cartasDevueltas.Count <= 6);

            return cartasDevueltas;
        }

        /// <summary>
        /// Cartas disponibles del jugador. si tiene 0 es el ganador
        /// </summary>
        /// <param name="listaCartas"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<CartaUno> CartasDisponibles(List<CartaUno> listaCartas)
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

        public List<CartaUno> LlenarMazo(List<CartaUno> listaCartas)
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

        public List<CartaUno> MezclarMazo(List<CartaUno> listaCartas)
        {
            var random = new Random();
            List<CartaUno> auxList = new List<CartaUno>(this.juego.MazoDeCartas);
            List<CartaUno> test2 = new List<CartaUno>(auxList.OrderBy(item => random.Next()));

            this.juego.MazoDeCartas = new Stack<CartaUno>(test2);
            return this.CartasMazo;
        }

        public CartaUno SiguienteCarta(List<CartaUno> listaCartas)
        {

            if (this.juego.MazoDeCartas == null || !this.juego.MazoDeCartas.Any())
            {
                return null;
            }

            return this.juego.MazoDeCartas.Pop();
        }

    }
}
