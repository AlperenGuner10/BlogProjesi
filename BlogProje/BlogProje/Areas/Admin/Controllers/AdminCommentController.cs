using BlogProje.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminCommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EfCommentRepository());
		public IActionResult Index()
		{
			var values = commentManager.GetCommentWithBlog();
			return View(values);
		}
	}
}
