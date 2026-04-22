using HSSMSSYNC_API.Models;

namespace HSSMSSYNC_API.Interfaces
{
    public interface IRemoteAccUserRepository
    {
        Task<RemoteAccUser?> GetUserByEnrollmentIdAsync(long enrollmentId);
    }
}
