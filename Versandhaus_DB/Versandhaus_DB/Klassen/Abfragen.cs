using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versandhaus_DB.Klassen
{
    class Abfragen
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
                a.Id = Convert.ToInt32(zeile[0]);
                a.EPreis = Convert.ToDouble(zeile[1]);
                a.VPreis = Convert.ToDouble(zeile[2]);
                a.Bezeichnung = zeile[3].ToString();
                if (zeile[4].Length > 0)
                {
                    switch (Convert.ToInt32(zeile[4]))
                    {
                        case 100:
                            a.LagerArt = Lager.Technik;
                            break;
                        case 2:
                            a.LagerArt = Lager.Kleidung;
                            break;
                    }
                }
                else
                {
                    a.LagerArt = Lager.Unbekannt;
                }
                alle.Add(a);
            }
            db.trennen();
            return alle.ToArray();
        }

        public static Kunde[] AlleKundenDetail()
        {
            Datenbank db = new Datenbank("localhost", "root", "", "versandhaus");
            db.verbinden();
            List<List<string>> tabelle = db.ausgebenTabelle("select k.kunden_id,k.nachname,k.vorname,kd.gebDatum,kd.bild from kunde as k"
                +" left outer join kundendetails as kd on k.kunden_id=kd.kunden_id;");
            List<Kunde> AlleKunden = new List<Kunde>();
            foreach(List<string> zeile in tabelle)
            {
                Kunde k = new Kunde();
                k.Kunden_Id = Convert.ToInt32(zeile[0]);
                k.Nachname = zeile[1];
                k.Vorname = zeile[2];
                if (zeile[3].Length > 0) { k.Geburtsdatum = Convert.ToDateTime(zeile[3]); }
                if (zeile[4].Length > 0) { k.BildPfad = zeile[4]; }
                k.Bestellungen.AddRange(BestellungenVonKunde(k.Kunden_Id));
                AlleKunden.Add(k);

            }
            db.trennen();
            return AlleKunden.ToArray();

        }

        public static Bestellung[] BestellungenVonKunde(int k_id)
        {
            Datenbank db = new Datenbank("localhost", "root", "", "versandhaus");
            db.verbinden();
            // List<List<string>> tabelle = db.ausgebenTabelle(" select b.kunden_id,b.datum,b.bestell_nr,a.bezeichnung,bp.anzahl,bp.anzahl*a.vpreis as position from bestellung as b join bestellpositionen as bp on b.bestell_nr=bp.bestell_nr join artikel as a on bp.artikel_id=a.artikel_id where b.kunden_id=11;");
            List<List<string>> tabelle = db.ausgebenTabelle("");
            List<Bestellung> Bestellungen = new List<Bestellung>();
            
            foreach (List<string> zeile in tabelle)
            {
                Bestellung b = new Bestellung();
                b.Kunden_Id = Convert.ToInt32(zeile[0]);
                b.Datum = Convert.ToDateTime(zeile[1]);
                b.Bestellnummer = Convert.ToInt32(zeile[2]);
                b.Positionen.AddRange(BestellPositionenVonBestellung(b.Bestellnummer));
            }


            return Bestellungen.ToArray();
        }

        private static Bestellposition[] BestellPositionenVonBestellung(int bestellnummer)
        {
            List<Bestellposition> Bestellpositionen = new List<Bestellposition>();
            Datenbank db = new Datenbank("localhost", "root", "", "versandhaus");
            db.verbinden();
            List<List<string>> tabelle = db.ausgebenTabelle("");
            List<Bestellung> Bestellungen = new List<Bestellung>();
            foreach(List<string> zeile in tabelle)
            {
                Bestellposition bp = new Bestellposition();
                bp.Id;
                bp.Ware = getArtikel(bp._id);
            }

            return Bestellpositionen.ToArray();
        }

        private static Artikel getArtikel(int art_id)
        {
            throw new NotImplementedException();
        }
    }
}
