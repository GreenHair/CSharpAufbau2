using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB_Taxicentrale
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection connection = new MySqlConnection();
            
            String connString = "server=localhost;uid=root";

            connection.ConnectionString = connString;

            connection.Open();

            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Verbindung aufgebaut");
            }
            else
            {
                Console.WriteLine("Verbindung konnte nicht hergestellt werden");
                return;
            }

            connection.ChangeDatabase("Taxicentrale");

            MySqlCommand command = new MySqlCommand("Select nummer,belegt from taxi", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                //for(int i = 0; i < reader.FieldCount; i++)
                //{
                //    Console.Write("{0,-15}", reader[i]);
                //}
                //Console.WriteLine();
                Console.WriteLine("Taxi nr: {0}\tBelegt: {1}", reader[0],Convert.ToBoolean(reader[1]));
            }
            reader.Close();
            Console.WriteLine(new string('-', 50));

            command = new MySqlCommand("Select nummer,belegt from taxi where belegt=0", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Taxi nr: {0}\tBelegt: {1}", reader[0], Convert.ToBoolean(reader[1]));
            }
            reader.Close();
            Console.WriteLine(new string('-', 50));

            command = new MySqlCommand("Select nummer,belegt from taxi where nummer=2", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Taxi nr: {0}\tBelegt: {1}", reader[0], Convert.ToBoolean(reader[1]));
            }
            reader.Close();
            Console.WriteLine(new string('-', 50));

            string fahrt = "insert into fahrt (start,ende,kilometer) values ('11:05','11:55',45);"
                + "update taxi set belegt=1,fahrtnr=last_insert_id() where belegt = 0 limit 1;";
            command = new MySqlCommand(fahrt, connection);
            int result = command.ExecuteNonQuery();
            Console.WriteLine(result + " Zeilen betroffen");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Welches Taxi möchten Sie zurück geben?");
            command = new MySqlCommand("Select nummer from taxi where belegt=1",connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Taxi Nr: " + reader[0]);
            }
            reader.Close();
            int nr = Convert.ToInt32(Console.ReadLine());


            string sql = "update taxi set belegt=0 where nummer="+nr+";"
                + "select kilometer from fahrt join taxi on fahrt.nummer = taxi.fahrtnr where taxi.nummer="+nr+";";
            command = new MySqlCommand(sql, connection);
            object kilo = command.ExecuteScalar();
            Console.WriteLine("Mit Taxi {1} wurde {0}km gefahren", kilo,nr);

            sql = "select sum(kilometer) from fahrt";
            command = new MySqlCommand(sql, connection);
            object obj = command.ExecuteScalar();
            Console.WriteLine((Convert.ToDouble(obj) * 1.5).ToString("F2") + "Euro Umsatz erzeugt");



            connection.Close();
        }
    }
}
