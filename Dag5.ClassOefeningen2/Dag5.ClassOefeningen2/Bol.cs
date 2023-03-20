namespace Dag5.ClassOefeningen2;

public class Bol
{
    // private fields moet met _ beginnen. 
    private double _diameter;

    public Bol(double diameter)
    {
        this._diameter = diameter;
    }

    // Constructor this verwijst naar een andere constructor.
    public Bol() : this(10)
    {
        Console.WriteLine("eerste constructor :)");
    }

    public double BerekenInhoud()
    {
        return 4 * Math.PI * Math.Pow(GetStraal(), 2);
        // return (4 / 3) * (Math.PI * Math.Pow(GetStraal(), 3));
    }

    public double GetStraal()
    {
        return _diameter / 2;
    }

    // Getter en Setter
    public double Diameter
    {
        get { return this._diameter; }
        set
        {
            // value is het argument dat is meegegeven. Er zijn geen haakjes meer nodig. Beetje raar :/
            this._diameter = value;
        }
    }
}