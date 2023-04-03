namespace BlackJack.Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void GenerateDeck_With52Cards()
        {
            Deck deck = new Deck();

            Assert.AreEqual(52, deck.CardList.Count());
        }
    }
}