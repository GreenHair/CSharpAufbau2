using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankschliessfach
{
    class Bank
    {
        public Schliessfach[] Schliessfächer { get; private set; }

        public Bank()
        {
            Schliessfächer = new Schliessfach[4];
            for(int i = 0; i < Schliessfächer.Length; i++)
            {
                Schliessfächer[i] = new Schliessfach();
            }
        }

        public List<string> Schliessfachöffnen(int nr)
        {
            List<string> inhalt;
            if (nr < 4 && nr >= 0)
            {
                inhalt = Schliessfächer[nr].GetInhalt();
            }
            else
            {
                inhalt = null;
            }
            return inhalt;
        }

        public string SchliessfachAnmieten(int nr)
        {
            if (nr < 4 && nr >= 0)
            {
                if (Schliessfächer[nr].IstBelegt)
                {
                    return "Das Schließfach ist Belegt.";
                }
                else
                {
                    Schliessfächer[nr].IstBelegt = true;
                    return "Das Schliessfach wurde angemietet.";
                }
            }
            return "Fach nicht vorhanden";
        }

        public string Zurückgeben(int nr)
        {
            if (nr < 4 && nr >= 0)
            {
                Schliessfächer[nr].IstBelegt = false;
                return "Das Schliessfach wurde zurück gegeben.";
            }
            else
            {
                return "Schließfach nicht vorhanden.";
            }
        }

        public string Befüllen(int nr, string wertsache)
        {
            if (nr < 4 && nr >= 0)
            {
                Schliessfächer[nr - 1].Hineinlegen(wertsache);
                return "Das Schließfach wurde befüllt";
            }
            else
            {
                return "Schließfach nicht vorhanden.";
            }
        }
    }
}
