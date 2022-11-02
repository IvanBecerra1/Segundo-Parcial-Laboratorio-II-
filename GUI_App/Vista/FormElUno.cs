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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_App.Vista
{
    public partial class FormElUno : Form
    {
        private Jugador jugadorTurno;
        private Carta cartaEnMesa;
        private List<Carta> cartasEnMazo;

        public FormElUno()
        {
            this.cartaEnMesa = new Carta();
            this.cartasEnMazo = new List<Carta>();
            this.jugadorTurno = new Jugador();

            InitializeComponent();

        }

        private void IniciarlizarTurnoJugador()
        {
        //    this.listBoxCartaMazo.Items.Clear();
            this.listBoxCartaMazo.DataSource = this.cartasEnMazo;

        //    this.listBoxCartaMesa.Items.Clear();
            this.listBoxCartaMesa.Items.Add(this.cartaEnMesa);

       //     this.listBoxCartasJugador.Items.Clear();
            this.listBoxCartasJugador.DataSource = this.jugadorTurno.Cartas;

        }


        public Jugador JugadorTurno { get => jugadorTurno; set => jugadorTurno = value; }
        public Carta CartaEnMesa { get => cartaEnMesa; set => cartaEnMesa = value; }
        public List<Carta> CartasEnMazo { get => cartasEnMazo; set => cartasEnMazo = value; }



        //Singleton instancia unica
        private static FormElUno instancia;
        public static FormElUno GetInstace(Form formularioContenedor)
        {

            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new FormElUno();

                //instancia.FormBorderStyle = FormBorderStyle.None;
             //   instancia.Dock = DockStyle.Fill;
            ///    instancia.ShowDialog();
            }
            else
            {
                if (instancia.WindowState == FormWindowState.Minimized)
                    instancia.WindowState = FormWindowState.Normal;

                instancia.BringToFront();
               
            }
            instancia.ShowDialog();
            instancia.IniciarlizarTurnoJugador();

            return instancia;
        }

        private void btnPasarTurno_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnTirarCarta_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
