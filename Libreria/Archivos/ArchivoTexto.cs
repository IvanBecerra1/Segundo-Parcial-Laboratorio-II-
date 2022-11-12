using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Archivos
{
    public class ArchivosTexto
    {

        public StreamWriter sw;
        public StreamReader sr;
        public string path;

        public static int idCount;
        public int id;

        public ArchivosTexto()
        {
            this.id = ArchivosTexto.idCount++;

            if (!Directory.Exists("..\\Archivos_texto"))
            {
                Directory.CreateDirectory("..\\Archivos_texto");
            }
            GenerarPathUnico();
        }

        public void GenerarPathUnico()
        {
            string pathGenerado = "";
            string letras = "abcdefghi";
            string numeros = "123456789";

            Random randomNum = new Random();
            do
            {
                pathGenerado += letras[randomNum.Next(0,letras.Length-1)];
                pathGenerado += numeros[randomNum.Next(0, numeros.Length-1)];
            } while (pathGenerado.Length < 5);

            pathGenerado += $"_{DateTime.Now.ToString("dd-MM-yyyy")}_partida_logs.txt";

            this.path = $"..\\Archivos_texto\\{pathGenerado}";

            if (File.Exists(this.path))
            {
                GenerarPathUnico();
            }
        }

        public bool AgregarAlArchivo(ArchivosLogs logs)
        {
            bool agrego = false;

            try
            {
                this.sw = new StreamWriter(this.path, true);
                this.sw.WriteLine(logs.ToString());
                agrego = true;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
            finally
            {
                if (this.sw != null)
                    this.sw.Close();
            }

            return agrego;
        }

        public List<ArchivosLogs> LeerArchivoLineaALinea()
        {
            string retorno = "";
            List<ArchivosLogs> listaLogs = new List<ArchivosLogs>();
            try
            {
                using (this.sr = new StreamReader(this.path))
                {
                    while ((retorno = this.sr.ReadLine()) != null)
                    {
                        string[] logs = retorno.Split(" - ");

                        ArchivosLogs p = new ArchivosLogs(logs[0], logs[1]);

                        listaLogs.Add(p);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            listaLogs.Reverse();
            return listaLogs;
        }

        public string LeerArchivoHastaElFinal()
        {
            string retorno = "";
            try
            {
                using (this.sr = new StreamReader(this.path))
                {
                    retorno = this.sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }

            return retorno;
        }
    }
}
