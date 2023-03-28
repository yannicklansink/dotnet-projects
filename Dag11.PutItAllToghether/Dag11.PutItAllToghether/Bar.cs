using Dag11.PutItAllToghether.Exceptions;

namespace Dag11.PutItAllToghether;

public class Bar
{
    public List<Tafel> Tafels { get; set; }
    public List<Ober> Obers { get; set; }

    public Bar()
    {
        Tafels = new List<Tafel>();
        Obers = new List<Ober>();
    }

    public decimal GetTotaalFooienpot()
    {
        decimal fooienpotTotaalBedrag = 0m;
        foreach (Ober ober in Obers)
        {
            fooienpotTotaalBedrag += ober.Fooienpot;
        }

        return fooienpotTotaalBedrag;
    }

    public void OpenTafel(int tafelnummer)
    {
        Tafel tafel = new Tafel(tafelnummer);
        Tafels.Add(tafel);
    }

    public void NeemBestellingOp(int tafelnummer, Ober ober, Bestelling bestelling)
    {
        if (TafelnummerExists(tafelnummer) && OberExists(ober))
        {
            Tafel tafelToModify = GetTafelFromTafelnummer(tafelnummer);
            tafelToModify.LopendeRekening.Add(bestelling); 
            if (!OberExistsOnTable(ober, tafelToModify))
            {
                // ober toevoegen aan tafel
                tafelToModify.Obers.Add(ober);
            }
        } else
        {
            throw new ArgumentDoesNotExistsException("De tafel of ober die je wilt toevoegen bestaat niet");
        }

    }

    public bool OberExistsOnTable(Ober o, Tafel tafel)
    {
        Ober oberToReturn;
        foreach (Ober ober in tafel.Obers)
        {
            if (ober == o)
            {
                // ober is al toegevoegd aan de tafel
                return true;
            }
        }
        return false;
    }

    public Tafel GetTafelFromTafelnummer(int tafelnummer)
    {
        Tafel tafelToReturn;
        foreach (Tafel tafel in Tafels)
        {
            if (tafel.Tafelnummer == tafelnummer)
            {
                tafelToReturn = tafel;
                return tafelToReturn;
            }
        }
        
        throw new ArgumentOutOfRangeException("Tafelnummer bestaat niet");
    }

    public bool TafelnummerExists(int tafelnummer)
    {
        return Tafels.Where(tafelnummer => Tafels.Contains(tafelnummer)).Any();
    }


    public bool OberExists(Ober ober)
    {
        return ober != null;
    }
}