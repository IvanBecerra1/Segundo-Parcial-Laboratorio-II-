using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Excepciones
{
    public class JuegoExcepcion : Exception
    {

        public JuegoExcepcion(string msg) : base(msg)
        {

        }

        public JuegoExcepcion(string msg, Exception exception) : base(msg, exception)
        {

        }
    }
}
