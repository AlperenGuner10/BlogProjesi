using BlogProje.Areas.Admin.Models;
using BlogProje.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class AdminRoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;

		public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager=roleManager;
			_userManager=userManager;
		}

		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddRole()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddRole(RoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				AppRole appRole = new AppRole
				{
					Name = model.Name,
				};
				var result = await _roleManager.CreateAsync(appRole);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
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
		[HttpGet]
		public IActionResult UpdateRole(int id)
		{
			var values = _roleManager.Roles.FirstOrDefault(X => X.Id == id);
			RoleUpdateViewModel model = new RoleUpdateViewModel()
			{
				Id = values.Id,
				name = values.Name
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
		{
			var values = _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefault();

			values.Name = model.name;
			var result = await _roleManager.UpdateAsync(values);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			return View(model);
		}
		public async Task<IActionResult> DeleteRole(int id)
		{
			var values = _roleManager.Roles.FirstOrDefault(x => x.Id==id);
			var result = await _roleManager.DeleteAsync(values);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public IActionResult UserRoleList()
		{
			var values = _userManager.Users.ToList();
			return View(values);
		}
		public async Task<IActionResult> AssignRole(int id)
		{
			var user = _userManager.Users.FirstOrDefault(x => x.Id==id);
			var roles = _roleManager.Roles.ToList();

			TempData["Userid"] = user.Id;

			var userRoles = await _userManager.GetRolesAsync(user);

			List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
			foreach (var item in roles)
			{
				RoleAssignViewModel a = new RoleAssignViewModel();
				a.RoleID = item.Id;
				a.Name = item.Name;
				a.Exists = userRoles.Contains(item.Name);
				model.Add(a);
			}

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
		{
			var userId = (int)TempData["Userid"];
			var user = _userManager.Users.FirstOrDefault(x=>x.Id == userId);
			foreach (var item in model)
			{
				if (item.Exists)
				{
					await _userManager.AddToRoleAsync(user, item.Name);
				}
				else
				{
					await _userManager.RemoveFromRoleAsync(user, item.Name);
				}
			}
			return RedirectToAction("UserRoleList");
		}

	}
}