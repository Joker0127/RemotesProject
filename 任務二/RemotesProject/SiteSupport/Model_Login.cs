using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSupport.Model
{
    class Model_Login
    {
        
    }

    public class UserinfoViewModel
    {
        public int ID { get; set; }

        public string Account { get; set; }
        public string Password { get; set; }

        public int SiteRole { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "請輸入帳號")]
        [Display(Name = "QA/RD")]
        public string Account { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [Display(Name = "密碼")]
        public string Password { get; set; }
    }

    public class AuthViewModel
    {
        public bool isQA { get; set; }
        public bool isRD { get; set; }
    }
}
