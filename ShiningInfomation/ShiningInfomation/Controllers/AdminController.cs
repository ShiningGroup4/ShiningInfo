using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShiningInfomation.Models;
using ShiningInfomation.Entity;
using ShiningInfomation.Models.ViewModel;

namespace ShiningInfomation.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminIndex() //管理员页
        {
            return View(AdminDemo.GetAll());
        }
        public ActionResult Details(string id)
        {
            var model = AdminDemo.GetById(id);
            if (model == null) return View("Error");
            return View(model);
        }
        public ActionResult Create()
        {
            return View(new Vm002());
        }
        [HttpPost]
        public ActionResult Create(Vm002 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
        public ActionResult Edit(string id)
        {
            var model = AdminDemo.GetById(id);
            if (model == null) return View("Error");
            ViewData.Model = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentInfoManagementEntities se = new StudentInfoManagementEntities();
                    var model = se.StudentInfo.FirstOrDefault(m => m.StudentID == id);
                    string[] strArr = collection.AllKeys;
                    TryUpdateModel(model, strArr);
                    se.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
        public ActionResult Delete(string id)
        {
            try
            {
                StudentInfoManagementEntities se = new StudentInfoManagementEntities();
                var Student01 = se.StudentInfo.FirstOrDefault(m => m.StudentID == id);
                if (Student01 != null)
                {
                    se.StudentInfo.Remove(Student01);
                    se.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
    }
}