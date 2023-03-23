using Dag6.OefeningInheritance;

namespace Dag6.InheritanceTesten
{
    [TestClass]
    public class BetaalkaartTest
    {

        [TestInitialize]
        public void TestInitilize()
        {
            // Setup voor elke test.
            // sut = system unit test. 
            
            
        }
        
        [TestMethod]
        public void Saldo_TestOfSaldoKlopt()
        {
            // arrange
            decimal saldo = 10m;
            Betaalkaart sut = new GewoneBetaalkaart("Yannick", saldo);
            // act
            
            // assert
            Assert.AreEqual(10m, sut.Saldo, 0.0001m);
        }
        
        [TestMethod]
        public void Saldo_Saldo_Verhogen()
        {
            // arrange
            decimal saldo = 10m;
            decimal newSaldo = 11m;
            Betaalkaart sut = new GewoneBetaalkaart("Yannick", saldo);
            // act
            void act()
            {
                sut.Saldo = newSaldo;
            }
            
            // assert
            Assert.ThrowsException<SaldoOntoereikendException>(act);
        }
        
        [TestMethod]
        public void Saldo_Saldo_VeranderenNaarMinder()
        {
            // arrange
            decimal saldo = 10m;
            decimal newSaldo = 9m;
            Betaalkaart sut = new GewoneBetaalkaart("Yannick", saldo);
            
            // act
            sut.Saldo = newSaldo;
            
            // assert
            Assert.AreEqual(9m, sut.Saldo, 0.0001m);
        }

        [TestMethod]
        public void ToString_ReturnOpgemaaktString()
        {
            // arrange
            string result = "Het saldo van Yannick is: 10";
            Betaalkaart sut = new GewoneBetaalkaart("Yannick", 10m);
            
            // act
            string result2 = sut.ToString();
            
            // assert
            Assert.AreEqual(result, result2);
        }
        
        
        
    }
}