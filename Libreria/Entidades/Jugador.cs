using Modelo.Entidades;
using Modelo.Enumeraciones;
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
        private string alias;

        private List<CartaUno> cartas;
        private Estadisticas estadisticas;

        private bool cantarUno;

        private EEstadoJugador estado;

        public Jugador()
        {
            this.cartas = new List<CartaUno>();
            this.estadisticas = new Estadisticas();
            this.estado = EEstadoJugador.DISPONIBLE;
        }
        public Jugador(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return $"Jugador: {this.nombre} - {this.alias} - Estado: {this.estado.ToString()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Jugador)
            {
                return (this == ((Jugador)obj));
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int Id { get => id; set => id = value; }
        public static int IdCount { get => idCount; set => idCount = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public List<CartaUno> Cartas { get => cartas; set => cartas = value; }
        public Estadisticas Estadisticas { get => estadisticas; set => estadisticas = value; }
        public bool CantarUno { get => cantarUno; set => cantarUno = value; }
        public string Alias { get => alias; set => alias = value; }
        public EEstadoJugador Estado { get => estado; set => estado = value; }

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
