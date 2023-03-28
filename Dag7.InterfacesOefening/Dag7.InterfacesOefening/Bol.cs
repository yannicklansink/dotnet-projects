namespace Dag7.InterfacesOefening;

public class Bol
{

    private double _straal;
    
    public double BerekenInhoud(double straal)
    {
        double inhoud = 4 / 3 * Math.PI * Math.Pow(straal, 3);
        return inhoud;
    }

    public double BerekenOppervlakte(double straal)
    {
        // straal * straal * PI
        
    }
}