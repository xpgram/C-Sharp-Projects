using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoPorschesInsurance.Models {
    public partial class Inquiry {
        public bool Valid() {
            return (
                this.FirstName != null &&
                this.LastName != null &&
                this.EmailAddress != null &&
                this.DateOfBirth != DateTime.MinValue &&     // Confirm this is checking anything. DoB may be real, but all zeroes.
                this.CarYear != 0 &&
                this.CarMake != null &&
                this.CarModel != null);
        }
    }
}