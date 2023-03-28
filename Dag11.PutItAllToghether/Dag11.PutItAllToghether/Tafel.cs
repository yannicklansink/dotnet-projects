namespace Dag11.PutItAllToghether;

public class Tafel
{

    public List<decimal> LopendeRekening { get; set; }
    public List<Ober> Obers { get; set; }
    public int Tafelnummer { get; set; }

    public Tafel(int tafelnummer)
    {
        Tafelnummer = tafelnummer;
        LopendeRekening = new List<decimal>();
        Obers = new List<Ober>();
    }
}