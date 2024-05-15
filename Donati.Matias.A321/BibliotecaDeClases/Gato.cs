using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Gato : Mascota
    {
        public Gato(string nombre, string raza) : base(nombre, raza) { }


        public static bool operator ==(Gato gato1, Gato gato2) 
        {
            return gato1.Nombre == gato2.Nombre && gato1.Raza == gato2.Raza;
        }

        public static bool operator !=(Gato gato1, Gato gato2)
        {
            return !(gato1 == gato2);
        }
        public override bool Equals(Object obj)
        {
            return obj == this;
        }

        protected override string Ficha()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("==============Gato=========\n");
            sb.Append($"Nombre: {Nombre}\n Raza{Raza}");
            return sb.ToString();
        }

    }
}
