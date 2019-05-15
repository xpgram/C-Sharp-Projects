using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    abstract class Game {
        protected List<Player> players = new List<Player>();

        public abstract void init();
        public abstract void preRound();
        public abstract void round();
        public abstract void postRound();

        // Lists all players currently attached to this game.
        public virtual void listPlayers() {
            foreach (Player p in players)
                Console.WriteLine(p.name);
        }

        // Adds a player object to a game object
        public static Game operator +(Game game, Player player) {
            game.players.Add(player);
            return game;
        }

        // Removes a player object to a game object
        public static Game operator -(Game game, Player player) {
            game.players.Remove(player);
            return game;
        }
    }
}
