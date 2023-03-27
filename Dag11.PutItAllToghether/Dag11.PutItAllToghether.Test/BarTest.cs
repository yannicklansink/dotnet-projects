using Dag11.PutItAllToghether;

namespace Dag11.PutItAllToghether.Test;

[TestClass]
public class BarTest
{
    [TestMethod]
    public void GetTotaalFooienPot_With0Obers()
    {
        // arrange
        Bar bar = new Bar();
        
        // act
        decimal totaalFooienPot = bar.GetTotaalFooienpot();

        // assert
        Assert.AreEqual(0M, totaalFooienPot);
    }
}