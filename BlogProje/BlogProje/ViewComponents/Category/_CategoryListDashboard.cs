using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Category
{
	public class _CategoryListDashboard : ViewComponent
	{
		CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());

		public IViewComponentResult Invoke()
		{
			var values = categoryManager.GetAll(); //GetAllCategories
			return View(values);
		}
	}
}
