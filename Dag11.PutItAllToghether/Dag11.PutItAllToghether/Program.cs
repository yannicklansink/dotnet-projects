namespace Dag11.PutItAllToghether;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welkom op een terras ergens in Frankrijk in de zon!");
        
        Bar bar = new Bar();
        bar.OpenTafel(1);

        List<Drink> drinkList = new List<Drink>()
        {
            Drink.DubbelBierTap,
            Drink.BierTap,
            Drink.Sinas,
        };
        List<Drink> drinkList2 = new List<Drink>()
        {
            Drink.DubbelBierTap,
            Drink.BierTap,
            Drink.Sinas,
        };
        List<Drink> drinkList3 = new List<Drink>()
        {
            Drink.DubbelBierTap,
            Drink.BierTap,
            Drink.Sinas,
        };

        Ober yannick = new Ober("Yannick");
        bar.NeemBestellingOp(1, yannick, drinkList);
        Console.WriteLine("----------");
        bar.NeemBestellingOp(1, new Ober("Piet"), drinkList2);
        Console.WriteLine("----------");
        bar.NeemBestellingOp(1, new Ober("Sjoerd"), drinkList3);

        Console.WriteLine("aantal obers: " + bar.Obers.Count);

        Console.WriteLine("aantal bestellingen: " + bar.GetTafelFromTafelnummer(1).AantalBestellingen);

        Console.WriteLine(bar.VraagRekening(1));

        bar.BetaalRekening(60.0m, 1);





    }
}

