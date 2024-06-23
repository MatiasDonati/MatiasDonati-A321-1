using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        private string _marca;
        private EPais _pais;

        /// <summary>
        /// Constructor vacio para seriaizar.
        /// </summary>
        public Fabricante() { }
        /// <summary>
        /// Constructor de instancia, inicializa los atributos.
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="pais"></param>
        public Fabricante(string marca, EPais pais)
        {
            _marca = marca;
            _pais = pais;
        }
        /// <summary>
        /// Propuedad publica de lectura y escritura de la marca del fabricante.
        /// </summary>
        public string Marca
        {
            get
            {
                return _marca;
            }
            set
            {
                _marca = value;
            }
        }
        /// <summary>
        /// Propuedad publica de lectura y escritura del pais del fabricante,
        /// </summary>
        public EPais Pais
        {
            get
            {
                return _pais;
            }
            set
            {
                _pais = value;
            }
        }
        /// <summary>
        /// Sobrecarga de operador ==, retorna true si las marcas y pais de los fabricantes son iguales.
        /// </summary>
        /// <param name="fabricante1"></param>
        /// <param name="fabricante2"></param>
        /// <returns></returns>
        public static bool operator ==(Fabricante fabricante1, Fabricante fabricante2)
        {
            return fabricante1.Marca == fabricante2.Marca && fabricante1.Pais == fabricante2.Pais;
        }
        /// <summary>
        /// Sobrecarga de operador !=, retorna true si las marcas y pais de los fabricantes son diferentes.
        /// </summary>
        /// <param name="fabricante1"></param>
        /// <param name="fabricante2"></param>
        /// <returns></returns>
        public static bool operator !=(Fabricante fabricante1, Fabricante fabricante2)
        {
            return !(fabricante1 == fabricante2);
        }
        /// <summary>
        /// Retrona una cadena con la marca y el pais del fabricante.
        /// </summary>
        /// <param name="fabricante"></param>
        public static implicit operator string(Fabricante fabricante)
        {
            return $"{fabricante.Marca}-{fabricante.Pais}";
        }

    }
}
