using Libreria.Entidades;
using Modelo.DTO;
using Modelo.Entidades;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models.Interfaz;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApptTestPP2
{
    public partial class FormEstadisticas : Form, IEstadistica
    {
        private static FormEstadisticas formInstancia;
        public event EventHandler EventoClickComboBox;
        public FormEstadisticas()
        {
            InitializeComponent();

            this.dataGridPartida.CellClick += delegate
            {
                this.EventoClickComboBox?.Invoke(this, EventArgs.Empty);
            };

            this.btnSalirEstadistica.Click += delegate
            {
                this.Close();
            };
        }

        /// <summary>
        /// Enlaze de control con BindingSource
        /// </summary>
        /// <param name="jugadorBindingSource"></param>
        public void EnlazarJugadorBindigSource(BindingSource jugadorBindingSource)
        {
            this.dataGridViewJugador.DataSource = jugadorBindingSource;
        }
        public void EnlazarPartidaBindigSource(BindingSource partidaBindingSource)
        {
            this.dataGridPartida.DataSource = partidaBindingSource;
        }
        public void EnlazarTopBindigSource(BindingSource topBindingSource)
        {
            this.dataGridViewTop.DataSource = topBindingSource;
        }

        /// <summary>
        /// Patron de diseño: Singleton
        /// Para evitar que el formulario Estadistica sea instanciado
        /// mas de una vez y que solo exista una unica instancia de ella.
        /// </summary>
        /// <returns>de vuelve la instancia</returns>
        public static FormEstadisticas InstanciaUnica()
        {
            // Si el form esta cerrado / no instanciado
            if (FormEstadisticas.formInstancia == null || FormEstadisticas.formInstancia.IsDisposed)
            {
                // instanciamos una
                FormEstadisticas.formInstancia = new FormEstadisticas();
            }
            else // si no, volvemos a traer el formulario
            {
                /// por si la ventana esta minimizada
                if (FormEstadisticas.formInstancia.WindowState == FormWindowState.Minimized)
                    FormEstadisticas.formInstancia.WindowState = FormWindowState.Normal;

                FormEstadisticas.formInstancia.BringToFront(); // Trae como vista principal
            }
            return FormEstadisticas.formInstancia; // Devolvemos la instancia
        }

    }
}
