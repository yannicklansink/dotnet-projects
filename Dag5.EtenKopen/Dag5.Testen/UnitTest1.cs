using Dag5.EtenKopen;

namespace Dag5.Testen;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestOfTotaalPrijsIsJuist()
    {
        //arrange
        Bon bon = new Bon();
        Regel brood = new Regel(4.50m, "broodje");
        
        //act
        bon.Scan(brood);
        bon.UpdateTotaalPrijs();
        
        //assert    
        Assert.AreEqual(4.50m, bon.TotaalPrijs);
        
    }
}