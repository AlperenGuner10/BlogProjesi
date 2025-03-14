using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());
		Context context = new Context();

		public IViewComponentResult Invoke()
		{
			var username = User.Identity.Name;
			ViewBag.v = username;
			var userMail = context.Users.Where(x=>x.UserName == username).Select(y=>y.Email).FirstOrDefault();

			var userID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();
			var values = writerManager.GetWriterById(userID);
			return View(values);
		}
	}
}
