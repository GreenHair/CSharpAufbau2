using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankschliessfach
{
    class Program
    {
        static Bank Sparkasse = new Bank();
        static void Main(string[] args)
        {            
            bool Beenden = false;
            do
            {
                Console.Clear();
                string m1;
                Console.Write("Darf ein Kunde die Bank betreten? (J/N)");
                m1 = Console.ReadLine().ToUpper();
                if(m1 == "J")
                {
                    Console.Clear();
                    foreach(Schliessfach fach in Sparkasse.Schliessfächer.ToList().FindAll(f => f.IstBelegt == false))
                    {
                        Console.WriteLine(fach);
                    }
                    Console.WriteLine("Was will der Kunde machen?");
                    Console.WriteLine(" 1. Fach mieten");
                    Console.WriteLine(" 2. Fach öffnen");
                    Console.WriteLine(" 3. Fach zurückgeben");
                    Console.WriteLine(" 4. Fach befüllen");
                    string m2 = Console.ReadLine();
                    switch (m2)
                    {
                        case "1":
                            FachMieten();
                            break;
                        case "2":
                            FachÖffnen();
                            break;
                        case "3":
                            FachZurückgeben();
                            break;
                        case "4":
                            FachBefüllen();
                            break;
                        default:
                            Console.WriteLine("Unbekannter Eingabe. Drücken Sie eine beliebige Taste...");
                            
                            break;
                    }
                    Console.ReadLine();
                }
                else
                {
                    Beenden = true;
                }
            } while (!Beenden);
        }

        private static void FachMieten()
        {
            Console.WriteLine("Welches Fach möchten Sie mieten? (1 - 4)");
            int nr;
            if(int.TryParse(Console.ReadLine(),out nr))
            {
                Console.WriteLine(Sparkasse.SchliessfachAnmieten(nr - 1));
            }
            else
            {
                Console.WriteLine("Fehler bei der Eingabe.");
            }
        }

        private static void FachÖffnen()
        {
            Console.WriteLine("Welches Fach möchten Sie öffnen? (1 - 4)");
            int nr;
            if(int.TryParse(Console.ReadLine(), out nr))
            {
                List<string> geöffnet = Sparkasse.Schliessfachöffnen(nr - 1);
                if (geöffnet != null)
                {
                    foreach (string inhalt in geöffnet)
                    {
                        Console.WriteLine(inhalt);
                    }
                }
                else
                {
                    Console.WriteLine("Kein Inhalt");
                }
            }
            else
            {
                Console.WriteLine("Fehler bei der Eingabe.");
            }
        }

        private static void FachZurückgeben()
        {
            Console.WriteLine("Welches Fach möchten Sie zurückgeben? (1 - 4)");
            int nr;
            if (int.TryParse(Console.ReadLine(), out nr))
            {
                Console.WriteLine(Sparkasse.Zurückgeben(nr - 1));
            }
            else
            {
                Console.WriteLine("Fehler bei der Eingabe.");
            }
        }

        private static void FachBefüllen()
        {
            Console.WriteLine("Welches Fach möchten Sie befüllen? (1 - 4)");
            int nr;
            if (int.TryParse(Console.ReadLine(), out nr))
            {
                Console.WriteLine("Was möchten Sie in das Schliessfach legen?");
                string Wertsache = Console.ReadLine();
                Console.WriteLine(Sparkasse.Befüllen(nr - 1,Wertsache));
            }
            else
            {
                Console.WriteLine("Fehler bei der Eingabe.");
            }
        }

    }
}
