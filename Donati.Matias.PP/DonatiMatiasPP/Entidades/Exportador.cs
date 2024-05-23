using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Exportador : Comercio
    {
        private ETipoProducto _tipo;

        public Exportador() { }

        public Exportador(string nombreComercio, float precioAlquiler, Comerciante comerciante, ETipoProducto tipo)
            :base(nombreComercio, comerciante, precioAlquiler)
        {
            _tipo = tipo;
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine((string)this);
            sb.AppendLine($"Tipo: {_tipo}");
            
            return sb.ToString();
        }

        public static bool operator ==(Exportador e1, Exportador e2)
        {
            // CHEKEAR ESTO POR LAS DUDAS
            return e1.Nombre == e2.Nombre && e1._tipo == e2._tipo;
        }

        public static bool operator !=(Exportador e1, Exportador e2)
        {
            return !(e1 == e2);
        }

        public static implicit operator ETipoProducto(Exportador exportador)
        {
            return exportador._tipo;
        }

    }
}
