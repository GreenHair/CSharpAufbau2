using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibo_Teich
{
    public class Frosch
    {
        private static string Quak = "Quak";
        public static readonly int AnzahlBeine = 2;
        public string Name { get; private set; }
        public int Alter { get; private set; }
        public bool HatHunger { get; private set;}
        public int MaxAlter { get; }

        public Frosch(string _name, int _alter,int _maxAlter, bool _hunger)
        {
            Name = _name;
            Alter = _alter;
            MaxAlter = _maxAlter;
            HatHunger = _hunger;
        }

        public string Springen(double hoehe)
        {
            return "Ich springe " + hoehe + "cm hoch!";
        }

        public string Geburtag()
        {
            string result;
            if(Alter+1 < MaxAlter)
            {
                Alter++;
                result = "Ich bin jetzt 1 Jahr älter";
            }
            else
            {
                result = "Das war mein letzter Geburtstag....";
            }
            return result;
        }

        public string Quaken()
        {
            return Quak;
        }

        public string Fressen(Fliege mahlzeit)
        {
            return "Die Fliege sagt: " + mahlzeit.WirdGefressen();
        }

        public override string ToString()
        {
            string jaNein = (HatHunger) ? "Ja" : "Nein";
            return "Name: " + Name + "Alter: " + Alter + "Hungrig: " + jaNein;
        }

        public override bool Equals(object obj)
        {
            Frosch vergleich = obj as Frosch;
            if(Name == vergleich.Name && Alter == vergleich.Alter && MaxAlter == vergleich.MaxAlter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            if (HatHunger)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
