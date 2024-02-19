using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReportDataBase.DB.Entities;

namespace ReportDataBase.DB.Configurations
{
	public class ReportConfig : IEntityTypeConfiguration<ReportEntity>
	{
		public void Configure(EntityTypeBuilder<ReportEntity> builder)
		{
			builder.HasKey(a => a.RaportId);
			
			builder.ToTable("Report");

		}
	}
}
