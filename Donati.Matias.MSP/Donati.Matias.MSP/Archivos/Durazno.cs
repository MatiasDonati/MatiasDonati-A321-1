using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Durazno : Fruta
    {
        #region Atributos
        protected int _cantPelusa;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return "Durazno"; }
            set { }
        }
        public int CantPelusa
        {
            get { return _cantPelusa; }
            set { _cantPelusa = value; }
        }

        public override bool TieneCarozo
        {
            get { return true; }
            set { }
        }
        #endregion

        #region Constructores
        public Durazno(string color, double peso, int cantPelusa) : base(color, peso)
        {
            _cantPelusa = cantPelusa;
        }
        #endregion

        #region Sobrecargas
        protected override string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fruta: {Nombre}.");
            sb.AppendLine($"Provincia de origen: {CantPelusa}.");
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
