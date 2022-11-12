using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApptTestPP2.models.Interfaz
{
    public interface IInicio
    {
        event EventHandler EventoMostrarAgregarJugador;
        event EventHandler EventoMostrarEstadistica;
    }
}
