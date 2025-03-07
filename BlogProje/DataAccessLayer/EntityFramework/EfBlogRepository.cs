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
	public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
	{
		Context context = new();
		public List<Blog> GetListWithCategory()
		{
			return context.Blogs.Include(b => b.Category).ToList();
		}

		public List<Blog> GetListWithCategoryByWriter(int id)
		{
			return context.Blogs.Include(x=>x.Category).Where(x => x.WriterID == id).ToList();
		}
	}
}
