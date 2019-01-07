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
    public class RegisterEmailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterEmails
        public ActionResult Index()
        {
            return View(db.RegisterEmails.ToList());
        }

        // GET: RegisterEmails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterEmail registerEmail = db.RegisterEmails.Find(id);
            if (registerEmail == null)
            {
                return HttpNotFound();
            }
            return View(registerEmail);
        }

        // GET: RegisterEmails/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: RegisterEmails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,Email")] RegisterEmail registerEmail)
        {
            if (ModelState.IsValid)
            {
                db.RegisterEmails.Add(registerEmail);
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    AddErrors("Email is already registered");
                    return View(registerEmail);
                }
                return RedirectToAction("Index");
            }

            return View(registerEmail);
        }

        private void AddErrors(String result)
        {
            ModelState.AddModelError("", result);           
        }

        // GET: RegisterEmails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterEmail registerEmail = db.RegisterEmails.Find(id);
            if (registerEmail == null)
            {
                return HttpNotFound();
            }
            return View(registerEmail);
        }

        // POST: RegisterEmails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email")] RegisterEmail registerEmail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerEmail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerEmail);
        }

        // GET: RegisterEmails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterEmail registerEmail = db.RegisterEmails.Find(id);
            if (registerEmail == null)
            {
                return HttpNotFound();
            }
            return View(registerEmail);
        }

        // POST: RegisterEmails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterEmail registerEmail = db.RegisterEmails.Find(id);
            db.RegisterEmails.Remove(registerEmail);
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
