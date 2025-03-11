using BlogProje.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogProje.Controllers
{
	public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());
		Context context = new Context();
		public IActionResult Index()
		{
			var userMail = User.Identity.Name;
			ViewBag.UserMail = userMail;
			var userName = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteName).FirstOrDefault();
			ViewBag.UserName = userName;
			return View();
		}
		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
		[AllowAnonymous]
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var userMail = User.Identity.Name;
			var userID = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriteID).FirstOrDefault();
			
			var values = writerManager.GetWriterById(userID);

			var writerValues = writerManager.GetById(userID);
			return View(writerValues);
		}
		[HttpPost]
		public IActionResult WriterEditProfile(Writer writer)
		{
			WriterValidator validations = new WriterValidator();
			ValidationResult validationResult = validations.Validate(writer);
			if (validationResult.IsValid)
			{
				writerManager.UpdateT(writer);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName,
						item.ErrorMessage);
				}
			}
			return View();
		}
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult WriterAdd(AddProfileImage image)
		{
			Writer writer = new Writer();
			if (image.WriteImage != null)
			{
				var extension = Path.GetExtension(image.WriteImage.FileName);
				var newimagename = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/writerImageFiles/", newimagename);
				var stream = new FileStream(location, FileMode.Create);
				image.WriteImage.CopyTo(stream);
				writer.WriteImage = newimagename;
			}
			writer.WriterMail = image.WriterMail;
			writer.WriteName = image.WriteName;
			writer.WriterPassword = image.WriterPassword;
			writer.WriteStatus = true;
			writer.WriteAbout = image.WriteAbout;
			writerManager.TAdd(writer);
			return RedirectToAction("Index", "Dashboard");
		}
	}
}
