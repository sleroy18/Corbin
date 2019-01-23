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
    public class ProjectImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProjectImages
        public ActionResult Index()
        {
            var projectImages = db.ProjectImages.Include(p => p.Project);
            return View(projectImages.ToList());
        }

        // GET: ProjectImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectImage projectImage = db.ProjectImages.Find(id);
            if (projectImage == null)
            {
                return HttpNotFound();
            }
            return View(projectImage);
        }

        // GET: ProjectImages/Create
        public ActionResult Create()
        {
            //ViewBag.ProjectId = new SelectList(db.Proj, "Id", "Title");
            return View();
        }

        // POST: ProjectImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsMainImage,Description,imageStream,ProjectId")] ProjectImage projectImage)
        {
            if (ModelState.IsValid)
            {
                db.ProjectImages.Add(projectImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ProjectId = new SelectList(db.Proj, "Id", "Title", projectImage.ProjectId);
            return View(projectImage);
        }

        // GET: ProjectImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectImage projectImage = db.ProjectImages.Find(id);
            if (projectImage == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ProjectId = new SelectList(db.Proj, "Id", "Title", projectImage.ProjectId);
            return View(projectImage);
        }

        // POST: ProjectImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsMainImage,Description,imageStream,ProjectId")] ProjectImage projectImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ProjectId = new SelectList(db.Proj, "Id", "Title", projectImage.ProjectId);
            return View(projectImage);
        }

        // GET: ProjectImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectImage projectImage = db.ProjectImages.Find(id);
            if (projectImage == null)
            {
                return HttpNotFound();
            }
            return View(projectImage);
        }

        // POST: ProjectImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectImage projectImage = db.ProjectImages.Find(id);
            db.ProjectImages.Remove(projectImage);
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
