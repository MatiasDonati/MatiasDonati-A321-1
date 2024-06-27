using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Banana : Fruta
    {
        #region Atributos
        protected string _paisOrigen;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return "Banana"; }
            set {}
        }
        public string PaisOrigen
        {
            get { return _paisOrigen; }
            set { _paisOrigen = value; }
        }

        public override bool TieneCarozo
        {
            get { return false; }
            set {}
        }
        #endregion

        #region Constructores
        public Banana(string color, double peso, string paisOrigen) : base(color, peso)
        {
            _paisOrigen = paisOrigen;
        }
        #endregion

        #region Sobrecargas
        protected override string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fruta: {Nombre}.");
            sb.AppendLine($"Provincia de origen: {PaisOrigen}.");
            if (TieneCarozo)
            {
                sb.AppendLine("Tiene carozo.");
            }
            else
            {
                sb.AppendLine("No tiene carozo.");
            }
            sb.AppendLine(base.FrutasToString());
            return sb.ToString();
        }

        public override string ToString()
        {
            return FrutasToString();
        }
        #endregion
    }
}
