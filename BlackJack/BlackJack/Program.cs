namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(); // creates a player and deck
            game.StartGame(5m); // creates player and dealer and gives both 2 cards

            Console.WriteLine("Total value of players hand is: " + game.Player.Hand.GetTotalValue());

            // Get the CardList through Game -> Player -> Hand -> CardList
            foreach (Card card in game.Player.Hand.CardList)
            {
                Console.WriteLine("Player cards are: " + card);
            }

            // Call the method GetCards() in Dealer through Game -> Dealer -> GetCards()
            foreach (Card card in game.Dealer.GetCards())
            {
                Console.WriteLine("Dealer cards are: " + card);
            }
            Console.WriteLine("---------");

            while(game.Dealer.Hand.GetTotalValue() < 21)
            {
                game.Dealer.Hit();
            }

            int value = game.Dealer.Hand.GetTotalValue();

            Console.WriteLine("the value of the dealer hand is: " + value);






        }
    }
}