using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShiningInfomation.Entity;
using System.Data;
using System.Data.Entity;
using System.Net;
using ShiningInfomation.Models.ViewModel;

namespace ShiningInfomation.Controllers
{
    
    public class SearchController : Controller
    {
        StudentInfoManagementEntities se = new StudentInfoManagementEntities();
 

        public ActionResult IndexTeacher() 
        {
            var TeacherInfo = se.TeacherInfo.Include(s => s.StudentInfo);
            return View(TeacherInfo.ToList());
        }

        public ActionResult Index()
        {
            var studentInfo = se.StudentInfo.Include(s => s.TeacherInfo);
            return View(studentInfo.ToList());
        }

        // GET: Search
        public ActionResult Search(string Search_name, string Search_team, string Search_group)  //搜索方法
        {
            if (!String.IsNullOrEmpty(Search_name) || !String.IsNullOrEmpty(Search_team) || !String.IsNullOrEmpty(Search_group))
            {
                var SearchList = from u in se.StudentInfo
                                 where u.StudentName.Contains(Search_name) && u.Team.Contains(Search_team) && u.GroupNum.Contains(Search_group)
                                 select u;
                return View(SearchList.ToList());
            }
            else
            {
                var SearchList = from u in se.StudentInfo
                                 where 1 != 1
                                 select u;
                return View(SearchList.ToList());
            }
        }

        public ActionResult DetailsTeacher(String id) //显示导师详情
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherInfo teacherInfo = se.TeacherInfo.Find(id);
            if (teacherInfo == null)
            {
                return HttpNotFound();
            }
            return View(teacherInfo);
        }

        public ActionResult DetailsStudent(string id)  //显示学生详情
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = se.StudentInfo.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }

 

        public ActionResult EditStudent(string id) //编辑学生信息
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }      

                StudentInfo studentInfo = se.StudentInfo.Find(id);
                if (studentInfo == null)
                {
                    return HttpNotFound();
                }
                ViewBag.TeacherID = new SelectList(se.TeacherInfo, "TeacherID", "TeacherName", studentInfo.TeacherID);
                return View(studentInfo);
 

        }

    }
}