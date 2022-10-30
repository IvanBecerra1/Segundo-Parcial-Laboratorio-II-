using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositorio
{
    public abstract class CRepositorio
    {

        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        static Repositorio()
        {
            AccesoDatos.cadena_conexion = @"Server=localhost\SQLEXPRESS;Database=db_juegos_carta;Trusted_Connection=True;";

        }

    }
}
