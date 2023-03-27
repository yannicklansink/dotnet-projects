namespace Dag10.Oefening2Events;

public class Persoon
{
    public string Naam { get; set; }
    public int Leeftijd { get; set; }

    public event LeeftijdEventHandler leeftijdEvent;

    public Persoon(string naam, int leeftijd)
    {
        Naam = naam;
        Leeftijd = leeftijd;
    }

    public void Verjaar()
    {
        Leeftijd++;
        LeeftijdChanged(new LeeftijdEventArgs(Naam, Leeftijd - 1, Leeftijd));
    }

    protected virtual void LeeftijdChanged(LeeftijdEventArgs e)
    {
        if (leeftijdEvent != null)
        {
            leeftijdEvent.Invoke(this, e);
        }
    }

    public override string ToString()
    {
        return $"{Naam} heeft een leeftijd van: {Leeftijd}";
    }
}