using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Interfaces
{
    public interface IEscobaQuince
    {
        public List<Carta> CartasMazo { get; }
        public List<Carta> CartasMesa { get; }
    }
}
