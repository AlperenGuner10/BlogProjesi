using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BlogProje.Controllers
{
	[AllowAnonymous]
	public class BlogController : Controller
	{
		BlogManager blogManager = new BlogManager(new EfBlogRepository());
		CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
		Context context = new Context();
		public IActionResult Index()
		{
			var values = blogManager.GetBlogListWithCategory();
			return View(values);
		}
		public IActionResult BlogReadAll(int id)
		{
			ViewBag.i = id;
			var values = blogManager.GetBlogByID(id);
			return View(values);
		}
		public IActionResult BlogListByWriter()
		{
			var userMail = User.Identity.Name;
			var userId = context.Writers.Where(x=>x.WriterMail == userMail).Select(y=>y.WriteID).FirstOrDefault();

			var values = blogManager.GetListWithCategoryByWriter(userId);
			return View(values);
		}
		[HttpGet]
		public IActionResult BlogAdd()
		{
			List<SelectListItem> categoryValues = (from x in categoryManager.GetAll()
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID.ToString()
												   }).ToList();
			ViewBag.categoryValue = categoryValues;
			return View();
		}
		[HttpPost]
		public IActionResult BlogAdd(Blog blog)
		{
			var userMail = User.Identity.Name;
			var userId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();

			BlogValidator validator = new BlogValidator();
			ValidationResult result = validator.Validate(blog);
			if (result.IsValid)
			{
				blog.BlogStatus = true;
				blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				blog.WriterID = userId;
				blogManager.AddBlog(blog);
				return RedirectToAction("BlogListByWriter", "Blog");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View(blog);
		}
		public IActionResult DeleteBlog(int id)
		{
			var blogValue = blogManager.GetBlogById(id);
			blogManager.RemoveBlog(blogValue);
			return RedirectToAction("BlogListByWriter");
		}
		[HttpGet]
		public IActionResult EditBlog(int id)
		{
			var values = blogManager.GetBlogById(id);
			List<SelectListItem> categoryValues = (from x in categoryManager.GetAll()
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID.ToString()
												   }).ToList();
			ViewBag.categoryValue = categoryValues;
			return View(values);
		}
		[HttpPost]
		public IActionResult EditBlog(Blog blog)
		{
			var userMail = User.Identity.Name;
			var userId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();

			blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			blog.BlogStatus = true;
			blog.WriterID = userId;
			blogManager.UpdateBlog(blog);
			return RedirectToAction("BlogListByWriter");
		}
	}
}
