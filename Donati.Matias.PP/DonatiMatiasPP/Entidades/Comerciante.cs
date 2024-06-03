using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        private string _apellido;
        private string _nombre;

        public Comerciante() { }

        public Comerciante(string apellido, string nombre)
        {
            _apellido = apellido;
            _nombre = nombre;
        }

        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
            }
        }

        public string Nombre
        {
            get { 
                return _nombre;
                }
            set
            {

            }
        }


        public static bool operator ==(Comerciante c1, Comerciante c2)
        {
            return c1.Nombre == c2.Nombre && c1._apellido == c2._apellido;
        }

        public static bool operator !=(Comerciante c1, Comerciante c2)
        {
            return !(c1 == c2);
        }


        public static implicit operator string(Comerciante c)
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Comerciante: {c.Nombre} {c.Apellido}");
            return sb.ToString();
        }


    }
}
