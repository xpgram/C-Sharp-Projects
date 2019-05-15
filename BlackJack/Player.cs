using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    class Player {
        public string name;
        public int funds;
        public int bet;
        public List<Card> Hand;
        public bool playing;
        public bool stay;
        public bool busted;
        public bool won;

        public Player(string name, int funds) {
            this.name = name;
            this.funds = funds;
            this.Hand = new List<Card>();
            this.stay = false;
            this.busted = false;
        }

        public void newRound() {
            this.ReturnBet();
            this.Hand.Clear();
            this.stay = false;
            this.busted = false;
        }

        // Print a string representing the player, their stats, and their hand.
        public void print() {
            Console.Write(String.Format("${0} {1}, ${2}:  ", funds, name, bet));
            foreach (Card card in Hand)
                Console.Write(card.ToString() + " ");
            Console.WriteLine(" : " + BlackjackRules.GetHandValue(this.Hand));
        }

        // Asks the player for their bet. Harasses them until they give something good.
        // Returns false if unsuccessful. Otherwise, ~always~ returns true, bb.
        public bool AskBet(int min, int max) {
            if (this.funds <= 0)
                return false;

            int bet;
            do {
                bet = Prompt.GetInt("Place your bet, " + this.name + ".");
                if (this.funds - bet < 0) {
                    Console.WriteLine("You don't have enough! Why?!");
                    bet = -1;
                }
                else if (bet < 0) {
                    throw new FraudException(this.name + " was caught cheating! Or trying to.");
                    // This is purely for demonstrational purposes.
                }
                else if (bet < min || bet > max) {
                    Console.WriteLine("Your bet is outside the table limits.");
                    bet = -1;
                }
            } while (bet == -1);

            this.funds -= bet;
            this.bet = bet;

            return true;
        }

        // The player "takes their bet back" in the sense that whatever became of it (whether it paid out
        // or got swept), it is added back into the player's bank.
        public void ReturnBet() {
            this.funds += this.bet;
            this.bet = 0;
        }

        // Recieves a list of cards and adds them to the hand.
        // This exists because Draw() is a security issue; gambling is very srs and cheating will not be tolerate.
        public void Take(Card card) {
            this.Hand.Add(card);
        }
        public void Take(List<Card> cards) {
            this.Hand.AddRange(cards);
        }

        // 'Draws' a card from a given deck by adding it to this.Hand and removing it from the deck.
        public void Draw(Deck deck) {
            this.Hand.Add(deck.Draw());
        }

        // 'Draws' a number of cards from a given deck by adding them to this.Hand and removing them from the deck.
        public void Draw(Deck deck, int num) {
            this.Hand.AddRange(deck.Draw(num));
        }
    }
}
