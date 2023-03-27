namespace Dag10.Oefening1;


public delegate string Formatteerder(int getal);

class Program
{
    static void Main(string[] args)
    {
        Printer printer = new Printer();
        Layout layout = new Layout();

        Formatteerder format = new Formatteerder(layout.LieftinckFormaat);
        
        printer.Print(53, format);
    }
    
}

public class Printer
{
    public void Print(int getal, Formatteerder formatteerder)
    {
        Console.WriteLine(formatteerder.Invoke(getal));
    }
}
public class Layout
{
    public string LieftinckFormaat(int getal)
    {
        return $"Het getal is {getal}";
    }
}

