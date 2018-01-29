using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BieneBiblio
{
    public class Biene
    {
        public enum EGeschlecht
        {
            Männlich, Weiblich
        }

        static string farbe = "Gelb-Schwarz-Gestreift";

        public int Alter { get; private set; }
        public double Gewicht { get; private set; }
        public EGeschlecht Geschlecht { get; private set; }

        public Biene(int _alter, double _gewicht, EGeschlecht _was)
        {
            Alter = _alter;
            Gewicht = _gewicht;
            Geschlecht = _was;
        }

        public void Geburtstag()
        {
            Alter++;
        }

        public string Fliegen(double distanz)
        {
            double aenderung = distanz / 100;
            if(Gewicht-aenderung > 0)
            {
                Gewicht -= aenderung;
                return "geschafft";
            }
            else
            {
                return "Geht nicht";
            }
        }

        public string Fressen(double menge)
        {
            Gewicht += menge * .5;
            return "Ich bin soooo voll";
        }

        public string Farbe
        {
            get
            {
                return farbe;
            }
        }

        public string gehBestaeuben(Blume blume)
        {
            return blume.Bestaeuben();
        }

        public String umwandelnGeschlecht()
        {
            if (this.Geschlecht == EGeschlecht.Männlich)
            {
                this.Geschlecht = EGeschlecht.Weiblich;
                return "Nu bin ich eine Frau";
            }
            else
            {
                this.Geschlecht = EGeschlecht.Männlich;
                return "nu bin ich ein Mann";
            }
        }

        public override string ToString()
        {
            return Alter + "|" + Gewicht + "|" + Geschlecht + "|" + farbe;
        }

        public override bool Equals(object obj)
        {
            //ACHTUNG: casting ohne Prüfung !!!! 
            Biene vergleich = (Biene)obj;

            Console.WriteLine(this);
            Console.WriteLine(vergleich);
            if (this.Alter == vergleich.Alter && this.Geschlecht == vergleich.Geschlecht)
            {
                Console.WriteLine("RICHTIG");
                return true;
            }
            return false;
        }
    }
}
