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

        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }

        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public Comerciante() { }

        public Comerciante(string nombre, string apellido)
        {
            _apellido = apellido;
            _nombre = nombre;
        }

        public static bool operator ==(Comerciante c1, Comerciante c2)
        {
            return c1.Nombre == c2.Nombre && c1.Apellido == c2.Apellido;
        }

        public static bool operator !=(Comerciante c1, Comerciante c2)
        {
            return !(c1 == c2);
        }

        public static implicit operator string(Comerciante comerciante)
        {
            return $"{comerciante.Nombre}, {comerciante.Apellido}";
        }
    }
}
