using Dag11.PutItAllToghether.Exceptions;
using System.Reflection.Emit;
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
        if (TafelnummerExists(tafelnummer))
        {
            Tafel tafel = GetTafelFromTafelnummer(tafelnummer);
            string totaalBedrag = tafel.GetTotaalBedrag();

            StringBuilder sb = new StringBuilder(); 
            foreach (var drink in tafel.LopendeRekening)
            {
                // (value / 100).ToString("0.00")
                string drinkValue = ((int)drink.Value / 100m).ToString("0.00");
                sb.Append($"{drink.Key} : {drinkValue}\n");
            }
            sb.Append("---------------------------\n");
            sb.Append($"Totaalbedrag: {totaalBedrag}");
            return sb.ToString();

        } else
        {
            throw new ArgumentDoesNotExistsException("De tafel waarvan je de rekening wilt bestaat niet");
        }
    }

    public void BetaalRekening(decimal bedragEnFooi, int tafelnummer)
    {
        if (TafelnummerExists(tafelnummer))
        {
            Tafel tafel = GetTafelFromTafelnummer(tafelnummer);
            if (tafel.GetTotaalBedragDecimal() > bedragEnFooi)
            {
                throw new BetalingOnvoldoendeException("Het bedrag dat je wilt betalen is minder dan he totaal bedrag");
            } else if (tafel.GetTotaalBedragDecimal() == bedragEnFooi)
            {
                // hoef niks te doen.
            } else
            {
                decimal fooiHoeveelheid = bedragEnFooi - tafel.GetTotaalBedragDecimal();
                Console.WriteLine("fooihoeveelheid: " + fooiHoeveelheid);
                decimal fooiHoeveelheidPerOber = fooiHoeveelheid / tafel.Obers.Count;
                Console.WriteLine("fooihoeveelheid per ober: " + fooiHoeveelheidPerOber);
                foreach (Ober ober in tafel.Obers)
                {
                    ober.Fooienpot += fooiHoeveelheidPerOber;
                }
            }
            // lopende rekening stoppen
            tafel.RekeningBetaald = true;
        }
        else
        {
            throw new ArgumentDoesNotExistsException("De tafel waar je wilt betalen bestaat niet");
        }
    }

    public bool OberExistsOnTable(Ober o, Tafel tafel)
    {
        AddOberToBar(o);
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

    public void AddOberToBar(Ober o)
    {
        foreach (Ober ober in Obers)
        {
            if (ober == o)
            {
                // ober is al toegevoegd aan de tafel
                return;
            }
        }
        Obers.Add(o);
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