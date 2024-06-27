using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
    public delegate void PrecioExtendido(object sender);

    [XmlInclude(typeof(Manzana))]
    public class Cajon<T> : ISerializar
    {
        #region Atributos
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;
        #endregion

        #region Eventos
        public event PrecioExtendido eventoPrecio;
        #endregion

        #region Propiedades
        public int Capacidad
        {
            get { return _capacidad; }
            set { _capacidad = value; }
        }
        public List<T> Elementos
        {
            get { return _elementos; }
            set {}
        }

        public double PrecioUnitario
        {
            get { return _precioUnitario; }
            set { _precioUnitario = value; }
        }

        public double PrecioTotal
        {
            get 
            {
                double precioTotal = _elementos.Count * _precioUnitario;
                if (precioTotal > 55)
                {
                    eventoPrecio?.Invoke(precioTotal);
                }
                return precioTotal;
            }
            set {}
        }
        #endregion

        #region Constructores
        public Cajon() 
        {
            _elementos = new List<T>();
        }

        public Cajon(int capacidad) : this()
        {
            _capacidad = capacidad;
        }

        public Cajon(double precio, int capacidad) : this(capacidad)
        {
            _precioUnitario = precio;
        }
        #endregion

        #region Metodos
        public bool Xml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cajon<T>));

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    xmlSerializer.Serialize(streamWriter, this);
                }
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
            
        }
        #endregion

        #region Sobrecargas
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Capacidad del cajon: {Capacidad}.");
            sb.AppendLine($"Cantidad total de elementos: {Elementos.Count()}.");
            sb.AppendLine($"Precio Total: {PrecioTotal}.");
            foreach (T elemento in Elementos)
            {
                sb.AppendLine(elemento.ToString());
            }

            return sb.ToString();
        }

        public static Cajon<T> operator +(Cajon<T> cajon, T elem)
        {
            if (cajon.Elementos.Count < cajon.Capacidad)
            {
                cajon.Elementos.Add(elem);

               // var precio = cajon.PrecioTotal;
               
            }
            else
            {
                throw new CajonLlenoException("El cajón ya se encuentra lleno.");
            }

            return cajon;
        }

        #endregion
    }
}
