using Bogus;
using Microsoft.EntityFrameworkCore;
using ReportDataBase.DB.Entities;

namespace ReportDataBase.DB
{
	public class ExportHistoryDbContext : DbContext
	{
		 
		public DbSet<ReportEntity> ReportEntities { get; set; }

		public ExportHistoryDbContext(DbContextOptions<ExportHistoryDbContext> options ) : base(options)
		{
			 
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var id = 1;
			var faker = new Faker<ReportEntity>()
				.RuleFor(a => a.Title, b => b.Commerce.ProductName())
				.RuleFor(a => a.DateAndTime, b => b.Date.Past())
				.RuleFor(a => a.NumberOfTheRoom, b => $"Room_{b.IndexFaker}")
				.RuleFor(a => a.UserName, b => b.Person.UserName)
				.RuleFor(a => a.RaportId, b => id++);

			var data = faker.Generate(1000);

			modelBuilder.Entity<ReportEntity>().HasData(data);

			base.OnModelCreating(modelBuilder);
		}
	}
}
