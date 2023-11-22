using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
    class HandOfCards : DeckOfCards, IHandOfCards
    {
        public int cardsInHand { get => cards.Count; } //Count hand

        public void Add(PlayingCard card) //Add card
        {
            cards.Add(card);
        }

        public void Add(DeckOfCards deck, int howManyCards) //Add card to hand and remove from deck
        {
            for (int i = 0; i < howManyCards; i++)
            {
                PlayingCard drawnCard = deck.RemoveTopCard();
                if (drawnCard != null)
                {
                    cards.Add(drawnCard);
                }
            }
        }

        public PlayingCard Highest //Check highest card
        {
            get
            {
                if (cards.Count == 0)
                {
                    return null;
                }

                PlayingCard highestCard = cards[0];
                foreach (var card in cards)
                {
                    if (card.Value > highestCard.Value)
                    {
                        highestCard = card;
                    }
                }
                return highestCard;
            }
        }
        public PlayingCard Lowest //Check lowest card in hand
        {
            get
            {
                if (cards.Count == 0)
                {
                    return null;
                }

                PlayingCard lowestCard = cards[0];
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].CompareTo(lowestCard) < 0)
                    {
                        lowestCard = cards[i];
                    }
                }
                return lowestCard;
            }
        }
        public void clearHand() //Clear hand
        {
            cards.Clear();
        }
    }
}