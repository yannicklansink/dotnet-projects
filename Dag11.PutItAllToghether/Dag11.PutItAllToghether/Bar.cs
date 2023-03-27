namespace Dag11.PutItAllToghether;

public class Bar
{
    public List<Tafel> Tafels { get; set; }
    public List<Ober> Obers { get; set; }

    public Bar()
    {
        Tafels = new List<Tafel>();
        Obers = new List<Ober>();
    }

    public decimal GetTotaalFooienpot()
    {
        decimal fooienpotTotaalBedrag = 0M;
        foreach (Ober ober in Obers)
        {
            fooienpotTotaalBedrag += ober.Fooienpot;
        }

        return fooienpotTotaalBedrag;
    }

    public void OpenTafel(int tafelnummer)
    {
        Tafel tafel = new Tafel(tafelnummer);
        Tafels.Add(tafel);
    }
}