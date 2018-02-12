using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conn = new MySqlConnection();

            //Allg. Aufbau der Zeichenfolge für Verbindung
            //server=[servername];uid=[username];pwd=[password]
            //hier gilt: Username ist root und es gibt kein Passwort, Verbunden wird mit localhost 
            String connString = "server=localhost;uid=root";

            conn.ConnectionString = connString;

            conn.Open();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Verbindung aufgebaut");
            }
            else
            {
                Console.WriteLine("Verbindung konnte nicht hergestellt werden");
                return;
            }

            //Wechseln der Datenbank
            conn.ChangeDatabase("blumenladen");

            //Abfrage, wie viele Einträge in Tabelle verkauf vorhanden sind
            MySqlCommand comm = new MySqlCommand("select count(*) from verkauf", conn);

            Console.WriteLine(comm.ExecuteScalar());
            string sql = "select * from blume";
            comm = new MySqlCommand(sql, conn);
            MySqlDataReader Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                for(int i = 0; i < Reader.FieldCount; i++)
                {
                    Console.Write("{0,-15}",Reader[i] );
                }
                Console.WriteLine();
            }
            conn.Close();
            Console.WriteLine(new string('*', 50));

            sql = "select bs_id, sum(anzahl) from verkauf group by bs_id;";
            comm = new MySqlCommand(sql, conn);
            conn.Open();
            Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    Console.Write("{0,-15}", Reader[i]);
                }
                Console.WriteLine();
            }
            conn.Close();
            Console.WriteLine(new string('*', 50));

            //Console.Write("Blumenname eingeben: ");
            //string name = Console.ReadLine();
            //Console.Write("Preis eingeben: ");
            //string preis = Console.ReadLine();
            //Console.Write("Anzahl eingeben: ");
            //string anzahl = Console.ReadLine();
            //sql = "insert into blume(art,preis,anzahl) values ('" + name + "'," + preis + "," + anzahl + ")";
            //comm = new MySqlCommand(sql, conn);
            //conn.Open();
            //int result = comm.ExecuteNonQuery();
            //Console.WriteLine("insert: {0} zeilen betroffen",result);
            //conn.Close();
            //Console.WriteLine(new string('*', 50));

            //sql = "update blume set preis=3.67 where art='Diestel'";
            //comm = new MySqlCommand(sql, conn);
            //conn.Open();
            //int result = comm.ExecuteNonQuery();
            //Console.WriteLine("update: {0} zeilen betroffen", result);
            //conn.Close();
            //Console.WriteLine(new string('*', 50));

            sql = "select bs_id, sum(anzahl*preis) from v_verkauf group by bs_id;";
            comm = new MySqlCommand(sql, conn);
            conn.Open();
            Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                for (int i = 0; i < Reader.FieldCount; i++)
                {
                    Console.Write("{0,-15}", Reader[i]);
                }
                Console.WriteLine();
            }
            conn.Close();
            Console.WriteLine(new string('*', 50));

            sql = "select sum(anzahl) from blume";
            comm = new MySqlCommand(sql, conn);
            conn.Open();
            Console.WriteLine(comm.ExecuteScalar());
            conn.Close();
            Console.WriteLine(new string('*', 50));

            sql = "select avg(summe) from (select sum(preis*anzahl) as summe from v_verkauf group by bs_id) as durchschnitt;";
            comm = new MySqlCommand(sql, conn);
            conn.Open();
            Console.WriteLine(comm.ExecuteScalar());
            conn.Close();
            Console.WriteLine(new string('*', 50));

            Console.ReadLine();
        }
    }
}
