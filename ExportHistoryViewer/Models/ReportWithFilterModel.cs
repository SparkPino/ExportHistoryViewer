namespace ExportHistoryViewer.Models
{
    public class ReportWithFilterModel
    {
        public List<ReportModel>? Report { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string? RoomName { get; set; }
       public int PageCount { get; set; }
        
    }
}
