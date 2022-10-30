using System;
using GUI_App.Interfaces;
using GUI_App.Vista;
using Libreria.Entidades;
using Libreria.Interfaces;
using Libreria.Servicios;

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
            
            EscobaQuinceServicio escobaQuinceServicio = new EscobaQuinceServicio();

            //Por el momento va tener 4 Rondas;
            Sala sala = new SalaCartas(4, escobaQuinceServicio, escobaQuinceServicio);

            FormEscobaQuince formJuegoCartas = new FormEscobaQuince();
            new EscobaQuincePresentacion(formJuegoCartas, (SalaCartas)sala);
        }

    }
}
