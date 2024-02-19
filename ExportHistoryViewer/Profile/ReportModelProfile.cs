using Application.DTO;
using ExportHistoryViewer.Models;

namespace ExportHistoryViewer.Profile
{
    public class ReportModelProfile : AutoMapper.Profile
	{
		public ReportModelProfile()
		{
			CreateMap<ReportDTO,ReportModel >()
				.ReverseMap();
		}
	}
}
