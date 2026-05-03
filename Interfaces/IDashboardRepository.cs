using HSSMSSYNC_API.DTOs;

namespace HSSMSSYNC_API.Interfaces
{
    public interface IDashboardRepository
    {
        Task<DashboardStatsResponse> GetDashboardStatsAsync();
    }
}