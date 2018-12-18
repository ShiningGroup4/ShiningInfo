using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ShiningInfomation.Models.ViewModel
{
    public class Vm001
    {
        [Required(ErrorMessage = "0,不能为空")]

        [Display(Name = "账号")]
        public String account { get; set; }

        [Required(ErrorMessage = "{0},不能为空")]
   
        [Display(Name = "密码")]
        public String pwd { get; set; }
    }
}