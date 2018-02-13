using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SprachqualiLib
{
    public class MySqlAbfragen
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
            foreach (List<string> zeile in tabelle)
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
            foreach (List<string> zeile in tabelle)
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

        public Person SuchePerson(char buchstabe)
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

        public int SprachFähigkeit(string persnr, string sprache)
        {
            object obj = db.zahlAusgeben("select grad from sprachen where persnr = '" + persnr +
                "' and sprache = '" + sprache + "'");
            return Convert.ToInt32(obj);
        }

        public int PersonHinzufügen(string persnr, string vorname, string name)
        {
            string prep = "insert into person (persnr,name,vorname) values (@persnr,@name,@vorname)";
            db.comm = new MySqlCommand(prep, db.conn);
            MySqlParameter p_nr = new MySqlParameter("@persnr", MySqlDbType.VarChar, 5);
            MySqlParameter n_name = new MySqlParameter("@name", MySqlDbType.VarChar, 50);
            MySqlParameter v_name = new MySqlParameter("@vorname", MySqlDbType.VarChar, 50);
            p_nr.Value = persnr;
            n_name.Value = name;
            v_name.Value = vorname;
            db.comm.Parameters.Add(p_nr);
            db.comm.Parameters.Add(n_name);
            db.comm.Parameters.Add(v_name);
            db.comm.Prepare();
            int result = db.comm.ExecuteNonQuery();
            return result;
        }

        public int HinzufügenSprache(string persnr, string sprache, int grad)
        {
            string prep = "insert into sprachen (persnr,sprache,grad) values (@persnr,@sprache,@grad)";
            db.comm = new MySqlCommand(prep, db.conn);
            MySqlParameter p_nr = new MySqlParameter("@persnr", MySqlDbType.VarChar, 5);
            MySqlParameter spr = new MySqlParameter("@sprache", MySqlDbType.VarChar, 50);
            MySqlParameter gr = new MySqlParameter("@grad", MySqlDbType.Int32,10);

            p_nr.Value = persnr;
            spr.Value = sprache;
            gr.Value = grad;
            db.comm.Parameters.Add(p_nr);
            db.comm.Parameters.Add(spr);
            db.comm.Parameters.Add(gr);
            db.comm.Prepare();


            int result = db.comm.ExecuteNonQuery();
            return result;
        }

        public int aktualisieren(String nummer, String sprache, int grad)
        {
            string sql = "update sprachen set grad = @grad where persnr = @nr and sprache = @sprache";
            MySqlCommand comm = new MySqlCommand(sql, db.conn);
            MySqlParameter param1 = new MySqlParameter("@nr", MySqlDbType.String, 0);
            MySqlParameter param2 = new MySqlParameter("@sprache", MySqlDbType.String, 100);
            MySqlParameter param3 = new MySqlParameter("@grad", MySqlDbType.Int32, 0);
            param1.Value = nummer;
            param2.Value = sprache;
            param3.Value = grad;

            comm.Parameters.Add(param1);
            comm.Parameters.Add(param2);
            comm.Parameters.Add(param3);

            comm.Prepare();
            return comm.ExecuteNonQuery();
        }

        public int aktualisieren(Person p)
        {
            string sql = "update person set name = @name where persnr = @nr";
            MySqlCommand comm = new MySqlCommand(sql, db.conn);
            MySqlParameter param1 = new MySqlParameter("@nr", MySqlDbType.String, 0);
            MySqlParameter param2 = new MySqlParameter("@name", MySqlDbType.String, 100);
            param1.Value = p.Pers_nr;
            param2.Value = p.Nachname;

            comm.Parameters.Add(param1);
            comm.Parameters.Add(param2);

            comm.Prepare();
            return comm.ExecuteNonQuery();
        }

        public int löschen(Person p)
        {
            string sql = "delete from sprachen where persnr = '" + p.Pers_nr + "'";
            new MySqlCommand(sql, db.conn).ExecuteNonQuery();

            sql = "delete from person where persnr = '" + p.Pers_nr + "'";
            return new MySqlCommand(sql, db.conn).ExecuteNonQuery();
        }

        ~MySqlAbfragen()
        {
            if (db.conn.State == System.Data.ConnectionState.Open)
            {
                db.trennen();
            }
        }
    }
}
