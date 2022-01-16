using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteSupport
{
    public class myEnum
    {


        public enum SiteRole : int
        {
            /// <summary>
            /// admin
            /// </summary>
            admin = 1,
            /// <summary>
            /// QA
            /// </summary>
            QA = 2,
            /// <summary>
            /// RD
            /// </summary>
            RD = 3
        }

        public enum bugStatus : int
        {
            /// <summary>
            /// 未開始
            /// </summary>
            Prepare = 0,
            /// <summary>
            /// 修改中
            /// </summary>
            coding = 1,
            /// <summary>
            /// 已完成
            /// </summary>
            complete = 2,
        }

        public class EnumUtil
        {
            public static string Convert_bugStatusstr(int statusint)
            {
                switch (statusint)
                {
                    case 0:
                        return "未開始";
                    case 1:
                        return "修改中";
                    case 2:
                        return "已完成";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}