using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBeet
{
    class Program
    {
        static void Main(string[] args)
        {
            Beet<Möhre,Person> myBeet = new Beet<Möhre, Person>();

            myBeet.Aussäen(new Möhre(), new Möhre(), new Möhre());

            Console.WriteLine(myBeet.Bewirtschaften(new Person(89)));

            Console.WriteLine("Und das ist die Ernte:");
            foreach(Gemüse m in myBeet.Ernten())
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("-----Gemischtes Beet-------");

            Beet<Gemüse, Person> allesZusammen = new Beet<Gemüse, Person>();
            allesZusammen.Aussäen(new Möhre(), new Kohlrabi());

            Console.WriteLine(allesZusammen.Bewirtschaften(new Person(40)));

            Console.WriteLine("Und das ist die Ernte:");
            foreach (Gemüse m in allesZusammen.Ernten())
            {
                Console.WriteLine(m);
            }

            Console.WriteLine("-----Kohlrabi Beet-------");

            Beet<Kohlrabi, Person> kohlrabibeet = new Beet<Kohlrabi, Person>();
            kohlrabibeet.Aussäen(new Kohlrabi(), new Kohlrabi());

            Console.WriteLine(allesZusammen.Bewirtschaften(new Gärtner()));

            Console.WriteLine("Und das ist die Ernte:");
            foreach (Kohlrabi m in kohlrabibeet.Ernten())
            {
                Console.WriteLine(m);
            }
        }

        public static void ernten<X,Y>(Beet<X,Y> beet) where X:Gemüse where Y:Person
        {
            beet.Ernten();
        }

        public static void Branding<T>(T vegetable , string wer) where T:Gemüse
        {
            vegetable.Branding(wer);
        }
    }
}
