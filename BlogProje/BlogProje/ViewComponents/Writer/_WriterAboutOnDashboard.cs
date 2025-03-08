using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterAboutOnDashboard : ViewComponent
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		public IViewComponentResult Invoke()
		{
			var values = writerManager.GetWriterById(4);
			return View(values);
		}
	}
}
