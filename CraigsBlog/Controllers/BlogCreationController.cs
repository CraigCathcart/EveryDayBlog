using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CraigsBlog.Models;

namespace CraigsBlog.Controllers
{
    public class BlogCreationController : Controller
    {
        //
        // GET: /BlogCreation/
        public ActionResult Index()
        {
            using (CraigsDB db = new CraigsDB())
            {
                return View(db.craigsBlogs.ToList());
            }
           
        }
        
        [HttpGet]
        public ActionResult CreateBlog()
        {
            if (Session["Id"] != null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("Login", "BlogUsers");
            }
        }

        [HttpPost]
        public ActionResult CreateBlog (Blogs newBlog) {
            
            using (CraigsDB db = new CraigsDB()) {
                db.craigsBlogs.Add(newBlog);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.Message = "Your blog entry has been created.";
            return View();
        }
            
        

        }
	}
