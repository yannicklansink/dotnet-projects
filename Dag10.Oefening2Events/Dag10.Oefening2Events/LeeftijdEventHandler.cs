namespace Dag10.Oefening2Events;

public delegate void LeeftijdEventHandler(object sender, LeeftijdEventArgs e);

public class LeeftijdEventArgs: EventArgs
{
    public string Naam { get; }
    public int OudeLeeftijd { get; }
    public int NieuweLeeftijd { get; }

    public LeeftijdEventArgs(string naam, int oudeLeeftijd, int nieuweLeeftijd)
    {
        Naam = naam; 
        OudeLeeftijd = oudeLeeftijd; 
        NieuweLeeftijd = nieuweLeeftijd;
    }
    
}