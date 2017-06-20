using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Coursaty.Models;

namespace Coursaty.Controllers
{
    public class LecturesCommentsController : Controller
    {
        private CoursatyEntities db = new CoursatyEntities();

        // GET: LecturesComments
        public ActionResult Index()
        {
            var lecturesComments = db.LecturesComments.Include(l => l.Lecture).Include(l => l.User);
            return View(lecturesComments.ToList());
        }

        // GET: LecturesComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesComment lecturesComment = db.LecturesComments.Find(id);
            if (lecturesComment == null)
            {
                return HttpNotFound();
            }
            return View(lecturesComment);
        }

        // GET: LecturesComments/Create
        public ActionResult Create()
        {
            ViewBag.lectureId = new SelectList(db.Lectures, "id", "name");
            ViewBag.userId = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: LecturesComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,currDate,comment,userId,lectureId,likes,dislikes")] LecturesComment lecturesComment)
        {
            if (ModelState.IsValid)
            {
                db.LecturesComments.Add(lecturesComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lectureId = new SelectList(db.Lectures, "id", "name", lecturesComment.lectureId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", lecturesComment.userId);
            return View(lecturesComment);
        }

        // GET: LecturesComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesComment lecturesComment = db.LecturesComments.Find(id);
            if (lecturesComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.lectureId = new SelectList(db.Lectures, "id", "name", lecturesComment.lectureId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", lecturesComment.userId);
            return View(lecturesComment);
        }

        // POST: LecturesComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,currDate,comment,userId,lectureId,likes,dislikes")] LecturesComment lecturesComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturesComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lectureId = new SelectList(db.Lectures, "id", "name", lecturesComment.lectureId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", lecturesComment.userId);
            return View(lecturesComment);
        }

        // GET: LecturesComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesComment lecturesComment = db.LecturesComments.Find(id);
            if (lecturesComment == null)
            {
                return HttpNotFound();
            }
            return View(lecturesComment);
        }

        // POST: LecturesComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LecturesComment lecturesComment = db.LecturesComments.Find(id);
            db.LecturesComments.Remove(lecturesComment);
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
