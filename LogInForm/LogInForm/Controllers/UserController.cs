
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
            var user = dbContext.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            if (ModelState.IsValid)
            {
                
                if (user != null) {
                    LogInForm.Models.Token TokenDb = new LogInForm.Models.Token();
                    TokenDb.tokenKey = Guid.NewGuid().ToString(); 
                    TokenDb.User_Id = user.Id;
                    TokenDb.CreatedAt = DateTime.Now;
                    TokenDb.ExpiredAt = null;
                    dbContext.Tokens.Add(TokenDb);
                    Session["Token_Id"] = user.Id;
                    dbContext.SaveChanges();
                }
               // var user = dbContext.Users.FirstOrDefault(u => u.Email == model.Email || u.Password == model.Password);
                //dbContext.
               /* if (user != null)
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
                }  */  
            }
            else
            { 
                return View();
            }

            var existingToken = dbContext.Tokens.FirstOrDefault(t => t.User_Id == user.Id);
            if (existingToken != null)
            {
                return RedirectToAction("Submit");
            }
            return View();
        }
        public ActionResult Submit() {
            TempData["Msg"] = "Login Successfull";
            return RedirectToAction("Profile", "Home");
        }
    }
}