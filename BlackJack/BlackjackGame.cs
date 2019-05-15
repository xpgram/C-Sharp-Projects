using System;
using System.Data;
using System.Data.SqlClient;

namespace BlackJack {
    class BlackjackGame : Game, IWalkAway {
        public BlackjackDealer dealer;
        public int tableMinimum = 5;
        public int tableMaximum = 500;

        public override void init() {
            dealer = new BlackjackDealer();
        }

        public override void preRound() {
            // Confirm the player wants to play,
            // Confirm the player has enough to bet
            foreach (Player player in players) {
                if (player.funds >= tableMinimum)
                    player.playing = Prompt.GetBool("A round of blackjack? [y/n]");
                else {
                    player.playing = false;
                    Console.WriteLine("You do not have enough money to keep playing. Leave.");
                }
            }
        }

        public void newRound() {
            foreach (Player player in this.players)
                player.newRound();
            dealer.newRound();
            Console.Clear();
        }

        public override void round() {
            newRound();

            // Get bets from all players, deal them cards (secretly)
            foreach (Player player in this.players) {
                Console.Clear();
                try {
                    player.AskBet(5, 100);
                }
                catch (FraudException e) {
                    Common.typedPrintln("Security!** Get this idiot outta here!**");
                    UpdateDBWithException(e);
                    player.playing = false;
                    return; // Return from this early.
                }
                dealer.Deal(player, 2);
            }
            dealer.hand.AddRange(dealer.deck.Draw(2));

            Console.Clear();
            Console.WriteLine("Players: ");
            Console.WriteLine();
            showTable();
            Common.WaitEllipses(".", 4000);

            // Check dealer's hand for natural blackjack
            if (BlackjackRules.CheckBlackjack(dealer.hand)) {
                dealer.downCard = false;
                dealer.print();
                Console.WriteLine("Dealer has a natural blackjack! Any players who can't push lose their bets.");
                Common.Wait(2000);

                // Carry out with the losing of the bets
                foreach (Player player in players)
                    if (BlackjackRules.CheckBlackjack(player.Hand) == false)
                        player.bet = 0;
            }
            // Play as normally
            else {
                foreach (Player player in players) {
                    Console.Clear();
                    Common.WaitEllipses("Grabbing " + player.name, 2000);

                    if (BlackjackRules.CheckBlackjack(player.Hand) == true) {
                        player.won = true;
                        player.bet += player.bet * 3 / 2;   // Naturals pay 3 to 2, or 150%

                        Console.Clear();
                        player.print();
                        Console.Write("A natural blackjack! You win this round.");
                        Common.Wait(1000);
                    }
                    else {
                        // Allow the player to hit
                        while (player.stay == false && player.busted == false &&
                            BlackjackRules.CheckBlackjack(player.Hand) == false) {
                            Console.Clear();
                            dealer.print();
                            player.print();

                            if (Prompt.GetBool("Hit? [y/n]")) {
                                dealer.Deal(player);
                                if (BlackjackRules.GetHandValue(player.Hand) > 21)
                                    player.busted = true;
                            }
                            else
                                player.stay = true;
                        }
                        Console.Clear();
                        dealer.print();
                        player.print();
                        Common.WaitEllipses(".", 2000);
                    }
                }

                // The dealer reveals their down card
                Console.Clear();
                dealer.print();
                Common.Wait(1500);
                dealer.downCard = false;
                dealer.print();
                Common.Wait(1500);

                // The dealer plays
                while (BlackjackRules.GetHandValue(dealer.hand) < 17) {
                    dealer.hand.Add(dealer.deck.Draw());
                    dealer.print();
                    Common.Wait(1500);
                }

                // Results
                Common.Linebreak();
                showTable();
                Common.WaitEllipses(".", 4000);

                // Round logic
                int dealerValue = BlackjackRules.GetHandValue(dealer.hand);
                int playerValue;
                foreach (Player player in players) {
                    playerValue = BlackjackRules.GetHandValue(player.Hand);

                    // Winning: Bet is payed out
                    if (!player.busted &&
                        !player.won &&      // Disqualify them from bet-handling if they had a natural blackjack
                        playerValue > dealerValue) {
                        player.bet *= 2;
                    }
                    // Losing: Lose your bet
                    else if (player.busted ||
                        playerValue < dealerValue) {
                        player.bet = 0;
                    }
                    // Push: You keep your bet
                }
            }
        }

        public override void postRound() {
            // Display player winnings (their bet capitalized(?)), and add their bets to their total.
            Console.Clear();
            foreach (Player player in players) {
                Console.WriteLine(player.name + " <- $" + player.bet);
                player.ReturnBet();
            }
        }

        public void showTable() {
            dealer.print();
            foreach (Player player in this.players) {
                player.print();
            }
        }

        public override void listPlayers() {
            Common.Linebreak();
            Console.WriteLine("Blackjack Players:");
            base.listPlayers();
        }

        void IWalkAway.WalkAway(Player player) {
            Console.WriteLine("Ejecting " + player.name + " from the building . . .");
            players.Remove(player);
        }

        // Normally this would go in a logger class, I suppose.
        private void UpdateDBWithException(Exception ex) {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                Initial Catalog = BlackjackGame;
                                Integrated Security = True; Connect Timeout = 30;
                                Encrypt = False; TrustServerCertificate = False;
                                ApplicationIntent = ReadWrite;
                                MultiSubnetFailover = False";
            string queryString =
                @"INSERT INTO Exceptions (ExceptionType, ExceptionMessage, TimeStamp) VALUES " +
                    "(@ExceptionType, @ExceptionMessage, @TimeStamp)";
            using (var connection = new SqlConnection(connectionString)) {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ExceptionType", SqlDbType.VarChar);
                command.Parameters.Add("@ExceptionMessage", SqlDbType.VarChar);
                command.Parameters.Add("@TimeStamp", SqlDbType.DateTime);

                command.Parameters["@ExceptionType"].Value = ex.GetType().ToString();
                command.Parameters["@ExceptionMessage"].Value = ex.Message;
                command.Parameters["@TimeStamp"].Value = DateTime.Now;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
