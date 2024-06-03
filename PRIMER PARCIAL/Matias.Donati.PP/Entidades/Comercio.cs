using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Comercio
    {
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected static Random _generadorDeEmpleados;
        protected string _nombre;
        protected float _precioAlquiler;

        public int CantidadDeEmpleados
        {
            get
            {
                if (_cantidadDeEmpleados == 0)
                {
                    _cantidadDeEmpleados = _generadorDeEmpleados.Next(1, 101);
                }
                return _cantidadDeEmpleados;
            }
            set
            {
                _cantidadDeEmpleados = value;
            }
        }

        public Comerciante Comerciante
        {
            get
            {
                return _comerciante;
            }
            set
            {
                _comerciante = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public float PrecioAlquiler
        {
            get
            {
                return _precioAlquiler;
            }
            set
            {
                _precioAlquiler = value;
            }
        }


        static Comercio()
        {
            _generadorDeEmpleados = new Random();
        }

        public Comercio() { }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Comercio.
        /// </summary>
        /// <param name="precioAlquiler">Precio del alquiler del comercio.</param>
        /// <param name="nombreComercio">Nombre del comercio.</param>
        /// <param name="nombre">Nombre del comerciante.</param>
        /// <param name="apellido">Apellido del comerciante.</param>
        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido)
            : this(nombreComercio, new Comerciante(nombre, apellido), precioAlquiler)
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase Comercio.
        /// </summary>
        /// <param name="nombre">Nombre del comercio.</param>
        /// <param name="comerciante">Instancia del comerciante.</param>
        /// <param name="precioAlquiler">Precio del alquiler del comercio.</param>
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler)
        {
            _nombre = nombre;
            _precioAlquiler = precioAlquiler;
            _comerciante = comerciante;
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {Nombre}");
            sb.AppendLine($"Comerciante: {(string)_comerciante}");
            sb.AppendLine($"Cantidad de Empleados: {CantidadDeEmpleados}");

            return sb.ToString();
        }

        public static bool operator ==(Comercio c1, Comercio c2)
        {
            return c1.Nombre == c2.Nombre && c1.Comerciante == c2.Comerciante;
        }
        public static bool operator !=(Comercio c1, Comercio c2)
        {
            return !(c1 == c2);
        }

        public static explicit operator string(Comercio comercio)
        {
            return comercio.Mostrar();
        }

        public override bool Equals(object obj)
        {
            return obj is Comercio comercio && comercio == this;
        }
    }
}
