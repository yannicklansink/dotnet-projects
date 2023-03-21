using System.Globalization;

namespace Dag6.MuntenOefening;

public struct Valuta
{
    
    public Muntsoort Muntsoort { get; }
    public decimal Bedrag;

    public Valuta(decimal bedrag, Muntsoort muntsoort)
    {
        Bedrag = bedrag;
        Muntsoort = muntsoort;
    }

    public override string ToString()
    {
        return $"Het bedrag is: {Bedrag} {ExtensionMuntsoortFunctions.GetMuntSoortCode(Muntsoort)}";
    }

    public decimal ConvertTo(Muntsoort converTo)
    {
        decimal converter;
        if (converTo == Muntsoort.Euro && Muntsoort == Muntsoort.Euro)
        {
            return Bedrag;
        } else if (converTo == Muntsoort.Dukaat && Muntsoort == Muntsoort.Dukaat)
        {
            return Bedrag;
        } else if (converTo == Muntsoort.Florijn && Muntsoort == Muntsoort.Florijn)
        {
            return Bedrag;
        } else if (converTo == Muntsoort.Gulden && Muntsoort == Muntsoort.Gulden)
        {
            return Bedrag;
        } else if (converTo == Muntsoort.Euro && Muntsoort == Muntsoort.Gulden)
        {
            // return van gulden naar euro
            converter = 0.45378m;
            return Decimal.Multiply(Bedrag, converter);
        } else if (converTo == Muntsoort.Gulden && Muntsoort == Muntsoort.Dukaat)
        {
            // return van dukaat naar Gulden
            // decimal.Round(yourValue, 2, MidpointRounding.AwayFromZero);
            converter = 5.1m;
            
            return Decimal.Multiply(Bedrag, converter);
        } else if (converTo == Muntsoort.Gulden && Muntsoort == Muntsoort.Euro)
        {
            // return van Euro naar Gulden
            converter = 2.20371m;
            return Decimal.Multiply(Bedrag, converter);
        } else if (converTo == Muntsoort.Gulden && Muntsoort == Muntsoort.Florijn)
        {
            // return van Flrijn naar Gulden
            converter = 1.0m;
            return Decimal.Multiply(Bedrag, converter);
        }
        throw new ArgumentException("muntsoort kan niet worden omgezet");
    }
    
}