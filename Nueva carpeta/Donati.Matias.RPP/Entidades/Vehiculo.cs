using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected Fabricante _fabricante;
        protected static Random _generadorDeVelocidades;
        protected string _modelo;
        protected float _precio;
        protected int _velocidadMaxima;

        /// <summary>
        /// Constructor de clase que inicializa el _generadorDeVelocidades
        /// </summary>
        static Vehiculo() 
        { 
            _generadorDeVelocidades = new Random();
        }
        /// <summary>
        /// Constructor de instancia vacio para serializacion
        /// </summary>
        public Vehiculo() { }
        /// <summary>
        /// Inicializa una nueva instancia con la marca, país, modelo y precio especificados.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="pais"></param>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        public Vehiculo(string marca, EPais pais, string modelo, float precio) 
            : this(modelo, precio, new Fabricante(marca, pais))
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia con el modelo, precio y un Fabricante.
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        /// <param name="fabricante"></param>
        public Vehiculo(string modelo, float precio, Fabricante fabricante) 
        {
            _modelo = modelo;
            _precio = precio;
            _fabricante = fabricante;
        }
        /// <summary>
        /// Obtiene o escribe el atributo fabricante
        /// </summary>
        public Fabricante Fabricante
        {
            get
            {
                return _fabricante;
            }
            set
            {
                _fabricante = value;
            }
        }
        /// <summary>
        /// Obtiene o escribe el atributo modelo
        /// </summary>
        public string Modelo
        {
            get
            {
                return _modelo;
            }
            set
            {
                _modelo = value;
            }
        }
        /// <summary>
        /// Obtiene o escribe el atributo precio
        /// </summary>
        public float Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                _precio = value;
            }
        }
        /// <summary>
        /// Si el atributo de _velocidadMaxima es 0, utiliando _generadorDeVElocidades le da un valor entre 100 y 201.
        /// </summary>
        public int VelocidadMaxima
        {
            get
            {
                if(_velocidadMaxima == 0)
                {
                    _velocidadMaxima = _generadorDeVelocidades.Next(100, 281);
                }
                return _velocidadMaxima;
            }
            set
            {
                _velocidadMaxima = value;
            }
        }
        /// <summary>
        /// Retonra una cadena detallando los atributos del vehiculo recibido por parametro
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        private static string Mostrar(Vehiculo vehiculo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"FABRICANTE:{(string)vehiculo._fabricante}");
            sb.AppendLine($"MODELO: {vehiculo.Modelo}");
            sb.AppendLine($"VELOCIDAD MAXIMA: {vehiculo.VelocidadMaxima}");
            sb.AppendLine($"PRECIO: ${vehiculo.Precio}");

            return sb.ToString();
        }
        /// <summary>
        /// Retorna True si el modelo y el fabricante de los vehiculos pasados por parametros son iguales.
        /// </summary>
        /// <param name="vehiculo1"></param>
        /// <param name="vehiculo2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return vehiculo1.Modelo == vehiculo2.Modelo && vehiculo1.Fabricante == vehiculo2.Fabricante;
        }

        public static bool operator !=(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return !(vehiculo1 == vehiculo2);
        }
        /// <summary>
        /// Retorna el detalle completo del vehiculo que recive por parametro.
        /// </summary>
        /// <param name="vehiculo"></param>
        public static explicit operator string(Vehiculo vehiculo)
        {
            return Mostrar(vehiculo);
        }

    }
}
