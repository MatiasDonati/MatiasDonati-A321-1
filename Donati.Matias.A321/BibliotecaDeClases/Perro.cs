using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Perro : Mascota
    {
        private int edad;
        private bool esAlfa;

        public Perro(string nombre, string raza) : base(nombre, raza) { }


        public Perro(string nombre, string raza, int edad, bool esAlfa) : this(nombre, raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }

        protected override string Ficha()
        {
            return this.ToString();
        }

        public override int GetHashCode()
        {
            return Nombre.GetHashCode();
        }

        public static bool operator ==(Perro perro1, Perro perro2)
        {
            return perro1.Nombre == perro2.Nombre && perro1.Raza == perro2.Raza && perro1.edad == perro2.edad;
        }

        public static bool operator !=(Perro perro1, Perro perro2)
        {
            return !(perro1 == perro2);
        }

        public override bool Equals(Object obj)
        {
            return obj == this;
        }

        public override string ToString() 
        { 
            StringBuilder  sb = new StringBuilder();
            sb.Append("==============Perro=========\n");
            sb.Append($"Nombre: {Nombre}\nRaza: {Raza}\nEdad: {edad}");

            if (esAlfa)
            {
                sb.Append("\nAlfa de la manada.");
            }

            return sb.ToString();
        }

    }
}
