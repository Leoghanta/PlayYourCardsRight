using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayYourCardsRight
{
    internal class Game
    {
        private List<PlayingCard> deck;
        private int currentCardIndex;
        private int attempts;

        /// <summary>
        /// Create the object Initialises the game.
        /// Create the deck, shuffle it and reset index and attempts to 0.
        /// </summary>
        public Game()
        {
            InitializeDeck();
            ShuffleDeck();
            currentCardIndex = 0;
            attempts = 0;
        }

        /// <summary>
        /// Initialise the Deck.
        /// Set the deck as a new list and loop through suits and ranks.
        /// ranks go from 2 to 14 (allowing for jack, queen, king, and Ace will be 14.
        /// </summary>
        private void InitializeDeck()
        {
            deck = new List<PlayingCard>();

            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                for (int rank = 2; rank <= 14; rank++)
                {
                    deck.Add(new PlayingCard(rank, suit));
                }
            }
        }

        /// <summary>
        /// Shuffle the deck. Each card is swapped with a random card in the deck.
        /// </summary>
        private void ShuffleDeck()
        {
            Random rand = new Random();
            int currentlocation = deck.Count;
            while (currentlocation > 1)
            {
                currentlocation--;
                int newlocation = rand.Next(currentlocation + 1);

                // swap the card in currentlocation to card in new location.
                PlayingCard templocation = deck[newlocation];
                deck[newlocation] = deck[currentlocation];
                deck[currentlocation] = templocation;
            }
        }

        /// <summary>
        /// get the current card in play
        /// </summary>
        /// <returns>Returns the current card as a PlayingCard object.</returns>
        public PlayingCard getCurrentCard()
        {
            return deck[currentCardIndex];
        }

        /// <summary>
        /// get the next card in play.
        /// </summary>
        /// <returns>Returns the next card as a PlayingCard object.</returns>
        public PlayingCard getNextCard()
        {
            return deck[currentCardIndex+1];
        }

        /// <summary>
        /// Guess the next card. True is higher, False is lower.
        /// Pairs are seen as fails. return false.
        /// Guess correct, return true.
        /// </summary>
        /// <param name="isHigher">True for higher, False for lower</param>
        /// <returns>True if guessed correctly. otherwise False.</returns>
        public bool Guess(bool isHigher)
        {
            attempts++;

            PlayingCard currentCard = getCurrentCard();
            PlayingCard nextCard = getNextCard();

            if (currentCard.Rank == nextCard.Rank)
            {
                // ooh, nothing for a pair! not in this game.
                return false;
            }
            else if (isHigher)
            {
                if (nextCard.Rank > currentCard.Rank)
                {
                    currentCardIndex++;
                    return true; // Correct.
                }
                else
                {
                    currentCardIndex++;
                    return false; // Wrong
                }
            }
            else
            {
                if (nextCard.Rank < currentCard.Rank)
                {
                    currentCardIndex++;
                    return true; //Correct, card is lower.
                }
                else
                {
                    currentCardIndex++;
                    return false; //Wrong
                }
            }
        }

        /// <summary>
        /// Returns the current score.
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            return attempts;
        }

        /// <summary>
        /// Reset the game by shuffling the deck and initialising the scores.
        /// </summary>
        public void Reset()
        {
            ShuffleDeck();
            currentCardIndex = 0;
            attempts = 0;
        }

    }
}
