using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2.models.Interfaz
{
    public interface IAgregarJugador
    {
        public event EventHandler EventoRegistrarJugador;
        public event EventHandler EventoIniciarPartida;
        public event EventHandler EventoQuitarJugador;
        public event EventHandler EventoAgregarJugador;
        public event EventHandler EventAcciones;

        public string TextNombre
        {
            get;
            set;
        }

        public string TextAlias
        {
            get;
            set;
        }

        public int Ronda
        {
            get;
            set;
        }

        public bool SalaValida
        {
            get;
            set;
        }

        public void EnlazarJugadoresBindingSource(BindingSource jugadores);
        public void EnlazarJugadorSalaBindingSource(BindingSource jugadorSala);
    }
}
