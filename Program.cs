using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayYourCardsRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // New Game
            Game game = new Game();
            Console.WriteLine("Welcome to Play Your Cards Right.");

            // Infinite Loop until broken.
            while (true)
            {
                //Display the current card.
                PlayingCard currentCard = game.getCurrentCard();
                Console.WriteLine($"\nThe Current Card is {currentCard.ToString()}");

                //Obtain user input.
                Console.WriteLine("Is the next card Higher or Lower?");
                Console.Write("Enter H/L/QUIT >> ");
                string response = Console.ReadLine().ToLower();

                ///Bye then!
                if (response == "quit")
                {
                    Console.WriteLine("Thanks for playing");
                    break;
                }

                // Response must be H or L. 
                if (response == "h" || response == "l")
                {
                    /* response == h will give boolean True.
                     * so using this in a parameter will send True value.
                     * otherwise, False value will be sent 
                     */
                    if (game.Guess(response == "h")) 
                    {
                        Console.WriteLine($"Correct - Score: {game.GetScore()}");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you lose!");
                        Console.WriteLine($"The next card was {game.getCurrentCard().ToString()}");
                        Console.WriteLine($"Your final score was {game.GetScore()}");
                        Console.WriteLine("\nThanks for playing!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Response!");
                }
                
            }
          
            // Stop the console closing on end.
            Console.ReadLine();
        }
    }
}
