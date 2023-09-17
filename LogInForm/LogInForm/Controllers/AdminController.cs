using AutoMapper;
using LogInForm.Models;
using LogInForm.Perams_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace LogInForm.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(AdminDTO ad)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else
            {
                ViewBag.ErrorMessage = "The password must contain one special character, one digit, one lowercase and one uppercase and length should be at most 8";

                return View(ad);
            }
            
        }
        public ActionResult SuccessAdmin(AdminDTO ad)
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<AdminDTO, Admin>();
                cfg.CreateMap<Admin, AdminDTO>();

            });
            var mapper = config.CreateMapper();
            var admin = mapper.Map<Admin>(ad);
            using (var db = new CTSContext())
            {
                db.Admins.Add(admin);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult AdminLogIn() {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogIn(AdminLogInDTO admin)
        {
            var dbContext = new CTSContext();
            if (ModelState.IsValid)
            {
                var user = dbContext.Admins.FirstOrDefault(u => u.Email == admin.Email || u.password == admin.Password);
                if (user != null)
                {
                    if (user.Email != null && user.Email != admin.Email)
                    {
                        ViewBag.Msg1 = "Invalid Email";
                        //return View();
                    }
                    else if (user.password != null && user.password != admin.Password)
                    {
                        ViewBag.Msg2 = "Invalid Password";
                       // return View();
                    }
                    else
                    if (ViewBag.Msg1 != "Invalid Email" && ViewBag.Msg2 != "Invalid Password")
                    {
                        Session["Admin_Id"] = user.Id;
                        return RedirectToAction("AdminProfile");
                    }
                   
                }
            }
                return View();
        }
        public ActionResult AdminProfile() {
            var dbContext = new CTSContext();
            int Admin_Id = (int)Session["Admin_Id"];
            var user = dbContext.Admins.Find(Admin_Id);

            if (user != null)
            {
                return View();
            }
            return RedirectToAction("AdminLogIn");
        }
    }
    
}