using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());
		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			var userMail = User.Identity.Name;
			var userID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();
			var values = writerManager.GetWriterById(userID);
			return View(values);
		}
	}
}
