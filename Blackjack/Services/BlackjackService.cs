using Blackjack.Models;
using System;

namespace Blackjack.Services
{
    public class BlackjackService
    {
        private readonly Game _game;

        public BlackjackService(Game game)
        {
            _game = game;
        }

        public void StartNewGame()
        {
            _game.DealerHand.Cards.Clear();
            _game.DealerHand.IsHoleCardHidden = true;
            _game.Winner = null;
            _game.PlayerHand.Cards.Clear();

            DealInitialCards();
        }

        public void DealInitialCards()
        {
            _game.Deck.Shuffle();
            _game.DealerHand.Cards.Add(_game.Deck.DrawCard());
            _game.DealerHand.Cards.Add(_game.Deck.DrawCard(true));
            _game.PlayerHand.Cards.Add(_game.Deck.DrawCard());
            _game.PlayerHand.Cards.Add(_game.Deck.DrawCard());

            if (_game.DealerHand.CalculateHandValue() == 21 && _game.DealerHand.CalculateHandValue() == 21)
            {
                _game.Winner = "Dealer";
            }
            else if (_game.PlayerHand.CalculateHandValue() == 21)
            {
                _game.Winner = "Player";
            }
            else if (_game.DealerHand.CalculateHandValue() == 21)
            {
                _game.Winner = "Dealer";
            }
        }

        public void DealerPlayes()
        {
            if (_game.Winner != null)
                throw new Exception("The game has already been won by " + _game.Winner);

            _game.DealerHand.Cards[1].IsHoleCard = false;

            while (_game.DealerHand.ShouldDealerDrawCard())
            {
                _game.DealerHand.Cards.Add(_game.Deck.DrawCard());
            }

        }

        public void PlayerHits()
        {
            if (_game.Winner != null)
                throw new Exception("The game has already been won by " + _game.Winner);

            if (_game.PlayerHand.IsBust())
                throw new Exception("Player has been bust");

            _game.PlayerHand.Cards.Add(_game.Deck.DrawCard());
        }

        public void PlayerStand()
        {
            if (_game.Winner != null)
            {
                throw new Exception("The game has already been won by " + _game.Winner);
            }

            DealerPlayes();
        }

        public bool PlayerBust()
        {
            if (_game.Winner != null)
            {
                throw new Exception("The game has already been won by " + _game.Winner);
            }

            return _game.PlayerHand.IsBust();

        }

        public void EndGame()
        {
            if (_game.PlayerHand.IsBust())
            {
                _game.Winner = "Dealer";
            }
            else if (_game.DealerHand.IsBust() || _game.PlayerHand.CalculateHandValue() > _game.DealerHand.CalculateHandValue())
            {
                _game.Winner = "Player";
            }
            else if (_game.DealerHand.CalculateHandValue() > _game.PlayerHand.CalculateHandValue())
            {
                _game.Winner = "Dealer";
            }
            else
            {
                _game.Winner = "Dealer";
            }
        }

        public int CalculatePlayerHand()
        {
            return _game.PlayerHand.CalculateHandValue();
        }

        public int CalculateDealerHand()
        {
            return _game.DealerHand.CalculateHandValue();
        }

        public Game GetGame()
        {
            return _game;
        }

    }
}
