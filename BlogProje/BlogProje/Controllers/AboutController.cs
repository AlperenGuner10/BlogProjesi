﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EfAboutRepository());
		public IActionResult Index()
		{
			var values = aboutManager.GetList();
			return View(values);
		}
		public PartialViewResult SocialMediaAbout()
		{
			return PartialView();
		}
	}
}
