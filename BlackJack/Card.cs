using System.Collections.Generic;

namespace BlackJack {
    struct Card {
        public readonly Face face;
        public readonly Suit suit;

        // Builds a new card object (immutable, and is guaranteed valid upon successful construct)
        public Card(Face face, Suit suit) {
            this.face = face;
            this.suit = suit;
        }

        // Returns a string representation of this card.
        public override string ToString() {
            return FaceToChar(this.face) + SuitToChar(this.suit);
        }

        // All possible card faces.
        public enum Face {
            Ace=1,
            Two=2,
            Three=3,
            Four=4,
            Five=5,
            Six=6,
            Seven=7,
            Eight=8,
            Nine=9,
            Ten=10,
            Jack=11,
            Queen=12,
            King=13
        }

        // All possible card suits
        public enum Suit {
            Spade,
            Heart,
            Club,
            Diamond
        }

        // Returns a char (length 1 string) representation of the Face value given.
        public static string FaceToChar(Face face) {
            int n = (int)face;
            string r = "";

            if (n == 1 || n >= 11 && n <= 13)
                r = face.ToString().Substring(0, 1);
            else if (n == 10)                           // Ten has 2 digits. It's annoying.
                r = "X";
            else
                r = n.ToString();

            return r;
        }

        // Returns a char (length 1 string) representation of the Suit value given.
        public static string SuitToChar(Suit suit) {
            return suit.ToString().Substring(0, 1).ToLower();
        }
    }
}
