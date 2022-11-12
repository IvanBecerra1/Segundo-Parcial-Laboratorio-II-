using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2.models.Interfaz
{
    public interface IEstadistica
    {
        public event EventHandler EventoClickComboBox;

        public void EnlazarJugadorBindigSource(BindingSource jugadorBindingSource);
        public void EnlazarPartidaBindigSource(BindingSource partidaBindingSource);
        public void EnlazarTopBindigSource(BindingSource topBindingSource);
    }
}
