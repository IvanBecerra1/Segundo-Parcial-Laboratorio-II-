using GUI_App.Presentacion;
using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_App.Vista
{
    public partial class FormSalaElUno : Form
    {
        /// <summary>
        /// Instacio el servicio
        /// el tipo de juego: jeugoCartas
        /// 
        /// </summary>
       

        public FormSalaElUno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FormAgregarJugadores formAgregarJugador = new FormAgregarJugadores();
            new AgregarJugadorPresentacion(formAgregarJugador);
            formAgregarJugador.ShowDialog();

            List<Jugador> lista = formAgregarJugador.ListaJugadores;
            FormElUno elUno = FormElUno.GetInstace(this);

            int ronda = 0;

            List<Carta> cartas = new List<Carta>() {
                new Carta(Libreria.Enumeraciones.ETipoCarta.ORO, 12),
                new Carta(Libreria.Enumeraciones.ETipoCarta.COPA, 12),
                new Carta(Libreria.Enumeraciones.ETipoCarta.BASTON, 12),
            };

            do
            {
                elUno.CartasEnMazo = cartas;
                elUno = FormElUno.GetInstace(this);


                ///elUno.JugadorTurno = //
                ///elUno.Cartas = //
                //Thread.Sleep(5000);



                ronda++;

            } while (ronda != 3);
            


        }
    }
}
