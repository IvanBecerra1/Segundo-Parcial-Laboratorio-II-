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
            Repositorio.CONEXION = @"Data Source=localhost;Initial Catalog=db_parcial_ll;Integrated Security=True"; ;

        }
    }
}
