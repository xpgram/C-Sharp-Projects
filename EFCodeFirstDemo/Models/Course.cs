using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFCodeFirstDemo.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [ConcurrencyCheck]
        [MaxLength(50)]
        public string Title { get; set; }
        public int Credits { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}