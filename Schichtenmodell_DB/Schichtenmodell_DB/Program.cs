using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schichtenmodell_DB.DreiSchichten;

namespace Schichtenmodell_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(Artikel a in sqlPool.getAlleArtikel())
            {
                Console.WriteLine("{0}\t{1,8:F2}\t{2,8:F2}\t{3}\t{4}", a.Artikel_id, a.EPreis, a.VPreis, a.bezeichnung, a.Lager_id);
            }
        }
    }
}
