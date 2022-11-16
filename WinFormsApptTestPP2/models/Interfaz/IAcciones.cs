using Libreria.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2.models.Interfaz
{
    public interface IAcciones
    {
        public event EventHandler EventGuardar;
        public event EventHandler EventEliminar;

        public int IdEstadistica
        {
            get;
            set;
        }
        public int IdJugador
        {
            get;
            set;
        }



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

        public int TextPartidasGanadas
        {
            get;
            set;

        }

        public int TextPartidasPerdidas
        {
            get;
            set;
        }

        public int TextPartidasTotal
        {
            get;
            set;
        }

        public int TextPartidasAbandonadas
        {
            get;
            set;
        }

        public bool PermitirModificacion
        {
            get;
            set;
        }

        public bool CerrarMenu
        {
            get;
            set;
        }
    }
}
