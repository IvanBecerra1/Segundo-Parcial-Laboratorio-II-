using GUI_App.Interfaces;
using GUI_App.Presentacion;
using GUI_App.Vista;
using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GUI_App.Entidades
{
    public class EscobaQuincePresentacion
    {
        private IEscobaQuinceForm escobaQuinceForm;
        private SalaCartas sala;

        public EscobaQuincePresentacion(IEscobaQuinceForm escobaQuince, SalaCartas sala)
        {
            this.escobaQuinceForm = escobaQuince;

            this.escobaQuinceForm.EventoIniciarPartida += IniciarPartida;
            this.escobaQuinceForm.EventoAbandonarPartida += AbandonarPartida;
            this.escobaQuinceForm.EventoEstadisticas += MostrarEstadisticas;

            this.escobaQuinceForm.EventoPanelHuecoUno += PanelHuecoUno;
            this.escobaQuinceForm.EventoPanelHuecoDos += PanelHuecoDos;
            this.escobaQuinceForm.EventoPanelHuecoTres += PanelHuecoTres;
            this.escobaQuinceForm.EventoPanelHuecoCuatro += PanelHuecoCuatro;
            this.escobaQuinceForm.EventoPanelHuecoCinco += PanelHuecoCinco;
            this.escobaQuinceForm.EventoPanelHuecoSeis += PanelHuecoSeis;

            /*
             * 
            this.escobaQuinceForm.EventoPanelMesonUno;
            this.escobaQuinceForm.EventoPanelMesonDos;
            this.escobaQuinceForm.EventoPanelMesonTres;
            this.escobaQuinceForm.EventoPanelMesonCuatro;
            this.escobaQuinceForm.
            this.escobaQuinceForm.EventoPanelJugadorUno;
            this.escobaQuinceForm.EventoPanelJugadorDos;
            this.escobaQuinceForm.EventoPanelJugadorTres;
            this.escobaQuinceForm.
          //  this.escobaQuinceForm.tones para las acciones de cartas
            this.escobaQuinceForm.EventoBotonVerificarCartas;
            this.escobaQuinceForm.EventoBotonPasarTurno;

             */


            this.escobaQuinceForm.Show();
            this.sala = sala;
        }
        private void PanelHuecoSeis(object? sender, EventArgs e)
        {

            throw new NotImplementedException();
        }
        private void PanelHuecoCinco(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void PanelHuecoCuatro(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void PanelHuecoTres(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PanelHuecoDos(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PanelHuecoUno(object? sender, EventArgs e)
        {


        }



        #region Eventos
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

      //      this.sala.CargarJugadores(3);

        }
        #endregion

    }
}
