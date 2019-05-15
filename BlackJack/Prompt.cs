using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    static class Prompt {

        public static string GetString(string message) {
            Common.typedPrintln(message);
            Console.Write("> ");
            return Console.ReadLine();
        }

        public static int GetInt(string message) {
            int n;
            string s;
            bool pass = false;

            do {
                s = GetString(message);
                if (Int32.TryParse(s, out n))
                    pass = true;
                else
                    TryAgainMessage();
            } while (!pass);

            return n;
        }

        public static double GetDouble(string message) {
            double d;
            string s;
            bool pass = false;

            do {
                s = GetString(message);
                if (Double.TryParse(s, out d))
                    pass = true;
                else
                    TryAgainMessage();
            } while (!pass);

            return d;
        }

        public static bool GetBool(string message) {
            bool? b = null;
            string s;
            bool pass = false;

            do {
                s = GetString(message).ToLower();
                if (s == "y" || s == "yes")
                    b = true;
                else if (s == "n" || s == "no")
                    b = false;
                else
                    TryAgainMessage();
            } while (b == null);

            return (bool)b;
        }

        public static void Wait() {
            Console.ReadLine();
        }

        static void TryAgainMessage() {
            Common.typedPrintln("Don't be funny.");
        }
    }
}
