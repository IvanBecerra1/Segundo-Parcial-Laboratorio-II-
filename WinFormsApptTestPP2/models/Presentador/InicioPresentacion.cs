using Libreria.Entidades;
using Modelo.Entidades;
using Modelo.Interfaces;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models.Interfaz;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApptTestPP2.models.Presentador
{

    /// <summary>
    /// Principio de Inyeccion de dependencias
    /// </summary>
    public class InicioPresentacion
    {

        private IInicio inicioPresentacion;

        // Formulario
        private AgregarJugador formJugador;

        public InicioPresentacion(IInicio inicioPresentacion)
        {
            this.inicioPresentacion = inicioPresentacion;
            
            this.inicioPresentacion.EventoMostrarAgregarJugador += CatchEventoAgregarJugador;
            this.inicioPresentacion.EventoMostrarEstadistica += CatchEventoMostrarEstadistica;
        }

        #region Captura de eventos
        
        /// <summary>
        /// Evento al abrir el formulario 
        /// para registrar/agregar jugadores en la sala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatchEventoAgregarJugador(object? sender, EventArgs e)
        {
            var tareas = Task.Run(() =>
            {
                AgregarJugador formJugador2 = new AgregarJugador();
                IRepositorio<Jugador> iRepositorio = new JugadorRepositorio();
                new AgregarJugadoresPresentador(formJugador2, iRepositorio);
             //   formJugador2.CatchEventMenu += AbrirMenuSala; // enviamos el metodo al delegado

                formJugador2.ShowDialog();

                if (formJugador2.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    AbrirMenuSala(formJugador2);
                }
            });

        }

        /// <summary>
        /// Evento para brir el formulario
        /// de estadistica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatchEventoMostrarEstadistica(object? sender, EventArgs e)
        {
            IEstadistica iForm = FormEstadisticas.InstanciaUnica(); // llamamos al metodo Singleton
            IRepositorio<Partida> iRepositorio = new PartidaRepositorio();
            new EstadisticaPresentador(iForm, iRepositorio);
            
            ((FormEstadisticas)iForm).Show();
        }

        /// <summary>
        /// Evento para abrir el menu de sala
        /// </summary>
        private void AbrirMenuSala(AgregarJugador formJugador)
        {
            FormJuego form = new FormJuego(formJugador.ListaJugadorEnSala);
            form.Rondas = formJugador.Ronda;

            new FormJuegoPresentador(form);
            form.BringToFront();
            form.ShowDialog();
        }
        #endregion
    }
}
