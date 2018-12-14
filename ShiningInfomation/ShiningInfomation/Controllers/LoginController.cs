using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShiningInfomation.Models;
using ShiningInfomation.Models.ViewModel;

namespace ShiningInfomation.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Vm001 model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userinfo = LoginDemo.LoginFun(model.account, model.pwd);
                    if (userinfo == true)
                    {
                        return RedirectToAction("Index", "Index"); //第一个Index是指Index控制器，第二个是Index这个action。这行实现了页面的跳转
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View("Error");
        }
    }
}