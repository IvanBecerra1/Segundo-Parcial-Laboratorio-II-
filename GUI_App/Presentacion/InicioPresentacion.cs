using System;
using System.Collections.Generic;
using GUI_App.Interfaces;
using GUI_App.Presentacion;
using GUI_App.Vista;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Servicios;
using Modelo.Servicios;

namespace GUI_App.Entidades
{
    public class InicioPresentacion
    {
        private I_Inicio I_Inicio;

        public InicioPresentacion(I_Inicio i_Inicio)
        {
            this.I_Inicio = i_Inicio;
            this.I_Inicio.MostrarJuegoCartas += AbrirFormInicio;
        }


        private void AbrirFormInicio(object sender, EventArgs e)
        {

            /*   EscobaQuinceServicio escobaQuinceServicio = new EscobaQuinceServicio();

            //Por el momento va tener 4 Rondas;
            Sala sala = new SalaCartas(4, escobaQuinceServicio);

            FormEscobaQuince formJuegoCartas = new FormEscobaQuince();
            new EscobaQuincePresentacion(formJuegoCartas, (SalaCartas)sala);*/


            /*   FormAgregarJugadores formAgregarJugador = new FormAgregarJugadores();
               new AgregarJugadorPresentacion(formAgregarJugador);

               formAgregarJugador.ShowDialog();

               List<Jugador> lista = formAgregarJugador.ListaJugadores;
            */
         
            /*UnoServicio elUnoJuego = new UnoServicio();
            Sala sala = new SalaCartas(4, elUnoJuego);

            FormElUno formJuegoCartas = new FormElUno();
            new JuegoElUnoPresentacion((SalaCartas)sala, elUnoJuego);
            formJuegoCartas.Show();
            */

            FormSalaElUno salaUno = new FormSalaElUno();
            salaUno.Show();


            // this.sala.CargarJugadores(3);
        }

    }
}
