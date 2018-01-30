using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Mitarbeiter
    {
        public string Name { get; private set; }
        public int Alter{ get; private set; }
        public double Gehalt { get; private set; }

        public Mitarbeiter(string _name, int _alter, int _gehalt)
        {
            Name = _name;
            Alter = _alter;
            Gehalt = _gehalt;                       
        }

        public override bool Equals(object obj)
        {
            if(obj is Mitarbeiter)
            {
                Mitarbeiter temp = obj as Mitarbeiter;
                if (Name == temp.Name && Alter == temp.Alter && Gehalt == temp.Gehalt)
                        return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.Length + Alter;
        }

        public override string ToString()
        {
            return String.Format("{0,-10} {1}\t{2:C}", Name, Alter, Gehalt);
        }
    }
}
