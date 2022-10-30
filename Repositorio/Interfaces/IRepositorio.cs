using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    /// <summary>
    /// Interfaz dedicada al CRUD 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositorio<T>
    {
        public bool guardar(T entidad);

        public bool eliminar(T entidad);

        public T buscarPorId(T entidad);

        public List<T> obtenerTodo();

    }
}
