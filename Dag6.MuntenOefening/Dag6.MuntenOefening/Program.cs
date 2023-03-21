namespace Dag6.MuntenOefening;
class Program
{
    static void Main(string[] args)
    {
        PrintGeldigheidMuntsoort(Muntsoort.Euro);
        PrintGeldigheidMuntsoort(Muntsoort.Dukaat);

        string CodeMuntsoortEuro = ExtensionMuntsoortFunctions.GetMuntSoortCode(Muntsoort.Euro);
        Console.WriteLine($"De code van muntsoort euro is: {CodeMuntsoortEuro}");

        Console.WriteLine("----------");
        string CodeMuntSoortFout = "EURROOO";
        Console.WriteLine($"De code {CodeMuntSoortFout} is {ExtensionMuntsoortFunctions.ToMuntSoort(CodeMuntSoortFout)}");

    }

    public static void PrintGeldigheidMuntsoort(Muntsoort muntsoort)
    {
        if (muntsoort == Muntsoort.Euro) Console.WriteLine($"Muntsoort {muntsoort} is een geldig betaalmiddel");
        else Console.WriteLine($"Muntsoort {muntsoort} is geen geldig betaalmiddel");
    }
}

