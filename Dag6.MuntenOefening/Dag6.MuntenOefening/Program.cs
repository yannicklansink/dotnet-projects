using System.Globalization;

namespace Dag6.MuntenOefening;
class Program
{
    static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("nl-BE");

        PrintGeldigheidMuntsoort(Muntsoort.Euro);
        PrintGeldigheidMuntsoort(Muntsoort.Dukaat);

        string CodeMuntsoortEuro = ExtensionMuntsoortFunctions.GetMuntSoortCode(Muntsoort.Euro);
        Console.WriteLine($"De code van muntsoort euro is: {CodeMuntsoortEuro}");

        Console.WriteLine("----------");
        // string CodeMuntSoortFout = "EURROOO";
        // Console.WriteLine($"De code {CodeMuntSoortFout} is {ExtensionMuntsoortFunctions.ToMuntSoort(CodeMuntSoortFout)}");

        Valuta valuta = new Valuta(4.00m, Muntsoort.Gulden);
        decimal bedragNieuw = valuta.ConvertTo(Muntsoort.Euro);
        Console.WriteLine(bedragNieuw);

        Console.WriteLine("----------");

        Valuta valuta2 = new Valuta(10.00m, Muntsoort.Dukaat);
        decimal bedragNieuw2 = valuta2.ConvertTo(Muntsoort.Gulden);
        Console.WriteLine($"Van {valuta2.Bedrag} dukaat naar gulden converten: {bedragNieuw2:n2}");

    }

    public static void PrintGeldigheidMuntsoort(Muntsoort muntsoort)
    {
        if (muntsoort == Muntsoort.Euro) Console.WriteLine($"Muntsoort {muntsoort} is een geldig betaalmiddel");
        else Console.WriteLine($"Muntsoort {muntsoort} is geen geldig betaalmiddel");
    }
}

