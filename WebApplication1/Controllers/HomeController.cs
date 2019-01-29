using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        MonoDbContext db = new MonoDbContext();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            return View();
        }

       

        public ActionResult Blog()
        {

            return View(db.Blogs.ToList());
        }
        public ActionResult Models()
        {
            return View();
        }

        public ActionResult Casting()
        {
            var model = db.OurModels.Take(4).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Casting(CastingModel casting)
        {
            db.CastingModels.Add(casting);
            db.SaveChanges();

            return RedirectToAction("Casting");
        }

        public ActionResult Contact()
        {
            var model = db.ProjectModels.FirstOrDefault();
            return View(model);
        }

        public ActionResult Project()
        {
            return View(db.ProjectModels.ToList());
        }

        public ActionResult BlogDetails()
        {
            return View();
        }
        
    }
}