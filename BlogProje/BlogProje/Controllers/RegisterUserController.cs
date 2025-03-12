using BlogProje.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
	[AllowAnonymous]
	public class RegisterUserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterUserController(UserManager<AppUser> userManager)
		{
			_userManager=userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserSignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					Email = model.Mail,
					UserName = model.UserName,
					NameSurname = model.NameSurname
				};
				var result = await _userManager.CreateAsync(appUser, model.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}

			}
			return View(model);
		}
	}
}
