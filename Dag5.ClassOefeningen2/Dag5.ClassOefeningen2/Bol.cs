namespace Dag5.ClassOefeningen2;

public class Bol
{
    public double diameter;

    public Bol(double diameter)
    {
        this.diameter = diameter;
    }

    public double BerekenInhoud()
    {
        return 4 * Math.PI * Math.Pow(GetStraal(), 2);
        // return (4 / 3) * (Math.PI * Math.Pow(GetStraal(), 3));
    }

    public double GetStraal()
    {
        return diameter / 2;
    }
}