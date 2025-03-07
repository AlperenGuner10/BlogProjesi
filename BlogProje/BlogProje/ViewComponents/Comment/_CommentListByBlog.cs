using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Comment
{
	public class _CommentListByBlog : ViewComponent
	{
		CommentManager commentManager = new CommentManager(new EfCommentRepository());
		public IViewComponentResult Invoke(int id)
		{
			var values = commentManager.GetAllComment(id);
			return View(values);
		}
	}
}
