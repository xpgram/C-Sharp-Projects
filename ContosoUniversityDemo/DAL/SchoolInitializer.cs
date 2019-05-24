using ContosoUniversityDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityDemo.DAL
{
    public class SchoolInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context) {
            var students = new List<Student> {
                new Student{FirstMidName="Squall", LastName="Leonheart", EnrollmentDate=DateTime.Parse("1999-09-01") },
                new Student{FirstMidName="Quistis", LastName="Trepe", EnrollmentDate=DateTime.Parse("1997-09-01") },
                new Student{FirstMidName="Selphie", LastName="Tilmitt", EnrollmentDate=DateTime.Parse("2000-09-01") },
                new Student{FirstMidName="Zell", LastName="Dincht", EnrollmentDate=DateTime.Parse("1999-09-01") },
                new Student{FirstMidName="Rinoa", LastName="Heartilly", EnrollmentDate=DateTime.Parse("2000-09-01") },
                new Student{FirstMidName="Irvine", LastName="Kinneas", EnrollmentDate=DateTime.Parse("2000-09-01") }
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var courses = new List<Course> {
                new Course{CourseID=2050, Title="Physical Training", Credits=2},
                new Course{CourseID=2061, Title="Gen. Combat Training", Credits=4},
                new Course{CourseID=4022, Title="GF Junctioning", Credits=4},
                new Course{CourseID=4041, Title="GF Summoning I", Credits=4},
                new Course{CourseID=4042, Title="GF Summoning II", Credits=4},
                new Course{CourseID=1045, Title="Algebra I", Credits=4},
                new Course{CourseID=3019, Title="Drawing Magic", Credits=2},
                new Course{CourseID=3091, Title="Attack Magic I", Credits=4},
                new Course{CourseID=3092, Title="Attack Magic II", Credits=4},
                new Course{CourseID=3071, Title="Indirect Magic I", Credits=4},
                new Course{CourseID=3072, Title="Indirect Magic II", Credits=4},
                new Course{CourseID=3081, Title="Restorative Magic I", Credits=4},
                new Course{CourseID=3082, Title="Restorative Magic II", Credits=4}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment> {
                new Enrollment{StudentID=1, CourseID=2050, Grade=Grade.A},
                new Enrollment{StudentID=1, CourseID=3091, Grade=Grade.B},
                new Enrollment{StudentID=1, CourseID=2061, Grade=Grade.A},
                new Enrollment{StudentID=2, CourseID=4022, Grade=Grade.A},
                new Enrollment{StudentID=2, CourseID=4041, Grade=Grade.A},
                new Enrollment{StudentID=2, CourseID=4042, Grade=Grade.A},
                new Enrollment{StudentID=3, CourseID=2050, Grade=Grade.B},
                new Enrollment{StudentID=4, CourseID=2050, Grade=Grade.A},
                new Enrollment{StudentID=4, CourseID=2061, Grade=Grade.B},
                new Enrollment{StudentID=4, CourseID=1045, Grade=Grade.C},
                new Enrollment{StudentID=5, CourseID=3071, Grade=Grade.A},
                new Enrollment{StudentID=5, CourseID=3081, Grade=Grade.B},
                new Enrollment{StudentID=6, CourseID=3072, Grade=Grade.B},
                new Enrollment{StudentID=6, CourseID=3092, Grade=Grade.B},
                new Enrollment{StudentID=6, CourseID=4042, Grade=Grade.C},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}