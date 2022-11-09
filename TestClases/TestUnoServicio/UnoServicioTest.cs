using Libreria.Entidades;
using Libreria.Enumeraciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Entidades;
using Modelo.Servicios;
using System.Collections.Generic;
using System.Linq;

namespace TestClases.TestCartasServicio
{

    [TestClass]
    public class UnoServicioTest
    {

        /// <summary>
        /// Comprueba si llena el mazo de cartas.
        /// </summary>
        [TestMethod]
        public void Test_CargarCartas_True()
        {
            // Arange
            UnoServicio juegoUno = new UnoServicio();
            List<CartaUno> listaCargada = new List<CartaUno>();

            // Act
            listaCargada = juegoUno.LlenarMazo();

            // Assert
            Assert.AreEqual(true, listaCargada.Any());
        }
        /// <summary>
        /// Comprueba si la lista fue mezclada o no
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void Test_ComprobarMezclaDeCartas()
        {
            // Arange
            UnoServicio juegoUno_1 = new UnoServicio();

            List<CartaUno> listaCargada_Esperada = new List<CartaUno>();
            List<CartaUno> listaCargada_Actual = new List<CartaUno>();

            // Act
            listaCargada_Actual = juegoUno_1.LlenarMazo();
            listaCargada_Esperada = juegoUno_1.MezclarMazo();

            // Assert
            CollectionAssert.AreEqual(listaCargada_Esperada, listaCargada_Actual);
        }

        /// <summary>
        /// Comprueba si devuelve una carta del mazo
        /// </summary>
        [TestMethod]

        public void Test_SiguienteCarta_True()
        {
            // Arange
            UnoServicio juegoUno_1 = new UnoServicio();
            List<CartaUno> listaCargada_Actual = new List<CartaUno>();
            CartaUno carta = null;

            // Act
            listaCargada_Actual = juegoUno_1.LlenarMazo();
            carta = juegoUno_1.SiguienteCarta();

            // Assert
            Assert.IsTrue((carta is not null));
        }
        /// <summary>
        /// Comprueba si se agrego la carta en la mesa.
        /// </summary>
        [TestMethod]
        public void Test_PonerCartaEnMesa_True()
        {
            // Arange
            UnoServicio juegoUno_1 = new UnoServicio();
            List<CartaUno> listaCargada_Actual = new List<CartaUno>();
            List<CartaUno> listaCartaMesa = new List<CartaUno>();

            // Act
            listaCargada_Actual = juegoUno_1.LlenarMazo();
            juegoUno_1.PonerCartaAlMeson();
            listaCartaMesa = juegoUno_1.CartasMesa;

            // Assert
            Assert.IsTrue((listaCartaMesa.Any()));
        }
        /// <summary>
        /// Devuelve la carta que se encuentra en la mesa.
        /// </summary>
        [TestMethod]
        public void Test_MostrarCartaMesa_True()
        {
            // Arange
            UnoServicio juegoUno_1 = new UnoServicio();
            List<CartaUno> listaCargada_Actual = new List<CartaUno>();
            List<CartaUno> listaCartaMesa = new List<CartaUno>();
            CartaUno carta = new CartaUno();

            // Act
            listaCargada_Actual = juegoUno_1.LlenarMazo();
            juegoUno_1.PonerCartaAlMeson();
            listaCartaMesa = juegoUno_1.CartasMesa;

            carta = juegoUno_1.MostrarCartaMesa();

            // Assert
            Assert.IsTrue((listaCartaMesa.Contains(carta)));
        }


        /// <summary>
        /// Comprobacion de si se pudo o no agregar la carta 
        /// al meson
        /// </summary>
        [TestMethod]
        public void Test_AgregarCartaAlMeson_True()
        {
            // Arange
            UnoServicio juegoUno_1 = new UnoServicio();

            List<CartaUno> listaCargada_Actual = new List<CartaUno>();
            List<CartaUno> listaCartaMesa = new List<CartaUno>();

            CartaUno carta_mesa = new CartaUno();
            CartaUno carta_enviar = new CartaUno();

            // Act
            listaCargada_Actual = juegoUno_1.LlenarMazo();
            juegoUno_1.PonerCartaAlMeson();

            carta_mesa = juegoUno_1.MostrarCartaMesa();

            carta_enviar = carta_mesa;
            carta_enviar.Color = Modelo.Enumeraciones.ETipoColor.AZUL;

            bool verificar = juegoUno_1.AgregarCartasAlMeson(carta_enviar);

            // Assert
            Assert.IsTrue((verificar && juegoUno_1.CartasMesa.Contains(carta_enviar)));
        }

        /// <summary>
        /// Comprobacion de si el metodo baraja las cartas
        /// y las reparte al jugador, solo debe repartir 7 cartas.
        /// </summary>
        [TestMethod]
        public void Test_BarajarCartas_true()
        {
            // Arange
            UnoServicio juegoUno_1 = new UnoServicio();
            List<CartaUno> listaCargada_Actual = new List<CartaUno>();
            Jugador jugador = new Jugador();

            // Act
            listaCargada_Actual = juegoUno_1.LlenarMazo();
            jugador.Cartas.AddRange(juegoUno_1.BarajarCartas());

            // Assert
            Assert.IsTrue(jugador.Cartas.Count <= 7);
        }

        /// <summary>
        /// Comprobacion si la carta especial
        /// Roba dos y roba cuatro cumple con su funcion
        /// </summary>
        [TestMethod]
        public void Test_VerificarCartas_RobaDos_RobaCuatro()
        {
            // Arange
            UnoServicio juegoUno_1 = new UnoServicio();
            List<CartaUno> listaCargada_Actual = new List<CartaUno>();
            Jugador jugador_robaDos = new Jugador();
            Jugador jugador_robaCuatro = new Jugador();

            // Act
            listaCargada_Actual = juegoUno_1.LlenarMazo();

            bool validarRobaDos = false;
            bool validarRobaCuatro = false;

            ETipoCarta eTipoCarta = ETipoCarta.NONE;

            do
            {
                juegoUno_1.PonerCartaAlMeson();

                if (validarRobaDos == false && juegoUno_1.MostrarCartaMesa().Palo == ETipoCarta.ROBA_DOS) {

                    jugador_robaDos.Cartas.AddRange(juegoUno_1.VerificarCartasEspeciales(out eTipoCarta));
                    validarRobaDos = true;
                }

                if (validarRobaCuatro == false && juegoUno_1.MostrarCartaMesa().Palo == ETipoCarta.ROBA_CUATRO)
                {
                    jugador_robaCuatro.Cartas.AddRange(juegoUno_1.VerificarCartasEspeciales(out eTipoCarta));
                    validarRobaCuatro = true;
                }

            } while (validarRobaDos == false || validarRobaCuatro == false);

            // Assert
            Assert.IsTrue((jugador_robaDos.Cartas.Count == 2 && jugador_robaCuatro.Cartas.Count == 4));
        }
    }
    
}
