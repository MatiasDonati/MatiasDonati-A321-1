using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivo
{
    public class Texto : IArchivo
    {
        /// <summary>
        /// Guarda la lista de patentes en un archivo XML.
        /// </summary>
        /// <param name="datos">La lista de patentes a guardar.</param>
        /// <returns>True si se guardaron correctamente; de lo contrario, False.</returns>
        public bool Guardar(List<Patente> datos)
        {
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Patente>));
                using (TextWriter writer = new StreamWriter(rutaArchivo))
                {
                    serializer.Serialize(writer, datos);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Lee el archivo XML de patentes y devuelve una lista de patentes.
        /// </summary>
        /// <returns>La lista de patentes leídas desde el archivo XML.</returns>
        public List<Patente> Leer()
        {
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
            List<Patente> listaPatentes = new List<Patente>();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Patente>));
                using (FileStream fileStream = new FileStream(rutaArchivo, FileMode.Open))
                {
                    listaPatentes = (List<Patente>)serializer.Deserialize(fileStream);
                }
            }
            catch (Exception)
            {
              
            }

            return listaPatentes;
        }
    }
}
