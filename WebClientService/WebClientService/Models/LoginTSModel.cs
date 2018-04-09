using System.ComponentModel.DataAnnotations;

namespace WebClientService.Models
{
    public class LoginTSModel
    {
        [Required(ErrorMessage = "Xin vui lòng nhập user name")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Xin vui lòng nhập password")]
        public string Password { set; get; }
    }
}