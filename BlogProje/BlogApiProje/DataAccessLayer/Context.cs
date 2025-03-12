using Microsoft.EntityFrameworkCore;

namespace BlogApiProje.DataAccessLayer
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-TVGOALM\\SQLEXPRESS;database=BlogApiDb;TrustServerCertificate=true;Integrated Security=True;");
		}
		public DbSet<Employee> Employees { get; set; }
	}
}
