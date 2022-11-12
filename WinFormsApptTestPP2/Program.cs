using Libreria.Entidades;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApptTestPP2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            JugadorRepositorio repositorio = new JugadorRepositorio();

            List<Jugador> lista = new List<Jugador>();

            lista = repositorio.obtenerTodo();

            foreach (var aux in lista)
            {
                aux.Estado = Modelo.Enumeraciones.EEstadoJugador.DISPONIBLE;
                repositorio.editar(aux);
            }



            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormInicio());
        }
    }
}
