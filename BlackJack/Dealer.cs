using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    // This literally only exists to show off inheritance.
    class Dealer {
        public string name;
        public Deck deck;
        public int funds;

        public Dealer() {
            this.name = "Mr. Deal";
            this.deck = new Deck();
            this.funds = 2000;
        }

        public void Deal(Player player) {
            player.Take(deck.Draw());
        }

        public void Deal(Player player, int number) {
            player.Take(deck.Draw(number));
        }
    }
}
