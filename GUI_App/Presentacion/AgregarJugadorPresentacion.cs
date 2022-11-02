using GUI_App.Interfaces;
using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_App.Presentacion
{
    public class AgregarJugadorPresentacion
    {
        private IAgregarJugadoresForm agregarJugadores;
        private BindingSource jugadoresBindingSource;

        public AgregarJugadorPresentacion(IAgregarJugadoresForm agregarJugadores)
        {
            this.jugadoresBindingSource = new BindingSource();

            this.agregarJugadores = agregarJugadores;

            this.agregarJugadores.EventoAgregarJugador += AgregarJugador;


            this.agregarJugadores.AgregarJugadoresBindigSource(this.jugadoresBindingSource);

        }

        private void AgregarJugador(object? sender, EventArgs e)
        {
            if (this.agregarJugadores.TextNombre.Any() == false)
            {
                return;
            }

            Jugador jugador = new Jugador();
            jugador.Nombre = this.agregarJugadores.TextNombre;
            this.jugadoresBindingSource.Add(jugador);
        }
    }
}
