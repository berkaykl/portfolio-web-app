using System.ComponentModel.DataAnnotations;

namespace Core_Portfolio.Areas.User.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; } = string.Empty;

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifreyi giriniz")]
        public string Password { get; set; } = string.Empty;
    }
}
