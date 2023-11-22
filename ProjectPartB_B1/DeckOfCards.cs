using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class DeckOfCards : IDeckOfCards
    {
        protected const int MaxNrOfCards = 52; //Max value of deck

        protected List<PlayingCard> cards = new List<PlayingCard>(MaxNrOfCards); //Deck of cards

        public PlayingCard this[int idx] => cards[idx]; //Card index

        public int Count => cards.Count; //Cards left

        public override string ToString() //Printing cards
        {
            string sRet = "";
            for (int i = 0; i < cards.Count; i++)
            {
                sRet += $"{cards[i]}\t";
                if ((i + 1) % 13 == 0)
                    sRet += "\n";
            }
            return sRet;
        }

        public void Shuffle() //Shuffle cards with a tuple
        {
            var rnd = new Random();
            int nrCards = cards.Count;
            for (int i = 0; i < nrCards; i++)
            {
                int rndIndex = rnd.Next(i, nrCards);

                (cards[i], cards[rndIndex]) = (cards[rndIndex], cards[i]);
            }
        }
        public void Sort() //Sorting cards in order by value
        {
            cards.Sort();
        }

        public void Clear() //Clear deck
        {
            cards.Clear();
        }

        public void CreateFreshDeck() //Create new deck by looping through every card cards
        {
            foreach (PlayingCardColor color in Enum.GetValues(typeof(PlayingCardColor)))
            {
                foreach (PlayingCardValue value in Enum.GetValues(typeof(PlayingCardValue)))
                {
                    cards.Add(new PlayingCard(color, value));
                }
            }
        }

        public PlayingCard RemoveTopCard() //Remove card from deck
        {
            if (cards.Count > 0)
            {
                int lastIndex = cards.Count - 1;
                PlayingCard topCard = cards[lastIndex];
                cards.RemoveAt(lastIndex);
                return topCard;
            }
            else
            {
                Console.WriteLine("Empty deck!");
                return null;
            }
        }
    }
}
