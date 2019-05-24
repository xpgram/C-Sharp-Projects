using EFCodeFirstDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            // For testing purposes...
            var studentList = new List<string>();

            using (var context = new MyContext()) {

                // Create and save a new Student(s)

                var student = new Student {
                    FirstMidName = "Mark",
                    LastName = "Upston",
                    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                    // Why on earth are we parsing a string we created?
                };

                context.Students.Add(student);

                student = new Student {
                    FirstMidName = "Alain",
                    LastName = "Bomber",
                    EnrollmentDate = DateTime.Today
                };

                context.Students.Add(student);
                context.SaveChanges();

                // Display them now

                var students = (from s in context.Students
                                orderby s.FirstMidName
                                select s).ToList<Student>();

                foreach (var s in students) {
                    string name = s.FirstMidName + " " + s.LastName;
                    studentList.Add(String.Format("ID: {0}, Name: {1}", s.ID, name));
                }
            }

            return View(studentList);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}