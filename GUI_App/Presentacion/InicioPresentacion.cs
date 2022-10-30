using System;
using GUI_App.Interfaces;
using GUI_App.Vista;

namespace GUI_App.Entidades
{
    public class InicioPresentacion
    {
        private I_Inicio I_Inicio;

        public InicioPresentacion(I_Inicio i_Inicio)
        {
            I_Inicio = i_Inicio;

            this.I_Inicio.MostrarJuegoCartas += AbrirFormInicio;
        }


        private void AbrirFormInicio(object sender, EventArgs e)
        {
            FormEscobaQuince formJuegoCartas = new FormEscobaQuince();
            new EscobaQuincePresentacion(formJuegoCartas);
        }

    }
}
