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
    public class OurModelController : Controller
    {
        private MonoDbContext db = new MonoDbContext();

        // GET: Admin/OurModel
        public ActionResult Index()
        {
            var ourModels = db.OurModels.Include(o => o.ModelCategory);
            return View(ourModels.ToList());
        }

        // GET: Admin/OurModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurModel ourModel = db.OurModels.Find(id);
            if (ourModel == null)
            {
                return HttpNotFound();
            }
            return View(ourModel);
        }

        // GET: Admin/OurModel/Create
        public ActionResult Create()
        {
            ViewBag.ModelCategoryId = new SelectList(db.ModelCategories, "Id", "Name");
            return View();
        }

        // POST: Admin/OurModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Details,Profession,Photo,HoverPhoto,Facebook,Twitter,Instagram,Youtube,TopModel,ModelCategoryId")] OurModel ourModel)
        {
            if (ModelState.IsValid)
            {
                db.OurModels.Add(ourModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelCategoryId = new SelectList(db.ModelCategories, "Id", "Name", ourModel.ModelCategoryId);
            return View(ourModel);
        }

        // GET: Admin/OurModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurModel ourModel = db.OurModels.Find(id);
            if (ourModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelCategoryId = new SelectList(db.ModelCategories, "Id", "Name", ourModel.ModelCategoryId);
            return View(ourModel);
        }

        // POST: Admin/OurModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Details,Profession,Photo,HoverPhoto,Facebook,Twitter,Instagram,Youtube,TopModel,ModelCategoryId")] OurModel ourModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ourModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelCategoryId = new SelectList(db.ModelCategories, "Id", "Name", ourModel.ModelCategoryId);
            return View(ourModel);
        }

        // GET: Admin/OurModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OurModel ourModel = db.OurModels.Find(id);
            if (ourModel == null)
            {
                return HttpNotFound();
            }
            return View(ourModel);
        }

        // POST: Admin/OurModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OurModel ourModel = db.OurModels.Find(id);
            db.OurModels.Remove(ourModel);
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
