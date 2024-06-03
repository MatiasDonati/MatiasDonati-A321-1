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
        private int _capacidadMaxima;
        private List<Comercio> _comercios;

        private Shopping() 
        {
            _comercios = new List<Comercio>();
        }

        private Shopping(int capacidadMaxima) 
            : this ()
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
                _capacidadMaxima = value;

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
            sb.AppendLine($"\nCapacidad del Shopping: {shopping.CapacidadMaxima}");
            sb.AppendLine($"Total por Importadores: ${shopping.PrecioDeImportadores}");
            sb.AppendLine($"Total por Exportadores: ${shopping.PrecioDeExportadores}");
            sb.AppendLine($"Total: ${shopping.PrecioTotal}");
            sb.AppendLine("*****************************************");
            sb.AppendLine("Listado de Comercios");
            sb.AppendLine("*****************************************");

            foreach(Comercio comercio in shopping.Comercios)
            {
                if (comercio is Exportador exportador)
                {
                    sb.AppendLine(exportador.Mostrar());
                }
                else if(comercio is Importador importador)
                {
                    sb.AppendLine(importador.Mostrar());
                }

            }

            return sb.ToString();
        }

        public static implicit operator Shopping(int capacidad)
        {
            return new Shopping(capacidad);
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
            if(shopping.Comercios.Count >= shopping.CapacidadMaxima)
            {
                Console.WriteLine("No hay mas lugar en el Shopping!!!");
            }
            else if(shopping == comercio)
            {
                Console.WriteLine("El comercio ya esta en el Shopping");
            }
            else
            {
                shopping.Comercios.Add(comercio);
            }
            return shopping;
        }

        private double ObtenerPrecio(EComercios tipo)
        {
            double total = 0;

            foreach (Comercio comercio in Comercios)
            {
                if (tipo == EComercios.Ambos)
                {
                    total += comercio.PrecioAlquiler;
                }
                else if(comercio.GetType().Name == tipo.ToString())
                {
                    total += comercio.PrecioAlquiler;
                }

            }
            return total;
        }

        public void GuardarShopping(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                using (FileStream filestream = File.Create(rutaArchivo))
                {
                    filestream.Close();
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
