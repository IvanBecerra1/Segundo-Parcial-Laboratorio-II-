using Libreria.Entidades;
using Modelo.Excepciones;
using Modelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repositorio
{
    public class EstadisticasRepositorio : Repositorio, IRepositorio<Estadisticas>
    {
        private static string TABLA = " Estadisticas ";

        public bool eliminar(Estadisticas entidad)
        {
            bool seElimino = false;
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"DELETE FROM" + TABLA +  @"
                                            WHERE id_estadistica = @id";

                    comando.Parameters.AddWithValue("@id", entidad.Id);
                    comando.ExecuteNonQuery();
                }
                seElimino = true;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al Eliminar la entidad: " + typeof(Estadisticas), ex);
            }

            return seElimino;
        }

        public bool guardar(Estadisticas entidad)
        {
            bool seGuardo = false;
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"INSERT INTO" + TABLA + @"(puntos_juego, partidas_ganadas, partidas_perdidas, partidas_abandonadas)
                                            VALUES (@puntosJuego, @partidasGanadas, @partidasPerdidas, @partidasAbandonadas)";

                    comando.Parameters.AddWithValue("@puntosJuego", entidad.Puntos);
                    comando.Parameters.AddWithValue("@partidasGanadas", entidad.PartidasGanadas);
                    comando.Parameters.AddWithValue("@partidasPerdidas", entidad.PartidasPerdidas);
                    comando.Parameters.AddWithValue("@partidasAbandonadas", entidad.PartidasAbandonadas);
                    comando.ExecuteNonQuery();
                }
                seGuardo = true;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al guardar la entidad: " + typeof(Jugador), ex);
            }

            return seGuardo;
        }

        public List<Estadisticas> obtenerTodo()
        {
            List<Estadisticas> lisatEstadisticas = new List<Estadisticas>();

            using (conexion = new SqlConnection(Repositorio.CONEXION))
            using (comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT * 
                                        " + TABLA +  @"
                                        ORDER BY id_estadisticas DESC";

                using (lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Estadisticas estadisticas = new Estadisticas();
                        estadisticas.Id = lector.GetInt32(0);
                        estadisticas.Puntos = lector.GetInt32(1);
                        estadisticas.PartidasGanadas = lector.GetInt32(2);
                        estadisticas.PartidasPerdidas = lector.GetInt32(3);
                        estadisticas.PartidasAbandonadas = lector.GetInt32(4);
                        lisatEstadisticas.Add(estadisticas);
                    }
                }
            }
            return lisatEstadisticas;
        }


        public Estadisticas buscarPorId(int id)
        {
            Estadisticas estadisticas = new Estadisticas();
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"SELECT * 
                                            FROM " + TABLA +  @"
                                            WHERE id_estadisticas = @id";
                    comando.Parameters.AddWithValue("@id", id);

                    using (lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            estadisticas.Id = lector.GetInt32(0);
                            estadisticas.Puntos = lector.GetInt32(1);
                            estadisticas.PartidasGanadas = lector.GetInt32(2);
                            estadisticas.PartidasPerdidas = lector.GetInt32(3);
                            estadisticas.PartidasAbandonadas = lector.GetInt32(4);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al buscar la entidad: " + typeof(Jugador), ex);
            }

            return estadisticas;
        }

        public bool editar(Estadisticas entidad)
        {
            bool seModifico = false;
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"UPDATE " + TABLA + @" 
                                            SET puntos = @puntosJuego,
                                                partidas_ganadas = @partidasGanadas,
                                                partidas_perdidas = @partidasPerdidas,                                                                      
                                                partidas_abandonadas = @partidasAbandonadas
                                            WHERE id_estadisticas = @id";

                    comando.Parameters.AddWithValue("@id", entidad.Id);
                    comando.Parameters.AddWithValue("@puntosJuego", entidad.Puntos);
                    comando.Parameters.AddWithValue("@partidasGanadas", entidad.PartidasGanadas);
                    comando.Parameters.AddWithValue("@partidasPerdidas", entidad.PartidasPerdidas);
                    comando.Parameters.AddWithValue("@partidasAbandonadas", entidad.PartidasAbandonadas);
                    comando.ExecuteNonQuery();
                }
                seModifico = true;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al modificar la entidad: " + typeof(Jugador), ex);
            }

            return seModifico;
        }
    }
}
