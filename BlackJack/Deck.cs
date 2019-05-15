using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    class Deck {
        List<Card> cards;

        public List<Card> Cards { get { return this.cards.GetRange(0, this.cards.Count); } }
        public int Count { get { return this.cards.Count; } }

        public Deck() {
            this.cards = new List<Card>();
            Reset();
        }

        // Resets the deck to sorted full, like the dealer just opened a fresh new pack, baby.
        public void Reset() {
            this.cards.Clear();
            foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit))) {
                foreach (Card.Face f in Enum.GetValues(typeof(Card.Face))) {
                    Card c = new Card(f, s);
                    this.cards.Add(c);
                }
            }
        }

        // Shuffles the order the deck's cards are in.
        public void Shuffle() {
            List<Card> tmp = new List<Card>();
            tmp.AddRange(this.cards);
            this.cards.Clear();

            int i;
            while (tmp.Count > 0) {
                Random random = new Random();
                i = random.Next(tmp.Count);
                this.cards.Add(tmp[i]);
                tmp.RemoveAt(i);
            }
        }

        // Returns a card from the 'top' of the deck, removing it from the deck.
        public Card Draw() {
            Card c = this.cards[0];
            this.cards.RemoveAt(0);
            return c;
        }

        // Returns number cards from the 'top' of the deck, removing them from the deck.
        public List<Card> Draw(int number) {
            List<Card> c = this.cards.GetRange(0, number);
            this.cards.RemoveRange(0, number);
            return c;
        }

        // Inserts a card on 'top' of the deck.         (Pretty sure I'll never need these for this)
        public void PlaceOnTop(Card card) {
            this.cards.Insert(0, card);
        }

        // Inserts cards on 'top' of the deck.
        public void PlaceOnTop(List<Card> cards) {
            this.cards.InsertRange(0, cards);
        }

        // Insert a card on the 'bottom' of the deck.
        public void PlaceOnBottom(Card card) {
            this.cards.Insert(this.cards.Count, card);
        }

        // Inserts cards on the 'bottom' of the deck.
        public void PlaceOnBottom(List<Card> cards) {
            this.cards.InsertRange(this.cards.Count, cards);
        }
    }
}
