using LogInForm.Models;
using LogInForm.Perams_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogInForm.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Student()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Student(StudentDTO  s)
        {
            CTSContext db = new CTSContext();
            Teacher teacher = new Teacher();

            
            int? teacherId = (int)Session["T_Id"];
            int? user2 = (int)Session["Admin_Id"];
            if(user2!=null && teacherId != null)
            {
                LogInForm.Models.Student StudentDB = new LogInForm.Models.Student();
                StudentDB.Name = s.Name;
                StudentDB.phone = s.phone;
                StudentDB.username = s.username;
                StudentDB.password = s.password;
                StudentDB.Gender = s.Gender;
                StudentDB.A_Id = (int)user2;
                StudentDB.T_Id = (int)teacherId;
                StudentDB.Email = s.Email;
                db.Students.Add(StudentDB);
                db.SaveChanges();
                RedirectToAction("Index", "Home");
            }
            else if (teacherId!= null )
            {
                int? user = (int)Session["A_Id"];
                if (user != null)
                {
                    //int id = user.Admin_Id;
                    LogInForm.Models.Student StudentDB = new LogInForm.Models.Student();
                    StudentDB.Name = s.Name;
                    StudentDB.phone = s.phone;
                    StudentDB.username = s.username;
                    StudentDB.password = s.password;
                    StudentDB.Gender = s.Gender;
                    StudentDB.A_Id = (int)user;
                    StudentDB.T_Id = (int)teacherId;
                    StudentDB.Email = s.Email;
                    db.Students.Add(StudentDB);
                    db.SaveChanges();
                    //return View();
                    RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            //else {
            //    RedirectToAction("Index", "Home");
            //}
            return View();
           
        }
        public ActionResult StudentList()

        {
            CTSContext db = new CTSContext();
            List<Student> student = db.Students.ToList();
            return View(student);
        }
        

    }
}