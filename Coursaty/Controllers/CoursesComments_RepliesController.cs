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
    public class CoursesComments_RepliesController : Controller
    {
        private CoursatyEntities db = new CoursatyEntities();

        // GET: CoursesComments_Replies
        public ActionResult Index()
        {
            var coursesComments_Replies = db.CoursesComments_Replies.Include(c => c.CoursesComment).Include(c => c.User);
            return View(coursesComments_Replies.ToList());
        }

        // GET: CoursesComments_Replies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesComments_Replies coursesComments_Replies = db.CoursesComments_Replies.Find(id);
            if (coursesComments_Replies == null)
            {
                return HttpNotFound();
            }
            return View(coursesComments_Replies);
        }

        // GET: CoursesComments_Replies/Create
        public ActionResult Create()
        {
            ViewBag.commentId = new SelectList(db.CoursesComments, "id", "comment");
            ViewBag.userId = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: CoursesComments_Replies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,currDate,reply,userId,likes,dislikes,commentId")] CoursesComments_Replies coursesComments_Replies)
        {
            if (ModelState.IsValid)
            {
                db.CoursesComments_Replies.Add(coursesComments_Replies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.commentId = new SelectList(db.CoursesComments, "id", "comment", coursesComments_Replies.commentId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", coursesComments_Replies.userId);
            return View(coursesComments_Replies);
        }

        // GET: CoursesComments_Replies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesComments_Replies coursesComments_Replies = db.CoursesComments_Replies.Find(id);
            if (coursesComments_Replies == null)
            {
                return HttpNotFound();
            }
            ViewBag.commentId = new SelectList(db.CoursesComments, "id", "comment", coursesComments_Replies.commentId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", coursesComments_Replies.userId);
            return View(coursesComments_Replies);
        }

        // POST: CoursesComments_Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,currDate,reply,userId,likes,dislikes,commentId")] CoursesComments_Replies coursesComments_Replies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursesComments_Replies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.commentId = new SelectList(db.CoursesComments, "id", "comment", coursesComments_Replies.commentId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", coursesComments_Replies.userId);
            return View(coursesComments_Replies);
        }

        // GET: CoursesComments_Replies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoursesComments_Replies coursesComments_Replies = db.CoursesComments_Replies.Find(id);
            if (coursesComments_Replies == null)
            {
                return HttpNotFound();
            }
            return View(coursesComments_Replies);
        }

        // POST: CoursesComments_Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoursesComments_Replies coursesComments_Replies = db.CoursesComments_Replies.Find(id);
            db.CoursesComments_Replies.Remove(coursesComments_Replies);
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
