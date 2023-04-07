namespace BlackJack.Test
{
    [TestClass]
    public class HandTest
    {

        [TestMethod]
        public void AddCardToHand()
        {
            var hand = new Hand();
            var card = new Card(Rank.Ace, Suit.Spades);

            hand.AddCard(card);

            Assert.AreEqual(1, hand.CardList.Count);
        }

        [TestMethod]
        public void GetHandSize_Of2()
        {
            var hand = new Hand();
            var card = new Card(Rank.Ace, Suit.Spades);
            var card2 = new Card(Rank.Ten, Suit.Spades);

            hand.AddCard(card);
            hand.AddCard(card2);
            int value = hand.GetHandSize();

            Assert.AreEqual(2, value);
        }

        [TestMethod]
        public void GetTotalValue_With2Aces()
        {
            var hand = new Hand();
            var card = new Card(Rank.Ace, Suit.Spades);
            var card2 = new Card(Rank.Ace, Suit.Diamonds);

            hand.AddCard(card);
            hand.AddCard(card2);
            // possible values now: 2, 12, 22
            int value = hand.GetTotalValue();

            Assert.AreEqual(12, value);  
        }

        [TestMethod]
        public void GetTotalValue_With3Aces()
        {
            var hand = new Hand();
            var card = new Card(Rank.Ace, Suit.Spades);
            var card2 = new Card(Rank.Ace, Suit.Diamonds);
            var card3 = new Card(Rank.Ace, Suit.Diamonds);

            hand.AddCard(card);
            hand.AddCard(card2);
            hand.AddCard(card3);

            // possible values now: 3, 13, 23...
            int value = hand.GetTotalValue();

            Assert.AreEqual(13, value);
        }

        [TestMethod]
        public void GetTotalValue_With3AcesAnd8()
        {
            var hand = new Hand();
            var card = new Card(Rank.Ace, Suit.Spades);
            var card2 = new Card(Rank.Ace, Suit.Diamonds);
            var card3 = new Card(Rank.Ace, Suit.Diamonds);
            var card4 = new Card(Rank.Eight, Suit.Diamonds);

            hand.AddCard(card);
            hand.AddCard(card2);
            hand.AddCard(card3);
            hand.AddCard(card4);

            // possible values now: 11, 21....
            int value = hand.GetTotalValue();

            Assert.AreEqual(21, value);
        }

        [TestMethod]
        public void GetTotalValue_With_Ace_Nine_Two_Equals12()
        {
            var hand = new Hand();
            var card = new Card(Rank.Nine, Suit.Spades);
            var card2 = new Card(Rank.Ace, Suit.Diamonds);
            var card3 = new Card(Rank.Two, Suit.Diamonds);

            hand.AddCard(card);
            hand.AddCard(card2);
            hand.AddCard(card3);

            // possible values now: 12, 22
            int value = hand.GetTotalValue();

            Assert.AreEqual(12, value);
        }


    }
}