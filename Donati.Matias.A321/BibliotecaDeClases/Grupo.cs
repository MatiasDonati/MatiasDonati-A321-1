using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{
    public class Grupo
    {
        private List<Mascota> manada;
        private string nombre;
        private static EtipoManada tipo;

        public EtipoManada Tipo { set { tipo = value; } }

        static Grupo()
        {
            tipo = EtipoManada.Unica;
        }
        private Grupo()
        {
            manada = new List<Mascota>();
        }
        public Grupo(string nombre) : this()
        { 
            this.nombre = nombre;
        }
        public Grupo(string nombre, EtipoManada tipo) : this(nombre)
        {
            Tipo = tipo;
        }
        public static bool operator ==(Grupo g, Mascota m)
        {
            return g.manada.Contains(m);
        }

        public static bool operator !=(Grupo g, Mascota m)
        {
            return !(g == m);
        }

        public static Grupo operator +(Grupo g, Mascota m)
        {
            if(g != m)
            {
                g.manada.Add(m);

            }
            return g;
        }
        public static Grupo operator -(Grupo g, Mascota m)
        {
            if (g == m)
            {

                g.manada.Remove(m);
            }
            return g;
        }


        public static implicit operator string(Grupo grupo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"MANADA: {grupo.nombre} - Tipo de manada: {tipo} - INTEGRANTES {grupo.manada.Count()}");
            foreach (var mascota in grupo.manada)
            {
                sb.AppendLine(mascota.ToString());
            }
            return sb.ToString();
        }

    }
}
