﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDal<T>where T : class
	{
		void Add(T t);
		void Delete(T t);
		void Update(T t);
		List<T> GetAll();
		T GetById(int id);
		List<T> GetListAll(Expression<Func<T, bool>> filter);
	}
}
