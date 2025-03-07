using System.ComponentModel.DataAnnotations;

namespace BlogProje.Models
{
	public class UserComment
	{
		[Key]
		public int ID { get; set; }
		public string Username { get; set; }
	}
}
