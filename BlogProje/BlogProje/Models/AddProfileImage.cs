using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BlogProje.Models
{
	public class AddProfileImage
	{
		[Key]
		public int WriteID { get; set; }
		public string WriteName { get; set; }
		public string WriteAbout { get; set; }
		public IFormFile WriteImage { get; set; }
		public string WriterMail { get; set; }
		public string WriterPassword { get; set; }
		public bool WriteStatus { get; set; }
	}
}
