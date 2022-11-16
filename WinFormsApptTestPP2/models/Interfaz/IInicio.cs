using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2.models.Interfaz
{
    public interface IInicio
    {
        event EventHandler EventoMostrarAgregarJugador;
        event EventHandler EventoMostrarEstadistica;

        event EventHandler EventoClickCell;
        event EventHandler EventoActualizarTabla;

        public void EnlazarMenus(BindingSource enlazar);
    }
}
