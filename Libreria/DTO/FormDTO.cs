using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Modelo.DTO
{
    public class FormDTO
    {
        private int sala;
        private static int salaCount;
        private int cantidadJugador;
        private Object form;

        public int Sala { get => sala; set => sala = value; }
        public static int SalaCount { get => salaCount; set => salaCount = value; }
        public object Form { get => form; set => form = value; }
        public int CantidadJugador { get => cantidadJugador; set => cantidadJugador = value; }

        public FormDTO(object form, int cantidadJugador)
        {
            this.sala = FormDTO.salaCount++;
            this.form = form;
            this.cantidadJugador = cantidadJugador;
        }
    }
}
