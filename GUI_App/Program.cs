using GUI_App.Entidades;
using GUI_App.Interfaces;
using GUI_App.Vista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_App
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            I_Inicio FormInicio = new FormInicio();
            new InicioPresentacion(FormInicio);
            Application.Run((Form)FormInicio);
        }
    }
}
