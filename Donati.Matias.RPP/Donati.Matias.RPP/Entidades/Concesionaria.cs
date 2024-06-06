using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Includes para la serializazcion
    /// </summary>
    [XmlInclude(typeof(Moto))]
    [XmlInclude(typeof(Auto))]
    [XmlInclude(typeof(Vehiculo))]
    [XmlInclude(typeof(Fabricante))]
    public class Concesionaria
    {
        private int _capacidad;
        private List<Vehiculo> _vehiculos;
        /// <summary>
        /// Constructor privado que inicializa la lista de vehiculos
        /// </summary>
        private Concesionaria() 
        {
            _vehiculos = new List<Vehiculo>();
        }

        private Concesionaria(int capacidad) : this()
        {
            _capacidad = capacidad;
        }
        /// <summary>
        /// Obtiene o establece la capacidad del vehículo.
        /// </summary>
        public int Capacidad
        {
            get
            {
                return _capacidad;
            }

            set
            {
                _capacidad = value;
            }
        }
        /// <summary>
        /// Obtiene el precio de los vehiculos de tipo Auto.
        /// </summary>
        public double PrecioDeAutos
        {
            get
            {
                return ObtenerPrecio(EVehiculo.Auto);
            }
            set
            {

            }
        }
        /// <summary>
        /// Obtiene el precio de los vehiculos de tipo Moto.
        /// </summary>
        public double PrecioDeMotos
        {
            get
            {
                return ObtenerPrecio(EVehiculo.Moto);
            }
            set
            {

            }
        }
        /// <summary>
        /// Obtiene el precio total de los vehiculos.
        /// </summary>
        public double PrecioTotal
        {
            get
            {
                return ObtenerPrecio(EVehiculo.Ambos);
            }
            set
            {

            }
        }
        /// <summary>
        /// Obtiene o establece la lista de vehiculos
        /// </summary>
        public List<Vehiculo> Vehiculos
        {
            get
            {
                return _vehiculos;
            }
            set
            {
                _vehiculos = value;
            }
        }
        /// <summary>
        /// Dependiente el tipo de vehiculo que reciba devuelve la suma de sus precios.
        /// </summary>
        /// <param name="tipoVehiculo"></param>
        /// <returns></returns>
        private double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            double total = 0;

            foreach (Vehiculo vehiculo in Vehiculos)
            {
                if (tipoVehiculo == EVehiculo.Ambos)
                {
                    total += vehiculo.Precio;
                }
                else if (vehiculo.GetType().Name == tipoVehiculo.ToString())
                {
                    total += vehiculo.Precio;
                }
            }
            return total;

        }
        /// <summary>
        /// Metodo de clase que devuelve la informacion compelta de la concesionaria pasada por parametro.
        /// </summary>
        /// <param name="concesionaria"></param>
        /// <returns></returns>
        public static string Mostrar(Concesionaria concesionaria)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Capacidad: {concesionaria.Capacidad}");
            sb.AppendLine($"Total por autos: ${concesionaria.PrecioDeAutos}");
            sb.AppendLine($"Total por motos: ${concesionaria.PrecioDeMotos}");
            sb.AppendLine($"Total: ${concesionaria.PrecioTotal}\n");
            sb.AppendLine("***********************************************");
            sb.AppendLine("            Listado de Vehiculos");
            sb.AppendLine("**********************************************");

            foreach (Vehiculo vehiculo in concesionaria.Vehiculos)
            {
                if(vehiculo is Moto moto)
                {
                    sb.AppendLine(moto.ToString());
                    sb.AppendLine();
                }
                else if(vehiculo is Auto auto)
                {
                    sb.AppendLine(auto.ToString());
                    sb.AppendLine();

                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// Retorna True Si el vehiculo pasado por parametro se encuentra en la consecionaria.
        /// </summary>
        /// <param name="concesionaria"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static bool operator == (Concesionaria concesionaria, Vehiculo vehiculo)
        {
            return concesionaria.Vehiculos.Contains(vehiculo);
        }
        /// <summary>
        /// Retorna True Si el vehiculo pasado por parametro NO se encuentra en la consecionaria.
        /// </summary>
        /// <param name="concesionaria"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static bool operator !=(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            return !(concesionaria == vehiculo);
        }
        /// <summary>
        /// Agrega un vehiculo si la concesionaria tiene capacidad y/o si el vehiculo no se encuentra en la consecionaria.
        /// Devuelve la consesionaria pasada por parametro
        /// </summary>
        /// <param name="concesionaria"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static Concesionaria operator +(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            if(concesionaria.Vehiculos.Count >= concesionaria.Capacidad)
            {
                Console.WriteLine("¡No Hay mas lugar en la concesionaria!");
            }
            else if(concesionaria == vehiculo)
            {
                Console.WriteLine("¡El vehiculo ya esta en la concesionaria!");

            }
            else
            {
                concesionaria.Vehiculos.Add(vehiculo);
            }

            return concesionaria;
        }
        /// <summary>
        /// Elimina el vehiculo pasado por parametro si la concesionaria lo tiene en su lista.
        /// Devuelve la consesionaria pasada por parametro
        /// </summary>
        /// <param name="concesionaria"></param>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public static Concesionaria operator -(Concesionaria concesionaria, Vehiculo vehiculo)
        {
            if (concesionaria != vehiculo)
            {
                Console.WriteLine("¡El vehiculo no esta en la concesionaria!");
            }
            else
            {
                concesionaria.Vehiculos.Remove(vehiculo);
            }
            
            return concesionaria;
        }
        /// <summary>
        /// Al tener los constructores privados, la instacia de Concesionaria se realiza esta conversion implicita.
        /// </summary>
        /// <param name="capacidad"></param>
        public static implicit operator Concesionaria(int capacidad)
        {
            return new Concesionaria(capacidad);
        }
        /// <summary>
        /// Metodo para guardar un archivo txt con la informacion del shopping.
        /// </summary>
        /// <param name="rutaArchivo"></param>
        public void GuardarConcesionaria(string rutaArchivo)
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
        /// <summary>
        /// Metodo para Seralizar XML la informacion del shopping.
        /// </summary>
        /// <param name="path"></param>
        public void SerializarConcesionaria(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Concesionaria));

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                xmlSerializer.Serialize(streamWriter, this);
            }
        }
        /// <summary>
        /// Metodo para Deserializar Xml.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Concesionaria DeserializarConcesionaria(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Concesionaria));

            using (StreamReader streamReader = new StreamReader(path))
            {
                return (Concesionaria)xmlSerializer.Deserialize(streamReader);
            }
        }




    }
}
