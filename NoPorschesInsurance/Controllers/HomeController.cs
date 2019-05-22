using NoPorschesInsurance.Models;
using NoPorschesInsurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoPorschesInsurance.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            // If I choose to overload this method, I ~could~ build a blank Inquiry here to "fill in" the html with.
            // That may present its own problems, however... it wouldn't be worthless, though, probably.
            return View();
        }

        [HttpPost]
        public ActionResult SubmitCoverageApplication(Inquiry inquiry) {
            // Validate Object - Fail if invalid
            if (inquiry.Valid() == false)
                return RedirectToAction("Index");   // I don't pass inquiry back in, so we just erase everything they entered. Nice.
                                                    // With some HTML, I could actually prevent this. ...I might add this feature.

            // Calculate quote
            inquiry.Quote = calculateQuote(inquiry);

            //Post to DB
            using (var db = new NoPorscheInsuranceDBEntities()) {
                db.Inquiries.Add(inquiry);
                db.SaveChanges();
            }

            // Return success screen
            var inquiryVM = new InquiryVM(inquiry);
            return RedirectToAction("Quote", inquiryVM);
        }

        public ActionResult Quote(InquiryVM inquiryVM) {

            return View(inquiryVM);
        }



        private static decimal calculateQuote(Inquiry inquiry) {
            // Start with base of %50/month
            decimal quote = 50m;

            // Add 100 for <18 year olds
            if ((DateTime.Now - inquiry.DateOfBirth).Ticks < DateTime.MinValue.AddYears(18).Ticks)
                quote += 100m;
            // Add 25 for <25 year olds
            else if ((DateTime.Now - inquiry.DateOfBirth).Ticks < DateTime.MinValue.AddYears(25).Ticks)
                quote += 25m;
            // Add 25 for >100 year olds
            else if ((DateTime.Now - inquiry.DateOfBirth).Ticks > DateTime.MinValue.AddYears(100).Ticks)
                quote += 25m;

            // Add 25 for old car <2000
            if (inquiry.CarYear < 2000)
                quote += 25m;
            // Add 25 for new car >2015
            if (inquiry.CarYear > 2015)
                quote += 25m;

            // Surcharge for Porsches
            if (inquiry.CarMake.ToLower() == "porsche") {
                quote += 25m;
                if (inquiry.CarModel.ToLower() == "911 carrera")
                    quote += 25m;
            }

            // Add 10 for every speeding ticket
            quote += (decimal)(10 * inquiry.NumSpeedingTickets);

            // Raise by 25% if applicant been that DUI kind of naughty
            quote *= (inquiry.HadDUI) ? 1.25m : 1m;

            // Raise by 50% if applicant is insecure
            quote *= (inquiry.CoverageType == Inquiry.Coverage.Full.ToString()) ? 1.50m : 1m;

            return quote;
        }
    }
}