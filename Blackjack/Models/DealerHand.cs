using System.Collections.Generic;
using System.Linq;

namespace Blackjack.Models
{
    public class DealerHand
    {
        public List<Card> Cards { get; set; }
        public bool IsHoleCardHidden { get; set; }

        public DealerHand()
        {
            Cards = new List<Card>();
            IsHoleCardHidden = true;
        }

        public int CalculateHandValue()
        {
            var handValue = 0;
            var acesCount = 0;

            foreach (var card in Cards)
            {
                if (card.IsHoleCard)
                    continue;
                if (card.FaceValue == "A")
                    acesCount++;
                else
                    handValue += card.Value;

                for (var i = 0; i < acesCount; i++)
                {
                    if (handValue + 11 <= 21)
                        handValue += 11;
                    else
                        handValue += 1;
                }
            }
            return handValue;
        }

        public bool ShouldDealerDrawCard()
        {
            var handValue = CalculateHandValue();

            if (handValue < 17)
                return true;
            if (handValue == 17 && HasAce())
                return true;
            return false;
        }

        public bool HasAce()
        {
            foreach (var card in Cards)
            {
                if (card.FaceValue == "Ace")
                    return true;
            }
            return false;
        }

        public List<Card> GetCards()
        {
            if (IsHoleCardHidden)
            {          
                var cardsCopy = new List<Card>();
                cardsCopy.AddRange(Cards.Take(1));
                cardsCopy.Add(new Card("Unknown", "Unknown", 0));
                return cardsCopy;
            }
            else
            {
                return Cards;
            }
        }

        public bool IsBust()
        {
            return CalculateHandValue() > 21;
        }

    }
}
