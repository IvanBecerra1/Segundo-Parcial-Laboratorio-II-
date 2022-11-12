using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DTO
{
    public class JugadorTopDTO
    {
        private int id;
        private string nombre;
        private string alias;
        private int partidasGanadas;

        public JugadorTopDTO()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Alias { get => alias; set => alias = value; }
        public int PartidasGanadas { get => partidasGanadas; set => partidasGanadas = value; }

        /// <summary>
        /// Metodo estatico para hacer la transferencia de datos 
        /// entre la entidad jugador y el DTO
        /// </summary>
        /// <param name="jugadores">Recibe una entidad Jugador</param>
        /// <returns>La entidad mapeada</returns>
        public static JugadorTopDTO MapperEntidad(Jugador jugadores)
        {
            JugadorTopDTO jugadoresDTO = new JugadorTopDTO();

            jugadoresDTO.Id = jugadores.Id;
            jugadoresDTO.nombre = jugadores.Nombre;
            jugadoresDTO.alias = jugadores.Alias;
            jugadoresDTO.partidasGanadas = jugadores.Estadisticas.PartidasGanadas;

            return jugadoresDTO;
        }
    }
}
