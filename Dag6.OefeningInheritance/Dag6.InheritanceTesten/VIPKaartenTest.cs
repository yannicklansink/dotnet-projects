using Dag6.OefeningInheritance;

namespace Dag6.InheritanceTesten;

[TestClass]
public class VIPKaartenTest
{

    [TestMethod]
    public void Betaal_Saldo_In_De_Min()
    {
        // arrange
        decimal saldo = 10m;
        decimal bedragBetalen = 15m;
        decimal bedragTeBetalenMetKorting = bedragBetalen - ((bedragBetalen / 100) * 10m);
        decimal nieuwSaldoNaKorting = saldo - bedragTeBetalenMetKorting;
        
        Betaalkaart sut = new VIPKaarten("Yannick", saldo);
            
        // act
        sut.Betaal(bedragBetalen);

        // assert
        Assert.AreEqual(nieuwSaldoNaKorting, sut.Saldo, 0.0001m);
    }

    [TestMethod]
    public void Betaal_Bedrag_Met_Meer_Korting()
    {
        decimal kortingpercentage = 12.5m;
        
        
        
    }
    
}