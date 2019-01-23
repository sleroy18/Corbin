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
    public class ProjectVideosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProjectVideos
        public ActionResult Index()
        {
            var projectVideos = db.ProjectVideos.Include(p => p.Project);
            return View(projectVideos.ToList());
        }

        // GET: ProjectVideos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectVideo projectVideo = db.ProjectVideos.Find(id);
            if (projectVideo == null)
            {
                return HttpNotFound();
            }
            return View(projectVideo);
        }

        // GET: ProjectVideos/Create
        public ActionResult Create()
        {
            //ViewBag.ProjectId = new SelectList(db.Proj, "Id", "Title");
            return View();
        }

        // POST: ProjectVideos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsMainVideo,Name,Description,URL,ProjectId")] ProjectVideo projectVideo)
        {
            if (ModelState.IsValid)
            {
                db.ProjectVideos.Add(projectVideo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ProjectId = new SelectList(db.Proj, "Id", "Title", projectVideo.ProjectId);
            return View(projectVideo);
        }

        // GET: ProjectVideos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectVideo projectVideo = db.ProjectVideos.Find(id);
            if (projectVideo == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ProjectId = new SelectList(db.Proj, "Id", "Title", projectVideo.ProjectId);
            return View(projectVideo);
        }

        // POST: ProjectVideos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsMainVideo,Name,Description,URL,ProjectId")] ProjectVideo projectVideo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectVideo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ProjectId = new SelectList(db.Proj, "Id", "Title", projectVideo.ProjectId);
            return View(projectVideo);
        }

        // GET: ProjectVideos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectVideo projectVideo = db.ProjectVideos.Find(id);
            if (projectVideo == null)
            {
                return HttpNotFound();
            }
            return View(projectVideo);
        }

        // POST: ProjectVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectVideo projectVideo = db.ProjectVideos.Find(id);
            db.ProjectVideos.Remove(projectVideo);
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
