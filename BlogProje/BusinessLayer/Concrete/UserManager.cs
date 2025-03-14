using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal=userDal;
		}

		public List<AppUser> GetAll()
		{
			return _userDal.GetAll();
		}

		public AppUser GetById(int id)
		{
			return _userDal.GetById(id);
		}

		public void RemoveT(AppUser t)
		{
			_userDal.Delete(t);
		}

		public void TAdd(AppUser t)
		{
			_userDal.Add(t);
		}

		public void UpdateT(AppUser t)
		{
			_userDal.Update(t);
		}
	}
}
