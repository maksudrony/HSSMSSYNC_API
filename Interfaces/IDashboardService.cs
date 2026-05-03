using HSSMSSYNC_API.DTOs;

namespace HSSMSSYNC_API.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardStatsResponse> GetDashboardStatsAsync();
    }
}