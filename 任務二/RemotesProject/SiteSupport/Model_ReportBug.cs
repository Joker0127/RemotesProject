using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSupport.Model
{
    public class ReportBug
    {
        [Display(Name = "編號")]
        public int ID { get; set; }
        [Display(Name = "標題")]
        public string Title { get; set; }
        [Display(Name = "敘述")]
        public string bugDes { get; set; }
        [Display(Name = "建立時間")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "狀態")]
        public int bugStatus { get; set; }
    }

    public class ReportBugViewModel : ReportBug
    {
        [Display(Name = "狀態")]
        public string bugStatusstr {
            get
            {
                return myEnum.EnumUtil.Convert_bugStatusstr(bugStatus);
            }
        }

        [Display(Name = "建立時間")]
        public string CreateTimeStr { 
            get 
            {
                return CreateTime.ToString("yyyy/MM/dd HH:mm");
            }
        }
    }


}
