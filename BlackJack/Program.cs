using System;
using System.Collections.Generic;
using System.Data.SqlClient;

/* I've improved this thing by half-implementing new features and half-cleaning up the logic.
 * So. Yay.
 * It's half-impressive.
 */

namespace BlackJack {
    class TwentyOne {
        static void Main(string[] args) {

            Common.typedPrintln("Welcome to my house.**");
            string name = Prompt.GetString("Who are you?");

            // Admin feature - List all logged exceptions (which are probably problem patrons)
            if (name.ToLower() == "admin") {
                Console.Clear();
                List<ExceptionEntity> Exceptions = ReadExceptions();
                foreach (var e in Exceptions) {
                    Console.WriteLine(String.Format("{0} | {1} | {2} | {3}",
                        e.id, e.ExceptionType, e.ExceptionMessage, e.TimeStamp));
                }
                Console.Read();
                Common.typedPrintln("Thank you for your service.**");
                return; // Exit the prog early
            }

            // Lockout feature - prevent banned patrons from re-entering
            if (CheckDBForBannedPatron(name)) {
                Common.typedPrintln("Hey!* Get outta here, rat!***");
                return; // Exit the prog early
            }

            int money = Prompt.GetInt("How much money do you have?** just curious.");
            Prompt.GetString("And what's your social security number?** j*u*s*t* c*u*r*i*o*u*s.");
            Common.WaitEllipses("Inserting you into gambling", 2000);
            Console.Clear();

            Common.typedPrint("Hello there, chubby!** I've heard you have fresh money for me to take--*I mean,* " +
                "for you to play with.**\nWe're gonna have a lotta fun, boy!* Just you wait.");
            Common.Wait(2000);
            Console.Clear();

            // Init Game
            Player player = new Player(name, money);
            Game game = new BlackjackGame();
            game += player;
            player.playing = true;

            // Game Loop
            game.init();
            while (player.playing && player.funds > 0) {
                game.preRound();

                // It's either this or move preRound() after postRound(). Which is fine.
                // It creates a bug, though; you can start out with less than the table limit and get stuck in a betting loop.
                if (!player.playing)
                    continue;

                game.round();
                game.postRound();
            }

            Common.typedPrintln("Goodbye, young man.***");
        }

        private static List<ExceptionEntity> ReadExceptions() {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;
                                Initial Catalog = BlackjackGame;
                                Integrated Security = True; Connect Timeout = 30;
                                Encrypt = False; TrustServerCertificate = False;
                                ApplicationIntent = ReadWrite;
                                MultiSubnetFailover = False";
            string queryString = @"select Id, ExceptionType, ExceptionMessage, TimeStamp From Exceptions";

            var Exceptions = new List<ExceptionEntity>();

            using (var connection = new SqlConnection(connectionString)) {
                var cmd = new SqlCommand(queryString, connection);
                ExceptionEntity ex;

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    ex = new ExceptionEntity();
                    ex.id = Convert.ToInt32(reader["Id"]);
                    ex.ExceptionType = reader["ExceptionType"].ToString();
                    ex.ExceptionMessage = reader["ExceptionMessage"].ToString();
                    ex.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
                    Exceptions.Add(ex);
                }
                connection.Close();
            }

            return Exceptions;
        }

        private static bool CheckDBForBannedPatron(string name) {
            List<ExceptionEntity> exlist = ReadExceptions();
            for (int i = 0; i < exlist.Count; i++) {
                if (exlist[i].ExceptionMessage.Contains(name))
                    return true;
                    // This is not exactly fair. What if I name myself "the" or something?
            }
            return false;
        }
    }
}
