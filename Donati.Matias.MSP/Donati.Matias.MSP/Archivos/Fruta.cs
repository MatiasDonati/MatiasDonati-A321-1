using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public abstract class Fruta
    {
        #region Atributos
        protected string _color;
        protected double _peso;
        #endregion

        #region Propiedades
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public double Peso
        {
            get { return _peso; }
            set { _peso = value; }
        }

        public abstract bool TieneCarozo { get; set; }

        #endregion

        #region Constructores
        public Fruta() { }

        public Fruta(string color, double peso)
        {
            _color = color;
            _peso = peso;
        }
        #endregion

        #region Metodos
        protected virtual string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Color: {Color}.");
            sb.AppendLine($"Peso: {Peso}.");

            return sb.ToString();
        }
        #endregion
    }
}
