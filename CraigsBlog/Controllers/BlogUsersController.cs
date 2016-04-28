using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CraigsBlog.Models;

namespace CraigsBlog.Controllers
{
    public class BlogUsersController : Controller
    {
        //
        // GET: /BlogUsers/
        public ActionResult Index()
        {
            using (CraigsDB db = new CraigsDB())
            {
                return View(db.craigsUsers.ToList());  //to see a list of table contents
            }
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Registration(Users newAccount) {

            if (ModelState.IsValid)
            {
                using (CraigsDB db = new CraigsDB())
                {
                    db.craigsUsers.Add(newAccount);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = newAccount.Name + "'s account has been registered!";
            }
            else
            {
                ModelState.AddModelError("", "Please try entering your details again");
            }
            return View();

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users registeredUser)
        {
            try { 
            using (CraigsDB db = new CraigsDB())
            {
                var usr = db.craigsUsers.Single(u => u.Email == registeredUser.Email && u.Password == registeredUser.Password); //only if the user email and password are true then it is not null and a session can be created.
                
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["Email"] = usr.Email.ToString();
                    Session["Name"] = usr.Name.ToString();

                    if (Session["Email"].ToString() == "admin@admin.com") {
                        return RedirectToAction( "Index", "BlogUsers");
                    }
                    else {
                        return RedirectToAction("MembersPage", "BlogUsers");
                    }
                    
                    
                }
            }
            
         }
                    catch (Exception) // taken from http://www.codeproject.com/Articles/850062/Exception-handling-in-ASP-NET-MVC-methods-explaine
                {
                    ModelState.AddModelError("", "Login attempt has been unsuccessful.  Please try again.");
                    return View();
                }


            }
            
        

        public ActionResult Logout()
        {
            Session["Id"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult MembersPage()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
	}
}