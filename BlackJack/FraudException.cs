using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack {
    class FraudException : Exception {
        public FraudException() : base() { }
        public FraudException(string msg) : base(msg) { }
        // What if I didn't have these?
    }
}
