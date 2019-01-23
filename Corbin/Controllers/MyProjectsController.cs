using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Corbin.Models;
using Microsoft.AspNet.Identity;

namespace Corbin.Controllers
{
    [Authorize]
    public class MyProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyProjects
        public ActionResult Index()
        {
            var MyProjects = db.MyProjects.Include(p => p.User);
            List<ProjectViewModel> ProjectVMs = AutoMapper.Mapper.Map<List<MyProject>, List<ProjectViewModel>>(MyProjects.ToList());
            return View(ProjectVMs.ToList());
        }

        // GET: MyProjects/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyProject proj = db.MyProjects.Find(id);
            if (proj == null)
            {
                return HttpNotFound();
            }
            return View(proj);
        }

        // GET: MyProjects/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: MyProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description")] ProjectCreateViewModel projVM)
        {
            if (ModelState.IsValid)
            {
                MyProject proj = AutoMapper.Mapper.Map<ProjectCreateViewModel, MyProject>(projVM);
                proj.EntryDate = DateTime.Now;
                proj.LastUpdated = DateTime.Now;
                proj.ApplicationUserId = User.Identity.GetUserId();
                db.MyProjects.Add(proj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", projVM.ApplicationUserId);
            return View(projVM);
        }

        // GET: MyProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyProject proj = db.MyProjects.Find(id);
            if (proj == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", proj.ApplicationUserId);
            return View(proj);
        }

        // POST: MyProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,EntryDate,LastUpdated,ApplicationUserId")] MyProject proj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", proj.ApplicationUserId);
            return View(proj);
        }

        // GET: MyProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyProject proj = db.MyProjects.Find(id);
            if (proj == null)
            {
                return HttpNotFound();
            }
            return View(proj);
        }

        // POST: MyProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MyProject proj = db.MyProjects.Find(id);
            db.MyProjects.Remove(proj);
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
