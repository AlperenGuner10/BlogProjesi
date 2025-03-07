using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterNotification : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
