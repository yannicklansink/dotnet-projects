namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.WriteLine("Number of cards in the deck " + game.Deck.CardList.Count);
            Console.WriteLine(game.Deck.CardList[5]); // print 9
            game.Deck.CardList.RemoveAt(5);
            Console.WriteLine(game.Deck.CardList[5]); // print 8




        }
    }
}