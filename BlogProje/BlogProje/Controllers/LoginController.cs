using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Security.Claims;

namespace BlogProje.Controllers
{
	public class LoginController : Controller
	{
		Context context = new Context();
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(Writer writer)
		{
			Context context = new Context();
			var datavalue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
			if (datavalue != null)
			{
				var claims = new List<Claim>()
				{
					new Claim(ClaimTypes.Name,writer.WriterMail)
				};
				var useridentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal user = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(user);
				return RedirectToAction("Index", "Writer");
			}
			else
			{
				return View();
			}
		}
	}
}