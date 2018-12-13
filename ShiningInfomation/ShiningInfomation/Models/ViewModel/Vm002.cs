using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ShiningInfomation.Entity;

namespace ShiningInfomation.Models.ViewModel
{
    public class Vm002
    {
        [Required(ErrorMessage = "0,不能为空")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "请输入{2}至{1}个字符")]
        [Display(Name = "账号")]
        public string Account { get; set; }

        [Required(ErrorMessage = "{0},不能为空")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "请输入{2}至{1}个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /* [Required(ErrorMessage = "{0},不能为空")]
         [StringLength(4, MinimumLength = 2, ErrorMessage = "请输入{2}至{1}个字符")]
         [Display(Name = "姓名")]
         public string Name { get; set; }*/

        public Vm002()
        {
            Account = "";
            Password = "";
        }
        public void Save()
        {
            using (StudentInfoManagementEntities se = new StudentInfoManagementEntities())
            {
                var Student01 = new StudentInfo()
                {
                    StudentID = this.Account,
                    Password = this.Password
                };
                se.StudentInfo.Add(Student01);
                se.SaveChanges();
            }
        }

    }
}