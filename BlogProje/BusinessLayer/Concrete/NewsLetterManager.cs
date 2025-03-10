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
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetterDal _newsLetterDal;

		public NewsLetterManager(INewsLetterDal newsLetterDal)
		{
			this._newsLetterDal=newsLetterDal;
		}

		public void AddNewsLetter(NewsLetter newNewsLetter)
		{
			_newsLetterDal.Add(newNewsLetter);
		}
	}
}
