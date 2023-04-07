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
        private string UserInput { get; set; }

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

            ShowHandsDealerAndPlayer();
            Move();
            ShowWhoWon();
            ShowPlayerNewBalance();
            AskPlayerToKeepPlaying();
            if (Game.StillPlaying)
            {
                StartNextRound();
            }

            Console.WriteLine("----------------------------End of game----------------------------");
        }

        public void StartNextRound()
        {
            
            while (Game.StillPlaying)
            {
                AskPlayerBetAmount();
                ShowHandsDealerAndPlayer();
                Move();
                ShowWhoWon();
                ShowPlayerNewBalance();
                AskPlayerToKeepPlaying();
            }
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

        public void AskPlayerToKeepPlaying()
        {
            bool CanPlayerPlay = Game.Player.CanPlayAnotherRound();
            if (!CanPlayerPlay)
            {
                Console.WriteLine($"Your balance of {Game.Player.Balance} is to low to play.");
                Game.StillPlaying = false;
                return;
            }

            Console.Write("\nDo you want to keep playing (Y)es or (N)o? ");
            string? input = Console.ReadLine();
            CheckUserInputNullOrEmpty(input, AskPlayerToKeepPlaying);
            ValidateUserInput(input.ToUpper(), ValidateYandN, AskPlayerToKeepPlaying);

            if (input.ToUpper() == "N")
            {
                Game.StillPlaying = false;
                Console.WriteLine($"Ok, you give up {Game.Player.Name}. I win, muahahahahah!");
            }
        }

        public void ShowHandsDealerAndPlayer()
        {
            ShowDealerHand();
            ShowPlayerHand();
        }

        public void ShowHandsAfterRound()
        {
            ShowDealerHandWithoutFaceDown();
            ShowPlayerHand();
        }

        public void ShowPlayerHand()
        {
            Console.WriteLine(Game.Player.ShowHand());
        }

        public void ShowDealerHand()
        {
            Console.WriteLine(Game.Dealer.ShowHand());
        }

        public void ShowDealerHandWithoutFaceDown()
        {
            Console.WriteLine(Game.Dealer.ShowHandWithoutFaceDown());
        }

        public void ShowWhoWon()
        {
            if (Game.IsDraw())
            {
                Console.WriteLine("The round is a draw");
            } else if (Game.IsPlayerWinner())
            {
                Console.WriteLine("Player won the round");
            } else
            {
                Console.WriteLine("Dealer won the round");
            }
            ShowHandsAfterRound();
            Console.WriteLine($"Round {Game.RoundNumber} ended \n");
        }

        public void ShowPlayerNewBalance()
        {
            Console.WriteLine($"{Game.Player.Name}\n\t new balance: {Game.Player.Balance}");
        }

        public void ShowPlayerOrDealerBust()
        {
            if (Game.Player.IsBust())
            {
                Console.WriteLine($"{Game.Player} is busted with a score of {Game.Player.Hand.GetTotalValue()}");
            } else if (Game.Dealer.IsBust())
            {
                Console.WriteLine($"Dealer is busted with a score of {Game.Dealer.Hand.GetTotalValue()}");
            }
        }

        public void AskPlayerHSDP()
        {
            Console.Write($"(H)it or (S)tand or (D)ouble Down or Split (P)airs? ");
            string? input = Console.ReadLine();
            Console.WriteLine();
            CheckUserInputNullOrEmpty(input, AskPlayerHSDP);
            ValidateUserInput(input.ToUpper(), ValidateHSDP, AskPlayerHSDP);
            UserInput = input.ToUpper();
        }

        public void AskPlayerHS()
        {
            Console.Write($"(H)it or (S)tand ");
            string? input = Console.ReadLine();
            Console.WriteLine();
            CheckUserInputNullOrEmpty(input, AskPlayerHS);
            ValidateUserInput(input.ToUpper(), ValidateHS, AskPlayerHS);
            UserInput = input.ToUpper();
        }

        public void Move()
        {
            while (!Game.Player.IsStand && !Game.Player.IsBust())
            {
                if (Game.Player.Hand.GetHandSize() == 2)
                {
                    AskPlayerHSDP(); 
                    if (UserInput == "H")
                    {
                        Game.Player.Hit();
                    } else if (UserInput == "S")
                    {
                        Game.Player.Stand();
                    } else if (UserInput == "D")
                    {
                        // implement method
                    } else if (UserInput == "P")
                    {
                        // implement method
                    } else
                    {
                        Console.WriteLine("Something went wrong...");
                    }
                } else
                {
                    AskPlayerHS();
                    if (UserInput == "H")
                    {
                        Game.Player.Hit();
                    }
                    else if (UserInput == "S")
                    {
                        Game.Player.Stand();
                    }
                }
                if (!Game.Player.IsStand && !Game.Player.IsBust())
                {
                    ShowHandsDealerAndPlayer();
                }
            }
            Game.EndRound();

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
                    Game.StartRound(parsedBet);
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
