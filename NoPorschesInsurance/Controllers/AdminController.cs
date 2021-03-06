﻿using NoPorschesInsurance.Models;
using NoPorschesInsurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoPorschesInsurance.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var inquiryVMs = new List<InquiryVM>();
            using (var db = new NoPorscheInsuranceDBEntities()) {
                foreach (Inquiry i in db.Inquiries) {
                    var iVM = new InquiryVM(i);
                    inquiryVMs.Add(iVM);
                }
            }

            return View(inquiryVMs);
        }

        public ActionResult Delete(int id) {
            using (var db = new NoPorscheInsuranceDBEntities()) {
                db.Inquiries.Remove( db.Inquiries.Find(id) );
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}