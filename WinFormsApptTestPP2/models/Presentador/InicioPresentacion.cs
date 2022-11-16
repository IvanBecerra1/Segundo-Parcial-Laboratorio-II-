using Libreria.Entidades;
using Modelo.DTO;
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
    /// Clase destinada que sera la separacion
    /// entre la Vista (windows Form) y la logica de las entidades
    /// Aca se manejaria toda las funciones que se implementan en la vista
    /// pero logrando una separacion con las interfaces 
    /// </summary>
    public class InicioPresentacion
    {

        // interfaz
        private IInicio inicioPresentacion;
        private BindingSource formBindingSource;

        private List<FormDTO> listaForm = new List<FormDTO>();

        public InicioPresentacion(IInicio inicioPresentacion)
        {
            this.inicioPresentacion = inicioPresentacion;

            this.formBindingSource = new BindingSource();

            // Asociacion de eventos
            this.inicioPresentacion.EventoMostrarAgregarJugador += CatchEventoAgregarJugador;
            this.inicioPresentacion.EventoMostrarEstadistica += CatchEventoMostrarEstadistica;
            this.inicioPresentacion.EventoClickCell += CatchEvent;
            this.inicioPresentacion.EventoActualizarTabla += CatchActualizarTabla;

            //Enlazar bindingSource
            this.inicioPresentacion.EnlazarMenus(this.formBindingSource);
        }

        #region Captura de eventos

        /// <summary>
        /// Evento para cuando se hace click en el DataGrid
        /// su funcionalidad es abrir el formulario/sala
        /// que se seleccione.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CatchEvent(object? sender, EventArgs e)
        {

            FormDTO formDTO = (FormDTO)this.formBindingSource.Current;
            FormJuego formJuegoSala = (FormJuego)formDTO.Form;

            if (formJuegoSala.IsDisposed)
            {
                this.formBindingSource.Remove(this.formBindingSource.Current);
                this.formBindingSource.ResetBindings(true);

                MessageBox.Show("La sala seleccionada ya no esta disponible", "Centro de salas");
                return;
            }

            if (formJuegoSala.WindowState == FormWindowState.Minimized)
                formJuegoSala.WindowState = FormWindowState.Normal;

            formJuegoSala.Show();

            formJuegoSala.BringToFront();

            //   ((FormJuego)this.formBindingSource.Current).Show();
        }
        /// <summary>
        /// Evento al abrir el formulario de
        /// registrar/agregar jugadores en la sala
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
        /// Evento para Abrir el formulario
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
        /// Metodo para abrir el menu de sala
        /// </summary>
        private void AbrirMenuSala(AgregarJugador formJugador)
        {
            IJuego form = new FormJuego();
            form.ListaJugadores = formJugador.ListaJugadorEnSala;

           // FormJuego form = new FormJuego(formJugador.ListaJugadorEnSala);
            form.Rondas = formJugador.Ronda;
            new FormJuegoPresentador(form);
            
            FormDTO formDTO = new FormDTO(((FormJuego)form), form.ListaJugadores.Count);
            this.listaForm.Add(formDTO);
            /*((FormJuego)form).BringToFront();
            ((FormJuego)form).ShowDialog();
            */
        }

        /// <summary>
        /// Evento para actualizar la Tabla
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void CatchActualizarTabla(Object?obj, EventArgs e)
        {
            this.formBindingSource.DataSource = this.listaForm;
            this.formBindingSource.ResetBindings(true);
        }
        #endregion
    }
}
