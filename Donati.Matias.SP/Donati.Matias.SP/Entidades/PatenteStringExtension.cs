using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public static class PatenteStringExtension
    {
        public const string patente_vieja = "^[A-Z]{3}[0-9]{3}$";
        public const string patente_mercosur = "^[A-Z]{2}[0-9]{3}[A-Z]{2}$";

        /// <summary>
        /// Metodo para validar la patente y devolver una patentee.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Patente ValidarPatente(this string str)
        {
            Regex rgxVieja = new Regex(patente_vieja);
            Regex rgxMercosur = new Regex(patente_mercosur);

            if (rgxVieja.IsMatch(str))
            {
                return new Patente(str, Tipo.Vieja);
            }
            else if (rgxMercosur.IsMatch(str))
            {
                return new Patente(str, Tipo.Mercosur);
            }

            throw new PatenteInvalidaException($"{str} no cumple con el formato");

        }
    }

}
