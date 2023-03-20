using Dag5.ClassOefeningen2;

namespace Dag5.Testen3;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        //act
        Bol bol1 = new Bol(10);
        
        //assert
        var inhoudBol = bol1.BerekenInhoud();

        //arrange
        Assert.AreEqual(524, inhoudBol);
    }
}