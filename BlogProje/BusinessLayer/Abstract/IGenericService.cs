using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T>
	{
		void TAdd(T t);
		void RemoveT(T t);
		void UpdateT(T t);
		List<T> GetAll();
		T GetById(int id);
	}
}
