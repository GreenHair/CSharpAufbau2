using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprachqualiLib
{
    class MySqlAbfragen
    {
        Datenbank db;

        public MySqlAbfragen(string database, string user, string password)
        {
            db = new Datenbank("localhost", user, password, database);
            if (db.verbinden())
            {
                Console.WriteLine("verbunden");
            }
            else
            {
                throw new Exception("Verbinden fehlgeschlagen");
            }
        }

        public Person[] AllePersonen()
        {
            List<Person> jeder = new List<Person>();
            List<List<string>> tabelle = db.ausgebenTabelle("select persnr,vorname,name from person");
            foreach(List<string> zeile in tabelle)
            {
                Person p = new Person();
                p.Pers_nr = zeile[0];
                p.Vorname = zeile[1];
                p.Nachname = zeile[2];
                p.Sprachen = SprachenVonPerson(p.Pers_nr);
                jeder.Add(p);
            }

            return jeder.ToArray();
        }

        public List<Sprache> SprachenVonPerson(string persnr)
        {
            List<Sprache> sprachen = new List<Sprache>();
            List<List<string>> tabelle = db.ausgebenTabelle("select sprache,grad from sprachen where persnr=" + persnr);
            foreach(List<string> zeile in tabelle)
            {
                Sprache s = new Sprache();
                s.Welche = zeile[0];
                s.Niveau = Convert.ToInt32(zeile[1]);
                sprachen.Add(s);
            }
            return sprachen;
        }

        public Person SuchePerson(string persnr)
        {            
            List<List<string>> tabelle = db.ausgebenTabelle("select persnr,vorname,name from person where persnr=" + persnr);
            Person p = Getperson(tabelle);
            return p;
        }

        public  Person SuchePerson(char buchstabe)
        {
            List<List<string>> tabelle = db.ausgebenTabelle("select persnr,vorname,name from person where name like '" + buchstabe + "%'");
            Person p = Getperson(tabelle);
            return p;
        }

        public Person Getperson(List<List<string>> tabelle)
        {
            Person p = new Person();
            foreach (List<string> zeile in tabelle)
            {
                p.Pers_nr = zeile[0];
                p.Vorname = zeile[1];
                p.Nachname = zeile[2];
                p.Sprachen = SprachenVonPerson(p.Pers_nr);
            }
            return p;
        }

        public Sprache[] AlleSprachen()
        {
            List<Sprache> sprachen = new List<Sprache>();
            List<List<string>> tabelle = db.ausgebenTabelle("select persnr,sprache,grad from sprachen");
            foreach (List<string> zeile in tabelle)
            {
                Sprache s = new Sprache();
                s.Pers_nr = zeile[0];
                s.Welche = zeile[1];
                s.Niveau = Convert.ToInt32(zeile[2]);
                sprachen.Add(s);
            }
            return sprachen.ToArray();
        }

        public double DurchschnittVonSprache(string sprache)
        {
            object obj = db.zahlAusgeben("select avg(grad) from sprachen where sprache='" + sprache + "'");
            return Convert.ToDouble(obj);
        }

        public int SprachFähigkeit(string persnr,string sprache)
        {
            object obj = db.zahlAusgeben("select grad from sprachen where persnr = '" + persnr +
                "' and sprache = '" + sprache + "'");
            return Convert.ToInt32(obj);
        }

        ~MySqlAbfragen()
        {
            if(db.conn.State == System.Data.ConnectionState.Open)
            {
                db.trennen();
            }
        }
    }
}
