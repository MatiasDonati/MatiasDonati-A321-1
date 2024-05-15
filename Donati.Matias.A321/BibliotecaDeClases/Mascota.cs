using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public abstract class Mascota
    {
        private string nombre;
        private string raza;

        public Mascota(string nombre, string raza) 
        {
            this.nombre = nombre;
            this.raza = raza;
        }
        public string Nombre { get { return nombre; } }

        public string Raza { get { return raza; } }

        protected string DatosCompletos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Nombre);
            sb.Append("");
            sb.Append(Raza);
            return sb.ToString();
        }

        protected abstract string Ficha();
    }
}
