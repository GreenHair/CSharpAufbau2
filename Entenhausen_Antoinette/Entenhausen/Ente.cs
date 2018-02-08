using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entenhausen
{
    class Ente
    {
        private List<Sack> liste;

        private Geldspeicher speicher;

        public Ente(List<Sack> wohin, Geldspeicher woher)
        {
            liste = wohin;
            speicher = woher;
        }

        public void schaufeln()
        {
            Random rnd = new Random();
            int schaufel, menge;
            while (speicher.Taler > 0)
            {
                schaufel = rnd.Next(Sack.Max);

                menge = speicher.leeren(schaufel);
                if (menge > 0)
                {
                    liste.Add(new Sack(menge));
                    Console.WriteLine("Sack mit " + menge + " Talern abgefüllt");
                }
            }
        }
    }
}
