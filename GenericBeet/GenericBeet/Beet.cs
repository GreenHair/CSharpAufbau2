using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBeet
{
    class Beet<T,U> where T:Gemüse where U:Person
    {
        private List<T> _gemüse;
        private static Random rnd = new Random();

        public Beet()
        {
            _gemüse = new List<T>();
        }

        public void Aussäen(params T[] saatgut)
        {
            foreach(T m in saatgut)
            {
                _gemüse.Add(m);
            }
        }

        public string Bewirtschaften(U p)
        {
            if (p is Gärtner)
            {
                foreach (T m in _gemüse)
                {
                    m.VernichtenFeind();
                    m.Bewässern();
                }
                return "Der Gärtner war da.";
            }
            else
            {
                if (p.Skills > 50)
                {
                    int zufall = rnd.Next(2);
                    switch (zufall)
                    {
                        case 0:
                            foreach (T m in _gemüse)
                            {
                                m.VernichtenFeind();
                            }
                            // break;
                            return "Feinde vernichtet";
                        case 1:
                            foreach (T m in _gemüse)
                            {
                                m.Bewässern();
                            }
                            return "Gemüse wurde bewässert";
                    }
                }
                return "Nicht bewirtschaftet";
            }
            return "";
        }

        public List<T> Ernten()
        {
            List<T> ernte = new List<T>();
            ernte = _gemüse.FindAll(m => m.IsReif);
            _gemüse.RemoveAll(m => m.IsReif);

            return ernte;
        }

        public List<T> Gemüse
        {
            get
            {
                return _gemüse;
            }

            set
            {
                _gemüse = value;
            }
        }
    }
}
