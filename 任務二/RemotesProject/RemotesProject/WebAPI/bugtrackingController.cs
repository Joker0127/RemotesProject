using SiteSupport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RemotesProject.WebAPI
{

    [RoutePrefix("api/bugtracking")]
    public class bugtrackingController : ApiController
    {
        [System.Web.Http.HttpPost]
        [Route("BugInsert")]
        public IHttpActionResult Create(ReportBugViewModel model)
        {
            int insertid = 0;
            bool ok = SiteSupport.SupportDB.Report_Insert(model,out insertid);
            ReportBug reportBug = new ReportBug();
            if (insertid != 0)
            {
                reportBug = SiteSupport.SupportDB.ReportBug_Get(insertid);
            }
            return Ok(reportBug);
        }

        [System.Web.Http.HttpPut]
        [Route("BugUpdate")]
        public IHttpActionResult Update(ReportBugViewModel model)
        {
            bool ok = SiteSupport.SupportDB.Report_Update(model);
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        [Route("BugDelete")]
        public IHttpActionResult Delete(ReportBugViewModel model)
        {
            bool ok = SiteSupport.SupportDB.Report_Delete(model.ID);
            return Ok();
        }
    }

    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        [System.Web.Http.HttpGet]
        [Route("bugAuth")]
        public IHttpActionResult Get(string Account)
        {
            AuthViewModel model = SiteSupport.SupportDB.Account_ChectAuth(Account);
            return Ok(model);
        }        
    }
}
