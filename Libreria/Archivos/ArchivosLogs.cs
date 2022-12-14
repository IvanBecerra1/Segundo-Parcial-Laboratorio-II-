using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Archivos
{
    /// <summary>
    /// Archivos Losgs, su funcion solo es
    /// guardar cada notificacion de la sala
    /// cada accion sera registrado en un archivo Txt
    /// </summary>
    public class ArchivosLogs
    {
        private string nombre;
        private string accion;

        public ArchivosLogs()
        {

        }
        public ArchivosLogs(string nombre, string accion)
        {
            this.nombre = nombre;
            this.accion = accion;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Accion { get => accion; set => accion = value; }

        public override string ToString()
        {
            return this.nombre + " - " + this.accion;
        }

    }
}
