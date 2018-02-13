using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PreparedStatements_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root";
            conn.Open();
            conn.ChangeDatabase("test");

            int zahl = 10;
            string sql = "insert into prepstmt (zahl) values (" + zahl + ")";
            Console.WriteLine("SQL: " + sql);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            Console.WriteLine(comm.ExecuteNonQuery());

            double komma = 3.1465;
            sql = "insert into prepstmt (komma) values (" + komma + ")"; // Wurde ein exception audslösen
            Console.WriteLine("SQL: " + sql);
            string prepare = "insert into prepstmt (komma) values (@komma)";
            comm = new MySqlCommand(prepare, conn);
            MySqlParameter param = new MySqlParameter("@komma", MySqlDbType.Double, 0);
            param.Value = komma;
            comm.Parameters.Add(param);
            comm.Prepare();
            Console.WriteLine(comm.ExecuteNonQuery());

            string wort = "Hallo Welt";
            sql = "insert into prepstmt (wort) values ('" + wort + "')";
            Console.WriteLine("SQL: " + sql);
            comm = new MySqlCommand(sql, conn);
            Console.WriteLine(comm.ExecuteNonQuery());

            //SQL-Injection
            wort = "';select * from prepstmt;";
            sql = "insert into prepstmt (wort) values ('" + wort + "')";
            Console.WriteLine("SQL: " + sql);

            prepare = "insert into prepstmt (wort) values (@wort)";
            comm = new MySqlCommand(prepare, conn);
            param = new MySqlParameter("@wort", MySqlDbType.VarChar, 100);
            param.Value = wort;
            comm.Parameters.Add(param);
            comm.Prepare();
            Console.WriteLine(comm.ExecuteNonQuery());
        }
    }
}
