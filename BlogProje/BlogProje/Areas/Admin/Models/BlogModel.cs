using System.ComponentModel.DataAnnotations;

namespace BlogProje.Areas.Admin.Models
{
	public class BlogModel
	{
		[Key]
		public int ID { get; set; }
		public string BlogName{ get; set; }
	}
}
