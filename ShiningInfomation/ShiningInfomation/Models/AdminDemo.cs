using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShiningInfomation.Entity;

namespace ShiningInfomation.Models
{
    public class AdminDemo
    {
        public static IEnumerable<StudentInfo> GetAll()
        {
            StudentInfoManagementEntities se = new StudentInfoManagementEntities();
            return se.StudentInfo;
        }
        public static StudentInfo GetById(string id)
        {
            StudentInfoManagementEntities se = new StudentInfoManagementEntities();
            return se.StudentInfo.FirstOrDefault(m => m.StudentID == id);
        }
    }
}