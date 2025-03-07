using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterMessageNotification : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
