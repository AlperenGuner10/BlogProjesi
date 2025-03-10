﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Controllers
{
	public class NotificationController : Controller
	{
		NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());
		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult AllNotification()
		{
			var values = notificationManager.GetAll();
			return View(values);
		}
	}
}
