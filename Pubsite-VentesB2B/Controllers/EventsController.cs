using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using PagedList.Mvc;
using Pubsite_VentesB2B.Models;

namespace Pubsite_VentesB2B.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Events
        public ActionResult Index(int? Page)
        {
            var events = db.Events.Include(e => e.Address).Include(e => e.ContentDetail).ToList().ToPagedList(Page ?? 1, 10);
            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
                events.ContentDetail.CreatedDate = DateTime.Now;
                events.ContentDetail.UpdatedDate = DateTime.Now;
                if (events.ContentDetail.Upload.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(events.ContentDetail.Upload.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads/Events/Images"), fileName);
                    events.ContentDetail.Upload.SaveAs(path);
                    events.ContentDetail.Image = "Uploads/Events/Images/" + fileName;
                }
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                events.ContentDetail.CreatedDate = DateTime.Now;
                events.ContentDetail.UpdatedDate = DateTime.Now;
                events.ContentDetail.CreatedById = user.Id;
                events.ContentDetail.UpdatedById = user.Id;
                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event events)
        {
            if (ModelState.IsValid)
            {
                if (events.ContentDetail.Upload != null && events.ContentDetail.Upload.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(events.ContentDetail.Upload.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads/News/Images"), fileName);
                    events.ContentDetail.Upload.SaveAs(path);
                    events.ContentDetail.Image = "Uploads/News/Images/" + fileName;
                }
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                events.ContentDetail.UpdatedDate = DateTime.Now;
                events.ContentDetail.UpdatedById = user.Id;
                db.Entry(events).State = EntityState.Modified;
                db.Entry(events.ContentDetail).State = EntityState.Modified;
                db.Entry(events.Address).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(events);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthFilter(Roles = "AppAdmin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event events = db.Events.Find(id);
            db.Events.Remove(events);
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
