using AutoMapper;
using Application.DTO;
using ReportDataBase.DB.Entities;

namespace ExportHistoryViewer.AutomaperProfile
{
	public class ReportProfile : Profile
	{
		public ReportProfile()
		{
			CreateMap<ReportEntity, ReportDTO>()
				.ReverseMap();
				

		}
	}
}
