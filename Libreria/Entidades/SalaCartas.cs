using Libreria.Interfaces;
using Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Entidades
{
    public class SalaCartas : Sala
    {
        public IJuegoDeCarta<CartaUno> juego { get => null; }

        public SalaCartas(IJuegoDeCarta<CartaUno> juegos) : base(juegos)
        {
          //  this.escobaQuince = escobaQuince;
        }


    }
}
