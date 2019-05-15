using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    static class BlackjackRules {

        // All possible card face values (ten, jack, queen and king are the same)
        public static Dictionary<Card.Face, int> FaceValue = new Dictionary<Card.Face, int>() {
            {Card.Face.Ace, 1},
            {Card.Face.Two, 2},
            {Card.Face.Three, 3},
            {Card.Face.Four, 4},
            {Card.Face.Five, 5},
            {Card.Face.Six, 6},
            {Card.Face.Seven, 7},
            {Card.Face.Eight, 8},
            {Card.Face.Nine, 9},
            {Card.Face.Ten, 10},
            {Card.Face.Jack, 10},
            {Card.Face.Queen, 10},
            {Card.Face.King, 10}
        };

        // Returns an int representing the best interpretation of this player's hand possible.
        // "Best possible" means closest to 21 without going over.
        // Funny that only one ace can be interpreted as 11 given this condition.
        public static int GetHandValue(List<Card> hand) {
            int aces = hand.Count(x => x.face == Card.Face.Ace);
            int sum = hand.Sum(x => BlackjackRules.FaceValue[x.face]);
            sum += aces * 10;
            while (sum > 21 && aces > 0) {
                sum -= 10;
                aces--;
            }
            return sum;
        }

        // Returns true if the given hand has a blackjack, false if not.
        public static bool CheckBlackjack(List<Card> hand) {
            int n = GetHandValue(hand);
            return (n == 21);
        }

    }
}
