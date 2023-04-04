using BlackJack.Exceptions;

namespace BlackJack.Test
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Bet_Throw_BetIsHigherThenBalanceException()
        {
            Game game  = new Game();
            
            void act()
            {
                game.StartGame(25m);
            }

            Assert.ThrowsException<BetIsHigherThenBalanceException>(act);
        }

        [TestMethod]
        public void Bet_IsAsHighAsBalance()
        {
            Game game = new Game();

            game.StartGame(20m);

            Assert.AreEqual(0m, game.Player.Balance);
        }


    }
}