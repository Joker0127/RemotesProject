using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiteSupport.Model;

namespace SiteSupport
{
    public partial class SupportDB
    {
        public static DBmanager dbm = new DBmanager();
        const string table_ReportBug = "ReportBug";
        const string ID = "ID";
        const string Title = "Title";
        const string bugDes = "bugDes";
        const string CreateTime = "CreateTime";
        const string bugStatus = "bugStatus";


        public static List<ReportBugViewModel> ReportBug_Get()
        {
            List<ReportBugViewModel> list = new List<ReportBugViewModel>();
            DataTable dt = dbm.DB_GetDatatable(table_ReportBug, string.Empty);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    ReportBugViewModel reportBug = new ReportBugViewModel();
                    reportBug.ID = Convert.ToInt32(row[ID]);
                    reportBug.Title = row[Title].ToString();
                    reportBug.bugDes = row[bugDes].ToString();
                    reportBug.CreateTime = Convert.ToDateTime(row[CreateTime]);
                    reportBug.bugStatus = Convert.ToInt32(row[bugStatus]);
                    list.Add(reportBug);
                }
            }
            return list;
        }

        public static ReportBugViewModel ReportBug_Get(int id)
        {
            ReportBugViewModel reportBug = new ReportBugViewModel();
            DataTable dt = dbm.DB_GetDatatable(table_ReportBug, $"{ID} = {id}");
            if (dt.Rows.Count > 0)
            {
                reportBug.ID = Convert.ToInt32(dt.Rows[0][ID]);
                reportBug.Title = dt.Rows[0][Title].ToString();
                reportBug.bugDes = dt.Rows[0][bugDes].ToString();
                reportBug.CreateTime = Convert.ToDateTime(dt.Rows[0][CreateTime]);
                reportBug.bugStatus = Convert.ToInt32(dt.Rows[0][bugStatus]);
            }
            return reportBug;
        }

        public static bool Report_Insert(ReportBugViewModel model,out int insertid)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic[Title] = model.Title;
            dic[bugDes] = model.bugDes;
            dic[bugStatus] = model.bugStatus;
            bool ok = dbm.DB_Insert(table_ReportBug, dic,out insertid);
            return ok;
        }

        public static bool Report_Update(ReportBugViewModel model)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic[Title] = model.Title;
            dic[bugDes] = model.bugDes;
            dic[bugStatus] = model.bugStatus;
            bool ok = dbm.DB_Update(table_ReportBug, dic, $"{ID} = {model.ID}");
            return ok;
        }

        public static bool Report_Delete(int id)
        {
            bool ok = dbm.DB_Delete(table_ReportBug, $"{ID} = {id}");
            return ok;
        }
    }
}
