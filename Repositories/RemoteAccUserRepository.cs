using System.Data;
using Dapper;
using HSSMSSYNC_API.Interfaces;
using HSSMSSYNC_API.Models;

namespace HSSMSSYNC_API.Repositories
{
    public class RemoteAccUserRepository : IRemoteAccUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public RemoteAccUserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<RemoteAccUser?> GetUserByEnrollmentIdAsync(long enrollmentId)
        {
            string sql = @"
                SELECT EMP_ENROLL, EMP_NAME, EMP_PWD 
                FROM REMOTE_ACC_USER 
                WHERE EMP_ENROLL = :EnrollmentId";

            // Dapper maps the Oracle data to our C# model
            return await _dbConnection.QueryFirstOrDefaultAsync<RemoteAccUser>(sql, new { EnrollmentId = enrollmentId });
        }
    }
}