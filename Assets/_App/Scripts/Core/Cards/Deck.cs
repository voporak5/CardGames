using CardGames.Core.Deck.Interfaces;
using CardGames.Core.Deck.Types;
using System;
using System.Collections.Generic;

namespace CardGames.Core.Deck
{
    public class Deck : IDeck
    {
        protected List<ICard> deck = new List<ICard>();
        protected List<ICard> inPlay = new List<ICard>();
        protected List<ICard> discard = new List<ICard>();

        public Deck()
        {
            Populate();
        }

        public int Count()
        {
            return deck.Count;
        }

        public ICard Draw()
        {
            if (Count() == 0) return null;

            ICard card = deck[0];
            deck.RemoveAt(0);
            inPlay.Add(card);

            return card;
        }

        public void Shuffle()
        {
            List<ICard> cards = new List<ICard>();
            EmptyCardsInto(deck, cards);
            EmptyCardsInto(inPlay, cards);
            EmptyCardsInto(discard, cards);

            Utils.Shuffle(cards);
            EmptyCardsInto(cards, deck);
        }

        public void Discard(ICard card)
        {
            if(inPlay.Remove(card)) discard.Add(card);
        }

        void EmptyCardsInto(List<ICard> source, List<ICard> target)
        {
            while (source.Count > 0)
            {
                target.Add(source[0]);
                source.RemoveAt(0);
            }
        }

        protected virtual void Populate()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    deck.Add(new Card(suit,value));
                }
            }
        }

    }
}