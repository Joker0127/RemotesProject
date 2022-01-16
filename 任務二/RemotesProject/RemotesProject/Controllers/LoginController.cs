using SiteSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiteSupport.Model;

namespace RemotesProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginmodel)
        {
            string account = string.Empty;
            bool loginok = SupportDB.Account_LoginCheck(loginmodel.Account, loginmodel.Password, out account);

            if (loginok && account != string.Empty)
            {
                UserinfoViewModel userinfo = SupportDB.Account_Get(account);
                Session["UserInfo"] = userinfo;
                return RedirectToAction("index", "Home");
            }            
            return View();
        }
    }
}