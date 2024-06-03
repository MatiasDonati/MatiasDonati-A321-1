using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        private EPaises _paisOrigen;

        public Importador() { }

        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciante, EPaises paisOrigen)
            : base(nombreComercio, comerciante, precioAlquiler)
        {
            _paisOrigen = paisOrigen;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append((string)this);
            sb.AppendLine($"Pais de origen: {_paisOrigen}");

            return sb.ToString();

        }

        public static bool operator ==(Importador i1, Importador i2)
        {
            return i1 == i2 && i1._paisOrigen == i2._paisOrigen;
        }
        public static bool operator !=(Importador i1, Importador i2)
        {
            return !(i1 == i2);
        }

        public static implicit operator EPaises(Importador importador)
        {
            return importador._paisOrigen;
        }
    }
}
