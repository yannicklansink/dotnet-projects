namespace Dag5.EtenKopen;

public class Bon
{
    public List<Regel> Regels;
    private decimal _totaalPrijs;

    public Bon()
    {
        Regels = new List<Regel>();
        
    }

    public void Scan(Regel regel)
    {
        // if (regel.Prijs >= 0.0 && regel.Prijs < Math.Max(decimal)) ;
        this.Regels.Add(regel);
        
    }

    public void ScanAll(params Regel[] regel)
    {
        foreach (Regel x in regel)
        {
            this.Regels.Add(x);
        }
    }

    public void UpdateTotaalPrijs()
    {
        decimal totaalPrijsBerekening = 0.0m;
        foreach (Regel regel in Regels)
        {
            totaalPrijsBerekening += regel.Prijs;
        }

        this._totaalPrijs = totaalPrijsBerekening;
    }

    public void ToString()
    {
        foreach (Regel regel in Regels)
        {
            Console.WriteLine("product: " + regel.Naam + " met prijs van: " + regel.Prijs);
        }
        Console.WriteLine("-------------------------");
        UpdateTotaalPrijs();
        Console.WriteLine("Met een totaalprijs van: " + this._totaalPrijs);
    }
    

    
}