using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibPizzalieferung
{
    public class Pizza
    {
        public string Groesse { get; set; }
        public List<string> Belag { get; set; }
        public bool Fertig { get; set; }

        public Pizza()
        {
            Belag = new List<string>();
        }
    }

    public delegate void Message(string message);

    public class Lieferdienst
    {
        public List<Pizza> Bestellungen { get; set; }
        public List<string> Groessen { get; set; }
        public double Umsatz { get; set; }
        Message Log;

        public Lieferdienst()
        {
            Bestellungen = new List<Pizza>();
            Groessen = new List<string>() { "Klein", "Mittlel", "Groß" };
        }

        public void Bestellen(Pizza p)
        {
            Bestellungen.Add(p);
        }

        public void Bestellen(string groesse, List<string> belag)
        {
            Bestellungen.Add(new Pizza { Groesse = groesse, Belag = belag });
        }
    }
}
