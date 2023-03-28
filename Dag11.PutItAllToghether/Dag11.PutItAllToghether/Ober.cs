namespace Dag11.PutItAllToghether;

public class Ober
{
    public string Naam { get; set; }
    public decimal Fooienpot { get; set; }

    public Ober(string naam, decimal fooienpot = 0)
    {
        Naam = naam;
        Fooienpot = fooienpot;
    }
}