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

        bar.NeemBestellingOp(1, new Ober("Yannick"), drinkList);
        Console.WriteLine("----------+");
        bar.NeemBestellingOp(1, new Ober("Yannick"), drinkList2);

        Console.WriteLine(bar.VraagRekening(1));



    }
}

