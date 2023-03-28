using Dag11.PutItAllToghether;
using Dag11.PutItAllToghether.Exceptions;
using Microsoft.VisualBasic;

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

    [TestMethod]
    public void GetTafelFromTafelnummer_With_Correct_Tafel()
    {
        // arrange
        Bar bar = new Bar();
        Tafel tafel1 = new Tafel(5);

        // act
        bar.Tafels.Add(tafel1);
        Tafel tafelToTest = bar.GetTafelFromTafelnummer(5);

        // assert
        Assert.AreSame(tafelToTest, tafel1);
    }

    [TestMethod]
    public void GetTafelFromTafelnummer_Throw_Exception()
    {
        // arrange
        Bar bar = new Bar();
        Tafel tafel1 = new Tafel(5);

        // act
        bar.Tafels.Add(tafel1);
        void act()
        {
            bar.GetTafelFromTafelnummer(20);
        }

        // assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(act);
    }

    [TestMethod]
    public void OberExistsOnTable_ReturnTrue()
    {
        // arrange
        
        Bar bar = new Bar();
        Ober ober = new Ober("Yannick");
        Tafel tafel1 = new Tafel(5);
        tafel1.Obers.Add(ober);
        bar.Tafels.Add(tafel1);

        // act
        bool act = bar.OberExistsOnTable(ober, tafel1);

        // assert
        Assert.AreEqual(true, act);
    }

    [TestMethod]
    public void OberExists_ReturnTrue()
    {
        // arrange
        Bar bar = new Bar();

        // act
        bool oberExists = bar.OberExists(new Ober("Yannick"));

        // assert
        Assert.AreEqual(true, oberExists);
    }

    [TestMethod]
    public void TafelnummerExists_ReturnTrue()
    {
        // arrange
        Bar bar = new Bar();
        bar.Tafels.Add(new Tafel(5));   

        // act
        bool tafelnummerExistsInBar = bar.TafelnummerExists(5);

        // assert
        Assert.AreEqual(true, tafelnummerExistsInBar);
    }

    [TestMethod]
    public void NeemBestellingOp_ThrowArgumentDoesNotExistsException()
    {
        //arrange
        Bar bar = new Bar();

        //act
        void act() {
            bar.NeemBestellingOp(2, new Ober("Yannick"), new Bestelling());

        }

        //assert
        Assert.ThrowsException<ArgumentDoesNotExistsException>(act);
    }





}