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
        public static StudentInfo LogFunction(Vm001 model)
        {
            StudentInfoManagementEntities se = new StudentInfoManagementEntities();

            return se.StudentInfo.FirstOrDefault(m => m.StudentID == model.account && m.Password == model.pwd);
        }
    }
}