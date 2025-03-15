using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogProje.Controllers
{
	public class MessageController : Controller
	{
		MessageConnectionManager connectionManager = new MessageConnectionManager(new EfMessageConnectionRepository());
		Context context = new Context();
		public IActionResult InBox()
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
		public IActionResult MessageDetails(int id)
		{
			var values = connectionManager.GetById(id);
			return View(values);
		}
		[HttpGet]
		public IActionResult SendMessage()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SendMessage(MessageConnection connection)
		{
			var username = User.Identity.Name;
			var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

			var userID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();

			connection.SenderID = userID;
			connection.RecieverID = 8;
			connection.MessageStatus = true;
			connection.MessageDate= Convert.ToDateTime(DateTime.Now.ToShortDateString());
			connectionManager.TAdd(connection);
			return RedirectToAction("InBox");
		}
	}
}
