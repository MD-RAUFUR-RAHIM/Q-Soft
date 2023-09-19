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
            CTSContext db = new CTSContext();

            var viewModel = new TeacherModel
            {
                TeacherId = db.Teachers.Select(t => t.Id).ToList()
            };

            var list = db.Teachers.Select(x=> new TeacherList()
            {
                Id= x.Id,
                Name = x.Name,  
            }).ToList();
           
            if(list!=null)
            {
                ViewBag.TeacherList = list;
            }

            return View();
           // return View();
        }
        [HttpPost]
        public ActionResult Student(StudentDTO  s)
        {
            CTSContext db = new CTSContext();
            TeacherList teacher = new TeacherList();
            int? teacherId = Session["T_Id"] as int?;
            int? user2 = Session["Admin_Id"] as int?;
            int? user = Session["A_Id"] as int?;

            if (user2!=null)
            {
                int selectedTeacherId = s.T_Id;
                //Session["T_Id"] = teacherId;
                LogInForm.Models.Student StudentDB = new LogInForm.Models.Student();
                StudentDB.Name = s.Name;
                StudentDB.phone = s.phone;
                StudentDB.username = s.username;
                StudentDB.password = s.password;
                StudentDB.Gender = s.Gender;
                StudentDB.A_Id = (int)user2;
                StudentDB.T_Id = selectedTeacherId;
                StudentDB.Email = s.Email;
                db.Students.Add(StudentDB);
                db.SaveChanges();
                 return RedirectToAction("Index", "Home");
            }
           
            else if (user!= null )
            {
                int selectedTeacherId = s.T_Id;

                if (selectedTeacherId != null && selectedTeacherId!=0)
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
                    return RedirectToAction("Index", "Home");
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