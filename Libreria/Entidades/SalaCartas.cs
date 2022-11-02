using Libreria.Interfaces;
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
        public IJuegoDeCarta<Carta> juego { get => base.juego; }

        public SalaCartas(int rondas, IJuegoDeCarta<Carta> juegos) : base(rondas, juegos)
        {
          //  this.escobaQuince = escobaQuince;
        }


    }
}
