namespace Dag10.Oefening2Events;
class Program
{
    static void Main(string[] args)
    {
        Persoon persoon = new Persoon("Yannick", 23);
        Console.WriteLine(persoon);
        persoon.Verjaar();
        Console.WriteLine(persoon);
    }
}

