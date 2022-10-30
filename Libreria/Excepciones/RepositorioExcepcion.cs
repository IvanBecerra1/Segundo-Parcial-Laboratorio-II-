using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Excepciones
{
    public class RepositorioExcepcion : Exception
    {
        public RepositorioExcepcion(string msg) : base(msg) 
        {
        
        }

        public RepositorioExcepcion(string msg, Exception excepcion) : base(msg, excepcion) 
        {

        }
    }
}
