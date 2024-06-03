using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ModeloPrimerParcialSabado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> a = new Queue<string>();

            a.Enqueue("a");
            a.Enqueue("b");
            a.Enqueue("c");

            while (a.Count > 0)
            {
                Console.WriteLine(a.Dequeue());
            }


            Console.ReadKey();
        }
    }
}
