using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Areas.Admin.ViewComponents.Statistic
{
	public class _Statistic4 : ViewComponent
	{
		Context context = new();
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = context.Admins.Where(x=>x.AdminID==1).Select(x=>x.Name).FirstOrDefault();
			ViewBag.v2 = context.Admins.Where(x=>x.AdminID==1).Select(x=>x.ImageURL).FirstOrDefault();
			ViewBag.v3 = context.Admins.Where(x=>x.AdminID==1).Select(x=>x.ShortDesc).FirstOrDefault();
			return View();
		}
	}
}
