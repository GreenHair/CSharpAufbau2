using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Call_Center_Threading
{
    class Anruf
    {
        
        public enum Priorität
        {
            Neukunde,Beschwerde,Bestandskunde
        }
        Random rand = new Random();
        public readonly int Nummer;
        public Priorität Wichtigkeit { get; private set; }

        public Anruf(int nr)
        {
            Nummer = nr;
            Wichtigkeit = (Priorität)rand.Next(3);
        }

        //public int CompareTo(object obj)
        //{
        //    if(obj.GetType() == typeof(Anruf))
        //    {
        //        Anruf a = obj as Anruf;
        //        return Nummer.CompareTo(a.Nummer);
        //    }
        //    return -1;
        //}
    }
}
