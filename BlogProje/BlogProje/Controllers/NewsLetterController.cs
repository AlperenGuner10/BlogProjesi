using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
	public class NewsLetterController : Controller
	{
		NewsLetterManager manager = new NewsLetterManager(new EfNewsLetterRepository());
		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult SubscribeMail(NewsLetter newsLetter)
		{
			manager.AddNewsLetter(newsLetter);
			newsLetter.MailStatus = true;
			return PartialView();
		}
	}
}
