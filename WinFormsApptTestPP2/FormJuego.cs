using Libreria.Entidades;
using Modelo.Archivos;
using Modelo.Entidades;
using Modelo.Enumeraciones;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models;
using WinFormsApptTestPP2.models.Interfaz;

namespace WinFormsApptTestPP2
{
    public partial class FormJuego : Form, IJuego
    {
        private ArchivosTexto archivosTexto;
        private delegate void ActualizarArchivos();
        private event ActualizarArchivos EventoActualizarArchivos;
        private bool terminar;

        #region Setters
        public void setRonda(int i) => this.textBoxRondas.Text = i.ToString();
        public void setNotificacion(string value) => this.lblNotificacion.Text = value;
        public void setTextNombre(string value) => this.lblNombreJugador.Text = value;
        public void setCartaMesa(CartaUno carta)
        {
            this.listBoxCartaMesa.Items.Clear();
            this.listBoxCartaMesa.Items.Add(carta);
        }
        
        public void setMostrarCartaJugador(bool value)
        {
            this.listBoxCartaJugador.Visible = value;
            this.lblMostrarMensajeCartas.Visible = !value;
        }

        public void setArchivos(ArchivosLogs value)
        {
            this.archivosTexto.AgregarAlArchivo(value);
            this.EventoActualizarArchivos?.Invoke();// llamamos al evento actualizar
        }
        public void setTerminoRonda(bool value)
        {
            this.terminar = value;
            if (this.terminar == true)
            {
                this.Dispose(true);
                this.Close();
            };
        }
        #endregion

        #region propiedad

        // nolo uso
        public List<CartaUno> ListaCartasJugador
        {
            get; set;
        }
        public int Rondas
        {
            get {
                int ronda = int.TryParse(this.textBoxRondas.Text, out _) ? Convert.ToInt32(this.textBoxRondas.Text) : 0;
                return ronda;
            }
            set
            {
                if (this.InvokeRequired)
                    this.BeginInvoke((MethodInvoker)delegate () { setRonda(value); });
                else
                    setRonda(value);
            }
        }
       
        public CartaUno CartaMesa
        {
            get => (CartaUno)this.listBoxCartaMesa.Items[0];
            set
            {
                if (this.InvokeRequired)
                    this.BeginInvoke((MethodInvoker)delegate (){ setCartaMesa(value); });
                else
                    setCartaMesa(value);
            }
        }
        public List<CartaUno> ListaCartaMazo
        {
            get { List<CartaUno> lista = (List<CartaUno>)this.listBoxCartaMazo.DataSource; return lista; }
            set { this.listBoxCartaMazo.DataSource = value; }
        }
        public List<Jugador> ListaJugadores
        {
            get { List<Jugador> lista = (List<Jugador>)this.listBoxJugadores.DataSource; return lista; }
            set { this.listBoxJugadores.DataSource = value; }
        }
        public string Notificacion
        {
            get => this.lblNotificacion.Text;
            set
            {
                if (this.InvokeRequired)
                    this.BeginInvoke((MethodInvoker)delegate () { setNotificacion(value); });
                else
                    this.lblNotificacion.Text = value;
            }
        }
        public bool TerminoRonda
        {
            set
            {
                if (this.InvokeRequired)
                    this.BeginInvoke((MethodInvoker)delegate () { setTerminoRonda(value); }) ;
                else
                    setTerminoRonda(value);
            }
        }

        public bool MostrarCartasJugador
        {
            set
            {
                if (this.InvokeRequired)
                    this.BeginInvoke((MethodInvoker)delegate (){ setMostrarCartaJugador(value);});
                else
                    setMostrarCartaJugador(value);
            }
        }

        public ArchivosLogs Archivos {
            set
            {
                if (this.InvokeRequired)
                    this.BeginInvoke((MethodInvoker)delegate () { setArchivos(value); });
                else
                    setArchivos(value);
            }
        }

        public string textTurnoJugador 
        { 
            set
            {
                if (this.InvokeRequired)
                    this.BeginInvoke((MethodInvoker)delegate () { setTextNombre(value); });
                else
                    setTextNombre(value);
            }
        }
        #endregion


        public FormJuego()
        {
            this.archivosTexto = new ArchivosTexto();
          
            InitializeComponent();
            InicializarEventos();

            this.textBoxRondas.Text = "0";
        }
        public void InicializarEventos()
        {
            this.btnTirarCarta.Click += delegate { TirarCarta?.Invoke(this, EventArgs.Empty); };
            this.btnPasarTurno.Click += delegate { PasarTurno?.Invoke(this, EventArgs.Empty); };
            this.btnAgarrarCarta.Click += delegate { RecojerCarta?.Invoke(this, EventArgs.Empty); };
            this.btnAbandonar.Click += delegate
            {
                  abandonar?.Invoke(this, EventArgs.Empty);

                  if (this.terminar == true)
                  {
                      this.Dispose(true);
                        this.Close();
                  };
            };
            this.btnCantarUno.Click += delegate { CantarUno?.Invoke(this, EventArgs.Empty); };
            this.btnMostrarCarta.Click += delegate { BotonMostrarCarta?.Invoke(this, EventArgs.Empty); };
            this.EventoActualizarArchivos += CapturarEventoActualizarArchivos;
        }

        public event EventHandler TirarCarta;
        public event EventHandler RecojerCarta;
        public event EventHandler PasarTurno;
        public event EventHandler abandonar;
        public event EventHandler CantarUno;
        public event EventHandler VerEstadisticaJugador;
        public event EventHandler BotonMostrarCarta;

        #region Eventos

        /// <summary>
        /// Captura el evento para actualizar la lista de 
        /// mensajes del list box
        /// </summary>
        public void CapturarEventoActualizarArchivos()
        {
            this.listBoxArchivos.DataSource = this.archivosTexto.LeerArchivoLineaALinea();
        }

        private void FormJuego_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            RestablecerEstadoJugador();
            e.Cancel = false;
        }
        #endregion

        #region BindingSource
        public void cartasJugadorBindingSource(BindingSource cartasJugador)
        {
            this.listBoxCartaJugador.DataSource = cartasJugador;

            /// Aun aplicando el InvokeRequired no llega a actualizar 
            /// el binding source, dejo la porcion de codigo
            /// que habia implementado
            /*if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.listBoxCartaJugador.DataSource = cartasJugador;
                });
            }
            else
            {
                this.listBoxCartaJugador.DataSource = cartasJugador;
            }*/
        }

        public void jugadoresDataSource(List<Jugador> jugadores)
        {
            this.listBoxJugadores.DataSource = jugadores;
        }
        #endregion

        #region funciones
        public void RestablecerEstadoJugador()
        {
            JugadorRepositorio repositorioJugador = new JugadorRepositorio();

            foreach (var aux in this.ListaJugadores)
            {
                aux.Estado = EEstadoJugador.DISPONIBLE;
                repositorioJugador.editar(aux);
            }
        }
        #endregion

        public override string ToString()
        {
            return  "JUEGO UNO";
        }
    }
}
