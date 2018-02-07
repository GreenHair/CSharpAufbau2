using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreiDDrucker
{
    class Drucker
    {
        public Queue<Druckauftrag> Warteschlange { get; private set; }
        public int Betriebszeit { get; private set; }

        public Drucker()
        {
            Warteschlange = new Queue<Druckauftrag>();
        }

        public void Hinzufügen(Druckauftrag auftrag)
        {
            Warteschlange.Enqueue(auftrag);
            Console.WriteLine("Druckauftrag hinzugefügt");
        }

        public void Drucken()
        {
            while(Warteschlange.Count > 0)
            {
                Druckauftrag auftrag = Warteschlange.Dequeue();
                Console.WriteLine("Gedruckt wird ein(e) {0}, Dauer: {1}", auftrag.Beschreibung, auftrag.Dauer);
                Betriebszeit += auftrag.Dauer;
            }
        }
    }
}
