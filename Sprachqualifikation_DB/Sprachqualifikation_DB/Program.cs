using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SprachqualiLib;

namespace Sprachqualifikation_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlAbfragen sql = new MySqlAbfragen("sprachquali", "root", "");
            //foreach(Person p in sql.AllePersonen())
            //{
            //    Console.WriteLine(p.Pers_nr);
            //    Console.WriteLine(p.Vorname);
            //    Console.WriteLine(p.Nachname);
            //    Console.WriteLine("---Sprachen: ---");
            //    foreach(Sprache s in p.Sprachen)
            //    {
            //        Console.WriteLine("\t{0}\tGrad: {1}", s.Welche, s.Niveau);
            //    }
            //    Console.WriteLine("_______________________________________");
            //}
            Tabellezeigen(sql);
            Console.WriteLine(sql.PersonHinzufügen("0235", "Fritz", "Fröhlich"));
            Tabellezeigen(sql);
            Console.WriteLine(sql.HinzufügenSprache("0235", "Swahilisch", 5));
            Tabellezeigen(sql);
            Console.WriteLine(sql.aktualisieren("0235", "Swahilisch", 8));
            Tabellezeigen(sql);
            Console.WriteLine(sql.aktualisieren(new Person { Pers_nr = "0235", Nachname = "Traurig", Vorname = "Fritz" }));
            Tabellezeigen(sql);
            Console.WriteLine(sql.löschen(new Person { Pers_nr = "0235" }));
            Tabellezeigen(sql);
        }

        static void Tabellezeigen(MySqlAbfragen sql)
        {
            foreach (Person p in sql.AllePersonen())
            {
                Console.WriteLine(p.Pers_nr);
                Console.WriteLine(p.Vorname);
                Console.WriteLine(p.Nachname);
                Console.WriteLine("---Sprachen: ---");
                foreach (Sprache s in p.Sprachen)
                {
                    Console.WriteLine("\t{0}\tGrad: {1}", s.Welche, s.Niveau);
                }
                Console.WriteLine("_______________________________________");
            }
            Console.ReadLine();
        }
    }
}
