using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebClientService.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Xin vui lòng nhập user name")]
        public string UserName { set; get; }

        [Required(ErrorMessage ="Xin vui lòng nhập password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}