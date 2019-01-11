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
    [Authorize]
    public class ProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Projects
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.User).ToList();
            var projectVMList = AutoMapper.Mapper.Map<List<Project>, List<ProjectViewModel>>(projects);
            return View(projectVMList);
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectDetailsViewModel projectDetailsVM = AutoMapper.Mapper.Map<Project, ProjectDetailsViewModel>(db.Projects.Find(id));
            if (projectDetailsVM == null)
            {
                return HttpNotFound();
            }
            return View(projectDetailsVM);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            //ViewBag.ApplicationUserId = User.Identity.Name;

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,ImageFile,VideoFile")] ProjectCreateViewModel projectCreateVM)
        {
            try
            {
                //Project project Map
                db.Projects.Add(AutoMapper.Mapper.Map<ProjectCreateViewModel, Project>(projectCreateVM));

                //create this after project is created
                //return projectId with add(poject) and use as ProjectID
                //foreach(ImageViewModel imageVM in projectCreateVM.images)
                //{
                //    Image image = new Image()
                //    {
                //        IsMainImage = imageVM.image.IsMainImage,
                //        Location = imageVM.image.Location,
                //        Name = imageVM.image.Name,

                //    }
                //    //save image file here
                //    //add image to database
                //}

                //foreach (VideoViewModel videoVM in projectCreateVM.videos)
                //{
                //    Video video = new Video()
                //    {
                //        IsMainVideo = videoVM.video.IsMainVideo,
                //        Location = videoVM.video.Location,
                //        Name = videoVM.video.Name,

                //    }
                //    //save video file here
                //    //add video to database
                //}


                //continue here
                //db.Projects.Add(Project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                //ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", project.applicationUserId);
                return View(projectCreateVM);
            }          
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", project.ApplicationUserId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,EntryDate,LastUpdated,ApplicationUserId")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", project.ApplicationUserId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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
