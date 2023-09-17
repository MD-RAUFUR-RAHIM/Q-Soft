using LogInForm.Models;
using LogInForm.Perams_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LogInForm.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult UserLogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogIn(LoginPerams model)
        {
            var dbContext = new CTSContext();
            if (ModelState.IsValid)
            {
                var user = dbContext.Users.FirstOrDefault(u => u.Email == model.Email || u.Password == model.Password);
                if (user != null)
                {
                    if(user.Email !=null && user.Email != model.Email)
                    {
                        ViewBag.Msg1 = "Invalid Email";
                        return View();
                    }
                    else if(user.Password !=null && user.Password!=model.Password) 
                    {
                        ViewBag.Msg2 = "Invalid Password";
                        return View();
                    }
                    else 
                    return RedirectToAction("Submit");
                }    
            }
            else
            { 
                return View();
            }
            return View();
        }
        public ActionResult Submit() {
            TempData["Msg"] = "Login Successfull";
            return RedirectToAction("Profile", "Home");
        }
    }
}