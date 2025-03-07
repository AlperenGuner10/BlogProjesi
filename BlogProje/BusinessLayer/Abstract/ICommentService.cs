using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface ICommentService
	{
		void AddComment(Comment comment);
		//void RemoveCategory(Comment comment);
		//void UpdateCategory(Comment comment);
		List<Comment> GetAllComment(int id);
		//Comment GetCategoryById(int id);
	}
}
