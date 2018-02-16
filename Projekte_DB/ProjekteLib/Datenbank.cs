using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjekteLib
{
    public class Datenbank
    {
        MySqlConnection conn;
        MySqlCommand comm;
        MySqlDataReader Reader;

        public Datenbank()
        {
            conn = new MySqlConnection("server=localhost;uid=root;");
            conn.Open();
            conn.ChangeDatabase("projekte");
        }

        public Projekt[] AlleProjekte()
        {
            List<Projekt> projekte = new List<Projekt>();
            //comm.CommandText = "Select pj_id,pj_name from projekt";
            //comm = conn.CreateCommand();
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;");
            conn.Open();
            conn.ChangeDatabase("projekte");
            MySqlCommand comm = new MySqlCommand("Select pj_id,pj_name from projekt", conn);
            MySqlDataReader Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                Projekt p = new Projekt();
                p.Id = (int)Reader["pj_id"];
                p.Name = Reader["pj_name"].ToString();
                projekte.Add(p);
            }
            Reader.Close();
            conn.Close();
            return projekte.ToArray();
        }

        public Personal[] GetPersonal(int abt_nr)
        {
            List<Personal> pers = new List<Personal>();
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;");
            conn.Open();
            conn.ChangeDatabase("projekte");
            MySqlCommand comm = new MySqlCommand("SELECT p_id,p_name FROM personal WHERE abt_id = " + abt_nr, conn);
            MySqlDataReader Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                Personal p = new Personal();
                p.Id = (int)Reader["p_id"];
                p.Name = Reader["p_name"].ToString();
                p.Aufgaben = getArbeit(p.Id).ToList();
                pers.Add(p);
            }
            Reader.Close();
            conn.Close();
            return pers.ToArray();
        }
        public Personal[] GetPersonal()
        {
            List<Personal> pers = new List<Personal>();
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;");
            conn.Open();
            conn.ChangeDatabase("projekte");
            MySqlCommand comm = new MySqlCommand("SELECT p_id,p_name FROM personal", conn);
            MySqlDataReader Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                Personal p = new Personal();
                p.Id = (int)Reader["p_id"];
                p.Name = Reader["p_name"].ToString();
                pers.Add(p);
            }
            Reader.Close();
            conn.Close();
            return pers.ToArray();
        }

        public Abteilung[] GetAbteilungen()
        {
            List<Abteilung> abt = new List<Abteilung>();
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;");
            conn.Open();
            conn.ChangeDatabase("projekte");
            MySqlCommand comm = new MySqlCommand("select abt_id,abt_name from abteilung", conn);
            MySqlDataReader Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                Abteilung a = new Abteilung();
                a.Id = (int)Reader["abt_id"];
                a.Name = Reader["abt_name"].ToString();
                a.Arbeiter.AddRange(GetPersonal(a.Id));
                abt.Add(a);
            }
            Reader.Close();
            conn.Close();
            return abt.ToArray();
        }

        public Arbeit[] getArbeit(int pers_nr)
        {
            List<Arbeit> arb = new List<Arbeit>();
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;");
            conn.Open();
            conn.ChangeDatabase("projekte");
            MySqlCommand comm = new MySqlCommand("select pj_id,pj_std from arbeit where p_id = " + pers_nr,conn);
            MySqlDataReader Reader = comm.ExecuteReader();
            while (Reader.Read())
            {
                Arbeit a = new Arbeit();
                a.Task = GetProjekt((int)Reader["pj_id"]);
                a.Stunden = (int)Reader["pj_std"];
                arb.Add(a);
            }
            Reader.Close();
            conn.Close();
            return arb.ToArray();
        }

        public Projekt GetProjekt(int proj_id)
        {
            Projekt p = new Projekt();
            MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;");
            conn.Open();
            conn.ChangeDatabase("projekte");
            MySqlCommand comm = new MySqlCommand("select pj_id,pj_name from projekt where pj_id = " + proj_id, conn);
            MySqlDataReader Reader = comm.ExecuteReader();
            Reader.Read();
            p.Id = (int)Reader["pj_id"];
            p.Name = Reader["pj_name"].ToString();
            Reader.Close();
            conn.Close();
            return p;
        }

        public int GetStunden(int proj_id)
        {
            MySqlCommand comm = new MySqlCommand("SELECT SUM(pj_std) FROM arbeit WHERE pj_id = " + proj_id, conn);
            object std = comm.ExecuteScalar();
            return Convert.ToInt32(std);
        }

        ~Datenbank()
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
