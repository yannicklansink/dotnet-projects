using BlackJack.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace BlackJack.Test
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void Bet_Throw_BetIsHigherThenBalanceException()
        {
            Game game = new Game();

            void act()
            {
                game.StartRound(25m);
            }

            Assert.ThrowsException<BetIsInvalidException>(act);
        }

        [TestMethod]
        public void Bet_IsAsHighAsBalance()
        {
            Game game = new Game();

            game.StartRound(20m);

            Assert.AreEqual(0m, game.Player.Balance);
        }

        [TestMethod]
        public void Stand_PlayerIsStandEqualsTrue()
        {
            Game game = new Game();
            game.StartRound(1m);

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
                game.StartRound(20m);
                game.Player.Stand();
                game.EndRound();
            } while (!game.Dealer.IsBust());

            Assert.AreEqual(40m, game.Player.Balance);
        }

        [TestMethod]
        public void Player_Balance_StaysTheSame_AfterDraw()
        {
            Game game;

            do
            {
                game = new Game();
                game.StartRound(20m);
                game.Player.Stand();
                game.EndRound();
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
                game.StartRound(20m); // bet everything
                game.Player.Stand();
            } while (game.Dealer.Hand.GetTotalValue() < game.Player.Hand.GetTotalValue() || game.Dealer.IsBust());

            Assert.AreEqual(0m, game.Player.Balance);
        }

        [TestMethod]
        public void Bet_WithANegativeDecimal()
        {
            Game game = new Game();

            void act()
            {
                game.StartRound(-1);
            }

            Assert.ThrowsException<BetIsInvalidException>(act);
        }

        [TestMethod]
        public void Stand_MakesDealerPlay()
        {
            Game game = new Game();
            game.StartRound(5);

            game.Player.Stand();

            Assert.AreEqual(true, game.Player.IsStand);
            Assert.AreEqual(true, game.Dealer.IsPlaying);
        }

        [TestMethod]
        public void IsBetHigherThenBalance_ReturnsTrue()
        {
            Game game = new Game();

            bool value = game.Player.IsBetHigherThenBalance(25);

            Assert.IsTrue(value);
        }

        [TestMethod]
        public void CanPlayAnotherRound_ReturnTrue()
        {
            Game game = new Game();
            game.StartRound(5);

            bool value = game.Player.CanPlayAnotherRound();

            Assert.IsTrue(value);
        }

        [TestMethod]
        public void CanPlayAnotherRound_ReturnFalse()
        {
            Game game = new Game();
            game.StartRound(20);

            bool value = game.Player.CanPlayAnotherRound();

            Assert.IsFalse(value);
        }

        [TestMethod]
        public void NewRound_ClearsHandValue()
        {
            Game game = new Game();
            game.StartRound(5);
            game.Player.Stand();
            game.EndRound();

            game.Player.NewRound();
            int playerHandValue = game.Player.Hand.GetTotalValue();

            Assert.AreEqual(0, playerHandValue);
        }

        [TestMethod]
        public void SetAndGetNameOfPlayer()
        {
            Game game = new Game();
            game.StartRound(5);
            game.Player.Name = "Bart";

            string value = game.Player.Name;

            Assert.AreEqual("Bart", value);
        }



    }
}