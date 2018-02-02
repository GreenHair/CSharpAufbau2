using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunktezählerWerbeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Browser Firefox = new Browser();
            WerbeApp Videoplugin = new WerbeApp();
            List<Video> YouTube = new List<Video>();
            YouTube.Add(new Video(true));
            YouTube.Add(new Video(false));
            YouTube.Add(new Video(false));
            YouTube.Add(new Video(false));
            YouTube.Add(new Video(true));
            YouTube.Add(new Video(true));
            YouTube.Add(new Video(false));
            YouTube.Add(new Video(true));
            YouTube.Add(new Video(false));
            YouTube.Add(new Video(true));
            YouTube.Add(new Video(false));
            YouTube.Add(new Video(true)); // 12 Video's, davon 6 Werbevideos

            Firefox.Zähler += Videoplugin.Untersuchen;

            Console.WriteLine("Das Punktkonto hat {0} Punkte", Videoplugin.Punktkonto);

            foreach (Video film in YouTube)
            {
                Console.WriteLine("Das Punktekonto hat jetzt {0} Punkte", Firefox.Abspielen(film));
            }

            Console.WriteLine("Das Punktkonto hat {0} Punkte", Videoplugin.Punktkonto);
        }
    }
}
