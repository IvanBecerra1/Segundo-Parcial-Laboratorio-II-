using Libreria.Entidades;
using Modelo.Entidades;
using Modelo.Repositorio;
using Modelo.Serializacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2
{
    public partial class FormPartidaTerminada : Form
    {
        private List<Jugador> listaJugadores;
        private Jugador jugadorGanador;
        private int rondas;

        private PartidaRepositorio repositorioPartida;


        public FormPartidaTerminada()
        {
            this.listaJugadores = new List<Jugador>();
            this.jugadorGanador = new Jugador();
            this.repositorioPartida = new PartidaRepositorio();

            InitializeComponent();
        }

        public List<Jugador> ListaJugadores { get => this.listaJugadores; set => this.listaJugadores = value; }
        public Jugador JugadorGanador { get => this.jugadorGanador; set => this.jugadorGanador = value; }
        public int Rondas { get => rondas; set => rondas = value; }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }

        private void FormPartidaTerminada_Load(object sender, EventArgs e)
        {
            this.listBoxJugadores.DataSource = listaJugadores;
            this.lblNombreGanador.Text = jugadorGanador.Nombre;
        }
    }
}
