using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index() {
            var signupVMs = new List<SignUpVM>();

            // Generate a list of all signups
            using (var db = new NewsletterDBEntities()) {

                // Alt filter method (using "Link"(?)):
                //var signups = (from s in db.SignUps
                //               where s.Removed == null
                //               select s).ToList();

                foreach (var signup in db.SignUps.Where(x => x.Removed == null).ToList()) {
                    var signupVM = new SignUpVM();
                    signupVM.Id = signup.Id;
                    signupVM.FirstName = signup.FirstName;
                    signupVM.LastName = signup.LastName;
                    signupVM.EmailAddress = signup.EmailAddress;
                    signupVMs.Add(signupVM);
                }
            }

            // Submit them with the view
            return View(signupVMs);
        }

        public ActionResult Delete(int Id) {
            using (var db = new NewsletterDBEntities()) {
                var signup = db.SignUps.Find(Id);

                signup.Removed = DateTime.Now;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}