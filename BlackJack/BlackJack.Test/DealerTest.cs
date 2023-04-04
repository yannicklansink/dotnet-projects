namespace BlackJack.Test
{
    [TestClass]
    public class DealerTest
    {
        [TestMethod]
        public void GetCards_TotalOf2CardsInList()
        {
            Game game  = new Game();
            game.StartGame(1m);

            int value = game.Dealer.GetCards().Count();

            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void IsBust_DealerHasValueOver21()
        {
            // this test sometimes fails?
            // why does it sometimes return false? 
            Game game = new Game();
            game.StartGame(1m);

            while (game.Dealer.Hand.GetTotalValue() < 21)
            {
                game.Dealer.Hit();
            }

            Assert.AreEqual(true, game.Dealer.IsBust());
        }



    }
}