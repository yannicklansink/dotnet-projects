using System.Collections.Generic;
using System.Text;

namespace Dag11.PutItAllToghether;

public class Bestelling
{
    public decimal Bedrag { get; set; }

    public List<Dranken> DrankenLijst { get; set; }

    public override string ToString()
    {
        var q = DrankenLijst.GroupBy(drankje => drankje.DrankNaam)
            .Select(drankje => new 
            {
                Count = drankje.Count(),
                Name = drankje.Key,
            })
            .OrderByDescending(drankje => drankje.Count);

        StringBuilder sb = new StringBuilder();

        foreach (var x in q)
        {
            sb.Append("Count: " + x.Count + " Name: " + x.Name);
        }
        return sb.ToString();

    }



}