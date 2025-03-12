using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Areas.Admin.ViewComponents.Statistic
{
	public class _Statistic2 : ViewComponent
	{
		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = context.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
			ViewBag.v2 = context.Contacts.Count();
			ViewBag.v3 = context.Comments.Count();
			return View();
		}
	}
}
