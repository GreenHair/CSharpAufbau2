namespace Kaufhaus
{
    internal class Kunde
    {
        public readonly string Name;
        public readonly bool IstDieb;
        
        public Kunde(string _name,bool _istDieb)
        {
            Name = _name;
            IstDieb = _istDieb;
        }
    }
}