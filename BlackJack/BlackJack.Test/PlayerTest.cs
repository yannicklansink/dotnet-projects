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

        [TestMethod]
        public void Stand_PlayerIsStandEqualsTrue()
        {
            Game game = new Game();
            game.StartGame(1m);

            game.Player.Stand();

            Assert.AreEqual(true, game.Player.IsStand);
        }

        [TestMethod]
        public void Player_Balance_Doubled_AfterWin()
        {
            Game game;

            do
            {
                game = new Game();
                game.StartGame(20m);
                game.Player.Stand();
            } while (game.Dealer.Hand.GetTotalValue() >= game.Player.Hand.GetTotalValue());

            Assert.AreEqual(40m, game.Player.Balance);
        }

        [TestMethod]
        public void Player_Balance_StayedTheSame_AfterDraw()
        {
            Game game;

            do
            {
                game = new Game();
                game.StartGame(20m);
                game.Player.Stand();
            } while (game.Dealer.Hand.GetTotalValue() != game.Player.Hand.GetTotalValue());

            Assert.AreEqual(20m, game.Player.Balance);
        }

        [TestMethod]
        public void Player_Balance_LostBetAmount_AfterLose()
        {
            Game game;

            do
            {
                game = new Game();
                game.StartGame(20m); // bet everything
                game.Player.Stand();
            } while (game.Dealer.Hand.GetTotalValue() < game.Player.Hand.GetTotalValue() || game.Dealer.IsBust());

            Assert.AreEqual(0m, game.Player.Balance);
        }

    }
}