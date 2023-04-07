namespace BlackJack.Test
{
    [TestClass]
    public class DealerTest
    {
        [TestMethod]
        public void GetCards_TotalOf2CardsInList()
        {
            Game game  = new Game();
            game.StartRound(1m);

            int value = game.Dealer.GetCards().Count();

            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void IsBust_DealerHasValueOver21()
        {
            Game game = new Game();
            game.StartRound(1m);

            while (game.Dealer.Hand.GetTotalValue() <= 22)
            {
                game.Dealer.Hit();
            }

            Assert.AreEqual(true, game.Dealer.IsBust());
        }

        [TestMethod]
        public void GetCards_Return2Cards()
        {
            Game game = new Game();
            game.StartRound(6);

            int CardListSize = game.Dealer.GetCards().Count;

            Assert.AreEqual(2, CardListSize);
        }

        [TestMethod]
        public void Play_DealerPlaysUntillBust_Or_HigherThen17()
        {
            Game game = new Game();
            game.StartRound(5);

            game.Player.Stand();

            Assert.AreEqual(true, game.Dealer.IsPlaying);
        }

        [TestMethod]
        public void GetNameOfDealer()
        {
            Game game = new Game();
            game.StartRound(5);

            string dealerName = game.Dealer.Name;

            Assert.AreEqual("Dealer", dealerName);
        }

        //[TestMethod]
        //public void IsBust_AfterPlaying_ReturnsTrue()
        //{
        //    Game game = new Game();
        //    game.StartRound(5);

        //    while (!game.Dealer.IsBust())
        //    {
        //        game.Dealer.Hit();
        //    }

        //    Assert.AreEqual(true, game.Dealer.IsBust());
        //}


    }
}