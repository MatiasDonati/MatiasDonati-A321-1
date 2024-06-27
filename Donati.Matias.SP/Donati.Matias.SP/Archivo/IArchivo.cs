using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivo
{
    public interface IArchivo
    {
        /// <summary>
        /// Guarda una lista de patentes y retorna un bool
        /// </summary>
        /// <param name="listaPatentes"></param>
        /// <returns></returns>
        bool Guardar(List<Patente> listaPatentes);

        /// <summary>
        /// Lee y retorna una lsita de patentes.
        /// </summary>
        /// <returns></returns>
        List<Patente> Leer();
    }
}
