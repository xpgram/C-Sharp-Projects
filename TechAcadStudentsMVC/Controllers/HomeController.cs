using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechAcadStudentsMVC.Models;

namespace TechAcadStudentsMVC.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Contact The Boys - The Teach Acadami";

            return View();
        }

        public ActionResult Instructor(int id) {
            ViewBag.Id = id;

            var dayTimeInstructor = new Instructor(id, "Big", "Boi");

            return View(dayTimeInstructor);
        }

        public ActionResult Instructors() {
            var instructors = new List<Instructor> {
                new Instructor(1, "Rick", "Sanchez"),
                new Instructor(2, "Dirty", "Dan"),
                new Instructor(3, "Blueberry", "Boi"),
                new Instructor(4, "Big", "Boi")
            };
            return View(instructors);
        }
    }
}