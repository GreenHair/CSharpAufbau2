using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bibo
{
    public class Lieferdienst
    {
        private List<Pizza> Bestellungen = new List<Pizza>();

        private double getPrice(Pizza p)
        {
            double price = 0;
            if (p.Size == "Klein") price = 3.50;
            else if (p.Size == "Mittel") price = 5;
            else price = 7.50;

            price = price + p.Belag.Count;

            if (p.Sonder.Length > 0) price += 3;
            return price;
        }
        public double bestellen(Pizza p)
        {
            Bestellungen.Add(p);
            
            return getPrice(p);
        }

        public double getUmsatz()
        {
            double price = 0;
            foreach (Pizza p in Bestellungen)
            {
                if (p.Fertig == true)
                {
                    price += getPrice(p);
                }
            }
            return price;
        }

        public Pizza[] getAlle()
        {
            return Bestellungen.ToArray();
        }

        public String[] getSizes()
        {
            return new String[] { "Klein", "Mittel", "Groß" };
        }
    }
}
