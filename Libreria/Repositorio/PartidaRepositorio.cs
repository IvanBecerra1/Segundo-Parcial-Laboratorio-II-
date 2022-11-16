using Libreria.Entidades;
using Modelo.Entidades;
using Modelo.Enumeraciones;
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
    /// <summary>
    /// Manejo de la entidad Partidas y la tabla Partidas_Jugadores (relacion n a n)
    /// </summary>
    public class PartidaRepositorio : Repositorio, IRepositorio<Partida>
    {
        EstadisticasRepositorio estadisticasRepositorio = new EstadisticasRepositorio();
        JugadorRepositorio jugadorRepositorio = new JugadorRepositorio();

        static string TABLA = " Partidas ";
        static string TABLA_RELACION = " Partidas_Jugadores ";

        public Partida buscarPor(string dato)
        {

            int id = int.TryParse(dato, out _) ? Convert.ToInt32(dato) : 0;
            Partida partida = new Partida();
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;

                    comando.CommandText = @"
                     SELECT * 
                     FROM Partidas p
                     WHERE p.id = @id;";

                    comando.Parameters.AddWithValue("@id", id);
                    //  comando.Parameters.AddWithValue("@fecha", fecha);

                    using (lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            partida.Id = lector.GetInt32(0);
                            partida.Fecha = DateTime.Parse(lector.GetString(1));
                            partida.Rondas = lector.GetInt32(2);
                            partida.Ganador = jugadorRepositorio.buscarPor(lector.GetInt32(3).ToString());
                            partida.Jugadores = jugadorRepositorio.ConsultarJugadoresPartida(partida.Id);

                            //     listaPartidas.Add(partida);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return partida;
        }
        /// <summary>
        /// Solo es posible modificar la partida pero no
        /// su relacion de N a N
        /// </summary>
        /// <param name="entidad"></param>
        /// <returns></returns>
        /// <exception cref="RepositorioExcepcion"></exception>
        public bool editar(Partida entidad)
        {
            bool seGuardo = false;
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;

                    comando.CommandText = @"UPDATE " + TABLA + @"
                                            SET 
                                                fecha = @fecha,
                                                rondas = @rondas,
                                                id_ganador = @ganador
                                            WHERE id = @id";

                    comando.Parameters.AddWithValue("@id", entidad.Id);
                    comando.Parameters.AddWithValue("@fecha", entidad.Fecha.ToString("dd-MM-yyyy"));
                    comando.Parameters.AddWithValue("@rondas", entidad.Rondas);
                    comando.Parameters.AddWithValue("@ganador", entidad.Ganador.Id);

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

        public bool eliminar(Partida entidad)
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


                    comando.CommandText = @"DELETE FROM " + TABLA_RELACION + @" 
                                            WHERE id_partida = @idPartida";

                    comando.Parameters.AddWithValue("@idPartida", entidad.Id);
                    comando.ExecuteNonQuery();
                }
                seElimino = true;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al Eliminar la entidad: " + typeof(Partida), ex);
            }

            return seElimino;
        }
    
      
        public bool guardar(Partida entidad)
        {
            bool seGuardo = false;
            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;

                    comando.CommandText = @"INSERT INTO " + TABLA + @"(fecha,rondas,id_ganador) 
                                            VALUES (@fecha, @rondas, @ganador)";

                    comando.Parameters.AddWithValue("@fecha", entidad.Fecha.ToString("dd-MM-yyyy"));
                    comando.Parameters.AddWithValue("@rondas", entidad.Rondas);
                    comando.Parameters.AddWithValue("@ganador", entidad.Ganador.Id);

                    comando.ExecuteNonQuery();
                    guardarJugadores(entidad.Jugadores);
                }
                seGuardo = true;
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al guardar la entidad: " + typeof(Jugador), ex);
            }

            return seGuardo;
        }


        public void guardarJugadores(List<Jugador> jugadores)
        {
            try
            {
                int idPartida = UltimoId();

                foreach (var aux in jugadores)
                {
                    using (conexion = new SqlConnection(Repositorio.CONEXION))
                    using (comando = new SqlCommand())
                    {
                        if (conexion.State == System.Data.ConnectionState.Closed)
                        {
                            conexion.Open();
                        }
                        comando.Connection = conexion;
                        comando.CommandText = @"INSERT INTO " + TABLA_RELACION + @"(id_jugador, id_partida) 
                                            VALUES (@idJugador, @IdPartida)";

                        comando.Parameters.AddWithValue("@idJugador", aux.Id);
                        comando.Parameters.AddWithValue("@IdPartida", idPartida);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al guardar la entidad: " + typeof(Jugador), ex);
            }
        }
        public int UltimoId()
        {
            int valor = -1;

            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = @"SELECT MAX(id) 
                                            FROM " + TABLA;

                    using (lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            valor = lector.GetInt32(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new RepositorioExcepcion("[EXPECION-REPOSITORIO]: Error al consultar el id: " + typeof(Jugador), ex);
            }

            return valor;
        }
        public List<Partida> obtenerTodo()
        {
            List<Partida> listaPartidas = new List<Partida>();

            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;

                    comando.CommandText = @"SELECT * 
                                        FROM Partidas p
                                        WHERE p.id IN (
	                                        SELECT id_partida 
                                            FROM Partidas_Jugadores jp
		                                    GROUP BY id_partida
	                                    );";

                    using (lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Partida partida = new Partida();
                            partida.Id = lector.GetInt32(0);
                            partida.Fecha = DateTime.Parse(lector.GetString(1));
                            partida.Rondas = lector.GetInt32(2);
                            partida.Ganador = jugadorRepositorio.buscarPor(lector.GetInt32(3).ToString());
                            partida.Jugadores = jugadorRepositorio.ConsultarJugadoresPartida(partida.Id);

                            listaPartidas.Add(partida);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaPartidas;
        }
        public List<Jugador> ConsultarPorPartidasGanadas_Top()
        {
            List<Jugador> lista = new List<Jugador>();

            try
            {
                using (conexion = new SqlConnection(Repositorio.CONEXION))
                using (comando = new SqlCommand())
                {
                    conexion.Open();
                    comando.Connection = conexion;

                    comando.CommandText = @" SELECT j.id, j.nombre_jugador,
                                                    j.alias_jugador,
                                                    e.partidas_ganadas FROM Jugadores j
                                             INNER JOIN Estadisticas e
                                             ON e.id = j.id_estadistica
                                             ORDER BY e.partidas_ganadas DESC;";

                    using (lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Jugador jugador = new Jugador();
                            jugador.Id = lector.GetInt32(0);
                            jugador.Nombre = lector.GetString(1);
                            jugador.Alias = lector.GetString(2);
                            jugador.Estadisticas.PartidasGanadas = lector.GetInt32(3);
                            lista.Add(jugador);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }
    }
}
