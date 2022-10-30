using Libreria.Entidades;
using Modelo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.Excepciones;

namespace Modelo.Repositorio
{
    public class JugadorRepositorio : Repositorio, IRepositorio<Jugador>
    {
        private static string TABLA = " Jugadores ";

        public bool eliminar(Jugador entidad)
        {
            bool seElimino = false;
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"DELETE FROM " + TABLA + @" 
                                            WHERE id_jugador = @id"; 

                    comando.Parameters.AddWithValue("@id", entidad.Id);
                    comando.ExecuteNonQuery();
                }
                seElimino = true;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al Eliminar la entidad: " + typeof(Jugador), ex);
            }

            return seElimino;
        }

        public bool guardar(Jugador entidad)
        {
            bool seGuardo = false;
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"INSERT INTO " + TABLA + @" 
                                            VALUES (@nombre, @idEstadisticas)";

                    comando.Parameters.AddWithValue("@nombre", entidad.Nombre);
                    comando.Parameters.AddWithValue("@idEstadisticas", entidad.Estadisticas.Id);
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

        public List<Jugador> obtenerTodo()
        {
            List<Jugador> listaJugadores = new List<Jugador>();

            using (conexion = new SqlConnection(Repositorio.CONEXION))
            using (comando = new SqlCommand())
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT * 
                                        FROM " + TABLA + @" 
                                        ORDER BY id_jugador DESC";

                EstadisticasRepositorio estadisticasRepositorio = new EstadisticasRepositorio();

                using (lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Jugador jugador = new Jugador();
                        jugador.Id = lector.GetInt32(0);
                        jugador.Nombre = lector.GetString(1);
                        jugador.Estadisticas = estadisticasRepositorio.buscarPorId(lector.GetInt32(2));
                        listaJugadores.Add(jugador);
                    }
                }
            }
            return listaJugadores;
        }

        public Jugador buscarPorId(int id)
        {
            Jugador jugador = new Jugador();
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"SELECT * 
                                            FROM " + TABLA + @"
                                            WHERE id_jugador = @id";
                    comando.Parameters.AddWithValue("@id", id);

                    EstadisticasRepositorio estadisticasRepositorio = new EstadisticasRepositorio();
                    using (lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            jugador.Id = lector.GetInt32(0);
                            jugador.Nombre = lector.GetString(1);
                            jugador.Estadisticas = estadisticasRepositorio.buscarPorId(lector.GetInt32(2));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al buscar la entidad: " + typeof(Jugador), ex);
            }

            return jugador;
        }

        public bool editar(Jugador entidad)
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
                                            SET nombre_jugador = @nombre,
                                                id_estadistica = @idEestadisticas
                                            WHERE id_jugador = @id";

                    comando.Parameters.AddWithValue("@id", entidad.Id);
                    comando.Parameters.AddWithValue("@nombre", entidad.Nombre);
                    comando.Parameters.AddWithValue("@idEestadisticas", entidad.Estadisticas.Id);
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
