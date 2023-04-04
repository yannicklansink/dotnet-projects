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
    }
}