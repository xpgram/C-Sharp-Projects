using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagementSystem.Models {
    public class Student {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student() { }

        public Student(int id, string fname, string lname) {
            this.ID = id;
            this.FirstName = fname;
            this.LastName = lname;
        }
    }
}