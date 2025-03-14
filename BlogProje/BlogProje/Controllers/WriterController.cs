using BlogProje.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogProje.Controllers
{
	public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterRepository());

		private readonly UserManager<AppUser> _userManager;

		Context context = new Context();

		public WriterController(UserManager<AppUser> userManager)
		{
			_userManager=userManager;
		}

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
		public async Task<IActionResult> WriterEditProfile()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserUpdatesViewModel viewModel = new UserUpdatesViewModel();
			viewModel.mail = values.Email;
			viewModel.username = values.UserName;
			viewModel.namesurname = values.NameSurname;
			viewModel.imageurl = values.ImageUrl;
			return View(viewModel);
		}
		[HttpPost]
		public async Task<IActionResult> WriterEditProfile(UserUpdatesViewModel viewModel)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.NameSurname = viewModel.namesurname;
			values.ImageUrl = viewModel.imageurl;
			values.UserName = viewModel.username;
			values.Email= viewModel.mail;
			values.PasswordHash = _userManager.PasswordHasher.HashPassword(values,viewModel.password);
			var result = await _userManager.UpdateAsync(values);
			return RedirectToAction("Index", "Dashboard");
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
