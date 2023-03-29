using System.Text;

namespace Dag11.PutItAllToghether;

public class Tafel
{

    // misschien heeft een tafel een rekening?
    // Rekening is een struct waar het totaalbedrag instaat?
    // of een dictionary? dan geen bestelling gebruiken?

    public Dictionary<Drink, int> LopendeRekening; 

    public List<Ober> Obers { get; set; }
    public int Tafelnummer { get; set; }

    public bool RekeningBetaald = false;

    public int AantalBestellingen { get; set; }

    public Tafel(int tafelnummer)
    {
        Tafelnummer = tafelnummer;
        Obers = new List<Ober>();
        AantalBestellingen = 0;
        LopendeRekening = new Dictionary<Drink, int>();
    }

    public void AddBestellingToRekening(List<Drink> bestelling)
    {
        foreach (Drink drink in bestelling)
        {
            if (LopendeRekening.ContainsKey(drink))
            {
                // er zit al een drink key in de dictionary
                // update bedrag in dictionary
                LopendeRekening[drink] += (int)drink;
            } else
            {
                // drink zit nog niet in de dictionary
                LopendeRekening.Add(drink, (int)drink);
            }
        }
        AantalBestellingen++;
    }

    public string GetTotaalBedrag()
    {
        int totaalBedrag = 0;
        foreach (var b in LopendeRekening)
        {
            totaalBedrag += b.Value;
        }
        return (totaalBedrag / 100).ToString("0.00");
    }

    public decimal GetTotaalBedragDecimal()
    {
        int totaalBedrag = 0;
        foreach (var b in LopendeRekening)
        {
            totaalBedrag += b.Value;
        }
        string totaalBedragString = (totaalBedrag / 100).ToString("0.00");
        return decimal.Parse(totaalBedragString);
    }
}



