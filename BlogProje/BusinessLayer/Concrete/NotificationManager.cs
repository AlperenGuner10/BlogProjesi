﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class NotificationManager : INotificationService
	{
		INotificationDal _notificationDal;

		public NotificationManager(INotificationDal notificationDal)
		{
			_notificationDal=notificationDal;
		}

		public List<Notification> GetAll()
		{
			return _notificationDal.GetAll();
		}

		public Notification GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void RemoveT(Notification t)
		{
			throw new NotImplementedException();
		}

		public void TAdd(Notification t)
		{
			throw new NotImplementedException();
		}

		public void UpdateT(Notification t)
		{
			throw new NotImplementedException();
		}
	}
}
