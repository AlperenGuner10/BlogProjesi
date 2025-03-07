using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICategoryService
	{
		void TAdd(Category category);
		void RemoveT(Category category);
		void UpdateT(Category category);
		List<Category> GetAll();
		Category GetById(int id);
	}
}
