using Libreria.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClases.TestRepositorio
{

    [TestClass]
    public class TestEstadisticaRepositorio
    {
        private EstadisticasRepositorio repositorio = new EstadisticasRepositorio();

        [TestMethod]
        public void Guardar_True()
        {
            // arange
            Estadisticas estadisticas = new Estadisticas();
            int ultimoId = this.repositorio.UltimoId();
            int nuevoUltimoId;

            // Act
            bool seGuardo = this.repositorio.guardar(estadisticas);

            nuevoUltimoId = this.repositorio.UltimoId();
            bool realGuardado = nuevoUltimoId != ultimoId;

            // Assert
            Assert.IsTrue(seGuardo && realGuardado);
        }

        [TestMethod]
        public void Eliminar_True()
        {
            // Arange
            Estadisticas estadisticas = new Estadisticas();

            int ultimoId = this.repositorio.UltimoId();
            int nuevoUltimoId;
            estadisticas.Id = ultimoId;
            
            // Act
            bool seBorro = this.repositorio.eliminar(estadisticas);
            nuevoUltimoId = this.repositorio.UltimoId();
            bool realBorro = nuevoUltimoId != ultimoId;

            // Assert
            Assert.IsTrue(seBorro && realBorro);
        }

        [TestMethod]
        public void Modificar_True()
        {
            // Arange
            Estadisticas estadisticas = new Estadisticas();
            Estadisticas estadisticasAux = new Estadisticas();

            int ultimoId = this.repositorio.UltimoId();
            estadisticas = this.repositorio.buscarPor(ultimoId.ToString());

            // Act
            estadisticas.PartidasPerdidas = 20;
            estadisticas.PartidasAbandonadas = 20;
            estadisticas.PartidasGanadas = 20;
            estadisticas.PartidasTotales = 20;

            bool seEdito = this.repositorio.editar(estadisticas);
            estadisticasAux = this.repositorio.buscarPor(ultimoId.ToString()); // actualiza

            bool realEditado = false;

            if (estadisticasAux.PartidasPerdidas == 20
                && estadisticasAux.PartidasAbandonadas == 20
                && estadisticasAux.PartidasGanadas == 20
                && estadisticasAux.PartidasTotales == 20)
            {
                realEditado = true;
            }

            // Assert
            Assert.IsTrue(seEdito && realEditado);
        }

        [TestMethod]
        public void Insertar_True()
        {
            // Arange
            Estadisticas estadisticas = new Estadisticas();

            int ultimoId = this.repositorio.UltimoId();
            int nuevoUltimoId;

            // Act

            bool seGuardo = this.repositorio.guardar(estadisticas);
            nuevoUltimoId = this.repositorio.UltimoId();

            bool realGuardo = nuevoUltimoId != ultimoId;

            // Assert
            Assert.IsTrue(seGuardo && realGuardo);
        }
        /* 
      [TestMethod]
      public void Test_ObtenerTodo()
      {
          // arange
       List<Estadisticas> lista = new List<Estadisticas>();
          int countEsperado = 32; // Cambiar el 30 si se agregaron mas datos

          // act
          lista = this.repositorio.obtenerTodo();

          // Assert
          Assert.AreEqual(countEsperado, lista.Count);

    }*/
    }
}
