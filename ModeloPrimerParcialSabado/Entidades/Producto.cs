using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        protected int _codigoDeBarra;
        protected EMarcaProducto _marcaProducto;
        protected float _precio;

        public Producto() { }

        public Producto(int codigoDeBarra, EMarcaProducto marcaProducto, float precio)
        {
            this._codigoDeBarra = codigoDeBarra;
            this._marcaProducto = marcaProducto;
            this._precio = precio;
        }

        public abstract float CalcularCostoDeProduccion { get; set; }

        public EMarcaProducto Marca { get { return this._marcaProducto; } }

        public float Precio { get { return this._precio; } }

        public int CodigoDeBarra { get { return this._codigoDeBarra; } }

        /// <summary>
        /// Retonar una cadena string utilizando la data de los atriutos.
        /// </summary>
        /// <returns></returns>
        private static string MostrarProducto(Producto producto)
        {
            return $"El producto {producto.CodigoDeBarra}, de la marca {producto.Marca} tiene un precio de ${producto.Precio}";
        }
        /// <summary>
        /// Metodo virtual que pueden sobrescribir las clases hijes.
        /// </summary>
        /// <returns></returns>
        public virtual string Consumir()
        {
            return "Parte de una mezcla.";
        }
        /// <summary>
        /// Sobrecarga de operador == que analiza si la marca , precio y codigo de barras de dos productos son iguales.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Producto p1, Producto p2)
        {
            return p1.GetType() == p2.GetType() && p1.Marca == p2.Marca && p1.CodigoDeBarra == p2.CodigoDeBarra;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Producto producto, EMarcaProducto marca)
        {
            return producto.Marca == marca;
        }

        public static bool operator !=(Producto producto, EMarcaProducto marca)
        {
            return !(producto == marca);
        }

        public static explicit operator int(Producto producto) { return producto.CodigoDeBarra; }

        public static implicit operator string(Producto producto) { return MostrarProducto(producto); }

        public override bool Equals(object obj)
        {
            // return obj is Producto prod && prod.GetType() == this.GetType();
            // return obj is Producto && this == (Producto)obj; 
             return obj.GetType() == this.GetType();
        }

    }
}

