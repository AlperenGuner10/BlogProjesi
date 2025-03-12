using BlogProje.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ChartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CategoryChart()
		{
			List<CategoryClass> categories = new List<CategoryClass>();

			categories.Add(new CategoryClass { categorycount = 1 ,categoryname="Teknoloji"});
			categories.Add(new CategoryClass { categorycount = 8 ,categoryname="Yazılım"});
			categories.Add(new CategoryClass { categorycount = 10 ,categoryname="Spor"});

			return Json(new { jsonlist = categories });
		}
		
	}
}
