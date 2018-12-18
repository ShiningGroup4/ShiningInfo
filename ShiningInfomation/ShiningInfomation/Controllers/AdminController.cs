using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShiningInfomation.Entity;

namespace ShiningInfomation.Controllers
{
    public class AdminController : Controller
    {
        private StudentInfoManagementEntities db = new StudentInfoManagementEntities();

        // GET: Admin
        public ActionResult Index()
        {
            var studentInfo = db.StudentInfo.Include(s => s.TeacherInfo);
            return View(studentInfo.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfo.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.TeacherID = new SelectList(db.TeacherInfo, "TeacherID", "TeacherName");
            return View();
        }

        // POST: Admin/Create
       
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,StudentName,StudentAlias,Password,Team,Motto,TeacherID,GroupNum")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                db.StudentInfo.Add(studentInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherID = new SelectList(db.TeacherInfo, "TeacherID", "TeacherName", studentInfo.TeacherID);
            return View(studentInfo);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfo.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherID = new SelectList(db.TeacherInfo, "TeacherID", "TeacherName", studentInfo.TeacherID);
            return View(studentInfo);
        }

        // POST: Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "StudentID,StudentName,StudentAlias,Password,Team,Motto,TeacherID,GroupNum")] StudentInfo studentInfo)
        //public ActionResult Edit([Bind(Include = "StudentID,StudentName,StudentAlias,Team,Motto,TeacherID,GroupNum")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherID = new SelectList(db.TeacherInfo, "TeacherID", "TeacherName", studentInfo.TeacherID);
            return View(studentInfo);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfo.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentInfo studentInfo = db.StudentInfo.Find(id);
            db.StudentInfo.Remove(studentInfo);
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
