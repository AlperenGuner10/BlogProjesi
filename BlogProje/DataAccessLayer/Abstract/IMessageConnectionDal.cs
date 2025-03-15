using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IMessageConnectionDal : IGenericDal<MessageConnection>
	{
		List<MessageConnection> GetInboxWithMessageByWriter(int id);
		List<MessageConnection> GetSendBoxWithMessageByWriter(int id);

	}
}
