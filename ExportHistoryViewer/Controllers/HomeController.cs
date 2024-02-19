using Application.DTO;
using AutoMapper;
using ExportHistoryViewer.Models;
using Microsoft.AspNetCore.Mvc;
using Service.ServiceReport;
namespace ExportHistoryViewer.Controllers
{
    public class HomeController : Controller
    {

        private readonly IServiceReport _reportService;
        private readonly IMapper _mapper;
        public HomeController(IServiceReport reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(ReportWithFilterModel reportFilterInfo, int pageNumber = 1, int pageSize = 10)
        {
            var allReports = await _reportService
                .GetAllReportsAsync(reportFilterInfo.From, reportFilterInfo.To, reportFilterInfo.RoomName, pageNumber, pageSize);

            var reports = _mapper.Map<List<ReportDTO>, List<ReportModel>>(allReports);

            var model = new ReportWithFilterModel()
            {
                Report = reports,
                From = reportFilterInfo.From,
                To = reportFilterInfo.To,
                RoomName = reportFilterInfo.RoomName,
                PageCount = _reportService.GetPageCount()
                
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Filter(ReportWithFilterModel reportFilterInfo, int pageNumber = 1, int pageSize = 10)
        {
            var allReports = await _reportService
                .GetAllReportsAsync(reportFilterInfo.From, reportFilterInfo.To, reportFilterInfo.RoomName , pageNumber,  pageSize);
            var reports = _mapper.Map<List<ReportDTO>, List<ReportModel>>(allReports);

            var model = new ReportWithFilterModel()
            {
                Report = reports,
                From = reportFilterInfo.From,
                To = reportFilterInfo.To,
                RoomName = reportFilterInfo.RoomName,

            };

            return RedirectToAction(nameof(Index), model);
        }


    }
}
