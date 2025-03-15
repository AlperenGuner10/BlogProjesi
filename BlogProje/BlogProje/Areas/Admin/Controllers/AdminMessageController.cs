using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminMessageController : Controller
	{
		MessageConnectionManager connectionManager = new MessageConnectionManager(new EfMessageConnectionRepository());
		Context context = new Context();
		public IActionResult Inbox()
		{
			var username = User.Identity.Name;
			var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

			var userID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();


			var values = connectionManager.GetInboxListByWriter(userID);
			return View(values);
		}
		public IActionResult SendBox()
		{
			var username = User.Identity.Name;
			var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

			var userID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();

			var values = connectionManager.GetSendBoxListByWriter(userID);
			return View(values);
		}
		[HttpGet]
		public IActionResult ComposeMessage()
		{
			return View();
		}
		[HttpPost]
		public IActionResult ComposeMessage(MessageConnection message)
		{
			var username = User.Identity.Name;
			var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

			var userID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();
			message.SenderID = userID;
			message.RecieverID = 7;
			message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			message.MessageStatus = true;
			connectionManager.TAdd(message);
			return RedirectToAction("SendBox");
		}
	}
}
