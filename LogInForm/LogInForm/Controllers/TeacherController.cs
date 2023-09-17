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
        // GET: Teacher
        [HttpPost]
        public ActionResult Teacher(TeacherDTO teacher)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else
            {
             ViewBag.ErrorMessage = "The password must contain one special character, one digit, one lowercase and one uppercase and length should be at most 8";
            
            return View(teacher); 
            }
            
        }
        
        public ActionResult Teacher()
        {

            return View();
        }

        public ActionResult Success(TeacherDTO obj)
          {
              var config = new MapperConfiguration(cfg => {

                  cfg.CreateMap<TeacherDTO, Teacher>();
                  cfg.CreateMap<Teacher, TeacherDTO>();

              });
              var mapper = config.CreateMapper();
              var teacher = mapper.Map<Teacher>(obj);

              using (var db = new CTSContext())
              {
                  db.Teachers.Add(teacher);
                  db.SaveChanges();
              }
              return View();
          }

    }
}