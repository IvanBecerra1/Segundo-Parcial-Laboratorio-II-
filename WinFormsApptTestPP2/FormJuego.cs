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
using WinFormsApptTestPP2.models.Interfaz;

namespace WinFormsApptTestPP2
{
    public partial class FormJuego : Form, IJuegoPresentador
    {

        private Jugador turnoJugador;
        private bool terminoRonda;

        private ArchivosTexto archivosTexto;

        private List<ArchivosLogs> archivosLogs;


        private delegate void ActualizarArchivos();
        private event ActualizarArchivos EventoActualizarArchivos;


        #region propiedad
        public int Rondas
        {
            get {


                int ronda = int.TryParse(this.textBoxRondas.Text, out _) ? Convert.ToInt32(this.textBoxRondas.Text) : 0;

                return ronda;
            }
            set
            {
                if (this.InvokeRequired)
                {

                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.textBoxRondas.Text = value.ToString();
                    });
                }
                else
                {
                    this.textBoxRondas.Text = value.ToString();
                }

            }
        }
        public List<CartaUno> ListaCartasJugador
        {
            get; set;
        }
        public CartaUno CartaMesa
        {
            get
            {

                //new CartaUno(Libreria.Enumeraciones.ETipoCarta.NONE,1,Modelo.Enumeraciones.ETipoColor.ROJO);
                return (CartaUno)this.listBoxCartaMesa.Items[0];
            }
            set
            {

                if (this.InvokeRequired)
                {

                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.listBoxCartaMesa.Items.Clear();
                        this.listBoxCartaMesa.Items.Add(value);
                    });
                }
                else
                {
                    this.listBoxCartaMesa.Items.Clear();
                    this.listBoxCartaMesa.Items.Add(value);
                }


            }
        }
        public List<CartaUno> ListaCartaMazo
        {
            get { List<CartaUno> lista = (List<CartaUno>)this.listBoxCartaMazo.DataSource; return lista; }
            set { this.listBoxCartaMazo.DataSource = value; }
        }
        public Jugador TurnoJugador
        {
            get
            {

                return this.turnoJugador;

            }
            set
            {

                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.turnoJugador = value;
                        this.textBox1.Text = this.turnoJugador.ToString();
                        this.lblNombreJugador.Text = this.turnoJugador.Nombre;
                    });
                }
                else
                {
                    this.turnoJugador = value;
                    this.textBox1.Text = this.turnoJugador.ToString();
                    this.lblNombreJugador.Text = this.turnoJugador.Nombre;
                }

            }
        }
        public List<Jugador> ListaJugadores
        {
            get { List<Jugador> lista = (List<Jugador>)this.listBoxJugadores.DataSource; return lista; }
            set { this.listBoxJugadores.DataSource = value; }
        }

        public string Notificacion
        {
            get
            {
                return this.lblNotificacion.Text;
            }
            set
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.lblNotificacion.Text = value;
                    });
                }
                else
                {
                    this.lblNotificacion.Text = value;
                }
            }
        }

        public bool TerminoRonda
        {
            get
            {

                return this.terminoRonda;
            }
            set
            {
                this.terminoRonda = value;

                if (this.InvokeRequired)
                {
                    

                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        if (this.terminoRonda == true)
                        {

                            this.Close();
                        }
                    });
                }
                else
                {
                    if (this.terminoRonda == true)
                    {
                        this.Close();
                    }
                }

            }
        }

        public bool MostrarCartasJugador
        {
            set
            {
                if (this.InvokeRequired)
                {

                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.listBoxCartaJugador.Visible = value;
                        this.lblMostrarMensajeCartas.Visible = !value;
                    });
                }
                else
                {
                    this.listBoxCartaJugador.Visible = value;
                    this.lblMostrarMensajeCartas.Visible = !value;
                }
            }
        }

        public ArchivosLogs Archivos {
            get
            {
                return null;
            }
            set
            {

                if (this.InvokeRequired)
                {

                    this.BeginInvoke((MethodInvoker)delegate ()
                    {

                        this.archivosTexto.AgregarAlArchivo(value);
                        this.EventoActualizarArchivos.Invoke();
                    });
                }
                else
                {

                    this.archivosTexto.AgregarAlArchivo(value);
                    this.EventoActualizarArchivos.Invoke();
                }
            }



        }
        #endregion


        public FormJuego(List<Jugador> lista)
        {
            this.turnoJugador = new Jugador();
            this.archivosTexto = new ArchivosTexto();
            this.archivosLogs = new List<ArchivosLogs>();
          
            InitializeComponent();
            InicializarEventos();

          //  CheckForIllegalCrossThreadCalls = false;

            this.textBoxRondas.Text = "0";
            this.ListaJugadores = lista;
        }
        public void InicializarEventos()
        {
            this.btnTirarCarta.Click += delegate { TirarCarta?.Invoke(this, EventArgs.Empty); };
            this.btnPasarTurno.Click += delegate { PasarTurno?.Invoke(this, EventArgs.Empty); };
            this.btnAgarrarCarta.Click += delegate { RecojerCarta?.Invoke(this, EventArgs.Empty); };
            this.btnAbandonar.Click += delegate { abandonar?.Invoke(this, EventArgs.Empty); };
            this.btnVerEstadisticaJugador.Click += delegate { VerEstadisticaJugador?.Invoke(this, EventArgs.Empty); };
            this.btnCantarUno.Click += delegate { CantarUno?.Invoke(this, EventArgs.Empty); };
            this.btnMostrarCarta.Click += delegate { BotonMostrarCarta?.Invoke(this, EventArgs.Empty); };
            this.EventoActualizarArchivos += CapturarEventoActualizarArchivos;

            //     this.FormClosing += delegate { abandonar?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler TirarCarta;
        public event EventHandler RecojerCarta;
        public event EventHandler PasarTurno;
        public event EventHandler abandonar;
        public event EventHandler CantarUno;
        public event EventHandler VerEstadisticaJugador;
        public event EventHandler BotonMostrarCarta;


        public void CapturarEventoActualizarArchivos()
        {
            this.listBoxArchivos.DataSource = archivosTexto.LeerArchivoLineaALinea();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartasJugador"></param>
        public void cartasJugadorBindingSource(BindingSource cartasJugador)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.listBoxCartaJugador.DataSource = cartasJugador;
                });
            }
            else
            {
                this.listBoxCartaJugador.DataSource = cartasJugador;
            }

        }

        private void FormJuego_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void FormJuego_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (this.terminoRonda == true)
            {
                return;
            }

            RestablecerEstadoJugador();
            e.Cancel = false;
        }

        public void RestablecerEstadoJugador()
        {
            JugadorRepositorio repositorioJugador = new JugadorRepositorio();

            foreach (var aux in this.ListaJugadores)
            {
                aux.EstaJugando = false;

                aux.Estado = EEstadoJugador.DISPONIBLE;
                repositorioJugador.editar(aux);
            }
        }
    }
}
