using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProje.Controllers
{
	[AllowAnonymous]
	public class MessageController : Controller
	{
		MessageConnectionManager connectionManager = new MessageConnectionManager(new EfMessageConnectionRepository());
		public IActionResult InBox()
		{
			int id = 4;
			var values = connectionManager.GetInboxListByWriter(4);
			return View(values);
		}
		public IActionResult MessageDetails(int id)
		{
			var values = connectionManager.GetById(id);
			return View(values);
		}
	}
}
