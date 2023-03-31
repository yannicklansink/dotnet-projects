using System.Linq.Expressions;

namespace Dag14.OefeningLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> Namen = new List<string> { "Anthony", "Daan", "Daniel", "Jaouad", "Jasper", "Mart", "Niek", "Rob", "Yannick" };
            /*
            Schrijf de queries in comprehension syntax EN extension methd syntax

            comprehension syntax
            from p in people
            select p.Name

            extension method syntax
            people.Select(p => p.Name)
            */

            // 1 Schrijf een query die berekent hoeveel namen er zijn
            var countNames = Namen.Count();
            Console.WriteLine($"Aantal namen {countNames}");

            // 2 Schrijf een query die berekent hoeveel namen er zijn met een a
            var namenMetA = from naam in Namen
                            where naam.Contains("a")
                            select naam;

            foreach ( var naam in namenMetA )
            {
                Console.WriteLine($"Aantal namen met a: {naam}");
            }
            Console.WriteLine();

            // 3 Schrijf een query die alle eerste letters van namen met een a opsomt, in omgekeerd alfabetische volgorde
            var namenMetAomgekeerd = Namen.Where(n => n.Contains("a")).OrderByDescending(y => y);

            foreach (var naam in namenMetAomgekeerd)
            {
                Console.WriteLine($"Aantal namen met a order by descending: {naam}");
            }
            Console.WriteLine();

            // 4 Schrijf een query die de som van de lengtes van de namen oplevert van alle namen waar een y in zit.
            var somLengteNamenMetY = Namen.Where(name => name.Contains("y") || name.Contains("Y")).Sum(name => name.Length);
            Console.WriteLine($"De som van de lengtes van de namen met een y zijn: {somLengteNamenMetY}");
            Console.WriteLine();


            // stof na de pauze (vrijdag)
            FileStream stream = null;
            try
            {
                stream = new FileStream("Naam", FileMode.Open);

            } finally
            {
                // Klaar - Garbage collector.
                // ? : checked of het niet null is. Als het null is dan word dispose niet uitgevoerd. 
                stream?.Dispose(); // ruim unmanaged resources op
            }

            // betere syntax. DOE DIT ALTIJD, ANDERS WORDT JE IN HET MEER GEGOOID MET BAKSTENEN AAN JE VOETEN!!!
            using(var stream2 = new FileStream("Naam", FileMode.Open))
            {

            } // hier word .Dipose() aangeroepen

            // using is ook wel een try{} block
            // Je moet IDisposable gebruiken voor een using.
            using(var stream3 = new FileParser("Naam"))
            {
                // doe hier wat je wilt.
                stream3.ReadLine();
                

            } // hier word .Dispose() aangeroepen
            
            

        }
    }

    public class FileParser : IDisposable
    {
        private FileStream stream;

        public FileParser(string filename)
        {
            stream = new FileStream("Naam", FileMode.Open);
        }

        public string ReadLine()
        {
            return stream.ReadByte().ToString();
        }
        public void Dispose()
        {
            stream?.Dispose();
        }
    }
}