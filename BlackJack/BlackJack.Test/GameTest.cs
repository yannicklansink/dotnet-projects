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
            game.StartRound(10);

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
            game.StartRound(10);

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
            game.StartRound(10);

            while (!game.Dealer.IsBust())
            {
                game.Dealer.Hit();
            }

            bool value = game.IsDraw();

            Assert.AreEqual(false, value);
        }

        [TestMethod]
        public void ShuffleDeck_PlayerAndDealer_Have2Cards()
        {
            Game game = new Game();
            game.StartRound(20);
            Assert.AreEqual(2, game.Player.Hand.CardList.Count);
            Assert.AreEqual(2, game.Dealer.Hand.CardList.Count);
        }

        [TestMethod]
        public void IsPlayerWinner_GivesFalseWhenBust()
        {
            Game game = new Game();
            game.StartRound(5);
            
            while (!game.Player.IsBust())
            {
                game.Player.Hit();
            }
            Assert.AreEqual(false, game.IsPlayerWinner());
        }



    }
}