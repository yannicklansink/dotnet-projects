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


        [TestMethod]
        public void Shuffle_CardListInDeck()
        {
            //arrange
            Deck deck = new Deck();

            //act
            deck.Shuffle();

            // assert          
            Assert.AreNotEqual(deck.CardList[0], 11);
            Assert.AreEqual(52, deck.CardList.Count()); // it still need a size of 52
        }

    }
}