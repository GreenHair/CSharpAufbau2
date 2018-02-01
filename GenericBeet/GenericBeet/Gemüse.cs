using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBeet
{
    class Gemüse
    {
        public bool IsReif { get; private set; }
        public string Wer { get; private set; }

        public Gemüse()
        {
            IsReif = false;
        }

        public string Bewässern()
        {
            IsReif = true;
            return "Die " + GetType().Name + " wurde bewässert und ist jetzt reif";
        }

        public string VernichtenFeind()
        {
            IsReif = false;
            return "Feinde vernichtet";
        }

        public void Branding(string wer)
        {
            Wer = wer;
        }
    }
}
