using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBeet
{
    class BeetM
    {
        private List<Möhre> _möhren;
        private static Random rnd = new Random();

        public BeetM()
        {
            _möhren = new List<Möhre>();
        }

        public void Aussäen(params Möhre[] saatgut)
        {
            foreach (Möhre m in saatgut)
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
                    foreach (Möhre m in _möhren)
                    {
                        return m.VernichtenFeind();
                    }
                    break;
                case 1:
                    foreach (Möhre m in _möhren)
                    {
                        return m.Bewässern();
                    }
                    break;
            }
            return "Nicht bewirtschaftet";
        }

        public List<Möhre> Ernten()
        {
            List<Möhre> ernte = new List<Möhre>();
            ernte = _möhren.FindAll(m => m.IsReif);
            _möhren.RemoveAll(m => m.IsReif);

            return ernte;
        }

        public List<Möhre> Möhren
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
