using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_App.Interfaces
{
    public interface IEscobaQuinceForm
    {
        event EventHandler EventoIniciarPartida;
        event EventHandler EventoAbandonarPartida;
        event EventHandler EventoEstadisticas;

        void Show();
    }
}
