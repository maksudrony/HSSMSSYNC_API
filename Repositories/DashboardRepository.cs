using System.Data;
using Dapper;
using HSSMSSYNC_API.DTOs;
using HSSMSSYNC_API.Interfaces;

namespace HSSMSSYNC_API.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        // Changed to match your RemoteAccUserRepository style exactly
        private readonly IDbConnection _dbConnection;

        public DashboardRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<DashboardStatsResponse> GetDashboardStatsAsync()
        {
            var parameters = new DynamicParameters();

            parameters.Add("P_PROCESS_COUNT", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("P_INVALID_COUNT", dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("P_TOTAL_DB_COUNT", dbType: DbType.Int32, direction: ParameterDirection.Output);

            // Using the standardized _dbConnection name here
            await _dbConnection.ExecuteAsync(
                "AFML_ERP.GET_SUNSHINE_SMS_DASHBOARD_STATS",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return new DashboardStatsResponse
            {
                ProcessedCount = parameters.Get<int>("P_PROCESS_COUNT"),
                InvalidCount = parameters.Get<int>("P_INVALID_COUNT"),
                TotalDbCount = parameters.Get<int>("P_TOTAL_DB_COUNT")
            };
        }
    }
}