using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Modelo.Entidades;

namespace Modelo.Serializacion
{
    /// <summary>
    /// Serializacion de las cartas Uno
    /// </summary>
    public static class SerializacionJSON
    {

        public static StreamWriter writer;
        public static StreamReader reader;
        public static string path;

        static SerializacionJSON()
        {
            if (!Directory.Exists($"..\\CartasJSON"))
            {
                Directory.CreateDirectory("..\\CartasJSON");
            }

            SerializacionJSON.path = $"..\\CartasJSON\\cartas_json.json";
        }

        public static bool ExisteDirectorio()
        {
            return File.Exists(SerializacionJSON.path);
        }

        public static bool SerializarJSON(Stack<CartaUno> cartas)
        {
            bool retorno = false;
            try
            {
                using (SerializacionJSON.writer = new StreamWriter(SerializacionJSON.path))
                {

                    string json = JsonSerializer.Serialize(cartas);

                    SerializacionJSON.writer.Write(json);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retorno;
        }

        public static Stack<CartaUno> DeserializarJSON()
        {
            Stack<CartaUno> aux = new Stack<CartaUno>();
            try
            {
                using (SerializacionJSON.reader = new StreamReader(SerializacionJSON.path))
                {
                    string json = SerializacionJSON.reader.ReadToEnd();

                    aux = JsonSerializer.Deserialize<Stack<CartaUno>>(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return aux;
        }

    }
}
