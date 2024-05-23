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

        public Comercio (float precioAlquiler, string nombreComercio, string nombre, string apellido)
        {
            _precioAlquiler = precioAlquiler;
            _nombre = nombreComercio;
            _comerciante = new Comerciante(apellido, nombre);
        } 
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler) : this(precioAlquiler, nombre, comerciante.Nombre, comerciante.Apellido)
        {

        }

        public int CantidadDeEmpleados 
        {
            get
            {
                if (_cantidadDeEmpleados == 0)
                {
                    _cantidadDeEmpleados = _generadorDeEmpleados.Next(1, 100);
                }
                return _cantidadDeEmpleados;
            }
            set
            {

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
            sb.AppendLine($"Cantidad de Empleados: {_cantidadDeEmpleados}");
            sb.AppendLine((string)_comerciante);
            sb.AppendLine($"Nombre de comercio: {_nombre}");
            sb.AppendLine($"Precio de alquiler: {_precioAlquiler}");

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
