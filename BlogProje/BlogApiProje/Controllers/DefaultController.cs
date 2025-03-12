using BlogApiProje.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiProje.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : ControllerBase
	{
		[HttpGet]
		public IActionResult EmployeeList()
		{
			using var Context = new Context();
			var values = Context.Employees.ToList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult EmployeeAdd(Employee employee)
		{
			using var context = new Context();
			context.Add(employee);
			context.SaveChanges();
			return Ok(employee);
		}
		[HttpGet("{id}")]
		public IActionResult EmployeeGet(int id)
		{
			using var context = new Context();
			var employees = context.Employees.Find(id);
			if (employees == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(employees);
			}
		}
		[HttpDelete("{id}")]
		public IActionResult EmployeeDelete(int id)
		{
			using var ctx = new Context();
			var values = ctx.Employees.Find(id);
			if(values == null)
			{
				return NotFound();
			}
			else
			{
				ctx.Employees.Remove(values);
				ctx.SaveChanges();
				return Ok(values);
			}
		}
		[HttpPut]
		public IActionResult EmployeeEdit(Employee employee)
		{
			using var context = new Context();
			var employ = context.Find<Employee>(employee.Id);
			if (employ==null)
			{
				return NotFound();
			}
			else
			{
				employ.Name = employee.Name;
				context.Update(employ);
				context.SaveChanges();
				return Ok();
			}
		}
	}
}
