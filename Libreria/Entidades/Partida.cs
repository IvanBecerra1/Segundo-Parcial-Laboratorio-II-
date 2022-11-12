using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    public class Partida
    {
        private int id;
        private DateTime fecha;
        private Jugador ganador;
        private List<Jugador> jugadores;
        private int rondas;

        public Partida()
        {
            jugadores = new List<Jugador>();
        }

        public Jugador Ganador { get => ganador; set => ganador = value; }
        public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
        public DateTime Fecha {
            get => fecha;
            set => fecha = value;
        
        }
        public int Rondas { get => rondas;
            set
            {
                this.rondas = value;
            }
              
                
                }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return $"{this.id} - {this.fecha.ToString("dd/MM/yy")} - Ganador: {this.ganador.Nombre} ({this.ganador.Alias}) - Rondas jugadas: {this.Rondas}";
        }
    }
}
