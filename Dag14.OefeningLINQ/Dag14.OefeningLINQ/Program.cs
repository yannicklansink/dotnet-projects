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
            //foreach (var naam in somLengteNamenMetY)
            //{
            //    Console.WriteLine($"Aantal namen met a order by descending: {naam}");
            //}
        }
    }
}