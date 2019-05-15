using System;

namespace BlackJack {
    static class Common {

        public static void Linebreak() {
            Console.WriteLine();
        }

        public static void Wait(int millis) {
            System.Threading.Thread.Sleep(millis);
        }

        public static void WaitEllipses(string message, int millis) {
            int interval = millis / 4;

            Common.typedPrint(message);
            for (int i = 0; i < 3; i++) {
                Wait(interval);
                Console.Write(" .");
            }
            Wait(interval);

            Console.WriteLine();    // Gotta get dat newline
        }

        public static void typedPrint(string message) {
            typedPrint(25, message);
        }

        public static void typedPrintln(string message) {
            typedPrintln(25, message);
        }

        public static void typedPrint(int millis, string message) {
            for (int i = 0; i < message.Length; i++) {
                if (message[i] == '*')
                    Wait(millis * 15);
                else {
                    Console.Write(message[i]);
                    Wait(millis);
                }
            }
        }

        public static void typedPrintln(int millis, string message) {
            typedPrint(millis, message);
            Console.WriteLine();
        }
    }
}
