using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BasicController : Controller
    {
        // GET: Basic
        
        public ActionResult Index()
        {
            //CastingModel model = new CastingModel();
            return View();
           
        }
    }
}