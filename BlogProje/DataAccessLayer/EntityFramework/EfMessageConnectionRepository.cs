using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfMessageConnectionRepository : GenericRepository<MessageConnection>, IMessageConnectionDal
	{
		Context context = new Context();

		public List<MessageConnection> GetSendBoxWithMessageByWriter(int id)
		{
			return context.MessageConnections.Include(x=>x.ReceiverUser).Where(y=>y.SenderID == id).ToList();
		}

		public List<MessageConnection> GetInboxWithMessageByWriter(int id)
		{
			return context.MessageConnections.Include(x => x.SenderUser).Where(x => x.RecieverID == id).ToList();
		}
	}
}
