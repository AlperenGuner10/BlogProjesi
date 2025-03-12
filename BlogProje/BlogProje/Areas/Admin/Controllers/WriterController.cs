using BlogProje.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class WriterController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterList()
		{
			return Json(WriterClasses);
		}

		public IActionResult GetWriterById(int writerid)
		{
			var findWriter = WriterClasses.FirstOrDefault(x => x.Id == writerid);
			var jsonWriters = JsonConvert.SerializeObject(findWriter);
			return Json(jsonWriters);
		}

		public static List<WriterClass> WriterClasses = new List<WriterClass>()
		{
			new WriterClass
			{
				Id = 1,
				Name = "Semih"
			},
			new WriterClass
			{
				Id = 2,
				Name ="Veli"
			},
			new WriterClass
			{
				Id = 3,
				Name = "Hayri"
			}
		};
	}
}
