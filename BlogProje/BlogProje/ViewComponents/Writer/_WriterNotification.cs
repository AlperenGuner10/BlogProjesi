﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.ViewComponents.Writer
{
	public class _WriterNotification : ViewComponent
	{
		NotificationManager notificationManager = new NotificationManager(new EfNotificationRepository());
		public IViewComponentResult Invoke()
		{
			var values = notificationManager.GetAll();
			return View(values);
		}
	}
}
