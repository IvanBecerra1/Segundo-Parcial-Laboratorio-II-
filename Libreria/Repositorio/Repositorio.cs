using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Repositorio
{
    public abstract class Repositorio
    {
        protected static string CONEXION;
        protected SqlConnection conexion;
        protected SqlCommand comando;
        protected SqlDataReader lector;

        static Repositorio()
        {
            Repositorio.CONEXION = @"Server=localhost\SQLEXPRESS;Database=db_juegos_carta;Trusted_Connection=True;";

        }
    }
}
