using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        private ETipo _tipo;

        public Auto() { }
        /// <summary>
        /// Inicializa una nueva instancia de la clase  con el modelo, precio, fabricante y tipo especificados,
        /// y pasa los atributos modelo, precio y fabricante a la clase base.       
        /// /// </summary>
        /// <param name="modelo"></param>
        /// <param name="precio"></param>
        /// <param name="fabricante"></param>
        /// <param name="tipo"></param>
        public Auto(string modelo, float precio, Fabricante fabricante, ETipo tipo)
            : base(modelo, precio, fabricante)
        {
            _tipo = tipo;
        }

        public ETipo Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }
        /// <summary>
        /// Retorna true si los vehiculos y tipos son iguales. False caso contrario.
        /// </summary>
        /// <param name="auto1"></param>
        /// <param name="auto2"></param>
        /// <returns></returns>
        public static bool operator ==(Auto auto1, Auto auto2)
        {
            return (Vehiculo)auto1 == (Vehiculo)auto2 && auto1.Tipo == auto2.Tipo;
        }
        /// <summary>
        /// Retorna true si los vehiculos y tipos son distintos. False caso contrario.
        /// </summary>
        /// <param name="auto1"></param>
        /// <param name="auto2"></param>
        /// <returns></returns>
        public static bool operator !=(Auto auto1, Auto auto2)
        {
            return !(auto1 == auto2);
        }
        /// <summary>
        /// Retorna el precio del auto pasado por parametro.
        /// </summary>
        /// <param name="auto"></param>
        public static explicit operator float(Auto auto)
        {
            return auto.Precio;
        }
        /// <summary>
        /// Retorna true si el paramtro recibido es igual a la instancia actual.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Auto auto && auto == this;
        }
        /// <summary>
        /// Retorna una cadena con la informacion completa del objeto,
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{(string)this}TIPO: {Tipo}";
        }

    }
}
