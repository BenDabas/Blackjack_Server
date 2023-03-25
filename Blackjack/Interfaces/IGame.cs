using Blackjack.Models;

namespace Blackjack.Interfaces
{
    public interface IGame
    {
        public DealerHand DealerHand { get; set; }
        public PlayerHand PlayerHand { get; set; }
        public Deck Deck { get; set; }
        public string Winner { get; set; }

    }
}
