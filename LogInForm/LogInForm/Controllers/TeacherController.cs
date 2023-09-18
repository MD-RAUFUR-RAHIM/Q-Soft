using AutoMapper;
using LogInForm.Models;
using LogInForm.Perams_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogInForm.Controllers
{
    public class TeacherController : Controller
    {

        
        [HttpPost]
        public ActionResult Teacher(TeacherDTO teacher)
        {
            CTSContext db = new CTSContext();
            int admidId = (int)Session["Admin_Id"];

            LogInForm.Models.Teacher TeacherDb = new LogInForm.Models.Teacher();
            TeacherDb.Name = teacher.Name;
            TeacherDb.phone = teacher.phone;
            TeacherDb.username = teacher.username;
            TeacherDb.password = teacher.password;
            TeacherDb.Gender = teacher.Gender;
            TeacherDb.Admin_Id = admidId;
            TeacherDb.Email = teacher.Email; 
            db.Teachers.Add(TeacherDb);
            db.SaveChanges();

            //return RedirectToAction("Index", "Home");

            return RedirectToAction("TeacherList");

            //else
            //{
            //    ViewBag.ErrorMessage = "The password must contain one special character, one digit, one lowercase and one uppercase and length should be at most 8";

            //    return View(teacher);
            //}

        }
        
        [HttpGet]
        public ActionResult Teacher()
        {

            return View();
        }

        //public ActionResult Success(TeacherDTO obj)
        //  {
        //      var config = new MapperConfiguration(cfg => {

        //          cfg.CreateMap<TeacherDTO, Teacher>();
        //          cfg.CreateMap<Teacher, TeacherDTO>();

        //      });
        //      var mapper = config.CreateMapper();
        //      var teacher = mapper.Map<Teacher>(obj);

        //      using (var db = new CTSContext())
        //      {

        //          db.Teachers.Add(teacher);
        //          db.SaveChanges();
        //      }
        //      return View();
        //  }
        public ActionResult TeacherList()

        {
            CTSContext db= new CTSContext();
            List<Teacher> teacher=db.Teachers.ToList();
            return View(teacher);
        }

        public ActionResult TeacherLogIn(TeacherLogInDTO t)
        {
            var dbContext = new CTSContext();
            if (ModelState.IsValid)
            {
                var user = dbContext.Teachers.FirstOrDefault(u => u.Email == t.Email || u.password == t.Password);
                if (user != null)
                {
                    if (user.Email != null && user.Email != t.Email)
                    {
                        ViewBag.Msg1 = "Invalid Email";
                        //return View();
                    }
                    else if (user.password != null && user.password != t.Password)
                    {
                        ViewBag.Msg2 = "Invalid Password";
                        // return View();
                    }
                    else
                    if (ViewBag.Msg1 != "Invalid Email" && ViewBag.Msg2 != "Invalid Password")
                    {
                        Session["T_Id"] = user.Id;
                        Session["A_Id"] = user.Admin_Id;
                        return RedirectToAction("TeacherProfile");
                    }

                }
            }
            return View();
        }
        public ActionResult TeacherProfile()
        {
            var dbContext = new CTSContext();
            int teacher_Id = (int)Session["T_Id"];
            var user = dbContext.Teachers.Find(teacher_Id);

            if (user != null)
            {
                return View();
            }
            return RedirectToAction("TeacherLogIn");
           
        }

    }
}