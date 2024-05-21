using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        protected static bool _deConsumo;
        protected ESaborJugo _sabor;

        public override float CalcularCostoDeProduccion 
        {
            get 
            {
                return Precio * (float)0.4;
                //return Precio * 0.4f;
            }
            set
            {
                // Precio aca no se puede porque es solo de lectura.
                _precio = value;
            }
        } 

        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor)
            : base (codigoBarra, marca, precio) 
        {
            _sabor = sabor;
        }

        static Jugo() 
        {
            _deConsumo = true;
        }

        public Jugo () 
        {

        }

        public override string Consumir()
        {
            return "Bebible.";
        }

        private string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Jugo sabor: {_sabor}");
            sb.AppendLine($"De consumo: {_deConsumo}");
            sb.AppendLine((string)this);
            
            return sb.ToString();
            
        }

        public override string ToString()
        {
            return this.MostrarJugo();
        }
    }
}
