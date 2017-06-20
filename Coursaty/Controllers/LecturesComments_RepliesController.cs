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
    public class LecturesComments_RepliesController : Controller
    {
        private CoursatyEntities db = new CoursatyEntities();

        // GET: LecturesComments_Replies
        public ActionResult Index()
        {
            var lecturesComments_Replies = db.LecturesComments_Replies.Include(l => l.LecturesComment).Include(l => l.User);
            return View(lecturesComments_Replies.ToList());
        }

        // GET: LecturesComments_Replies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesComments_Replies lecturesComments_Replies = db.LecturesComments_Replies.Find(id);
            if (lecturesComments_Replies == null)
            {
                return HttpNotFound();
            }
            return View(lecturesComments_Replies);
        }

        // GET: LecturesComments_Replies/Create
        public ActionResult Create()
        {
            ViewBag.commentId = new SelectList(db.LecturesComments, "id", "comment");
            ViewBag.userId = new SelectList(db.Users, "id", "name");
            return View();
        }

        // POST: LecturesComments_Replies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,currDate,reply,userId,likes,dislikes,commentId")] LecturesComments_Replies lecturesComments_Replies)
        {
            if (ModelState.IsValid)
            {
                db.LecturesComments_Replies.Add(lecturesComments_Replies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.commentId = new SelectList(db.LecturesComments, "id", "comment", lecturesComments_Replies.commentId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", lecturesComments_Replies.userId);
            return View(lecturesComments_Replies);
        }

        // GET: LecturesComments_Replies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesComments_Replies lecturesComments_Replies = db.LecturesComments_Replies.Find(id);
            if (lecturesComments_Replies == null)
            {
                return HttpNotFound();
            }
            ViewBag.commentId = new SelectList(db.LecturesComments, "id", "comment", lecturesComments_Replies.commentId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", lecturesComments_Replies.userId);
            return View(lecturesComments_Replies);
        }

        // POST: LecturesComments_Replies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,currDate,reply,userId,likes,dislikes,commentId")] LecturesComments_Replies lecturesComments_Replies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturesComments_Replies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.commentId = new SelectList(db.LecturesComments, "id", "comment", lecturesComments_Replies.commentId);
            ViewBag.userId = new SelectList(db.Users, "id", "name", lecturesComments_Replies.userId);
            return View(lecturesComments_Replies);
        }

        // GET: LecturesComments_Replies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturesComments_Replies lecturesComments_Replies = db.LecturesComments_Replies.Find(id);
            if (lecturesComments_Replies == null)
            {
                return HttpNotFound();
            }
            return View(lecturesComments_Replies);
        }

        // POST: LecturesComments_Replies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LecturesComments_Replies lecturesComments_Replies = db.LecturesComments_Replies.Find(id);
            db.LecturesComments_Replies.Remove(lecturesComments_Replies);
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
