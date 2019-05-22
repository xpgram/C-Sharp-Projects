using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsletterAppMVC.Controllers {
    public class HomeController : Controller {

        //private readonly string connectionString = @"Data Source=XPGWIN\SQLEXPRESS;Initial Catalog=NewsletterDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // ^This is unnecessary, I'm just keeping it for posterity.

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress, string creditCardNumber) {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
                return View("~/Views/Shared/Error.cshtml");
            
            // Command we want to send
            //string queryString = @"insert into SignUps(FirstName, LastName, EmailAddress) values " +
            //    "(@FirstName, @LastName, @EmailAddress)";

            //// Wrap memory-use contents in using statement
            //using (var connection = new SqlConnection(connectionString)) {
            //    // Build SqlCommand interfacer to help stave off nasty SQL injection attacks (I assume it sanitizes things for us)
            //    var command = new SqlCommand(queryString, connection);

            //    // Add parameters to list (like declaring)
            //    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
            //    command.Parameters.Add("@LastName", SqlDbType.VarChar);
            //    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);

            //    // Add values to parameters (like initializing)
            //    command.Parameters["@FirstName"].Value = firstName;
            //    command.Parameters["@LastName"].Value = lastName;
            //    command.Parameters["@EmailAddress"].Value = emailAddress;

            //    // Open, post, and close
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}

            // Use entity framework instead
            using (var db = new NewsletterDBEntities()) {
                var signup = new SignUp();
                signup.FirstName = firstName;
                signup.LastName = lastName;
                signup.EmailAddress = emailAddress;
                signup.CreditCardNumber = creditCardNumber; // I don't know if this is even doing anything anymore.
                                                            // EF does not have this as a property because I deleted it once,
                                                            // and I cannot get it to accept it as a thing again, so... ?
                                                            // The app works, though.

                db.SignUps.Add(signup);
                db.SaveChanges();
            }

                return View("Success");
        }
    }
}