using System.ComponentModel.DataAnnotations;

namespace Core_Portfolio.Areas.User.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen adınızı girin")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen soyadınızı adını girin")]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen kullanıcı adınızı girin")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen resim url değerini girin")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar girin girin")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lütfen mailinizi girin")]
        public string Mail { get; set; } = string.Empty;

    }
}
