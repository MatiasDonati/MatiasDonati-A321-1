using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Archivos
{
    [XmlInclude(typeof(Fruta))]
    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        #region Atributos
        protected string _provinciaOrigen;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return "Manzana"; }
            set {}
        }

        public string ProvinciaOrigen
        {
            get { return _provinciaOrigen; }
            set { _provinciaOrigen = value; }
        }

        public override bool TieneCarozo
        {
            get { return false; }
            set {}
        }
        #endregion

        #region Constructores
        public Manzana() { }

        public Manzana(string color, double peso, string provinciaOrigen) : base(color, peso)
        {
            _provinciaOrigen = provinciaOrigen;
        }
        #endregion

        #region Metodos
        public bool Xml(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Manzana));

            try 
            { 
            using(StreamWriter streamWriter = new StreamWriter(path))
            {
                xmlSerializer.Serialize(streamWriter, this);
            }
            return true;
            }catch (Exception)
            {
                return false;
            }
        }

        bool IDeserializar.Xml(string path, out Fruta fruta)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Manzana));
            using (StreamReader streamReader = new StreamReader(path))
            {
                try
                { 
                    fruta = (Manzana)xmlSerializer.Deserialize(streamReader);
                    return true;
                }
                catch (Exception)
                {
                    fruta = null;
                    return false;   
                }
            }
        }
        #endregion

        #region Sobrecargas
        protected override string FrutasToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fruta: {Nombre}.");
            sb.AppendLine($"Provincia de origen: {ProvinciaOrigen}.");
            if(TieneCarozo)
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
