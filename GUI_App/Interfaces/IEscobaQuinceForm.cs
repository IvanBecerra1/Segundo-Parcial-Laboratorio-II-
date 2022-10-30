using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_App.Interfaces
{
    public interface IEscobaQuinceForm
    {
        // Evento de los botones principales
        event EventHandler EventoIniciarPartida;
        event EventHandler EventoAbandonarPartida;
        event EventHandler EventoEstadisticas;

        // Eventos de los paneles para las cartas
        // Seran manejados dentro de la clase Presentacion
        event EventHandler EventoPanelHuecoUno;
        event EventHandler EventoPanelHuecoDos;
        event EventHandler EventoPanelHuecoTres;
        event EventHandler EventoPanelHuecoCuatro;
        event EventHandler EventoPanelHuecoCinco;
        event EventHandler EventoPanelHuecoSeis;

        event EventHandler EventoPanelMesonUno;
        event EventHandler EventoPanelMesonDos;
        event EventHandler EventoPanelMesonTres;
        event EventHandler EventoPanelMesonCuatro;

        event EventHandler EventoPanelJugadorUno;
        event EventHandler EventoPanelJugadorDos;
        event EventHandler EventoPanelJugadorTres;

        // Evento de los botones para las acciones de cartas
        event EventHandler EventoBotonVerificarCartas;
        event EventHandler EventoBotonPasarTurno;


        void Show();
    }
}
