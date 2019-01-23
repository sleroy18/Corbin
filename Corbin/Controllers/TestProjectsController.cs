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
    public class TestProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TestProjects
        public ActionResult Index()
        {
            var testProjects = db.TestProjects.Include(t => t.User);
            return View(testProjects.ToList());
        }

        // GET: TestProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestProject testProject = db.TestProjects.Find(id);
            if (testProject == null)
            {
                return HttpNotFound();
            }
            return View(testProject);
        }

        // GET: TestProjects/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: TestProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,EntryDate,LastUpdated,ApplicationUserId")] TestProject testProject)
        {
            if (ModelState.IsValid)
            {
                db.TestProjects.Add(testProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", testProject.ApplicationUserId);
            return View(testProject);
        }

        // GET: TestProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestProject testProject = db.TestProjects.Find(id);
            if (testProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", testProject.ApplicationUserId);
            return View(testProject);
        }

        // POST: TestProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,EntryDate,LastUpdated,ApplicationUserId")] TestProject testProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", testProject.ApplicationUserId);
            return View(testProject);
        }

        // GET: TestProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestProject testProject = db.TestProjects.Find(id);
            if (testProject == null)
            {
                return HttpNotFound();
            }
            return View(testProject);
        }

        // POST: TestProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestProject testProject = db.TestProjects.Find(id);
            db.TestProjects.Remove(testProject);
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
