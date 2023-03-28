using Dag11.PutItAllToghether.Exceptions;
using System.Text;

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
        if (!TafelnummerExists(tafelnummer))
        {
            Tafel tafel = new Tafel(tafelnummer);
            Tafels.Add(tafel);
        } else
        {
            throw new ArgumentDoesNotExistsException("De tafel is al in gebruik");
        }
        
    }

    public void NeemBestellingOp(int tafelnummer, Ober ober, List<Drink> drinkList)
    {
        //  if (TafelnummerExists(tafelnummer) && OberExists(ober))
        if (TafelnummerExists(tafelnummer))
        {
            Tafel tafelToModify = GetTafelFromTafelnummer(tafelnummer);

            tafelToModify.AddBestellingToRekening(drinkList);
            if (!OberExistsOnTable(ober, tafelToModify))
            {
                // ober toevoegen aan tafel
                tafelToModify.Obers.Add(ober);
            }
        } else
        {
            throw new ArgumentDoesNotExistsException("De tafel die je wilt toevoegen bestaat niet");
        }

    }

    public string VraagRekening(int tafelnummer)
    {

        // geeft een rekening terug (in string vorm?)
        // - met een lijst met drankjes dat besteld is en
        //      hoevaak elk drankje besteld is (elk drankje komt hooguit 1 keer voor op de rekening)
        // - met een totaalbedrag
        if (TafelnummerExists(tafelnummer))
        {
            Tafel tafel = GetTafelFromTafelnummer(tafelnummer);
            Console.WriteLine("tafel test: " + tafel.GetFirstValueInDictionary());
            string totaalBedrag = tafel.GetTotaalBedrag();

            StringBuilder sb = new StringBuilder(); 
            foreach (int drink in tafel.LopendeRekening.Keys)
            {
                // (value / 100).ToString("0.00")
                Console.WriteLine("Het totaal bedrag van de drink is: " + drink);
                string drinkValue = ((int)drink / 100m).ToString("0.00");
                sb.Append($"{drink} : {drinkValue}\n");
            }
            sb.Append($"Totaalbedrag: {totaalBedrag}");
            return sb.ToString();

        } else
        {
            throw new ArgumentDoesNotExistsException("De tafel waarvan je de rekening wilt bestaat niet");
        }
    }

    public bool OberExistsOnTable(Ober o, Tafel tafel)
    {
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