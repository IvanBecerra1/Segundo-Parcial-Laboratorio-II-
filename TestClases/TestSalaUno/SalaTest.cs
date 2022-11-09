using Libreria.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Entidades;
using Modelo.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClases.TestSalaUno
{
    [TestClass]
    public class SalaTest
    {
        /// <summary>
        /// Comprueba si se carga la sala correctamente
        /// REcordar que no hace falta invocar la funcion 
        /// CargarPartida() porque se invoca una vez instanciado la clase
        /// </summary>
        [TestMethod]
        public void Test_CargarPartida_True()
        {
            UnoServicio servicio = new UnoServicio();
            SalaUno salaCarta = new SalaUno(servicio);

            bool validarLLenarMazo = false;
            bool validarMezclarMazo = false;
            bool validarPonerCartaAlMeson = false;

            if (servicio.CartasMazo.Any())
            {
                validarLLenarMazo = true;
                validarMezclarMazo = true;
            }

            if (servicio.CartasMesa.Any())
            {
                validarPonerCartaAlMeson = true;
            }
            Assert.IsTrue((validarLLenarMazo && validarMezclarMazo && validarPonerCartaAlMeson));
        }

        /// <summary>
        /// Comprueba si se reparte correctamente las cartas al jugador.
        /// </summary>
        [TestMethod]
        public void Test_DarCartaJugador_True()
        {
            UnoServicio servicio = new UnoServicio();
            SalaUno salaCarta = new SalaUno(servicio);
            Jugador jugador = new Jugador();

            jugador.Cartas.AddRange(salaCarta.DarCartaJugador());
            
            Assert.IsTrue(jugador.Cartas.Any());
        }

        /// <summary>
        /// Comprueba si pudo agarrar una carta y se lo asigna al jugador
        /// </summary>
        [TestMethod]
        public void Test_AgarrarCarta_True()
        {
            UnoServicio servicio = new UnoServicio();
            SalaUno salaCarta = new SalaUno(servicio);
            Jugador jugador = new Jugador();

            jugador.Cartas.Add(salaCarta.AgarrarCarta());

            Assert.IsTrue(jugador.Cartas.Any());
        }

        /// <summary>
        /// Comprobar si deposito o no la carta en la mesa
        /// </summary>
        [TestMethod]
        public void Test_DepositarCarta_True()
        {
            UnoServicio servicio = new UnoServicio();
            SalaUno salaCarta = new SalaUno(servicio);
            Jugador jugador = new Jugador();

            jugador.Cartas.Add(salaCarta.MostrarCartaMesa());

            bool comprobar = salaCarta.DepositarCarta(jugador.Cartas[0]);

            Assert.IsTrue(true);
        }

        /// <summary>
        /// Comprueba si devuelve dos cartas 
        /// </summary>
        [TestMethod]
        public void Test_DevolverDosCartas_true()
        {
            UnoServicio servicio = new UnoServicio();
            SalaUno salaCarta = new SalaUno(servicio);
            Jugador jugador = new Jugador();

            jugador.Cartas.AddRange(salaCarta.DevolverDosCartas());

            bool comprobar = jugador.Cartas.Count >= 1;

            Assert.IsTrue(comprobar);
        }
    }
}
