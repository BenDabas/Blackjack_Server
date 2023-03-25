using System.Collections.Generic;

namespace Blackjack.Models
{
    public class PlayerHand
    {
        public List<Card> Cards { get; set; }

        public PlayerHand()
        {
            Cards = new List<Card>();
        }

        public int CalculateHandValue()
        {
            var handValue = 0;
            var acesCount = 0;

            foreach(var card in Cards)
            {
                if (card.FaceValue == "A")
                    acesCount++;
                else
                    handValue += card.Value;

                for(var i = 0; i < acesCount; i++)
                {
                    if (handValue + 11 <= 21)
                        handValue += 11;
                    else
                        handValue += 1;
                }
            }
            return handValue;
        }

        public bool IsBust()
        {
            return CalculateHandValue() > 21;
        }
    }
}
