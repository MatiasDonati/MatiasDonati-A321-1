using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita : Producto
    {
        protected static bool _deConsumo;
        protected float _peso;

        public override float CalcularCostoDeProduccion
        {
            get
            {
                return Precio * (float)0.33;
            }
            set
            {
                _precio = value;
            }
        }

        static Galletita() 
        {
            _deConsumo = true;
        }

        public Galletita() 
        {
            
        }

        public Galletita(int codigoDeBarra,  float precio, EMarcaProducto marcaProducto, float peso)
            : base(codigoDeBarra, marcaProducto, precio) 
        {
            _peso = peso;
        }

        private static string MostrarGalletita(Galletita galletita)
        {
            StringBuilder sb = new StringBuilder();
            // se pone galletita antes porque peso no esta como static ....
            // y el meto si .. si le pongo static a peso puedo no poner galletit
            sb.AppendLine($"Peso: {galletita._peso}");
            sb.AppendLine($"De consumo: {_deConsumo}");
            sb.AppendLine((string)galletita);

            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarGalletita(this);
        }

        public override string Consumir()
        {
            return "Comestible.";
        }
    }
}
