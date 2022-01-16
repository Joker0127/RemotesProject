using SiteSupport.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSupport
{
    public partial class SupportDB
    {
        const string table_Account = "Account";
        const string Account = "Account";
        const string Password = "Password";
        const string SiteRole = "SiteRole";
        const string CreateDate = "CreateDate";


        public static bool Account_LoginCheck(string account, string password,out string accountstr)
        {
            DataTable dt = dbm.DB_GetDatatable(table_Account,$"{Account} = '{account}' and {Password} = '{password}'");
            if(dt.Rows.Count > 0)
            {
                accountstr = dt.Rows[0][Account].ToString();
                return true;
            }
            accountstr = string.Empty;
            return false;
        }

        public static UserinfoViewModel Account_Get(string account)
        {
            UserinfoViewModel userinfo = new UserinfoViewModel();
            DataTable dt = dbm.DB_GetDatatable(table_Account, $"{Account} = '{account}'");
            if (dt.Rows.Count > 0)
            {
                userinfo.ID = Convert.ToInt32(dt.Rows[0][ID]);
                userinfo.Account = dt.Rows[0][Account].ToString();
                userinfo.SiteRole = Convert.ToInt32(dt.Rows[0][SiteRole]);
                userinfo.CreateDate = Convert.ToDateTime(dt.Rows[0][CreateDate]);
            }
            return userinfo;
        }

        public static AuthViewModel Account_ChectAuth(string account)
        {
            AuthViewModel auth = new AuthViewModel();
            UserinfoViewModel userinfo = new UserinfoViewModel();
            userinfo = SupportDB.Account_Get(account);
            if(userinfo.SiteRole == (int)myEnum.SiteRole.QA)
            {
                auth.isQA = true;
            }
            if(userinfo.SiteRole == (int)myEnum.SiteRole.RD)
            {
                auth.isRD = true;
            }

            return auth;
        }

    }
}
