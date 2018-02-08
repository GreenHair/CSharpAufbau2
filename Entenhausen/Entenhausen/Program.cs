using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entenhausen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sack> AlleSäcke = new List<Sack>();
            Geldspeicher Bank = new Geldspeicher();
            Console.WriteLine("Im Speicher sind {0} Taler", Bank.Taler);
            while(Bank.Taler > 0)
            {
                AlleSäcke.Add(new Sack(Bank.Entnehmen()));
            }
            Console.WriteLine("Es wurden {0} Säcke befüllt", AlleSäcke.Count);
            Console.WriteLine("Es sind durchschnittlich {0:F2} Taler in einem Sack.", AlleSäcke.Average(s => s.Inhalt));
            Console.WriteLine("Der größte Sack hat {0} Taler und der kleinste {1} Taler",
                                AlleSäcke.Max(s => s.Inhalt), AlleSäcke.Min(s => s.Inhalt));
            Console.ReadLine();
        }
    }
}
