using CardGames.Core.Deck.Types;

namespace CardGames.Core.Deck.Interfaces
{
    public interface ICard
    {
        Suit Suit();
        Value Value();
    }
}