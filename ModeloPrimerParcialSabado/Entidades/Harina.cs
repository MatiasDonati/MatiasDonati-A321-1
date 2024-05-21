using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina : Producto
    {
        protected static bool _deConsumo;
        protected ETipoHarina _tipo;


        public override float CalcularCostoDeProduccion
        {
            get
            {
                return Precio * (float)0.6;
            }
            set
            {
                _precio = value;
            }
        }

        static Harina()
        {
            _deConsumo = false;
        }

        public Harina() { }

        public Harina(int codigoDeBarra,  float precio, EMarcaProducto marcaProducto, ETipoHarina tipo)
            : base(codigoDeBarra, marcaProducto, precio)
        {
            _tipo = tipo;   
        }

        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Tipo: {_tipo}");
            sb.AppendLine($"De consumo: {_deConsumo}");
            sb.AppendLine((string)this);

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarHarina();
        }


        // Esto no lo pide

        /*public override string Consumir()
        {
            return "Bebible";
        }
        */
    }
}
