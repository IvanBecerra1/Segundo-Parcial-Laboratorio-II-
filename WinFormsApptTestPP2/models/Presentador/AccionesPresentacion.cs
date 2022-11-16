using Libreria.Entidades;
using Modelo.Interfaces;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models.Interfaz;

namespace WinFormsApptTestPP2.models.Presentador
{
    public class AccionesPresentacion
    {
        // interfaces
        private IAcciones iAcciones;
        private IRepositorio<Jugador> iRepositorio;
        private IRepositorio<Estadisticas> iRepositorioEstadistica;

        private Jugador jugadorSeleccinado;

        public AccionesPresentacion(
            IAcciones iAcciones, 
            IRepositorio<Jugador> repositorio,
            Jugador jugador)
        {
            this.iAcciones = iAcciones;
            this.iRepositorio = repositorio;
            this.iRepositorioEstadistica = new EstadisticasRepositorio();

            this.iAcciones.EventGuardar += CatchEventGuardar;
            this.iAcciones.EventEliminar += CatchEventEliminar;
            this.jugadorSeleccinado = jugador;

            CargarTextBox();
        }

        /// <summary>
        /// Se le envia los datos a la propiedad
        /// que esta vinculada con los Text box 
        /// del formulario
        /// </summary>
        public void CargarTextBox()
        {
            this.iAcciones.IdJugador = this.jugadorSeleccinado.Id;
            this.iAcciones.TextNombre = this.jugadorSeleccinado.Nombre;
            this.iAcciones.TextAlias = this.jugadorSeleccinado.Alias;

            this.iAcciones.IdEstadistica = this.jugadorSeleccinado.Estadisticas.Id;
            this.iAcciones.TextPartidasGanadas = this.jugadorSeleccinado.Estadisticas.PartidasGanadas;
            this.iAcciones.TextPartidasAbandonadas = this.jugadorSeleccinado.Estadisticas.PartidasAbandonadas;
            this.iAcciones.TextPartidasPerdidas = this.jugadorSeleccinado.Estadisticas.PartidasPerdidas;
            this.iAcciones.TextPartidasTotal = this.jugadorSeleccinado.Estadisticas.PartidasTotales;

            this.iAcciones.PermitirModificacion = !(this.jugadorSeleccinado.Estado == Modelo.Enumeraciones.EEstadoJugador.JUGANDO);
        }

        #region eventos

        /// <summary>
        /// Evento donde se guarda el jugador editado.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void CatchEventGuardar(object? obj, EventArgs e)
        {
            try
            {
                if (this.iAcciones.PermitirModificacion == false)
                {
                    MessageBox.Show("No se puede modificar un jugador que esta jugando", "Informacio", MessageBoxButtons.OK);
                    return;
                }

                if (this.jugadorSeleccinado.Alias != this.iAcciones.TextAlias &&
                        this.iRepositorio.buscarPor(this.iAcciones.TextAlias).Alias != null)
                {
                    MessageBox.Show("Ingrese otro Alias que no este en uso", "Error", MessageBoxButtons.OK);
                    return;
                }

                this.jugadorSeleccinado.Id = this.iAcciones.IdJugador;
                this.jugadorSeleccinado.Nombre = this.iAcciones.TextNombre;
                this.jugadorSeleccinado.Alias = this.iAcciones.TextAlias;

                this.jugadorSeleccinado.Estadisticas = new Estadisticas()
                {
                    Id = this.iAcciones.IdEstadistica,
                    PartidasGanadas = this.iAcciones.TextPartidasGanadas,
                    PartidasAbandonadas = this.iAcciones.TextPartidasAbandonadas,
                    PartidasPerdidas = this.iAcciones.TextPartidasPerdidas,
                    PartidasTotales = this.iAcciones.TextPartidasTotal
                };
                this.iRepositorio.editar(this.jugadorSeleccinado);
                this.iRepositorioEstadistica.editar(this.jugadorSeleccinado.Estadisticas);

                MessageBox.Show("Se modifico el jugador", "Base de datos", MessageBoxButtons.OK);
                this.iAcciones.CerrarMenu = true;
            }
            // Excepciones, de lo especifico al mas general
            catch (FormatException)
            {
                MessageBox.Show($"Ingrese un dato numerico, en los text box", "Error", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el usuario\n{ex}", "Base de datos", MessageBoxButtons.OK);

            }
        }

        /// <summary>
        /// Evento donde se elimina el jugador seleccionado.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void CatchEventEliminar(object? obj, EventArgs e)
        {

            try
            {
                if (this.iAcciones.PermitirModificacion == false)
                {
                    MessageBox.Show("No se puede modificar un jugador que esta jugando", "Informacio", MessageBoxButtons.OK);
                    return;
                }

                this.iRepositorio.eliminar(jugadorSeleccinado);
                this.iRepositorioEstadistica.eliminar(this.jugadorSeleccinado.Estadisticas);

                MessageBox.Show("Se elimino el jugador", "Base de datos", MessageBoxButtons.OK);
                this.iAcciones.CerrarMenu = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario\n{ex}", "Base de datos", MessageBoxButtons.OK);
            }
        }
        #endregion
    }

}
