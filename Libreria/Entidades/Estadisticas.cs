﻿using System;
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
        private int puntos;
        private int partidasGanadas;
        private int partidasPerdidas;
        private DateTime fecha;

        public Estadisticas()
        {
            this.id = Estadisticas.idCount++;
        }

        public Estadisticas( int puntos, int partidasGanadas, int partidasPerdidas, DateTime fecha) : this()
        {
            this.Puntos = puntos;
            this.PartidasGanadas = partidasGanadas;
            this.PartidasPerdidas = partidasPerdidas;
            this.Fecha = fecha;
        }

        public int Puntos { get => puntos; set => puntos = value; }
        public int PartidasGanadas { get => partidasGanadas; set => partidasGanadas = value; }
        public int PartidasPerdidas { get => partidasPerdidas; set => partidasPerdidas = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Id { get => id; set => id = value; }
    }
}