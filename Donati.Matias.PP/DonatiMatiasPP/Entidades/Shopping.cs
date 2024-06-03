using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Importador))]
    [XmlInclude(typeof(Exportador))]
    [XmlInclude(typeof(Comerciante))]
    [XmlInclude(typeof(Comercio))]

    public class Shopping
    {
        private static int _capacidadMaxima;
        private List<Comercio> _comercios;

        private Shopping()
        {
            _comercios = new List<Comercio>();
        }

        private Shopping(int capacidadMaxima) :this()
        {
            _capacidadMaxima = capacidadMaxima;
        }

        public int CapacidadMaxima
        {
            get
            {
                return _capacidadMaxima;
            }
            set
            {

            }
        }

        public List<Comercio> Comercios
        {
            get
            {
                return _comercios;
            }
            set
            {

            }
        }

        public double PrecioDeExportadores
        {
            get 
            {

                return ObtenerPrecio(EComercios.Exportador);
            }
            set
            {

            }
        }

        public double PrecioDeImportadores 
        {
            get
            {
                return ObtenerPrecio(EComercios.Importador);
            }
            set
            {

            }
        }

        public double PrecioTotal
        {
            get
            {
                return ObtenerPrecio(EComercios.Ambos);
            }
            set
            {

            }
        }
        
        public static string Mostrar(Shopping shopping)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"Capacidad maxima: {shopping.CapacidadMaxima}");
            sb.AppendLine($"Total por Importadores: ${shopping.PrecioDeImportadores}");
            sb.AppendLine($"Total por Exportadores: ${shopping.PrecioDeExportadores}");
            sb.AppendLine($"*****************************************");
            sb.AppendLine($"Listado de Comercios");
            sb.AppendLine($"*****************************************");

            foreach (Comercio comercio in shopping._comercios)
            {
                if(comercio is Exportador exportador)
                {
                    sb.AppendLine(exportador.Mostrar());
                }else if(comercio is Importador importador)
                {
                    sb.AppendLine(importador.Mostrar());

                }
                //   sb.AppendLine((string)comercio);

            }

            return sb.ToString();
        }

        public static implicit operator Shopping(int capacidad)
        {

            Shopping shopping = new Shopping(capacidad);
            return shopping;
        }

        public static bool operator ==(Shopping shopping, Comercio comercio)
        {
            return shopping.Comercios.Contains(comercio);
        }
        public static bool operator !=(Shopping shopping, Comercio comercio)
        {
            return !(shopping == comercio);
        }

        public static Shopping operator +(Shopping shopping, Comercio comercio)
        {
            if(shopping._comercios.Count < shopping.CapacidadMaxima && shopping != comercio)
            {
                shopping._comercios.Add(comercio);
                return shopping;
            }
            Console.WriteLine("NO HAY MAS LUGAR EN EL SHOPPING");
            return shopping;
        }

        private double ObtenerPrecio(EComercios tipo)
        {
            double valorAlquileres = 0;

            foreach (Comercio comercio in _comercios)
            {
                if (tipo == EComercios.Ambos)
                {
                    valorAlquileres += comercio.PrecioAlquiler;
                }
                else if(comercio.GetType().Name == tipo.ToString())
                {
                    valorAlquileres += comercio.PrecioAlquiler;
                }
            }
            return valorAlquileres;
        }

        public void GuardarShopping(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {
                    fileStream.Close();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                streamWriter.WriteLine(Mostrar(this));
            }
        }
        public void SerializarShopping(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                xmlSerializer.Serialize(streamWriter, this);
            }
        }

        public static Shopping DeserializarShopping(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));

            using (StreamReader streamReader = new StreamReader(path))
            {
                return (Shopping)xmlSerializer.Deserialize(streamReader);
            }
        }


    }
}
