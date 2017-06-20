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
    public class CoursesCommentsController : Controller
    {
        private CoursatyEntities db = new CoursatyEntities();

        // GET: CoursesComments
        public ActionResult Index()
        {
            var coursesComments = db.CoursesComments.Include(c => c.Course).Include(c => c.User);
            return View(coursesComments.ToList());
        }

        // GET: CoursesComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesComment coursesComment = db.CoursesComments.Find(id);
            if (coursesComment == null)
            {
                return HttpNotFound();
            }
            return View(coursesComment);
        }

        // GET: CoursesComments/Create
        public ActionResult Create()
        {
            ViewBag.courseId = new SelectList(db.Courses, "id", "title");
            ViewBag.userId = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: CoursesComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,currDate,comment,userId,courseId,likes,dislikes")] CoursesComment coursesComment)
        {
            if (ModelState.IsValid)
            {
                db.CoursesComments.Add(coursesComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.courseId = new SelectList(db.Courses, "id", "title", coursesComment.courseId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", coursesComment.userId);
            return View(coursesComment);
        }

        // GET: CoursesComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesComment coursesComment = db.CoursesComments.Find(id);
            if (coursesComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.courseId = new SelectList(db.Courses, "id", "title", coursesComment.courseId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", coursesComment.userId);
            return View(coursesComment);
        }

        // POST: CoursesComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,currDate,comment,userId,courseId,likes,dislikes")] CoursesComment coursesComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursesComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.courseId = new SelectList(db.Courses, "id", "title", coursesComment.courseId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", coursesComment.userId);
            return View(coursesComment);
        }

        // GET: CoursesComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesComment coursesComment = db.CoursesComments.Find(id);
            if (coursesComment == null)
            {
                return HttpNotFound();
            }
            return View(coursesComment);
        }

        // POST: CoursesComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoursesComment coursesComment = db.CoursesComments.Find(id);
            db.CoursesComments.Remove(coursesComment);
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
