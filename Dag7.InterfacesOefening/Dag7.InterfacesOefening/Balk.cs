namespace Dag7.InterfacesOefening;

public class Balk : IVormen
{
    
    public double BerekenInhoud(double hoogte, double breedte, double diepte)
    {
        double inhoud = hoogte * breedte * diepte;
        return inhoud;
    }

    public double BerekenOppervlakte()
    {
        
    }
    
}