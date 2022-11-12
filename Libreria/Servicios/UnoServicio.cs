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
using Modelo.Serializacion;

namespace Modelo.Servicios
{
    /// <summary>
    /// Clase Servicio, solo tendra la Responsabilidad Unica (Single Responsibility Principle)
    /// de crear e implementar la logica/mecanica que se necesita para el juego Uno
    /// </summary>
    public class UnoServicio : IJuegoDeCarta<CartaUno>
    {
        private JuegoCartas<CartaUno> juego;
        private delegate bool VerificarCarta(CartaUno carta, CartaUno carta2);
        private VerificarCarta verificar;

        public UnoServicio()
        {
            this.verificar = new VerificarCarta(verificarCarta);
            this.juego = new JuegoCartas<CartaUno>();

        }
        #region Propiedades
        public List<CartaUno> CartasMazo
        {
            get => new List<CartaUno>(this.juego.MazoDeCartas);
        }
        public List<CartaUno> CartasMesa { get => new List<CartaUno>(this.juego.MesaDeCartas); }

        #endregion

        /// <summary>
        /// Delegado que estara encargado de verificar
        /// y chequeara si la carta que se esta tirando 
        /// cumple con la regla del juego
        /// </summary>
        /// <param name="carta">Carta mesa</param>
        /// <param name="carta2">Carta enviada</param>
        /// <returns>Verdadero o falso si cumple con la regla del juego</returns>
        private bool verificarCarta(CartaUno carta, CartaUno carta2)
        {
            if (carta2.Palo == ETipoCarta.CAMBIAR_COLOR || carta2.Palo == ETipoCarta.ROBA_CUATRO || carta2.Palo == ETipoCarta.ROBA_DOS)
            {
                return true;
            }

            return (carta.Color == carta2.Color) || (carta.NumeroPalo == carta2.NumeroPalo);
        }

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

        /// <summary>
        /// Llena el mazo de cartas 
        /// Si existe el JSON de cartas cargadas, se deserializara
        /// Si no, se vuelve a crear el JSon
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

                if (SerializacionJSON.ExisteDirectorio())
                {
                    this.juego.MazoDeCartas = SerializacionJSON.DeserializarJSON();
                }
                else
                {
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
                    SerializacionJSON.SerializarJSON(this.juego.MazoDeCartas);
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
               // List<CartaUno> auxList = new List<CartaUno>(this.juego.MazoDeCartas);
                Stack<CartaUno> test2 = new Stack<CartaUno>(this.juego.MazoDeCartas.OrderBy(item => random.Next()));

              //  this.juego.MazoDeCartas.OrderBy(item => random.Next());

                this.juego.MazoDeCartas = test2;//new Stack<CartaUno>(test2);
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
                    throw new JuegoExcepcion("Se produjo un error, no se encuentran cartas en mesa!!");
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
        /// <returns>Devuelve la cartas que se asignara al jugador</returns>
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
