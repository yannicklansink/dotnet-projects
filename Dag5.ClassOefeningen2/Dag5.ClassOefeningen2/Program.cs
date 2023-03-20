namespace Dag5.ClassOefeningen2;
class Program
{
    static void Main(string[] args)
    {

        Balk balk1 = new Balk(6, 3, 8);

        Bol bol1 = new Bol(10);
        Console.WriteLine("Inhoud van bol is: " + bol1.BerekenInhoud());
        Console.WriteLine(Math.Pow(5, 3));

    }
}

