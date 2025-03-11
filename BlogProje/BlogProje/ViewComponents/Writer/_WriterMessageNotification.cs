using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterMessageNotification : ViewComponent
	{
		MessageConnectionManager messageManager = new MessageConnectionManager(new EfMessageConnectionRepository());
		public IViewComponentResult Invoke()
		{
			int id = 4;
			var values = messageManager.GetInboxListByWriter(id);
			return View(values);
		}
	}
}
