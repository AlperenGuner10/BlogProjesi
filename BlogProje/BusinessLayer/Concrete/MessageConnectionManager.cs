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
			return _messageConnectionDal.GetInboxWithMessageByWriter(id);
		}

		public List<MessageConnection> GetSendBoxListByWriter(int id)
		{
			return _messageConnectionDal.GetSendBoxWithMessageByWriter(id);
		}

		public void RemoveT(MessageConnection t)
		{
			_messageConnectionDal.Delete(t);
		}

		public void TAdd(MessageConnection t)
		{
			_messageConnectionDal.Add(t);
		}

		public void UpdateT(MessageConnection t)
		{
			_messageConnectionDal.Update(t);
		}
	}
}
