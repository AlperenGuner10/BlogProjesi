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
	public class AboutManager : IAboutService
	{
		IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)
		{
			_aboutDal=aboutDal;
		}

		public List<About> GetAll()
		{
			throw new NotImplementedException();
		}

		public About GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<About> GetList()
		{
			return _aboutDal.GetAll();
		}

		public void RemoveT(About t)
		{
			throw new NotImplementedException();
		}

		public void TAdd(About t)
		{
			throw new NotImplementedException();
		}

		public void UpdateT(About t)
		{
			throw new NotImplementedException();
		}
	}
}
