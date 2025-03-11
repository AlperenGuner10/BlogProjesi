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
	public class MessageConnectionManager : IMessageConnectionService
	{
		IMessageConnectionDal _messageConnectionDal;

		public MessageConnectionManager(IMessageConnectionDal messageConnectionDal)
		{
			_messageConnectionDal=messageConnectionDal;
		}

		public List<MessageConnection> GetAll()
		{
			return _messageConnectionDal.GetAll();
		}

		public MessageConnection GetById(int id)
		{
			return _messageConnectionDal.GetById(id);
		}

		public List<MessageConnection> GetInboxListByWriter(int id)
		{
			return _messageConnectionDal.GetListWithMessageByWriter(id);
		}

		public void RemoveT(MessageConnection t)
		{
			throw new NotImplementedException();
		}

		public void TAdd(MessageConnection t)
		{
			throw new NotImplementedException();
		}

		public void UpdateT(MessageConnection t)
		{
			throw new NotImplementedException();
		}
	}
}
