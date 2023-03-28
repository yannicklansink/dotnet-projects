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

    public Tafel(int tafelnummer)
    {
        Tafelnummer = tafelnummer;
        Obers = new List<Ober>();

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
                Console.WriteLine("nieuw drink: " + LopendeRekening[drink]);
            } else
            {
                // drink zit nog niet in de dictionary
                LopendeRekening.Add(drink, (int)drink);
                Console.WriteLine("nieuw drink: " + LopendeRekening[drink]);
            }
        }
    }

    public string GetTotaalBedrag()
    {
        int totaalBedrag = 0;
        foreach (var b in LopendeRekening.Keys)
        {
            totaalBedrag += (int)b;
        }
        return (totaalBedrag / 100).ToString("0.00");
    }

    /*
    public string GetLijstMetAlleBestellingenGroupedByName()
    {
        foreach (Bestelling bestelling in LopendeRekening)
        {
            var query = bestelling.DrankenLijst.GroupBy(drankje => drankje.DrankNaam)
           .Select(drankje => new
           {
               Count = drankje.Count(),
               Name = drankje.Key,
           })
           .OrderByDescending(drankje => drankje.Count);
        }

       
        StringBuilder sb = new StringBuilder();
        foreach (var x in query)
        {
            sb.Append("Count: " + x.Count + " Name: " + x.Name);
        }
        return sb.ToString();

    }
    */
}



