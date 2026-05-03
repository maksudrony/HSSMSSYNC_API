using HSSMSSYNC_API.DTOs;
using HSSMSSYNC_API.Interfaces;

namespace HSSMSSYNC_API.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;

        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardStatsResponse> GetDashboardStatsAsync()
        {
            return await _repository.GetDashboardStatsAsync();
        }
    }
}