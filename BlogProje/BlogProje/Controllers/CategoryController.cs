using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
	public class CategoryController : Controller
	{
		CategoryManager manager = new CategoryManager(new EfCategoryRepository());
		public IActionResult Index()
		{
			var values = manager.GetAll(); //GetAllCategories
			return View(values);
		}
	}
}
