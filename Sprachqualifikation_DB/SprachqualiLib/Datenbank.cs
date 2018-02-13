using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SprachqualiLib
{
    public class Datenbank
    {
        public MySqlConnection conn;
        public MySqlCommand comm;
        string Server;
        string User;
        string Password;
        string Database;

        public Datenbank(string _server, string _user, string _password, string _database)
        {
            Server = _server;
            User = _user;
            Password = _password;
            Database = _database;
            conn = new MySqlConnection();
        }

        public bool verbinden()
        {
            conn.ConnectionString = "server=" + Server + ";uid=" + User + ";pwd=" + Password + ";";
            conn.Open();
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.ChangeDatabase(Database);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void trennen()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public List<List<string>> ausgebenTabelle(string sql)
        {
            List<List<string>> tabelle = new List<List<string>>();
            comm = new MySqlCommand(sql, conn);
            MySqlDataReader msdr = comm.ExecuteReader();
            while (msdr.Read())
            {
                List<string> zeile = new List<string>();
                for (int i = 0; i < msdr.FieldCount; i++)
                {
                    zeile.Add(msdr[i].ToString());
                }
                tabelle.Add(zeile);
            }
            msdr.Close();
            return tabelle;
        }

        public object zahlAusgeben(string sql)
        {
            comm = new MySqlCommand(sql, conn);
            return comm.ExecuteScalar();
        }

        public int datenAendern(string sql)
        {
            comm = new MySqlCommand(sql, conn);
            return comm.ExecuteNonQuery();
        }
    }
}
