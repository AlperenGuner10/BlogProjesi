using System.ComponentModel.DataAnnotations;

namespace BlogProje.Models
{
	public class UserSignUpViewModel
	{
		[Display(Name ="Ad Soyad")]
		[Required(ErrorMessage ="Lütfen Ad Soyad Giriniz")]
		public string NameSurname { get; set; }

		[Display(Name = "Şifre")]
		[Required(ErrorMessage = "Lütfen Şifre Giriniz")]
		public string Password { get; set; }

		[Display(Name = "Şifre Tekrar")]
		[Required(ErrorMessage = "Şifreler Uyuşmuyor")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Mail Adresi")]
		[Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz")]
		public string Mail { get; set; }

		[Display(Name = "Kullanıcı Adı")]
		[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
		public string UserName { get; set; }
	}
}
