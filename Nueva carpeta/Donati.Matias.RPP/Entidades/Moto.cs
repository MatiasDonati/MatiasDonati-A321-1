using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        private ECilindrada _cilindrada;

        public Moto() { }

        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada)
            : base(modelo, precio, new Fabricante(marca, pais))
        {
            _cilindrada = cilindrada;
        }

        public ECilindrada Cilindrada
        {
            get
            {
                return _cilindrada;
            }
            set
            {
                _cilindrada = value;
            }
        }
        /// <summary>
        /// Retorna true si los vehiculos y las cilindraras son iguales. False caso contrario.
        /// </summary>
        /// <param name="moto1"></param>
        /// <param name="moto2"></param>
        /// <returns></returns>
        public static bool operator ==(Moto moto1, Moto moto2)
        {
            return (Vehiculo)moto1 == (Vehiculo)moto2 && moto1.Cilindrada == moto2.Cilindrada;
        }
        /// <summary>
        /// Retorna true si los vehiculos y las cilindraras son distintas. False caso contrario
        /// </summary>
        /// <param name="moto1"></param>
        /// <param name="moto2"></param>
        /// <returns></returns>
        public static bool operator !=(Moto moto1, Moto moto2)
        {
            return !(moto1 == moto2);
        }
        /// <summary>
        /// Retorna el precio de la moto pasada por parametro.
        /// </summary>
        /// <param name="moto"></param>
        public static explicit operator float(Moto moto)
        {
            return moto.Precio;
        }
        /// <summary>
        /// Retorna true si el paramtro recibido es igual a la instancia actual.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Moto moto && moto == this;
        }
        /// <summary>
        /// Retorna una cadena con la informacion completa del objeto,
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{(string)this}CILINDRADA: {Cilindrada}";
        }
    }
}
