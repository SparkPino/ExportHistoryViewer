using Microsoft.EntityFrameworkCore;
using ReportDataBase.DB.Configurations;

namespace ReportDataBase.DB.Entities
{

	[EntityTypeConfiguration(typeof(ReportConfig))]
	public class ReportEntity
	{
		public int RaportId { get; set; }
		public string Title { get; set; }
		public DateTime DateAndTime { get;set; }
		public string UserName { get; set; }
		public string NumberOfTheRoom { get; set; }
	}
}
