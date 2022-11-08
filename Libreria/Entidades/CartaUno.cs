using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.Entidades;
using Libreria.Enumeraciones;
using Modelo.Enumeraciones;

namespace Modelo.Entidades
{
    public class CartaUno : Carta
    {
        private ETipoColor color;
        private bool accion;

        public CartaUno(ETipoCarta tipo, int numero, ETipoColor color)
            : base(tipo, numero)
        {
            this.color = color;
        }

        public override string ToString()
        {
            return base.ToString() + " - Color: " + this.color.ToString();
        }
        public ETipoColor Color { get => color; set => color = value; }
        public bool Accion { get => accion; set => accion = value; }
    }
}
