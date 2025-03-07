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
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal=blogDal;
		}

		public void AddBlog(Blog blog)
		{
			_blogDal.Add(blog);
		}

		public List<Blog> GetAllBlogs()
		{
			return _blogDal.GetAll();
		}
		public List<Blog> GetLastThreeBlogs()
		{
			return _blogDal.GetAll().Take(3).ToList();
		}

		public Blog GetBlogById(int id)
		{
			return _blogDal.GetById(id);
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}
		public List<Blog> GetListWithCategoryByWriter(int id)
		{
			return _blogDal.GetListWithCategoryByWriter(id);
		}
		public List<Blog> GetBlogByID(int id)
		{
			return _blogDal.GetListAll(x=>x.BlogID == id);
		}

		public void RemoveBlog(Blog blog)
		{
			_blogDal.Delete(blog);
		}

		public void UpdateBlog(Blog blog)
		{
			_blogDal.Update(blog);
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x=>x.WriterID == id);
		}
	}
}
