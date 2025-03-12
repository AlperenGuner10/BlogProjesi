using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BlogProje.Areas.Admin.ViewComponents.Statistic
{
	public class _Statistic1 : ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = blogManager.GetAllBlogs().Count();
			ViewBag.v2 = context.Contacts.Count();
			ViewBag.v3 = context.Comments.Count();

			string api = "cb65971c621007b8a8d79959217192f6";
			string connection = "https://api.openweathermap.org/data/2.5/weather?q=Istanbul&mode=xml&lang=tr&units=metric&appid="+api;

			XDocument xDocument = XDocument.Load(connection);
			ViewBag.v4 = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;
			return View();
		}
	}
}
