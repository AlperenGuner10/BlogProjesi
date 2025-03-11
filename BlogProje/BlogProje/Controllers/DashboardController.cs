using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			Context context = new Context();
			ViewBag.v1 = context.Blogs.Count().ToString();
			ViewBag.v2 = context.Blogs.Where(x=>x.WriterID == 4).Count();
			ViewBag.v3 = context.Categories.Count();
			return View();
		}
	}
}
