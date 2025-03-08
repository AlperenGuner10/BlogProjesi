using BlogProje.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult Test()
		{
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
		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writerValues = writerManager.GetById(4);
			return View(writerValues);
		}
		[AllowAnonymous]
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
		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}
		[AllowAnonymous]	
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
