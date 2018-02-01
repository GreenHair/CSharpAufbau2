using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBeet
{
    class BeetK
    {
        private List<Kohlrabi> _möhren;
        private static Random rnd = new Random();

        public BeetK()
        {
            _möhren = new List<Kohlrabi>();
        }

        public void Aussäen(params Kohlrabi[] saatgut)
        {
            foreach (Kohlrabi m in saatgut)
            {
                _möhren.Add(m);
            }
        }

        public string Bewirtschaften()
        {
            int zufall = rnd.Next(2);
            switch (zufall)
            {
                case 0:
                    foreach (Kohlrabi m in _möhren)
                    {
                        return m.VernichtenFeind();
                    }
                    break;
                case 1:
                    foreach (Kohlrabi m in _möhren)
                    {
                        return m.Bewässern();
                    }
                    break;
            }
            return "Nicht bewirtschaftet";
        }

        public List<Kohlrabi> Ernten()
        {
            List<Kohlrabi> ernte = new List<Kohlrabi>();
            ernte = _möhren.FindAll(m => m.IsReif);
            _möhren.RemoveAll(m => m.IsReif);

            return ernte;
        }

        public List<Kohlrabi> Möhren
        {
            get
            {
                return _möhren;
            }

            set
            {
                _möhren = value;
            }
        }
    }
}
