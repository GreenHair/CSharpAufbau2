using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekatologLib
{
    public delegate void Logging(string message);

    public class Katalog
    {
        public List<Reiseziel> Ziele;
        public event Logging Log;

        public Katalog()
        {
            Ziele = new List<Reiseziel>();

            Reiseziel r1 = new Reiseziel { Land = "Schweiz", Ort = "Bern", Unterkunft = new List<Hotel>() };
            r1.Unterkunft.Add(new Hotel { Name = "Continental", Bewertung = 4, Bild = @"Images\R1H1.jpg" });
            r1.Unterkunft.Add(new Hotel { Name = "Hilton", Bewertung = 5, Bild = @"Images\R1H2.jpg" });
            r1.Unterkunft.Add(new Hotel { Name = "Econtel", Bewertung = 3, Bild = @"Images\R1H3.jpg" });
            Ziele.Add(r1);

            Reiseziel r2 = new Reiseziel { Land = "Italien", Ort = "Rom", Unterkunft = new List<Hotel>() };
            r2.Unterkunft.Add(new Hotel { Name = "Prima Donna", Bewertung = 4, Bild = @"Images\R2H1.jpg" });
            r2.Unterkunft.Add(new Hotel { Name = "Colloseum", Bewertung = 5, Bild = @"Images\R2H2.jpg" });
            r2.Unterkunft.Add(new Hotel { Name = "Cavalieri", Bewertung = 3, Bild = @"Images\R2H3.jpg" });
            Ziele.Add(r2);

            Reiseziel r3 = new Reiseziel { Land = "Turkei", Ort = "Istanbul", Unterkunft = new List<Hotel>() };
            r3.Unterkunft.Add(new Hotel { Name = "Cevahir", Bewertung = 4, Bild = @"Images\R3H1.jpg" });
            r3.Unterkunft.Add(new Hotel { Name = "Antik", Bewertung = 5, Bild = @"Images\R3H2.jpg" });
            r3.Unterkunft.Add(new Hotel { Name = "Raddisson", Bewertung = 3, Bild = @"Images\R3H3.jpg" });
            Ziele.Add(r3);
        }

        public Reiseziel[] AlleZiele()
        {
            Log?.Invoke("Alle Reiseziele herausgesucht");
            return Ziele.ToArray();
        }

        public Hotel[] HotelsInZiel(string land)
        {
            Reiseziel ziel = Ziele.Find(z => z.Land == land);
            Log?.Invoke("Alle Hotels in " + land + " herausgesucht");
            return ziel.Unterkunft.ToArray();
        }

        public Hotel[] HotelsInZiel(string land,string ort)
        {
            Reiseziel ziel = Ziele.Find(z => z.Land == land && z.Ort == ort);
            Log?.Invoke("Alle Hotels in " + land + " in Stadt " + ort + " herausgesucht");
            return ziel.Unterkunft.ToArray();
        }

        public Hotel[] HotelsInZiel(string ort, int sterne)
        {
            Reiseziel ziel = Ziele.Find(z => z.Ort == ort);
            List<Hotel> hotels = ziel.Unterkunft.FindAll(h => h.Bewertung >= sterne);
            Log?.Invoke("Alle Hotels in " + ort + " mit " + sterne + " Sterne oder mehr herausgesucht");
            return hotels.ToArray();
        }
    }
}
