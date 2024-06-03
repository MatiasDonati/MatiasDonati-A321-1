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
        protected Comerciante _comerciante ;
        protected static Random _generadorDeEmpleados ;
        protected string _nombre;
        protected float _precioAlquiler;

        public Comercio() 
        {

        }

        static Comercio() 
        {
            _generadorDeEmpleados = new Random();

        }

        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido) : this(nombreComercio, new Comerciante(nombre, apellido), precioAlquiler)
        {
            _comerciante.Nombre = nombre;
            _comerciante.Apellido = apellido;
        }
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler) 
        {
            _nombre = nombre;
            _comerciante = comerciante;
            _precioAlquiler = precioAlquiler;
        }

        public int CantidadDeEmpleados 
        {
            get
            {
                if (_cantidadDeEmpleados == 0)
                {
                    return _cantidadDeEmpleados = _generadorDeEmpleados.Next(1, 100);
                }
                else
                {
                    return _cantidadDeEmpleados;
                }
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

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cantidad de Empleados: {CantidadDeEmpleados}");
            sb.Append((string)Comerciante);
            sb.AppendLine($"Nombre de comercio: {Nombre}");
            sb.AppendLine($"Precio de alquiler: {PrecioAlquiler}");

            return sb.ToString();
        }

        public static bool operator ==(Comercio c1, Comercio c2)
        {
            return c1._nombre == c2._nombre &&  c1._comerciante == c2._comerciante;
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
            return obj is Comercio comercio && this == comercio;
        }

    }
}
