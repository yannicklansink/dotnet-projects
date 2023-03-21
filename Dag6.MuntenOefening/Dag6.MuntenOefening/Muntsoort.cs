using System.ComponentModel;

namespace Dag6.MuntenOefening;

public enum Muntsoort
{
    Gulden,
    Euro,
    Florijn,
    Dukaat,
}

static class ExtensionMuntsoortFunctions
{
    public static string GetMuntSoortCode(this Muntsoort muntsoort)
    {
        switch (muntsoort) 
        {
            case Muntsoort.Euro:   return "EUR";
            case Muntsoort.Gulden:   return "Hfl";
            case Muntsoort.Florijn:   return "fl";
            case Muntsoort.Dukaat:   return "HD";
            default:    throw new InvalidEnumArgumentException("De muntsoort is onjuist");
        }
    }

    public static Muntsoort ToMuntSoort(this string muntcode)
    {
        switch (muntcode) 
        {
            case "EUR":   return Muntsoort.Euro;
            case "Hfl":   return Muntsoort.Gulden;
            case "fl":   return Muntsoort.Florijn;
            case "HD":   return Muntsoort.Dukaat;
            default:    throw new InvalidValutaException($"De muntcode {muntcode} is geen geldige valuta");
        }
    }
    
}