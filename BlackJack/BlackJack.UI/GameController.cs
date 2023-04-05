using BlackJack.Exceptions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.UI
{
    public class GameController
    {

        // possible user inputs:
        // Int              For bet amount
        // Yy, Nn           For start playing and keep playing
        // H, S, D, P       For player when only 2 cards in hand
        // H, S             For player when cards.count > 2

        public Game Game { get; set; }

        private string[] ValidateYandN = { "Y", "N" };
        private string[] ValidateHSDP = { "H", "S", "D", "P" };
        private string[] ValidateHS = { "H", "S" };

        public GameController()
        {
            Game = new Game();

        }

        public void StartGame()
        {
            Console.WriteLine("Hello, user. Welcome to Blackjack!");
            AskPlayerPlayGame();
            ShowDealerHand(); 
            ShowPlayerHand();


            AskPlayerHSDP(); // when players has only 2 cards. 
        }

        public void AskPlayerPlayGame()
        {
            Console.WriteLine("Do you want to play a game?(Y)(N)");

            string? input = Console.ReadLine();
            CheckUserInputNullOrEmpty(input, AskPlayerPlayGame);
            ValidateUserInput(input.ToUpper(), ValidateYandN, AskPlayerPlayGame);

            if (input.ToUpper() == "Y") AskPlayerBetAmount();
            else if (input == "N") Console.WriteLine("Ok, maybe another time.");
        }

        public void AskPlayerBetAmount()
        {
            Console.WriteLine($"Your balance is ${Game.Player.Balance}");
            Console.Write($"Place a bet between 1 and {Game.Player.Balance}: ");
            string? bet = Console.ReadLine();
            ConvertUserInput(bet, AskPlayerBetAmount);
        }

        public void ShowPlayerHand()
        {
            Console.WriteLine(Game.Player.ShowHand());
        }

        public void ShowDealerHand()
        {
            Console.WriteLine(Game.Dealer.ShowHand());
        }

        public void AskPlayerHSDP()
        {
            Console.Write($"(H)it or (S)tand or (D)ouble Down or Split (P)airs? ");
            string? input = Console.ReadLine();
            CheckUserInputNullOrEmpty(input, AskPlayerHSDP);
            ValidateUserInput(input.ToUpper(), ValidateHSDP, AskPlayerHSDP);

        }

        public void Move()
        {
            // make move. if statements......
        }





        // Helper function:
        public void ConvertUserInput(string? bet, Action function)
        {
            int parsedBet;
            // The 'out' parameter  will contain the converted integer if the conversion is successful.
            if (int.TryParse(bet, out parsedBet))
            {
                if (parsedBet >= 1 && parsedBet <= Game.Player.Balance)
                {
                    // valid bet
                    Game.StartGame(parsedBet);
                    Console.WriteLine($"Your bet of {Game.Player.Bet} is placed. Your new balance is {Game.Player.Balance}");
                    return;
                } else
                {
                    Console.WriteLine($"Invalid bet. Bet must be greater than or equal to 1 and less than or equal to {Game.Player.Balance}.");
                    function();
                }
            } else
            {
                Console.WriteLine("Invalid bet. Please enter a valid number.");
                function();
            }
        }

        public void CheckUserInputNullOrEmpty(string userInput, Action function)
        {
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine($"Checked user input. Your input: {userInput} is invalid, please try again.");
                function();
            }
        }


        public void ValidateUserInput(string userInput, string[] validate, Action function)
        {
            bool inputIsCorrect = false;
            foreach (string value in validate)
            {
                if (value == userInput)
                {
                    return;
                }
            }
            Console.WriteLine($"Validated user input. Your input: {userInput} is invalid, please try again.");
            function();
        }




    }
}
