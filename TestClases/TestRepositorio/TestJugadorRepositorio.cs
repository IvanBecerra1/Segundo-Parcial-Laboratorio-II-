using Libreria.Entidades;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestClases.TestRepositorio
{
    [TestClass]
    public class TestJugadorRepositorio
    {
        private JugadorRepositorio repositorio = new JugadorRepositorio();

        /// <summary>
        /// Test de guardar Jugador
        /// </summary>
        [TestMethod]
        public void Test_GuardarJugador_True()
        {
            // Arange = organizar
            Jugador jugador = new Jugador()
            {
                Nombre = "Ivan",
                Alias = "BecerraTest",
            };
            Jugador jugadorEsperado = new Jugador();


            //Act = actuar
            bool seGuardo = repositorio.guardar(jugador);

            //    int idUltimo = repositorio.UltimoId();
            //   jugadorEsperado = repositorio.buscarPor(idUltimo.ToString());

            //Assert = Preparar
            //Assert.AreEqual(jugadorEsperado, jugador);
            Assert.IsTrue(seGuardo);
        }

        /// <summary>
        /// Test de eliminar
        /// </summary>
        [TestMethod]
        public void Test_EliminarJugador_True()
        {
            // Arange
            Jugador jugador = new Jugador();

            int idUltimoJugador = this.repositorio.UltimoId();
            int idUltimoAux = idUltimoJugador;

            jugador = this.repositorio.buscarPor(idUltimoJugador.ToString());

            // Act
            bool seElimino = this.repositorio.eliminar(jugador);

            idUltimoJugador = this.repositorio.UltimoId();
            bool seEliminoReal = idUltimoAux != idUltimoJugador;

            // Assert
            Assert.IsTrue(seEliminoReal && seElimino);
        }

        /// <summary>
        /// Metodo modificado
        /// </summary>
        [TestMethod]
        public void Test_ModificarJugador_True()
        {
            // Arange
            Jugador jugador = new Jugador();
            Jugador jugadorAux = new Jugador();

            int idUltimoJugador = this.repositorio.UltimoId();
            jugador = this.repositorio.buscarPor(idUltimoJugador.ToString());

            string nombreAux = "PepitoRamirez";
            string aliasAux = "DeLosAndes";

            jugador.Nombre = nombreAux;
            jugador.Alias = aliasAux;

            // Act
            bool seModifico = this.repositorio.editar(jugador);

            jugadorAux = this.repositorio.buscarPor(idUltimoJugador.ToString());
            bool realModificado = (jugadorAux.Nombre == nombreAux && jugadorAux.Alias == aliasAux);

            // Assert
            Assert.IsTrue(seModifico && realModificado);
        }

        /// <summary>
        /// Test buscar por Id
        /// </summary>
        [TestMethod]
        public void BuscarJugadorId_true()
        {
            // Arange
            Jugador jugador = new Jugador();
            int IdABuscar = 7;

            // Act
            jugador = this.repositorio.buscarPor(IdABuscar.ToString());
            bool esElId = jugador.Id == IdABuscar;

            // Assert
            Assert.IsTrue(esElId);

        }
        /// <summary>
        /// Test buscar por Alias
        /// </summary>
        [TestMethod]
        public void BuscarJugadorAlias_true()
        {
            // Arange
            Jugador jugador = new Jugador();
            string aliasABuscar = "becerra";

            // Act
            jugador = this.repositorio.buscarPor(aliasABuscar);
            bool esElAlias = jugador.Alias == aliasABuscar;

            // Assert
            Assert.IsTrue(esElAlias);
        }

        /// <summary>
        /// Test de jugadores en partida
        /// El id de la partida debe cambiar si no existe
        /// La cantidad de jugadres esperados es de 2
        /// </summary>
        [TestMethod]
        public void BuscarJugadoresPartida()
        {
            // Arange
            List<Jugador> lista = new List<Jugador>();
            int idPartida = 1027;
            int JugadoresEsperados = 2;

            //Act
            lista = this.repositorio.ConsultarJugadoresPartida(idPartida);

            //Assert
            Assert.AreEqual(JugadoresEsperados, lista.Count);
        }
    }
}
