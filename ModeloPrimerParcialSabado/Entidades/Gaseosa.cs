using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        protected static bool _deConsumo;
        protected float _litros;


        public override float CalcularCostoDeProduccion
        {
            get
            {
                return Precio * (float)0.42;
            }
            set
            {
                _precio = value;
            }
        }

        static Gaseosa()
        {
            _deConsumo = true;
        }

        public Gaseosa() { }

        public Gaseosa(Producto producto, float litros)
            : this(producto.CodigoDeBarra, producto.Marca, producto.Precio, litros)
        {

        }

        public Gaseosa(int codigoDeBarra, EMarcaProducto marcaProducto, float precio, float litros)
            : base (codigoDeBarra, marcaProducto, precio)
        {
            _litros = litros;
        }


        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Litros: {_litros}");
            sb.AppendLine($"De consumo: {_deConsumo}");
            sb.AppendLine((string)this);

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarGaseosa();
        }

        public override string Consumir()
        {
            return "Bebible";
        }

    }
}
