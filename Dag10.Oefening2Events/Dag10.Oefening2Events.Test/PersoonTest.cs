namespace Dag10.Oefening2Events.Test;

[TestClass]
public class PersoonTest
{
    [TestMethod]
    public void ToString_Persoon_ConsoleWriteLine()
    {
        // arrange
        Persoon persoon = new Persoon("Yannick", 23);
        
        // act
        string persoonToString = persoon.ToString();
        
        // assert
        Assert.AreEqual("Yannick heeft een leeftijd van: 23", persoonToString);
    }

    [TestMethod]
    public void Verjaar_Persoon_Met1Jaar()
    {
        Persoon persoon = new Persoon("Yannick", 23);

        int persoonLeeftijdNu = persoon.Leeftijd;
        persoon.Verjaar();
        
        Assert.AreEqual(24, persoon.Leeftijd);

    }
    
}