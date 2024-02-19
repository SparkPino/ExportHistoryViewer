using Application.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ReportDataBase.DB;

namespace Service.ServiceReport
{
    public interface IServiceReport
	{
		public Task<List<ReportDTO>> GetAllReportsAsync(DateTime? from, DateTime? to, string? placeNumber, int pageNumber, int pageSize);
        public int GetPageCount();

    }
	public class ServiceReport : IServiceReport
	{
		private readonly ExportHistoryDbContext _dbContext;
		private readonly IMapper _mapper;
        private int pageCount;
		public ServiceReport(ExportHistoryDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
			_mapper = mapper;
        }


		public async Task<List<ReportDTO>> GetAllReportsAsync(DateTime? from, DateTime? to,  string? placeNumber , int pageNumber, int pageSize)   
		{
			var reportQuery = _dbContext.ReportEntities.AsQueryable();
			if (from is not null)
			{
				reportQuery = reportQuery.Where(c => c.DateAndTime.Date >= from.Value);
			}
			if (to is not null) {
				reportQuery = reportQuery.Where(c => c.DateAndTime.Date <= to.Value);
			}

			if (!string.IsNullOrEmpty(placeNumber))
			{
				reportQuery = reportQuery.Where(a => a.NumberOfTheRoom == placeNumber);
			}
            reportQuery = reportQuery.OrderByDescending(c => c.DateAndTime);
            pageCount = reportQuery.Count();
            int skip = (pageNumber - 1) * pageSize;
            
            return await reportQuery.Skip(skip).Take(10).ProjectTo<ReportDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public int GetPageCount()
        {
            if (pageCount > 100)
            {
                pageCount = 100;
            }

            return pageCount;
        }
		 
	}
}
