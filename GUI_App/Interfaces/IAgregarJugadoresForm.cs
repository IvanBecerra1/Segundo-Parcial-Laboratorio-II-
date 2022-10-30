using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_App.Interfaces
{
    public interface IAgregarJugadoresForm
    {
        public String TextNombre { get; set; }
        public List<Jugador> ListaJugadores { get; }

        public event EventHandler EventoAceptar;
        public event EventHandler EventoAgregarJugador;

        public void AgregarJugadoresBindigSource(BindingSource listaJugadores);
     
    }
}
