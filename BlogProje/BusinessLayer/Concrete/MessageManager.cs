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
	public class MessageManager : IMessageService
	{
		IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			this._messageDal=messageDal;
		}

		public List<Message> GetAll()
		{
			return _messageDal.GetAll();
		}

		public List<Message> GetInboxListByWriter(string s)
		{
			return _messageDal.GetListAll(x => x.Reciever == s);
		}

		public Message GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void RemoveT(Message t)
		{
			throw new NotImplementedException();
		}

		public void TAdd(Message t)
		{
			throw new NotImplementedException();
		}

		public void UpdateT(Message t)
		{
			throw new NotImplementedException();
		}
	}
}
