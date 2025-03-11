using BlogProje.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogController : Controller
	{
		public IActionResult ExportStaticExcelBlogList()
		{
			using (var workbook = new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("Blog Listesi");
				worksheet.Cell(1, 1).Value = "Blog ID";
				worksheet.Cell(1, 2).Value = "Blog Adı";

				int BlogRowCount = 2;
				foreach (var item in GetBlogList())
				{
					worksheet.Cell(BlogRowCount, 1).Value = item.ID;
					worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
					BlogRowCount++;
				}
				using (var stream = new MemoryStream())
				{
					workbook.SaveAs(stream);
					var content = stream.ToArray();
					return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya.xlsx");
				}
			}
		}
		public List<BlogModel> GetBlogList()
		{
			List<BlogModel> blogModel = new List<BlogModel>()
			{
				new BlogModel{ID = 1, BlogName = "C# Programlama"},
				new BlogModel{ID = 2, BlogName = ".NET Programlama"},
				new BlogModel{ID = 3, BlogName = "Pyhton Programlama"}
			};
			return blogModel;
		}
		public IActionResult BlogListExcel()
		{
			return View();
		}

		public IActionResult ExportDynamicExcelBlogList()
		{
			using (var workbook = new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("Blog Listesi");
				worksheet.Cell(1, 1).Value = "Blog ID";
				worksheet.Cell(1, 2).Value = "Blog Adı";

				int BlogRowCount = 2;
				foreach (var item in BlogTitleList())
				{
					worksheet.Cell(BlogRowCount, 1).Value = item.ID;
					worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
					BlogRowCount++;
				}
				using (var stream = new MemoryStream())
				{
					workbook.SaveAs(stream);
					var content = stream.ToArray();
					return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya.xlsx");
				}
			}
		}
		public List<BlogModel2> BlogTitleList()
		{
			List<BlogModel2> blogModels = new List<BlogModel2>();
			using (var context = new Context())
			{
				blogModels = context.Blogs.Select(x => new BlogModel2
				{
					ID =x.BlogID,
					BlogName = x.BlogTitle
				}).ToList();
			}
			return blogModels;
		}
		public IActionResult BlogTitleListExcel()
		{
			return View();
		}
	}
}
