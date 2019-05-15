using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private string _connectionString = @"Data Source=XPGWIN\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET: Student
        public ActionResult Index() {

            string queryString = "select * from Students";
            var students = new List<Student>();

            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int id;
                string fname, lname;
                while (reader.Read()) {
                    id = Convert.ToInt32(reader["Id"]);
                    fname = reader["FirstName"].ToString();
                    lname = reader["LastName"].ToString();
                    students.Add(new Student(id, fname, lname));
                }
                connection.Close();
            }

            return View(students);
        }

        // GET: Add Student Form
        public ActionResult Add() {
            return View();
        }

        // POST: Student
        [HttpPost]
        public ActionResult Add(Student student) {
            string queryString = @"insert into Students (FirstName, LastName) values (@FirstName, @LastName)";

            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);

                command.Parameters["@FirstName"].Value = student.FirstName;
                command.Parameters["@LastName"].Value = student.LastName;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) {
            string queryString = "select * from Students where id = @id";
            var student = new Student();

            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int);

                command.Parameters["@id"].Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    student.ID = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                }
                connection.Close();
            }
            return View(student);
        }

        public ActionResult Edit(int id) {
            string queryString = "select * from Students where id = @id";
            var student = new Student();

            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int);

                command.Parameters["@id"].Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    student.ID = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                }
                connection.Close();
            }
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student) {
            string queryString = @"update Students set FirstName = @FirstName, LastName = @LastName where Id = @ID";

            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@ID", SqlDbType.Int);
                command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                command.Parameters.Add("@LastName", SqlDbType.VarChar);

                command.Parameters["@ID"].Value = student.ID;
                command.Parameters["@FirstName"].Value = student.FirstName;
                command.Parameters["@LastName"].Value = student.LastName;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) {
            string queryString = "delete from Students where id = @id";

            using (var connection = new SqlConnection(_connectionString)) {
                var command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
            return RedirectToAction("Index");
        }
    }
}