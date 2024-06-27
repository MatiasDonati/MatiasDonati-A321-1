using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Patente
    {
        private string _codigoPatente;
        private Tipo _tipoCodigo;
        /// <summary>
        /// Propiedad que obtiene y establece el codigo de la patente
        /// </summary>
        public string CodigoPatente
        {
            get 
            { 
                return _codigoPatente; 
            }
            set 
            { 
                _codigoPatente = value; 
            }
        }
        /// <summary>
        /// Propiedad que obtiene y establece el tipo de codigo de la patente
        /// </summary>
        public Tipo TipoCodigo 
        {
            get
            {
                return _tipoCodigo;
            }
            set
            {
                _tipoCodigo = value;
            }
        }
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Patente() { }
        /// <summary>
        /// Constructor que inicializa los atributos de la patente.
        /// </summary>
        /// <param name="codigoPatente"></param>
        /// <param name="tipoCodigo"></param>
        public Patente(string codigoPatente, Tipo tipoCodigo)
        {
            _codigoPatente = codigoPatente;
            _tipoCodigo = tipoCodigo;
        }
        /// <summary>
        /// Metodo que retorna el codigo de la patente.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _codigoPatente;
        }
    }
}
