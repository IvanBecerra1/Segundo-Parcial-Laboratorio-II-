using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class Estadisticas
    {
        private int id;
        private static int idCount;
        private int partidasTotales;
        private int partidasGanadas;
        private int partidasPerdidas;
        private int partidasAbandonadas;

        public Estadisticas()
        {
           // this.id = Estadisticas.idCount++;
        }

        public Estadisticas( int puntos, int partidasGanadas, int partidasPerdidas, int partidasAbandonadas) : this()
        {
            this.partidasTotales = puntos;
            this.PartidasGanadas = partidasGanadas;
            this.PartidasPerdidas = partidasPerdidas;
            this.partidasGanadas = partidasAbandonadas;
        }

        public int PartidasTotales { get => partidasTotales; set => partidasTotales = value; }
        public int PartidasGanadas { get => partidasGanadas; set => partidasGanadas = value; }
        public int PartidasPerdidas { get => partidasPerdidas; set => partidasPerdidas = value; }
        public int Id { get => id; set => id = value; }
        public int PartidasAbandonadas { get => partidasAbandonadas; set => partidasAbandonadas = value; }

        public override string ToString()
        {
            return $"P.G: {this.partidasGanadas} - P.P: {this.partidasPerdidas} - P.A: {this.partidasAbandonadas} - P.T: {this.PartidasTotales}";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Estadisticas)
            {
                return this.id == (((Estadisticas)obj).id);
            }
            return false;
        }
    }
}
