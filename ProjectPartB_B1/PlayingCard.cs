using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPartB_B1
{
	public class PlayingCard : IComparable<PlayingCard>, IPlayingCard
	{
        public PlayingCard(PlayingCardColor color, PlayingCardValue value)
        {
            Color = color;
            Value = value;
        }

        public PlayingCardColor Color { get; init; }
		public PlayingCardValue Value { get; init; }

		public int CompareTo(PlayingCard card1) //Compare cards
        {
            return this.Value.CompareTo(card1.Value);
        }

        string ShortDescription => Color switch //Switch expression assigning symbols to Color //Ingen default, sorry
        {
            PlayingCardColor.Spades => '\u2664' + Value.ToString(),
            PlayingCardColor.Hearts => '\u2661' + Value.ToString(),
            PlayingCardColor.Diamonds => '\u2662' + Value.ToString(),
            PlayingCardColor.Clubs => '\u2667' + Value.ToString(),
        };

        public override string ToString() => $"{ShortDescription}"; //Print symbols
    }
}
