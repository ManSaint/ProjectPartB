using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPartB_B1
{
    class Program
    {
        static DeckOfCards myDeck = new DeckOfCards();
        static HandOfCards player1 = new HandOfCards();
        static HandOfCards player2 = new HandOfCards(); //Static variables accessible everywhere

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //For printing Unicode symbols

            Decks();

            Game(myDeck, player1, player2);
        }

        public static void Game(DeckOfCards myDeck, HandOfCards player1, HandOfCards player2) //Asking for cards, rounds and errors
        {
            Console.Write("How many cards for each player? 1-5: ");
            bool all_ok = int.TryParse(Console.ReadLine(), out int NrOfCards);
            while (!all_ok || NrOfCards < 1 || NrOfCards > 5)
            {
                Console.Write("Invalid input. Please enter a value between 1 and 5: ");
                all_ok = int.TryParse(Console.ReadLine(), out NrOfCards);
            }

            Console.Write("\nHow many rounds do you want to play? 1-5: ");
            all_ok = int.TryParse(Console.ReadLine(), out int NrOfRounds);
            while (!all_ok || NrOfRounds < 1 || NrOfRounds > 5)
            {
                Console.Write("Invalid input. Please enter a value between 1 and 5: ");
                all_ok = int.TryParse(Console.ReadLine(), out NrOfRounds);
            }

            for (int i = 0; i < NrOfRounds; i++)
            {
                Console.WriteLine($"\n\nNow playing round {i +1}");
                Console.WriteLine("-------------------");
                Deal(myDeck, NrOfCards, player1, player2);
                DetermineWinner(player1, player2, myDeck);
            }
        }

        private static void Decks() //Printing decks
                {
                    myDeck.CreateFreshDeck();
                    Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
                    Console.WriteLine(myDeck);

                    Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
                    myDeck.Sort();
                    Console.WriteLine(myDeck);

                    Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
                    myDeck.Shuffle();
                    Console.WriteLine($"{myDeck}\n");
                }

        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2) //Adding cards to players and printing hands
        {
            for (int i = 0; i < (nrCardsToPlayer * 2); i++)
            {
                if (i % 2 != 1)
                {
                    PlayingCard cardToGive = myDeck.RemoveTopCard();
                    player1.Add(cardToGive);
                }
                else
                {
                    PlayingCard cardToGive = myDeck.RemoveTopCard();
                    player2.Add(cardToGive);
                }
            }
            Console.WriteLine($"{nrCardsToPlayer} cards was given to each player. {myDeck.Count} cards left in the deck.\n");
            Console.WriteLine($"Player 1 got {nrCardsToPlayer} cards.");
            Console.WriteLine($"Lowest card in hand is: {player1.Lowest} | Highest is: {player1.Highest}");
            Console.WriteLine($"{player1}");

            Console.WriteLine($"\nPlayer 2 got {nrCardsToPlayer} cards.");
            Console.WriteLine($"Lowest card in hand is: {player2.Lowest} | Highest is: {player2.Highest}");
            Console.WriteLine($"{player2}\n");
        }

        private static void DetermineWinner(HandOfCards player1, HandOfCards player2, DeckOfCards mydeck) //Checking highest and lowest card, printing winner, clearing hands
        {
            try
            {
                if (player1.Highest.Value > player2.Highest.Value)
                {
                    Console.WriteLine("Player1 Wins!");
                }
                else if (player1.Highest.Value < player2.Highest.Value)
                {
                    Console.WriteLine("Player2 Wins!");
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\nNot enough cards, creating new deck");
                mydeck.Clear();
                mydeck.CreateFreshDeck();
            }
            player1.Clear();
            player2.Clear();
        }
    }
}