using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CraigsBlog.Models;

namespace CraigsBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult publicBlogsCount()
        {
            using (CraigsDB db = new CraigsDB())
            {
                var blogtotal = (db.craigsBlogs.Where(p => (p.IsPublic == true)).Count());// checks database, counts public blogs and returns a number - puts it into variable blogtotal
                return Json(blogtotal, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GrabNewestPost()
        {
            using (CraigsDB db = new CraigsDB())
            {
                Blogs post = new Blogs();
                post = db.craigsBlogs.Where(p => (p.IsPublic == true))
                                                            .OrderByDescending(p => p.Id)
                                                            .FirstOrDefault();

                return Json(post, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetNextPost(int Id)
        {
            using (CraigsDB db = new CraigsDB())
            {
                Blogs post = new Blogs();
                post = db.craigsBlogs.Where(p => (p.IsPublic == true) && (p.Id > Id))
                                      .OrderBy(p => p.Id)
                                      .FirstOrDefault();

                return Json(post, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetPreviousPost(int Id)
        {
            using (CraigsDB db = new CraigsDB())
            {
                Blogs post = new Blogs();
                post = db.craigsBlogs.Where(p => (p.IsPublic == true) && (p.Id == (Id -1)))
                              .OrderBy(p => p.Id)
                              .FirstOrDefault();

                return Json(post, JsonRequestBehavior.AllowGet);
            }
        }

        }
    }
