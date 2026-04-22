using HSSMSSYNC_API.DTOs;

namespace HSSMSSYNC_API.Interfaces
{
    public interface IRemoteAccUserService
    {
        Task<LoginResponse> AuthenticateAsync(LoginRequest request);
    }
}