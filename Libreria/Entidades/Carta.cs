using Libreria.Enumeraciones;
using System;
using System.Runtime.InteropServices;
namespace Libreria.Entidades
{
    public class Carta
    {
        private int id;
        private static int idCount;
        private ETipoCarta palo;
        private int numeroPalo;

        public Carta()
        {
            this.id = idCount++;
        }
        public Carta(ETipoCarta palo, int numeroPalo) : this()
        {
            this.palo = palo;
            this.numeroPalo = numeroPalo;
        }

        public override string ToString()
        {
            return "id: " + this.id + " - tipo: " + this.palo.ToString() + " - Numero: " + this.numeroPalo;
        }

        public override bool Equals(object obj)
        {
            if (obj is Carta)
            {
                return (this == ((Carta)obj));
            }
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int Id { get => id; set => id = value; }
        public ETipoCarta Palo { get => palo; set => palo = value; }
        public int NumeroPalo { get => numeroPalo; set => numeroPalo = value; }

        public static bool operator ==(Carta cartaA, Carta cartaB)
        {
            return (cartaA.id == cartaB.id);
        }
        public static bool operator !=(Carta cartaA, Carta cartaB)
        {
            return !(cartaA == cartaB);
        }
    }
}
