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
			var username = User.Identity.Name;
			var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

			var writerid = context.Writers.Where(x => x.WriterMail == userMail).Select(x => x.WriteID).FirstOrDefault();

			ViewBag.v1 = context.Blogs.Count().ToString();
			ViewBag.v2 = context.Blogs.Where(x=>x.WriterID == writerid).Count();
			ViewBag.v3 = context.Categories.Count();
			return View();
		}
	}
}
