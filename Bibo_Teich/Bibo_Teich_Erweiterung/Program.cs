using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibo_Teich;

namespace Bibo_Teich_Erweiterung
{
    class Program
    {
        static void Main(string[] args)
        {
            Frosch[] meineFrösche = new Frosch[3];
            meineFrösche[0] = new Frosch("Kermit", 1, 4, true);
            meineFrösche[1] = new Frosch("Karel", 2, 3, true);
            meineFrösche[2] = new Frosch("Konstantin", 1, 3, true);

            Fliege[] meineFliegen = new Fliege[3] { new Fliege(), new Fliege(), new Fliege() };

            int fliegen = meineFliegen.Length;
            int frösche = meineFrösche.Length;
            int jarige;

            do
            {
                foreach(Frosch kikker in meineFrösche)
                {
                    Console.WriteLine(kikker);
                }
                Console.WriteLine("Welcher Frosch dasf Geburtstag feiern?");
                if(int.TryParse(Console.ReadLine(), out jarige))
                {
                    if(jarige > 0 && jarige <= meineFrösche.Length)
                    {
                        if(meineFrösche[jarige -1].IstLebendig)
                        {
                            Console.WriteLine(meineFrösche[jarige-1].Geburtag());
                            if (meineFrösche[jarige - 1].IstLebendig == false)
                            {
                                //meineFrösche[jarige - 1] = null;
                                frösche--;
                            }
                            else
                            {
                                if (meineFliegen[fliegen - 1] != null)
                                {
                                    Console.WriteLine(meineFrösche[jarige - 1].Fressen(ref meineFliegen[fliegen - 1]));
                                    if (meineFliegen[fliegen - 1] == null)
                                        fliegen--;
                                }
                                //else
                                //{
                                //    Console.WriteLine("Dieser Frosch hat schon eine Fliege bekommen");
                                //}
                            }
                        }
                        else
                        {
                            Console.WriteLine("Dieser Frosch ist tot");
                        }
                    }
                }
            } while (fliegen >= 1 && frösche >= 1);
        }
    }
}
