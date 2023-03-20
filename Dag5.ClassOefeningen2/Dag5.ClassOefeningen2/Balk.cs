namespace Dag5.ClassOefeningen2;

public class Balk
{

    public double hoogte;
    public double breedte;
    public double diepte;
    public const int aantalZijden = 2;
    public Balk(double hoogte, double breedte, double diepte)
    {
        this.hoogte = hoogte;
        this.breedte = breedte;
        this.diepte = diepte;
    }

    public double BerekenInhoud()
    {
        return this.breedte * this.hoogte * this.diepte;
    }

    public double BerekenOppervlakte()
    {
        double oppervlakteVoorkantAchterkant = (this.breedte * this.hoogte) * aantalZijden;
        double oppervlakteZijkant = (this.diepte * this.hoogte) * aantalZijden;
        double oppervlakteOnderkantBovenkant = (this.diepte * this.breedte) * aantalZijden;
        return oppervlakteVoorkantAchterkant + oppervlakteZijkant + oppervlakteOnderkantBovenkant;
    }
    
    
}