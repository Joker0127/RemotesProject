using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemotesProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<SiteSupport.Model.ReportBugViewModel> list = SiteSupport.SupportDB.ReportBug_Get();
            return View(list);
        }

    }
}