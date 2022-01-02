namespace CardGames.Core.Deck.Interfaces
{
    public interface IDeck
    {
        int Count();

        ICard Draw();
        void Shuffle();        
        void Discard(ICard c);
        
    }
}