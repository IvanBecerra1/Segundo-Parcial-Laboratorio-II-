using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.DTO
{
    public class JugadorDTO
    {
        private int id;
        private string nombre;
        private string alias;
        private int partidasGanadas;
        private int partidasPerdidas;
        private int partidasAbandonadas;
        private int partidasTotales;

        public JugadorDTO()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Alias { get => alias; set => alias = value; }
        public int PartidasGanadas { get => partidasGanadas; set => partidasGanadas = value; }
        public int PartidasPerdidas { get => partidasPerdidas; set => partidasPerdidas = value; }
        public int PartidasAbandonadas { get => partidasAbandonadas; set => partidasAbandonadas = value; }
        public int PartidasTotales { get => partidasTotales; set => partidasTotales = value; }
    
    
        /// <summary>
        /// Metodo estatico para hacer la transferencia de datos 
        /// entre la entidad jugador y el DTO jugador 
        /// </summary>
        /// <param name="jugadores">Recibe una entidad Jugador</param>
        /// <returns>La entidad mapeada</returns>
        public static JugadorDTO MapperEntidad(Jugador jugadores)
        {
            JugadorDTO jugadoresDTO = new JugadorDTO();

            jugadoresDTO.Id = jugadores.Id;
            jugadoresDTO.nombre = jugadores.Nombre;
            jugadoresDTO.alias = jugadores.Alias;

            jugadoresDTO.partidasGanadas = jugadores.Estadisticas.PartidasGanadas;
            jugadoresDTO.partidasPerdidas = jugadores.Estadisticas.PartidasPerdidas;
            jugadoresDTO.partidasAbandonadas = jugadores.Estadisticas.PartidasAbandonadas;
            jugadoresDTO.partidasTotales = jugadores.Estadisticas.PartidasTotales;
            
            return jugadoresDTO;
        }
    }
}
