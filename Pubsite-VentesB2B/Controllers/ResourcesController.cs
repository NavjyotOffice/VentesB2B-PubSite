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
    public class ResourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Resources
        public ActionResult Index(int? Page, string searchText="")
        {
            searchText = searchText.Trim();
            var resources = db.Resources.Include(r => r.ContentDetail).Where(r => r.ContentDetail.Title.Contains(searchText)).ToList().ToPagedList(Page ?? 1, 10);
            return View(resources);
        }

        // GET: Resources/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // GET: Resources/Create
        public ActionResult Create()
        {
            ViewBag.ContentID = new SelectList(db.ContentDetails, "ContentID", "Title");
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resource resource)
        {
            if (ModelState.IsValid)
            {
                if (resource.ContentDetail.Upload != null && resource.ContentDetail.Upload.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(resource.ContentDetail.Upload.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads/Resourses/Images"), fileName);
                    resource.ContentDetail.Upload.SaveAs(path);
                    resource.ContentDetail.Image = "Uploads/Resourses/Images/" + fileName;
                }

                if (resource.Upload != null && resource.Upload.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(resource.ContentDetail.Upload.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads/Resourses/Resourse"), fileName);
                    resource.Upload.SaveAs(path);
                    resource.ResourceFile = "Uploads/Resourses/Resourse/" + fileName;
                }

                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                resource.ContentDetail.CreatedDate = DateTime.Now;
                resource.ContentDetail.UpdatedDate = DateTime.Now;
                resource.ContentDetail.CreatedById = user.Id;
                resource.ContentDetail.UpdatedById = user.Id;

                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContentID = new SelectList(db.ContentDetails, "ContentID", "Title", resource.ContentID);
            return View(resource);
        }

        // GET: Resources/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentID = new SelectList(db.ContentDetails, "ContentID", "Title", resource.ContentID);
            return View(resource);
        }

        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resource resource)
        {
            if (ModelState.IsValid)
            {
                if (resource.ContentDetail.Upload != null && resource.ContentDetail.Upload.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(resource.ContentDetail.Upload.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads/Resourses/Images"), fileName);
                    resource.ContentDetail.Upload.SaveAs(path);
                    resource.ContentDetail.Image = "Uploads/Resourses/Images/" + fileName;
                }

                if (resource.Upload != null && resource.Upload.ContentLength > 0)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(resource.Upload.FileName);
                    string path = Path.Combine(Server.MapPath("~/Uploads/Resourses/Resourse"), fileName);
                    resource.Upload.SaveAs(path);
                    resource.ResourceFile = "Uploads/Resourses/Resourse/" + fileName;
                }
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                resource.ContentDetail.UpdatedDate = DateTime.Now;
                resource.ContentDetail.UpdatedById = user.Id;
                db.Entry(resource).State = EntityState.Modified;
                db.Entry(resource.ContentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContentID = new SelectList(db.ContentDetails, "ContentID", "Title", resource.ContentID);
            return View(resource);
        }

        // GET: Resources/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthFilter(Roles = "AppAdmin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
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
