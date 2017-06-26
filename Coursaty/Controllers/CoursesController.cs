using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Coursaty.Models;
using System.Web;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Coursaty.Controllers
{
    public class CoursesController : Controller
    {
        private CoursatyEntities db = new CoursatyEntities();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Instructor).Include(c => c.Track);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.instructorId = new SelectList(db.Instructors, "id", "name");
            ViewBag.trackId = new SelectList(db.Tracks, "id", "name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,link,image,rate,views,description,instructorId,trackId")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.instructorId = new SelectList(db.Instructors, "id", "name", course.instructorId);
            ViewBag.trackId = new SelectList(db.Tracks, "id", "name", course.trackId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.instructorId = new SelectList(db.Instructors, "id", "name", course.instructorId);
            ViewBag.trackId = new SelectList(db.Tracks, "id", "name", course.trackId);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,link,image,rate,views,description,instructorId,trackId")] Course course)
        {
            if (ModelState.IsValid)
            {
                string virtualImageName = course.id.ToString() + course.image.Substring(course.image.LastIndexOf('.'));
                course.image = virtualImageName;
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.instructorId = new SelectList(db.Instructors, "id", "name", course.instructorId);
            ViewBag.trackId = new SelectList(db.Tracks, "id", "name", course.trackId);
            return View(course);
        }

        [HttpGet]
        public ActionResult UploadImage(string filename)
        {
            ViewBag.FileName = filename;
            return View();
        }
        public ActionResult UploadImage2(int id)
        {
            return Json("id");
        }
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images"), pic);
                // file is uploaded
                file.SaveAs(path);
                ViewBag.FileName = pic;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Test()
        {
            return View();
        }
        public async Task<JsonResult> UploadHomeReport(string id)

        {
            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        // get a stream
                        var stream = fileContent.InputStream;
                        string ext = fileContent.FileName.Substring(fileContent.FileName.LastIndexOf('.'));
                        // and optionally write the file to disk
                        var fileName = DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ext; //Path.GetFileName(file);
                        var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }
            return Json("File uploaded successfully");
        }
        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
