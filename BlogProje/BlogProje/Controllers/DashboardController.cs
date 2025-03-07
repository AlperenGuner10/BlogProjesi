using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
	public class DashboardController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
	}
}
