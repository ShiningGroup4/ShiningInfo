using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShiningInfomation.Entity;

namespace ShiningInfomation.Controllers
{
    public class SearchController : Controller
    {
        StudentInfoManagementEntities se = new StudentInfoManagementEntities();
        // GET: Search
        public ActionResult Search(string Search_name, string Search_team, string Search_group, string Search_teacher)
        {
            if (!String.IsNullOrEmpty(Search_name) || !String.IsNullOrEmpty(Search_team) || !String.IsNullOrEmpty(Search_group) || !String.IsNullOrEmpty(Search_teacher))
            {
                var SearchList = from u in se.StudentInfo
                                 where u.StudentName.Contains(Search_name) && u.Team.Contains(Search_team) && u.GroupNum.Contains(Search_group) && u.TeacherInfo.TeacherName.Contains(Search_teacher)
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
    }
}