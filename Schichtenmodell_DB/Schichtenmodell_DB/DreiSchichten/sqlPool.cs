using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schichtenmodell_DB.DreiSchichten
{
    class sqlPool
    {
        public static Artikel[] getAlleArtikel()
        {
            List<Artikel> alle = new List<Artikel>();
            Datenbank db = new Datenbank("localhost", "root", "", "versandhaus");
            db.verbinden();
            List<List<string>> tabelle = db.ausgebenTabelle("select artikel_id,epreis,vpreis,bezeichnung,lager_id from artikel");
            foreach (List<string> zeile in tabelle)
            {
                Artikel a = new Artikel();
                a.Artikel_id = Convert.ToInt32(zeile[0]);
                a.EPreis = Convert.ToDouble(zeile[1]);
                a.VPreis = Convert.ToDouble(zeile[2]);
                a.bezeichnung = zeile[3].ToString();
                if (zeile[4].Length > 0)
                    a.Lager_id = Convert.ToInt32(zeile[4]);

                alle.Add(a);
            }
            db.trennen();
            return alle.ToArray();
        }
    }
}
