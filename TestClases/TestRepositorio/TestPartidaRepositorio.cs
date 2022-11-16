using Libreria.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Entidades;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClases.TestRepositorio
{

    [TestClass]
    public class TestPartidaRepositorio
    {
        private PartidaRepositorio repositorio = new PartidaRepositorio();

        [TestMethod]
        public void Test_BuscarPorId()
        {
            // arange
            Partida partida = new Partida();
            int idBuscar = 1035;

            // act
            partida = repositorio.buscarPor(idBuscar.ToString());

            bool idIguales = partida.Id == idBuscar;

            // Assert
            Assert.IsTrue(idIguales);
        }

        [TestMethod]
        public void Test_GuardarPartida()
        {
            // arange
            
            Partida partida = new Partida();
            int ultimoId = this.repositorio.UltimoId();
            int ultimoIdAux;

            List<Jugador> jugadores = new List<Jugador>();
            Jugador jugador1 = new Jugador();
            Jugador jugador2 = new Jugador();
            Jugador jugador3 = new Jugador();

            int idJugador1 = 1020;
            int idJugador2 = 1021;
            int idJugador3 = 1022;

            jugador1 = new JugadorRepositorio().buscarPor(idJugador1.ToString());
            jugador2 = new JugadorRepositorio().buscarPor(idJugador2.ToString());
            jugador3 = new JugadorRepositorio().buscarPor(idJugador3.ToString());

            jugadores.Add(jugador1);
            jugadores.Add(jugador2);
            jugadores.Add(jugador3);

            partida.Jugadores = jugadores;
            partida.Ganador = jugador1;
            partida.Rondas = 20;

            // act
            bool seGuardo = this.repositorio.guardar(partida);

            ultimoIdAux = this.repositorio.UltimoId();

            bool realGuardado = ultimoIdAux != ultimoId;

            // Assert
            Assert.IsTrue(seGuardo && realGuardado);
        }

        [TestMethod]
        public void Test_Eliminar()
        {
            // Arange
            Partida partida = new Partida();
            int ultimoId = this.repositorio.UltimoId();
            int ultimoIdAux;

            partida = this.repositorio.buscarPor(ultimoId.ToString());

            // ACt
            bool seBorro = this.repositorio.eliminar(partida);

            ultimoIdAux = this.repositorio.UltimoId();

            bool seBorroDefinitivo = ultimoIdAux != ultimoId;

            // assert
            Assert.IsTrue(seBorro && seBorroDefinitivo);
        }

        [TestMethod]
        public void Test_Editar()
        {
            // Arange
            Partida partida = new Partida();
            Partida partidaAux = new Partida();
            Jugador jugador3 = new Jugador();

            int ultimoId = this.repositorio.UltimoId();

            partida = this.repositorio.buscarPor(ultimoId.ToString());

            int idJugador3 = 7;
            jugador3 = new JugadorRepositorio().buscarPor(idJugador3.ToString());

            partida.Ganador = jugador3;
            partida.Rondas = 1;
            partida.Fecha = DateTime.Today;

            string DateTimeString = partida.Fecha.ToString("dd-MM-yyyy");
            // act
            bool seEdito = this.repositorio.editar(partida);

            bool realEditado = false;

            partidaAux = this.repositorio.buscarPor(ultimoId.ToString());

            if (partidaAux.Ganador.Id == 7
                && partidaAux.Rondas == 1
                && partidaAux.Fecha == DateTime.Parse(DateTimeString))
            {
                realEditado = true;
            }

            //asser
            Assert.IsTrue(seEdito && realEditado);
        }

        [TestMethod]
        public void ObtenerTodo()
        {
            List<Partida> lista = new List<Partida>();

            lista = this.repositorio.obtenerTodo();
            
            Assert.IsTrue(lista.Any());    
        }


        [TestMethod]
        public void ConsultarTop()
        {
            List<Jugador> lista = new List<Jugador>();

            lista = this.repositorio.ConsultarPorPartidasGanadas_Top();

            Assert.IsTrue(lista.Any());
        }
    }
}
