using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterMessageNotification : ViewComponent
	{
		MessageManager messageManager = new MessageManager(new EfMessageRepository());
		public IViewComponentResult Invoke()
		{
			string p;
			p ="rafa@gmail.com";
			var values = messageManager.GetInboxListByWriter(p);
			return View(values);
		}
	}
}
