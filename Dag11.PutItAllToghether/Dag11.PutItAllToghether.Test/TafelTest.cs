using Dag11.PutItAllToghether;
using Dag11.PutItAllToghether.Exceptions;
using Microsoft.VisualBasic;

namespace Dag11.PutItAllToghether.Test;

[TestClass]
public class TafelTest
{
    [TestMethod]
    public void AddBestellingToRekening_WithDuplicateKey()
    {
        // arrange
        Tafel tafel = new Tafel(1);
        List<Drink> drinkList = new List<Drink>() 
        { 
            Drink.DubbelBierTap,
            Drink.BierTap,
            Drink.Sinas,
        };
        List<Drink> drinkList2 = new List<Drink>()
        {
            Drink.DubbelBierTap,
            Drink.BierTap,
            Drink.Sinas,
        };

        // act
        tafel.AddBestellingToRekening(drinkList);
        tafel.AddBestellingToRekening(drinkList2);

        // assert
        Assert.AreEqual(500, tafel.LopendeRekening[Drink.Sinas]);
    }

    


}