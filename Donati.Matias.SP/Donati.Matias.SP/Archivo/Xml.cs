using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivo
{
    public class Xml : IArchivo
    {
        /// <summary>
        /// Guardar archixo Xml en el escritorio
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(List<Patente> datos)
        {
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
            try
            {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Patente>));
                    serializer.Serialize(fs, datos);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Leer archivo xml
        /// </summary>
        /// <returns></returns>
        public List<Patente> Leer()
        {
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "patentes.xml");
            List<Patente> listaPatentes = new List<Patente>();

            try
            {
                using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Patente>));
                    listaPatentes = (List<Patente>)serializer.Deserialize(fs);
                }
            }
            catch (Exception)
            {
               

            }

            return listaPatentes;
        }
    }
}
