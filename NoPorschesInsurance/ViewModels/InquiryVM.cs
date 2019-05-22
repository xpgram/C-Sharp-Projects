using NoPorschesInsurance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoPorschesInsurance.ViewModels {
    public class InquiryVM {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CoverageType { get; set; }
        public decimal Quote { get; set; }

        public InquiryVM() { }
        public InquiryVM(Inquiry inquiry) {
            MapFromInquiry(inquiry);
        }

        public void MapFromInquiry(Inquiry inquiry) {
            this.FirstName = inquiry.FirstName;
            this.LastName = inquiry.LastName;
            this.EmailAddress = inquiry.EmailAddress;
            this.CoverageType = inquiry.CoverageType;
            this.Quote = (decimal)inquiry.Quote;        // What if this is null for some reason?
        }
    }
}