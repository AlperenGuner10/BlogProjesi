using System.ComponentModel.DataAnnotations;

namespace BlogProje.Models
{
	public class UserSignInViewModel
	{
		[Required(ErrorMessage ="Lütfen Kullanıcı Adınızı Girin")]
		public string username { get; set; }
		[Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
		public string password { get; set; }
	}
}
