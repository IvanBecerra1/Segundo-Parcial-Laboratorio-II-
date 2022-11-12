using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Entidades
{
    static class StringExtension
    {
        /// <summary>
        /// Funcionalidad que permite convertir un string a enum
        /// </summary>
        /// <typeparam name="T">Tipo de dato</typeparam>
        /// <param name="param">parametro</param>
        /// <returns>Enum convertido</returns>
        public static T ConvertirEnum<T>(this string param)
        {
            return (T)Enum.Parse(typeof(T), param, true);
        }
    }
}
