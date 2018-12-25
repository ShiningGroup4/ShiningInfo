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
        public static int LoginFun(string account, string pwd)
        {
            StudentInfoManagementEntities se = new StudentInfoManagementEntities();

            var modelID = se.StudentInfo.FirstOrDefault(m => m.StudentAlias == account);
            var AdminModelID = se.AdminInfo.FirstOrDefault(m => m.AdminName == account); //管理员mmm

            if (modelID != null && AdminModelID == null)
            {
                if (modelID.Password == pwd) { return 1; }
                else { return 0; }
            }
            else if (modelID == null && AdminModelID != null)
            {
                if (AdminModelID.Password == pwd) { return 2; }
                else { return 0; }
            }
            else
            {
                return 0;
            }
        }
    }
}