namespace BlackJack.Test
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void GetTheRightValueFromValue()
        {
            Card card = new Card(Rank.Nine, Suit.Spades);

            int value = card.Value;

            Assert.AreEqual(9, value);
        }
    }
}