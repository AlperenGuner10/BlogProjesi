using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using X.PagedList.Extensions;

namespace BlogProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
		Context context = new Context();
		public IActionResult Index(int page = 1)
		{
			var values = categoryManager.GetAll().ToPagedList(page,3);
			return View(values);
		}
		[HttpGet]
		public IActionResult AddCategory()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddCategory(Category category)
		{
			CategoryValidator validator = new CategoryValidator();
			ValidationResult result = validator.Validate(category);
			if (result.IsValid)
			{
				category.CategoryStatus = true;
				categoryManager.TAdd(category);
				return RedirectToAction("Index", "Category");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(category);
		}
		public IActionResult DeleteCategory(int id)
		{
			var blogValue = categoryManager.GetById(id);
			categoryManager.RemoveT(blogValue);
			return RedirectToAction("Index");
		}
	}
}
