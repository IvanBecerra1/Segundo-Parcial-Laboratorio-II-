using Libreria.Entidades;
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

namespace WinFormsApptTestPP2
{
    public partial class FormAcciones : Form, IAcciones
    {
        //Delegados
        private delegate void DelegadoPermitirAcciones();
        private delegate void DelegadoCerrarMenu();
        
        //Eventos
        private event DelegadoCerrarMenu EventCerrarMenu;
        private event DelegadoPermitirAcciones EventPermitirAcciones;

        //Eventos de Interfaz
        public event EventHandler EventGuardar;
        public event EventHandler EventEliminar;


        private bool cerrarMenu;
        private bool permitirEditar;

        private int idJugador;// No lo uso, borrar
        private int idEstadistica; // no lo uso, borrar

        public FormAcciones()
        {
            InitializeComponent();

            this.EventCerrarMenu += CatchCerrarMenu;
            this.EventPermitirAcciones += CatchPermitirAcciones;

            this.btnSalir.Click += delegate
            {
                this.DialogResult = DialogResult.Cancel;
            };

            this.btnEliminar.Click += delegate
            {
                this.EventEliminar?.Invoke(this, EventArgs.Empty);
                this.EventCerrarMenu?.Invoke();

            };

            this.btnEditar.Click += delegate
            {
                this.EventGuardar?.Invoke(this, EventArgs.Empty);
                this.EventCerrarMenu?.Invoke();
            };
        }

        #region Propiedades
        public string TextNombre
        {
            get => this.textBoxNombre.Text;
            set => this.textBoxNombre.Text = value;
        }
        public string TextAlias
        {
            get => this.textBoxAlias.Text;
            set => this.textBoxAlias.Text = value;
        }
        public int TextPartidasGanadas
        {
            get => int.Parse(this.txtPartidasGanadas.Text);
            set => this.txtPartidasGanadas.Text = value.ToString();
        }
        public int TextPartidasPerdidas
        {
            get => int.Parse(this.txtPartidasPerdidas.Text);
            set => this.txtPartidasPerdidas.Text = value.ToString();
        }
        public int TextPartidasTotal
        {
            get => int.Parse(this.txtPartidasTotales.Text);
            set => this.txtPartidasTotales.Text = value.ToString();
        }
        public int TextPartidasAbandonadas
        {
            get => int.Parse(this.txtPartidasAbandonadas.Text);
            set => this.txtPartidasAbandonadas.Text = value.ToString();
        }

        public bool PermitirModificacion
        {
            get => this.permitirEditar;
            set
            {
                this.permitirEditar = value;
                this.EventPermitirAcciones?.Invoke();
            }
        }
        public bool CerrarMenu
        {
            get => this.cerrarMenu;
            set => this.cerrarMenu = value;
        }
        public int IdEstadistica
        {
            get => idEstadistica;
            set => idEstadistica = value;
        }
        public int IdJugador
        {
            get => idJugador;
            set => idJugador = value;
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Cierra el menu
        /// </summary>
        public void CatchCerrarMenu()
        {
            if (cerrarMenu == true)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// Bloquea los textbox dependiendo la condicon
        /// si puede modificar o no
        /// </summary>
        public void CatchPermitirAcciones()
        {
            this.textBoxAlias.Enabled = this.permitirEditar;
            this.textBoxNombre.Enabled = this.permitirEditar;
            this.txtPartidasAbandonadas.Enabled = this.permitirEditar;
            this.txtPartidasGanadas.Enabled = this.permitirEditar;
            this.txtPartidasPerdidas.Enabled = this.permitirEditar;
            this.txtPartidasTotales.Enabled = this.permitirEditar;
        }
        #endregion

    }
}
