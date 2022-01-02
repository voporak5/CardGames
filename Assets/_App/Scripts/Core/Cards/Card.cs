using CardGames.Core.Deck.Interfaces;
using CardGames.Core.Deck.Types;

namespace CardGames.Core.Deck
{
    public class Card : ICard
    {
        private readonly Suit suit;
        private readonly Value value;

        public Card(Suit suit, Value value)
        {
            this.suit = suit;
            this.value = value;
        }

        public Suit Suit()
        {
            return suit;
        }

        public Value Value()
        {
            return value;
        }
    }
}