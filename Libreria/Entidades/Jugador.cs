using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class Jugador
    {
        private int id;
        private static int idCount;
        private string nombre;

        private List<CartaUno> cartas;
        private List<CartaUno> cartasEnBodega;
        private Estadisticas estadisticas;


        public Jugador()
        {
            this.cartas = new List<CartaUno>();
            this.cartasEnBodega = new List<CartaUno>();
        }
        public Jugador(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return $"Jugador: {this.nombre}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Jugador)
            {
                return (this == ((Jugador)obj));
            }
            return base.Equals(obj);
        }
        public int Id { get => id; set => id = value; }
        public static int IdCount { get => idCount; set => idCount = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<CartaUno> Cartas { get => cartas; set => cartas = value; }
        public List<CartaUno> CartasEnBodega { get => cartasEnBodega; set => cartasEnBodega = value; }
        public Estadisticas Estadisticas { get => estadisticas; set => estadisticas = value; }

        public static bool operator ==(Jugador jugadorA, Jugador JugadorB)
        {
            return (jugadorA.id == JugadorB.id);
        }

        public static bool operator !=(Jugador jugadorA, Jugador JugadorB)
        {
            return !(jugadorA == JugadorB);
        }
    }
}
