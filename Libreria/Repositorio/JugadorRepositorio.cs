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
using Modelo.Enumeraciones;
using Modelo.Entidades;
using System.Threading;

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
                                            WHERE id = @id"; 

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

                /// Ultimo INSERT de estadistica
                EstadisticasRepositorio estadisticasRepositorio = new EstadisticasRepositorio();
                estadisticasRepositorio.guardar(entidad.Estadisticas);


                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;

                    comando.CommandText = @"INSERT INTO " + TABLA + @"(nombre_jugador, alias_jugador,id_estadistica, estado) 
                                            VALUES (@nombre, @alias, @idEstadisticas, @estado)";

                    comando.Parameters.AddWithValue("@nombre", entidad.Nombre);
                    comando.Parameters.AddWithValue("@alias", entidad.Alias);
                    comando.Parameters.AddWithValue("@idEstadisticas", estadisticasRepositorio.UltimoId()); // Consulta de obtener el ultimo Id
                    comando.Parameters.AddWithValue("@estado", entidad.Estado.ToString());
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
                                        FROM " + TABLA + @" j
                                        INNER JOIN Estadisticas e
                                        ON j.id_estadistica = e.id
                                        ORDER BY j.id DESC";

                EstadisticasRepositorio estadisticasRepositorio = new EstadisticasRepositorio();

                using (lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        Jugador jugador = new Jugador();
                        jugador.Id = lector.GetInt32(0);
                        jugador.Nombre = lector.GetString(1);
                        jugador.Alias = lector.GetString(2);
                        //jugador.Estadisticas = estadisticasRepositorio.buscarPor(lector.GetInt32(3).ToString());
                        jugador.Estado = lector.GetString(4).ConvertirEnum<EEstadoJugador>();
                        
                        jugador.Estadisticas.Id = lector.GetInt32(5);
                        jugador.Estadisticas.PartidasTotales = lector.GetInt32(6);
                        jugador.Estadisticas.PartidasGanadas = lector.GetInt32(7);
                        jugador.Estadisticas.PartidasPerdidas = lector.GetInt32(8);
                        jugador.Estadisticas.PartidasAbandonadas = lector.GetInt32(9);

                        listaJugadores.Add(jugador);
                    }
                }
            }
            return listaJugadores;
        }

        public Jugador buscarPor(string dato)
        {
            Jugador jugador = new Jugador();

            int id = int.TryParse(dato, out _) ? Convert.ToInt32(dato) : 0;
            string alias = dato;
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"SELECT * 
                                        FROM " + TABLA + @" j
                                        INNER JOIN Estadisticas e
                                        ON j.id_estadistica = e.id
                                        WHERE j.id = @id OR j.alias_jugador LIKE @alias+'%'";

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Parameters.AddWithValue("@alias", alias);

                    EstadisticasRepositorio estadisticasRepositorio = new EstadisticasRepositorio();
                    using (lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            jugador.Id = lector.GetInt32(0);
                            jugador.Nombre = lector.GetString(1);
                            jugador.Alias = lector.GetString(2);
                            //jugador.Estadisticas = estadisticasRepositorio.buscarPor(lector.GetInt32(3).ToString());
                            jugador.Estado = lector.GetString(4).ConvertirEnum<EEstadoJugador>();

                            jugador.Estadisticas.Id = lector.GetInt32(5);
                            jugador.Estadisticas.PartidasTotales = lector.GetInt32(6);
                            jugador.Estadisticas.PartidasGanadas = lector.GetInt32(7);
                            jugador.Estadisticas.PartidasPerdidas = lector.GetInt32(8);
                            jugador.Estadisticas.PartidasAbandonadas = lector.GetInt32(9);

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
                                                alias_jugador = @alias,
                                                id_estadistica = @idEestadisticas,
                                                estado = @estado
                                            WHERE id = @id";

                    comando.Parameters.AddWithValue("@id", entidad.Id);
                    comando.Parameters.AddWithValue("@nombre", entidad.Nombre);
                    comando.Parameters.AddWithValue("@alias", entidad.Alias);
                    comando.Parameters.AddWithValue("@idEestadisticas", entidad.Estadisticas.Id);
                    comando.Parameters.AddWithValue("@estado", entidad.Estado.ToString());
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
        public List<Jugador> ConsultarJugadoresPartida(int dato)
        {
            List<Jugador> lista = new List<Jugador>();
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;

                    comando.CommandText = @"SELECT id_jugador 
                                            FROM Partidas_Jugadores
                                            WHERE id_partida = @idPartida;";

                    comando.Parameters.AddWithValue("@idPartida", dato);

                    using (lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Jugador jugador = new Jugador();

                            var taskConsulta = Task.Run(() =>
                            {
                                jugador = new JugadorRepositorio().buscarPor(lector.GetInt32(0).ToString());
                            });
                            Task.WaitAll(taskConsulta);

                            lista.Add(jugador);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("Se produjo un error, en la consulta: ConsultaJugadores Repositorio Partida");
            }
            return lista;
        }
    }
}
