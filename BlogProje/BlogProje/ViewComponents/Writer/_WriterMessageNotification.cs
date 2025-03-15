using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterMessageNotification : ViewComponent
	{
		MessageConnectionManager messageManager = new MessageConnectionManager(new EfMessageConnectionRepository());

		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			var username = User.Identity.Name;
			var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();

			var userID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();

			var values = messageManager.GetInboxListByWriter(userID);
			return View(values);
		}
	}
}
