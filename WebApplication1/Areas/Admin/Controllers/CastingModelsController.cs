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
    public class CastingModelsController : Controller
    {
        private MonoDbContext db = new MonoDbContext();

        // GET: Admin/CastingModels
        public ActionResult Index()
        {
            return View(db.CastingModels.ToList());
        }

        // GET: Admin/CastingModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastingModel castingModel = db.CastingModels.Find(id);
            if (castingModel == null)
            {
                return HttpNotFound();
            }
            return View(castingModel);
        }

        // GET: Admin/CastingModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CastingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Resume,Title,SubTitle")] CastingModel castingModel)
        {
            if (ModelState.IsValid)
            {
                db.CastingModels.Add(castingModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(castingModel);
        }

        // GET: Admin/CastingModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastingModel castingModel = db.CastingModels.Find(id);
            if (castingModel == null)
            {
                return HttpNotFound();
            }
            return View(castingModel);
        }

        // POST: Admin/CastingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Resume,Title,SubTitle")] CastingModel castingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castingModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(castingModel);
        }

        // GET: Admin/CastingModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastingModel castingModel = db.CastingModels.Find(id);
            if (castingModel == null)
            {
                return HttpNotFound();
            }
            return View(castingModel);
        }

        // POST: Admin/CastingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CastingModel castingModel = db.CastingModels.Find(id);
            db.CastingModels.Remove(castingModel);
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
