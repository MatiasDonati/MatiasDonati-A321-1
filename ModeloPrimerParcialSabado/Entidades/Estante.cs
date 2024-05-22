using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Harina))]
    [XmlInclude(typeof(Jugo))]
    [XmlInclude(typeof(Gaseosa))]
    [XmlInclude(typeof(Galletita))]
    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        private Estante()
        {
            _productos = new List<Producto>();
        }

        public Estante(sbyte capacidad) : this()
        {
            _capacidad = capacidad;
        }

        public List<Producto> GetProductos() 
        {
            return _productos;
        }

        public float ValorEstanteTotal
        {
            get
            {
                return GetValorEstante();
            }

            set
            {

            }
        }

        public List<Producto> Productos
        {
            get
            {
                return _productos;
            }
            set
            {
                _productos = value;
            }
        }

        public sbyte Capacidad
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

        public static string MostrarEstante(Estante estante)
        {
            StringBuilder sb = new StringBuilder();

            if (estante._productos.Count == 0)
            {
                sb.AppendLine("El estante no posee productos.");
            }
            else
            {
                sb.AppendLine($"Capacidad: {estante._capacidad}");
                foreach(Producto p in estante._productos) 
                {
                    sb.AppendLine(p.ToString());
                }
            }
            return sb.ToString();
        }


        public static void GuardarEstante(Estante estante, string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {
                    fileStream.Close();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                streamWriter.WriteLine(MostrarEstante(estante));
            }
        }

        public static void SerializarEstante(Estante estante, string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Estante));

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                xmlSerializer.Serialize(streamWriter, estante);
            }
        }

        public static Estante DeserializarEstante(string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Estante));

            using (StreamReader streamReader = new StreamReader(rutaArchivo))
            {
                return (Estante)xmlSerializer.Deserialize(streamReader);
            }
        }





        public static bool operator ==(Estante estante, Producto producto)
        {
            return estante._productos.Contains(producto);
        }

        public static bool operator !=(Estante estante, Producto producto)
        {
            return !(estante == producto);
        }

        public static bool operator +(Estante estante, Producto producto)
        {
            bool result = false;
            if (estante._productos.Count() < estante._capacidad && estante != producto) 
            {
                estante._productos.Add(producto);
                result = true;
            }

            return result;
        }

        public static Estante operator -(Estante estante, Producto producto)
        {
            if (estante == producto)
            {
                estante._productos.Remove(producto);
            }
            return estante;
        }

        public static Estante operator -(Estante estante, ETipoProducto tipo)
        {

            if (tipo == ETipoProducto.Todos)
            {
                estante._productos.Clear();
            }
            else
            {
                for (int i = 0; i < estante._productos.Count; i++)
                {
                    if (tipo.ToString() == estante._productos[i].GetType().Name)
                    {
                        estante._productos.RemoveAt(i);
                        i--;
                    }
                }
            }
            return estante;
        }

        public float GetValorEstante(ETipoProducto tipoProducto)
        {
            float valorTotal = 0;

            foreach(Producto item in _productos)
            {
                if(tipoProducto == ETipoProducto.Todos)
                {
                    valorTotal += item.CalcularCostoDeProduccion;
                }
                else if(item.GetType().Name == tipoProducto.ToString())
                {
                    valorTotal = +item.CalcularCostoDeProduccion;
                }
            }

            return valorTotal;

        }

        public float GetValorEstante()
        {
            return GetValorEstante(ETipoProducto.Todos);
        }

    }
}
