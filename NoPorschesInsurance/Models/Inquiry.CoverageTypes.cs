using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoPorschesInsurance.Models {
    public partial class Inquiry {
        public enum Coverage {
            Full,
            Liability
        }

        // TODO I may actually want to move this to the standard model. The above enum, too.
        public static readonly Dictionary<Coverage, string> CoverageLabels = new Dictionary<Coverage, string>() {
            { Coverage.Full, "Full Coverage" },
            { Coverage.Liability, "Liability" }
        };
    }
}