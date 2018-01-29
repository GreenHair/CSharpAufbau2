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
            if (!HatHunger)
            {
                HatHunger = true;
                return "Ich springe " + hoehe + "cm hoch, jetzt habe ich Hunger";
            }
            else
            {
                return "Mit leerem Magen kann ich nicht springen";
            }
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

        public string Fressen(ref Fliege mahlzeit)
        {
            string antwort;
            if (HatHunger)
            {
                HatHunger = false;                
                antwort = "Die Fliege sagt: " + mahlzeit.WirdGefressen();
            }
            else
                antwort = "Bin satt";
            mahlzeit = null;
            return antwort;
        }

        public override string ToString()
        {
            string jaNein = (HatHunger) ? "Ja" : "Nein";
            return "Name: " + Name + "\tAlter: " + Alter + "\tHungrig: " + jaNein;
        }

        public override bool Equals(object obj)
        {
            if (obj is Frosch)
            {
                Frosch vergleich = obj as Frosch;
                if (Name == vergleich.Name && Alter == vergleich.Alter && MaxAlter == vergleich.MaxAlter)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
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
