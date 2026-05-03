namespace HSSMSSYNC_API.DTOs
{
    public class DashboardStatsResponse
    {
        public int ProcessedCount { get; set; }
        public int InvalidCount { get; set; }
        public int TotalDbCount { get; set; }
    }
}