using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Blog
{
	public class _BlogLastThreePost : ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EfBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetLastThreeBlogs();
			return View(values);
		}
	}
}
