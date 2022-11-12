using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models;
using WinFormsApptTestPP2.models.Presentador;

namespace WinFormsApptTestPP2
{
    public partial class FormInicio : Form
    {
        public List<Jugador> listaJugador = new List<Jugador>();

        public delegate void EventoSala();
        public event EventoSala CatchEventMenu;

        public AgregarJugador formJugador;
        public FormInicio()
        {
            InitializeComponent();
            this.CatchEventMenu += AbrirMenuSala;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.formJugador = new AgregarJugador();
            this.formJugador.CatchEventMenu += AbrirMenuSala;
            this.formJugador.Show();
        }

        public void AbrirMenuSala()
        {
            FormJuego form = new FormJuego(formJugador.ListaJugadorEnSala);

            form.Rondas = formJugador.CantidadRonda;
            formJugador.Close();

            new FormJuegoPresentador(form);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEstadisticas form = new FormEstadisticas();
            form.Show();
        }
    }
}
