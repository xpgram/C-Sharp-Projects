using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    class BlackjackDealer : Dealer {
        public List<Card> hand;
        public bool stay;
        public bool busted;
        public bool downCard;

        public BlackjackDealer() {
            // TODO is Dealer's constructor run automatically? What if I didn't want it too? Would that even make sense?
            this.hand = new List<Card>();
            this.stay = false;
            this.busted = false;
            this.downCard = true;
        }

        public void print() {
            string hiddenCard = (this.downCard ? "## " : "");
            int startIdx = (this.downCard ? 1 : 0);

            Console.Write("Dealer:  " + hiddenCard);
            for (int i = startIdx; i < hand.Count; i++)
                Console.Write(hand[i].ToString() + " ");
            if (!this.downCard)
                Console.Write(" : " + BlackjackRules.GetHandValue(this.hand));
            Console.WriteLine();
        }

        public void newRound() {
            this.hand.Clear();
            this.deck.Reset();
            this.deck.Shuffle();
            this.downCard = true;
        }
    }
}
