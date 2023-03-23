using Dag6.MuntenOefening;

namespace Dag6.MuntenTesten;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Valuta valuta = new Valuta(10.00m, Muntsoort.Dukaat);
        
        decimal bedragNieuw2 = valuta.ConvertTo(Muntsoort.Gulden);
        
        
    }

    [DataTestMethod]
    [DataRow()]
    public void MethodName()
    {
        
    }
    
}