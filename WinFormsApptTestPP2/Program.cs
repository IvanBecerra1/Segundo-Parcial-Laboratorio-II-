using Libreria.Entidades;
using Modelo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApptTestPP2.models.Interfaz;
using WinFormsApptTestPP2.models.Presentador;

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

            /*
             
             
            IterfazTest iterfazTest = new Form1();

            new Form1Presentador(iterfazTest);

            Application.Run((Form1)iterfazTest);
             */


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            IInicio inicioPresentacion = new FormInicio();
            new InicioPresentacion(inicioPresentacion);

            Application.Run( (FormInicio)inicioPresentacion );

            // Application.Run(new FormInicio());
        }
    }
}
