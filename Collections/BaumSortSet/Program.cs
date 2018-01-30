using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaumSortSet
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Baum> liste = new SortedSet<Baum>();
            liste.Add(new Baum("Buche", 4));
            liste.Add(new Baum("Buche", 7));
            liste.Add(new Baum("Eiche", 8));
            liste.Add(new Baum("Ahorn", 8.5));
            liste.Add(new Baum("Eibe", 4));

            foreach (Baum b in liste)
                Console.WriteLine(b);
        }
    }
}
