using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UserSingUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Ad Soyad giriniz")]
        public string NameSurname { get; set; }
        
        [Display(Name ="Mail")]
        [Required(ErrorMessage ="Mail Gitiniz")]
        public string Mail { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage ="Şifrenizi giriniz")]
        public string Password { get; set; }
        
        [Display(Name ="Şifre tekrar")]
        [Compare("Password", ErrorMessage= "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı giriniz")]
        public string UserName { get; set; }



    }
}
