using Modelo.Entidades;
using Libreria.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria.Entidades;

namespace GUI_App.Presentacion
{
    public class JuegoElUnoPresentacion
    {
        private Sala sala;
        private IJuegoDeCarta<CartaUno> juego;

        public JuegoElUnoPresentacion(Sala sala, IJuegoDeCarta<CartaUno> juego)
        {
            this.sala = sala;
            this.juego = juego;
        }


    }
}
