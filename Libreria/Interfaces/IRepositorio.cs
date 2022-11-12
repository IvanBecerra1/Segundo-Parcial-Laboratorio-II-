using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Interfaces
{
    /// <summary>
    /// Interfaz dedicada al CRUD 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorio<T>
    {
        public bool guardar(T entidad);

        public bool eliminar(T entidad);

        public bool editar(T entidad);

        public T buscarPor(string dato);

        public List<T> obtenerTodo();

    }
}
