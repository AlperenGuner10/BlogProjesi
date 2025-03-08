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
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal=writerDal;
		}

		public List<Writer> GetAll()
		{
			throw new NotImplementedException();
		}

		public Writer GetById(int id)
		{
			return _writerDal.GetById(id);
		}

		public List<Writer> GetWriterById(int id)
		{
			return _writerDal.GetListAll(x => x.WriteID ==  id);
		}

		public void RemoveT(Writer t)
		{
			throw new NotImplementedException();
		}

		public void TAdd(Writer t)
		{
			_writerDal.Add(t);
		}

		public void UpdateT(Writer t)
		{
			_writerDal.Update(t);
		}
	}
}
