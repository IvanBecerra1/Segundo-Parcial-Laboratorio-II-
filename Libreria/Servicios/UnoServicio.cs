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
using Modelo.Excepciones;

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
            if (carta2.Palo == ETipoCarta.CAMBIAR_COLOR || carta2.Palo == ETipoCarta.ROBA_CUATRO || carta2.Palo == ETipoCarta.ROBA_DOS)
            {
                return true;
            }

            return (carta.Color == carta2.Color) || (carta.NumeroPalo == carta2.NumeroPalo);
        }

        public List<CartaUno> CartasMazo
        {
            get => new List<CartaUno>(this.juego.MazoDeCartas);
        }
        public List<CartaUno> CartasMesa { get => new List<CartaUno>(this.juego.MesaDeCartas); }

        /// <summary>
        /// Funcion que cumple para agregar cartas 
        /// </summary>
        /// <param name="carta">Carta a enviar</param>
        /// <returns>Devuelve true o false si se pudo agregar la carta</returns>
        public bool AgregarCartasAlMeson(CartaUno carta)
        {
            try
            {

                if (this.verificar(this.juego.MesaDeCartas.Peek(), carta) == false)
                {
                    return false;
                }

                this.juego.MesaDeCartas.Push(carta);
                return true;
            } catch (Exception ex)
            {
                throw new JuegoExcepcion($"Error: Metodo: AgregarCartasAlMeson: {ex.Message}");
            }
        }

        /// <summary>
        /// Pone una carta al meson
        /// </summary>
        public void PonerCartaAlMeson()
        {
            try
            {
                this.juego.MesaDeCartas.Push(this.SiguienteCarta());

            }
            catch (Exception ex)
            {
                throw new JuegoExcepcion($"Error, metodo: PonerCartaAlMeson(): {ex.Message}");
            }
        }

        /// <summary>
        /// Metodo encargado de añadir cartas para enviar
        /// al jugador, solo podran ser 7.
        /// </summary>
        /// <returns>Lista de cartas para el jugador</returns>
        public List<CartaUno> BarajarCartas()
        {
            try
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
            catch (Exception ex)
            {
                throw new JuegoExcepcion($"Error, metodo: BarajarCartas: {ex}");
            }
        }

        /// METODO NO UTILIZO
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

        /// METODO NO UTILIZO.
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

        /// <summary>
        /// Llena el mazo de cartas 
        /// </summary>
        /// <returns>Devuelve la lista de cartas</returns>
        public List<CartaUno> LlenarMazo()
        {
            try
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
            } catch (Exception ex)
            {
                throw new JuegoExcepcion($"Error, metodo: LlenarMazo(): {ex.Message}");

            }
           
        }

        /// <summary>
        /// Mezcla el mazo de cartas 
        /// </summary>
        /// <returns>Devuelve la lista de cartas mezcladas.</returns>
        public List<CartaUno> MezclarMazo()
        {
            try
            {

                var random = new Random();
                List<CartaUno> auxList = new List<CartaUno>(this.juego.MazoDeCartas);
                List<CartaUno> test2 = new List<CartaUno>(auxList.OrderBy(item => random.Next()));

                this.juego.MazoDeCartas = new Stack<CartaUno>(test2);
                return this.CartasMazo;
            }
            catch (Exception ex)
            {
                throw new JuegoExcepcion($"Error, metodo: MezclarMazo(): {ex.Message}");
            }
        }

        /// <summary>
        /// Devuelve la siguiente carta que se encuentra en 
        /// en la lista de cartas en mazo
        /// Si no hay cartas para devolver, se vuelcan
        /// las cartas que se encuentran en Mesa, hacia al mazo nuevamente.
        /// </summary>
        /// <returns>Carta de vuelta</returns>
        /// <exception cref="JuegoExcepcion"></exception>
        public CartaUno SiguienteCarta()
        {
            try
            {
                if (this.juego.MazoDeCartas == null)
                {
                    return new CartaUno();
                }

                if (this.juego.MazoDeCartas.Any() == false)
                {
                    this.juego.MazoDeCartas = this.juego.MesaDeCartas;
                    this.juego.MazoDeCartas.Pop();

                    CartaUno aux = this.MostrarCartaMesa();
                    this.juego.MesaDeCartas.Clear();
                    this.juego.MesaDeCartas.Push(aux);
                }
            }
            catch (Exception ex)
            {
                throw new JuegoExcepcion($"Error: Metodo: SiguienteCarta: {ex}");
            }
            
            return this.juego.MazoDeCartas.Pop();
        }

        /// <summary>
        /// Metodo que muestra cual es la carta en mesa
        /// </summary>
        /// <returns>Devuelve la carta que esta en mesa</returns>
        /// <exception cref="JuegoExcepcion"></exception>
        public CartaUno MostrarCartaMesa()
        {
            try
            {
                if (this.juego.MesaDeCartas.Any() == false)
                {
                    return null;
                }

                return this.juego.MesaDeCartas.Peek();
            }
            catch (Exception ex)
            {
                throw new JuegoExcepcion($"Error, Metodo: MostrarCartaMesa: {ex.Message}");
            }
        }

        /// <summary>
        /// Funcion que verifica las cartas especiales
        /// </summary>
        /// <param name="cartas">recibe la cartas del jugador</param>
        /// <returns>Devuelve la cartas modificadas</returns>
        public List<CartaUno> VerificarCartasEspeciales(out ETipoCarta accion)
        {
            try
            {
                accion = ETipoCarta.NONE;
                List<CartaUno> cartas = new List<CartaUno>();

                if (this.MostrarCartaMesa().Palo == ETipoCarta.ROBA_DOS || (this.MostrarCartaMesa().Palo == ETipoCarta.ROBA_CUATRO))
                {
                    int fin = (int)this.MostrarCartaMesa().Palo;

                    for (int i = 0; i <= fin; i++)
                    {
                        cartas.Add(SiguienteCarta());
                    }
                }

                accion = this.MostrarCartaMesa().Palo;
                return cartas;
            }
            catch (Exception ex)
            {
                throw new JuegoExcepcion($"Error, metodo: VerificarCartasEspeciales: {ex.Message}");
            }
        }
    }
}
