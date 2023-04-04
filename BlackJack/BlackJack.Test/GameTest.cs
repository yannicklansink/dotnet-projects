namespace BlackJack.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void GenerateAllGameDecks_6DecksTotal()
        {
            Game game  = new Game();

            Assert.IsNotNull(game.Deck);
        }

        [TestMethod]
        public void IsPlayerWinner_ReturnFalseWhenPlayerIsBust()
        {
            Game game = new Game();
            game.StartGame(10);

            while (!game.Player.IsBust())
            {
                game.Player.Hit();
            }

            bool value = game.IsPlayerWinner();

            Assert.AreEqual(false, value);
        }

        [TestMethod]
        public void IsPlayerWinner_ReturnTrueWhenDealerIsBust()
        {
            Game game = new Game();
            game.StartGame(10);

            while (!game.Dealer.IsBust())
            {
                game.Dealer.Hit();
            }

            bool value = game.IsPlayerWinner();

            Assert.AreEqual(true, value);
        }

        [TestMethod]
        public void IsDraw_ReturnFalseWhenDealerIsBust()
        {
            Game game = new Game();
            game.StartGame(10);

            while (!game.Dealer.IsBust())
            {
                game.Dealer.Hit();
            }

            bool value = game.IsDraw();

            Assert.AreEqual(false, value);
        }

    }
}