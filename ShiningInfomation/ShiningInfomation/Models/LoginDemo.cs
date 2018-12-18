using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShiningInfomation.Entity;
using ShiningInfomation.Models.ViewModel;

namespace ShiningInfomation.Models
{
    public class LoginDemo
    {
        public static Boolean LoginFun(string account, string pwd)
        {
            StudentInfoManagementEntities se = new StudentInfoManagementEntities();

            var modelID = se.StudentInfo.FirstOrDefault(m => m.StudentAlias == account);
            var AdminModelID = se.AdminInfo.FirstOrDefault(m => m.AdminName == account); //管理员

            if (modelID != null && AdminModelID == null)
            {
                if (modelID.Password == pwd) { return true; }
                else { return false; }
            }
            else if (modelID == null && AdminModelID != null)
            {
                if (AdminModelID.Password == pwd) { return true; }
                else { return false; }
            }
            else
            {
                return false;
            }
        }
    }
}