using BlogProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents
{
	public class _CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var values = new List<UserComment>()
			{
				new UserComment
				{
					ID = 1,
					Username = "Test",
				},
				new UserComment
				{
					ID = 2,
					Username= "Test1",
				},
				new UserComment
				{
					ID = 3,
					Username = "Test2"
				}
			};
			return View();
		}
	}
}
