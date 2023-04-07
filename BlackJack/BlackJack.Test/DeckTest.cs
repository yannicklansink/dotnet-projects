namespace BlackJack.Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void GenerateDeck_With312Cards()
        {
            Deck deck = new Deck();

            Assert.AreEqual(312, deck.CardList.Count());
        }


        [TestMethod]
        public void Shuffle_CardListInDeck()
        {
            //arrange
            Deck deck = new Deck();
            bool value = true;

            //act
            deck.Shuffle();
            if (
                   deck.CardList[0].Value == 11 
                && deck.CardList[1].Value == 10
                && deck.CardList[2].Value == 11
                && deck.CardList[5].Value == 9
            )
            {
                // if  values of 4 places stay the same, then shuffle method did not work.
                value = false;
            }

            // assert  
            Assert.AreEqual(true, value);
            Assert.AreEqual(312, deck.CardList.Count());
        }

        [TestMethod]
        public void Draw_ReturnAndRemoveLastCard()
        {
            //arrange
            Deck deck = new Deck();

            // act
            Card card = deck.Draw();

            //arrange
            Assert.AreNotEqual(deck.CardList.Last(), card);
        }

        [TestMethod]
        public void Draw_ReturnsDifferentSizeList()
        {
            //arrange
            Deck deck = new Deck();

            // act
            Card card = deck.Draw();

            //arrange
            Assert.AreEqual(311, deck.CardList.Count);
        }

    }
}