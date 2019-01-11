using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Corbin.Models;

namespace Corbin.Controllers
{
    public class test2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: test2
        public ActionResult Index()
        {
            var test2 = db.test2.Include(t => t.Test);
            return View(test2.ToList());
        }

        // GET: test2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test2 test2 = db.test2.Find(id);
            if (test2 == null)
            {
                return HttpNotFound();
            }
            return View(test2);
        }

        // GET: test2/Create
        public ActionResult Create()
        {
            ViewBag.TestId = new SelectList(db.tests, "Id", "test1");
            return View();
        }

        // POST: test2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Test2,TestId")] test2 test2)
        {
            if (ModelState.IsValid)
            {
                db.test2.Add(test2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TestId = new SelectList(db.tests, "Id", "test1", test2.TestId);
            return View(test2);
        }

        // GET: test2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test2 test2 = db.test2.Find(id);
            if (test2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.TestId = new SelectList(db.tests, "Id", "test1", test2.TestId);
            return View(test2);
        }

        // POST: test2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Test2,TestId")] test2 test2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(test2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TestId = new SelectList(db.tests, "Id", "test1", test2.TestId);
            return View(test2);
        }

        // GET: test2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            test2 test2 = db.test2.Find(id);
            if (test2 == null)
            {
                return HttpNotFound();
            }
            return View(test2);
        }

        // POST: test2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            test2 test2 = db.test2.Find(id);
            db.test2.Remove(test2);
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
