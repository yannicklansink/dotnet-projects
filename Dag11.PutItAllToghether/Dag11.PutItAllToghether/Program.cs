namespace Dag11.PutItAllToghether;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welkom op een terras ergens in Frankrijk in de zon!");

        Dranken drank = new Dranken("Bier", 3.50m, 1.00m);
        List<Dranken> drankenList = new List<Dranken>();
        drankenList.Add(drank);

        Bestelling bestelling = new Bestelling();  
        bestelling.DrankenLijst = drankenList;

        Bar bar = new Bar();
        Tafel tafel1 = new Tafel(5);

        bar.Tafels.Add(tafel1);
        bar.NeemBestellingOp(5, new Ober("yannick"), bestelling);
           


    }
}

