using GUI_App.Interfaces;
using GUI_App.Presentacion;
using GUI_App.Vista;
using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_App.Entidades
{
    public class EscobaQuincePresentacion
    {
        private IEscobaQuinceForm escobaQuince;

        public EscobaQuincePresentacion(IEscobaQuinceForm escobaQuince)
        {
            this.escobaQuince = escobaQuince;

            this.escobaQuince.EventoIniciarPartida += IniciarPartida;
            this.escobaQuince.EventoAbandonarPartida += AbandonarPartida;
            this.escobaQuince.EventoEstadisticas += MostrarEstadisticas;

            this.escobaQuince.Show();
        }

        private void MostrarEstadisticas(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AbandonarPartida(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void IniciarPartida(object? sender, EventArgs e)
        {

            FormAgregarJugadores formAgregarJugador = new FormAgregarJugadores();
            new AgregarJugadorPresentacion(formAgregarJugador);

            formAgregarJugador.ShowDialog();

            List<Jugador> lista = formAgregarJugador.ListaJugadores;
            
        }
    }
}
