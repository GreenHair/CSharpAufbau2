using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arztpraxis
{
    public class Patient:IComparable<Patient>
    {
        public enum EKrankheit
        {
            Fleischwunde,  Beinbruch
        }

        public string Name { get; private set; }
        public int Alter { get; private set; }
        public EKrankheit Krankheit { get; private set; }
        public bool IstGesund { get; set; }

        public Patient(string _name, int _alter, EKrankheit _krankheit)
        {
            Name = _name;
            Alter = _alter;
            Krankheit = _krankheit;
            IstGesund = false;
        }

        public override bool Equals(object obj)
        {
            if(obj is Patient)
            {
                Patient comp = obj as Patient;
                if (Name == comp.Name && Alter == comp.Alter && Krankheit == comp.Krankheit)
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
            string behandelt = (IstGesund) ? "Gesund" : "Krank";
            return Name + " | " + Alter + " | " + Krankheit + " | " + behandelt;
        }

        public int CompareTo(Patient other)
        {
            return Krankheit.CompareTo(other.Krankheit);
        }
    }
}
