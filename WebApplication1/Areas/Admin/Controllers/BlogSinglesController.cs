using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class BlogSinglesController : Controller
    {
        private MonoDbContext db = new MonoDbContext();

        // GET: Admin/BlogSingles
        public ActionResult Index()
        {
            return View(db.BlogModels.ToList());
        }

        // GET: Admin/BlogSingles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogSingle blogSingle = db.BlogModels.Find(id);
            if (blogSingle == null)
            {
                return HttpNotFound();
            }
            return View(blogSingle);
        }

        // GET: Admin/BlogSingles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogSingles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body,Date,ByPerson,Note,ByPersonNote")] BlogSingle blogSingle)
        {
            if (ModelState.IsValid)
            {
                db.BlogModels.Add(blogSingle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogSingle);
        }

        // GET: Admin/BlogSingles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogSingle blogSingle = db.BlogModels.Find(id);
            if (blogSingle == null)
            {
                return HttpNotFound();
            }
            return View(blogSingle);
        }

        // POST: Admin/BlogSingles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,Date,ByPerson,Note,ByPersonNote")] BlogSingle blogSingle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogSingle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogSingle);
        }

        // GET: Admin/BlogSingles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogSingle blogSingle = db.BlogModels.Find(id);
            if (blogSingle == null)
            {
                return HttpNotFound();
            }
            return View(blogSingle);
        }

        // POST: Admin/BlogSingles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogSingle blogSingle = db.BlogModels.Find(id);
            db.BlogModels.Remove(blogSingle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
