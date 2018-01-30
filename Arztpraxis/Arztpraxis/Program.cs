using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arztpraxis
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> Wartezimmer = new List<Patient>();
            Wartezimmer.Add(new Patient("Heinrich", 68, Patient.EKrankheit.Beinbruch));
            Wartezimmer.Add(new Patient("Ursula", 28, Patient.EKrankheit.Fleischwunde));
            Wartezimmer.Add(new Patient("Grisela", 47, Patient.EKrankheit.Beinbruch));
            Wartezimmer.Add(new Patient("Horst", 35, Patient.EKrankheit.Fleischwunde));
            Wartezimmer.Add(new Patient("Brunnhilde", 52, Patient.EKrankheit.Beinbruch));
            Wartezimmer.Add(new Patient("Wilhelm", 56, Patient.EKrankheit.Fleischwunde));
            foreach (Patient p in Wartezimmer)
                Console.WriteLine(p);

            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Die Schwester wird nun die Patienten sortieren.");
            Wartezimmer.Sort(new PatientAlterVergleich());
            Wartezimmer.Sort();
            
            foreach (Patient p in Wartezimmer)
                Console.WriteLine(p);
            Console.WriteLine();
            Console.WriteLine("Bitte einzeln eintreten.");
            Console.ReadLine();
            foreach(Patient p in Wartezimmer)
            {
                Console.Clear();
                Console.WriteLine(p);
                Console.WriteLine("Ist dieser Patient noch Krank? (J/N)");
                string entscheid = Console.ReadLine();
                entscheid = entscheid.ToUpper();
                if(entscheid == "N")
                {
                    p.IstGesund = true;
                }
                else
                {
                    Console.WriteLine("Der Patient bleibt Krank...");
                }
                Console.WriteLine("Entertaste für der nächste Patient....");
                Console.ReadLine();
            }
            Console.WriteLine(new string('-', 30));
            foreach(Patient p in Wartezimmer.FindAll( pat => pat.IstGesund == true))
                Console.WriteLine(p);
            Console.WriteLine();
            foreach (Patient p in Wartezimmer.FindAll(pat => pat.IstGesund == false))
                Console.WriteLine(p);
            Console.WriteLine();
            Wartezimmer.RemoveAll(p => p.IstGesund == true);
            Console.WriteLine("Es sind noch {0} Patienten Krank.", Wartezimmer.Count);

            Console.ReadLine();
        }
    }
}
