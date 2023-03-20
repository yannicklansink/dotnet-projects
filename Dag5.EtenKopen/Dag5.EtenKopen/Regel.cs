namespace Dag5.EtenKopen;

public class Regel
{

    private decimal _prijs;
    private string _naam;

    public Regel(decimal prijs, string naam)
    {
        this._prijs = prijs;
        this._naam = naam;
    }

    public decimal Prijs
    {
        get { return this._prijs; }
        set { this._prijs = value; }
    }

    public string Naam
    {
        get { return this._naam; }
        set { this._naam = value; }
    }
    
}