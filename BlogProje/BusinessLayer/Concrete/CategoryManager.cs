using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal=categoryDal;
		}

		public List<Category> GetAll()
		{
			return _categoryDal.GetAll();
		}

		public Category GetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public void RemoveT(Category category)
		{
			_categoryDal.Delete(category);
		}

		public void TAdd(Category category)
		{
			_categoryDal.Add(category);
		}

		public void UpdateT(Category category)
		{
			_categoryDal.Update(category);
		}
	}
}
